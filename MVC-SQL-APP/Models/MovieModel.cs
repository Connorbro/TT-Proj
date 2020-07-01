using System;
using System.Data.SqlClient;


namespace MVC_SQL_APP.Models
{
    class Sqlcon
    {


        public void Main(string[] args)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost, 1433";
                builder.UserID = "sa";
                builder.Password = "Mypasswordisgreat";
                builder.InitialCatalog = "Movies"; //DB name

                // What to send to sql?

                string SELECT = "SELECT * FROM MovieModel";
                string INSERT = "INSERT INTO MovieModel(MovieID, Title, Genre, Rating, ReleaseDate, IMDbscore) VALUES(8, 'Starwars', 'Scifi', '12', '1973-01-01', 6)";
                string UPDATE;
                string DELETE;

                Console.WriteLine("Connecting to SQL server");
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                using (connection)
                {

                    SqlCommand cmd = new SqlCommand(INSERT, connection);
                    connection.Open();
                    //SqlCommand cmd = new SqlCommand(INSERT, connection);
                    //connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.WriteLine(reader.GetValue(i));
                            }
                        }
                    }
                    Console.WriteLine("Done");
                }
            }
            catch (SqlException error)
            {
                Console.WriteLine(error.ToString());
            }
            Console.WriteLine("All done. All sorted.");
            Console.Read();

        }
    }
}







//public class MovieModel
//    {
//        public int MovieID { get; set; }
//        public string Title { get; set; }
//        public string Genre { get; set; }
//        public string Rating { get; set; }
//        public string ReleaseDate { get; set; }
//        public int IMDbscore { get; set; }

//    }