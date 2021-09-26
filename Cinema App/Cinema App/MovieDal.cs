using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_App
{
    class MovieDal
    {
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\mssqllocaldb; initial catalog=MovieTheater; integrated security=true");

        #region ControlConnection
        private void ControlConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        #endregion
        #region GetAll
        public List<Movie> GetAll()
        {
            ControlConnection();

            SqlCommand command = new SqlCommand("Select * from Movies", _connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Movie> movies = new List<Movie>();

            while (reader.Read())
            {
                Movie movie = new Movie
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    MovieName = reader["MovieName"].ToString(),
                    TicketPrice = reader["TicketPrice"].ToString(),
                    StartTime = reader["StartTime"].ToString(),
                    MovieDuration = reader["MovieDuration"].ToString()
                };
                movies.Add(movie);
            }

            reader.Close();
            _connection.Close();

            return movies;
        }
        #endregion
        #region Add 
        public void Add(Movie movie)
        {
            ControlConnection();

            SqlCommand command = new SqlCommand("Insert into Movies values(@movieName,@ticketPrice,@startTime,@movieDuration)", _connection);
            command.Parameters.AddWithValue("@movieName", movie.MovieName);
            command.Parameters.AddWithValue("@ticketPrice", movie.TicketPrice);
            command.Parameters.AddWithValue("@startTime", movie.StartTime);
            command.Parameters.AddWithValue("@movieDuration", movie.MovieDuration);
            command.ExecuteNonQuery();

            _connection.Close();
        }
        #endregion
        #region Update
        public void Update(Movie movie)
        {
            ControlConnection();

            SqlCommand command = new SqlCommand("Update Movies set MovieName=@moviename, TicketPrice=@ticketprice, StartTime=@starttime, MovieDuration=@movieduration where Id=@id", _connection);
            command.Parameters.AddWithValue("@moviename", movie.MovieName);
            command.Parameters.AddWithValue("@ticketprice", movie.TicketPrice);
            command.Parameters.AddWithValue("@starttime", movie.StartTime);
            command.Parameters.AddWithValue("@movieduration", movie.MovieDuration);
            command.Parameters.AddWithValue("@id", movie.Id);
            command.ExecuteNonQuery();

            _connection.Close();

        }

        #endregion
        #region Delete
        public void Delete(int id)
        {
            ControlConnection();

            SqlCommand command = new SqlCommand("Delete from Movies where Id=@id",_connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            _connection.Close();
        }
        #endregion
    }
}
