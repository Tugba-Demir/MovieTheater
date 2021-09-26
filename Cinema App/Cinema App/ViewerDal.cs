using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_App
{
    class ViewerDal
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
        public List<Viewer> GetAll()
        {
            ControlConnection();

            SqlCommand command = new SqlCommand("Select * from Viewers",_connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Viewer> viewers = new List<Viewer>();
            while (reader.Read())
            {
                Viewer viewer = new Viewer
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ViewerName = reader["ViewerName"].ToString(),
                    ViewerSurname = reader["ViewerSurname"].ToString(),
                    SeatNumber = reader["SeatNumber"].ToString(),
                    SelectedMovie = reader["SelectedMovie"].ToString()
                };
                viewers.Add(viewer);
            }

            reader.Close();
            _connection.Close();

            return viewers;
        }
        #endregion
        #region Add
        public void Add(Viewer viewer)
        {
            ControlConnection();

            SqlCommand command = new SqlCommand("Insert into Viewers values(@name, @surname, @seatnumber, @selectedmovie)",_connection);
            command.Parameters.AddWithValue("@name", viewer.ViewerName);
            command.Parameters.AddWithValue("@surname", viewer.ViewerSurname);
            command.Parameters.AddWithValue("@seatnumber", viewer.SeatNumber);
            command.Parameters.AddWithValue("@selectedmovie", viewer.SelectedMovie);
            command.ExecuteNonQuery();

            _connection.Close();
        }
        #endregion
        #region Update
        public void Update(Viewer viewer)
        {
            ControlConnection();

            SqlCommand command = new SqlCommand("Update Viewers set ViewerName=@name, ViewerSurname=@surname, SeatNumber=@seat, SelectedMovie=@movie where Id=@id", _connection);
            command.Parameters.AddWithValue("@name", viewer.ViewerName);
            command.Parameters.AddWithValue("@surname", viewer.ViewerSurname);
            command.Parameters.AddWithValue("@seat", viewer.SeatNumber);
            command.Parameters.AddWithValue("@movie", viewer.SelectedMovie);
            command.Parameters.AddWithValue("@id", viewer.Id);
            command.ExecuteNonQuery();

            _connection.Close();
        }
        #endregion
        #region Remove
        public void Delete(int id)
        {
            ControlConnection();

            SqlCommand command = new SqlCommand("Delete from Viewers where Id=@id",_connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            _connection.Close();
        }
        #endregion






    }
}
