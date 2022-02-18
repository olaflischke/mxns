using System;
using System.Data.SqlClient;

namespace HistoricalTradingDaysDal
{
    public class ExchangeRate
    {
        public double EuroRate { get; set; }
        public string Symbol { get; set; }

        #region POCO-Implementierung
        public ExchangeRate()
        {

        }

        public ExchangeRate(int id)
        {
            this.Id = id;

            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = "ConnectionString";
                    connection.Open();

                    SqlCommand command = new SqlCommand()
                    {
                        Connection = connection,
                        CommandText = $"SELECT * FROM ExchangeRates WHERE ID = @Id"
                    };

                    SqlParameter parId = new SqlParameter("@Id", id);
                    command.Parameters.Add(parId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        this.EuroRate = Convert.ToDouble(reader["Rate"]);
                        this.Symbol = reader["ISO"].ToString();
                    }
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public int Id { get; set; }

        public void Save()
        {
            if (this.Id > 0)
            {
                // UPDATE
                using (SqlConnection connection = new SqlConnection("ConnectionString"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand()
                    {
                        Connection = connection,
                        CommandText = "UPDATE ExchangeRates SET Rate=@rate, ISO=@symbol WHERE ID = @Id"
                    };

                    command.Parameters.Add(new SqlParameter("@Id", this.Id));
                    command.Parameters.Add(new SqlParameter("@rate", this.EuroRate));
                    command.Parameters.Add(new SqlParameter("@symbol", this.Symbol));

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected != 1)
                    {
                        // ALARM
                    }
                }
            }
            else
            {
                // INSERT
                SqlTransaction transaction = null;

                try
                {
                    using (SqlConnection connection = new SqlConnection("ConnectionString"))
                    {
                        connection.Open();

                        transaction = connection.BeginTransaction();

                        SqlCommand command = new SqlCommand()
                        {
                            Connection = connection,
                            CommandText = "INSERT INTO ExchangeRates VALUES (@rate, @symbol)",
                            Transaction = transaction
                        };

                        command.Parameters.Add(new SqlParameter("@rate", this.EuroRate));
                        command.Parameters.Add(new SqlParameter("@symbol", this.Symbol));

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 1)
                        {
                            SqlCommand cmdId = new SqlCommand()
                            {
                                Connection = connection,
                                CommandText = "SELECT ident_current('ExchangeRates')",
                                Transaction = transaction
                            };

                            this.Id = Convert.ToInt32(cmdId.ExecuteScalar());
                        }

                        transaction.Commit();
                    }

                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    throw;
                }
            }
        }
        public void Delete()
        {

        }
        #endregion
    }
}