using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region LoadMoviesMethod  
        private void LoadMovies()
        {
            dgvMovie.DataSource = _movieDal.GetAll();
        }
        #endregion
        #region LoadViewerMethod
        private void LoadViewer()
        {
            dgvViewer.DataSource = _viewerDal.GetAll();
        }
        #endregion


        MovieDal _movieDal = new MovieDal();
        ViewerDal _viewerDal = new ViewerDal();

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadMovies();
            LoadViewer();
            SeatNumbers();

        }

        #region SeatNumbers
        private void SeatNumbers()
        {
            Button[,] buttons = new Button[5, 5];

            int left = 1081;
            int top = 500;
            int seatNumber = 1;

            for (int i = 0; i <= buttons.GetUpperBound(0); i++)
            {
                for (int j = 0; j < buttons.GetUpperBound(1); j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Width = 70;
                    buttons[i, j].Height = 70;
                    buttons[i, j].Left = left;
                    buttons[i, j].Top = top;
                    left += 70;
                    buttons[i, j].Text = seatNumber.ToString();
                    seatNumber++;
                    buttons[i, j].BackColor = Color.Teal;

                    this.Controls.Add(buttons[i, j]);

                }
                left = 1081;
                top += 70;
            }
        }
        #endregion
        #region btnMovieAdd
        private void btnMovieAdd_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie
            {
                MovieName = txtMovieNameAdd.Text.ToString(),
                TicketPrice = txtTicketPriceAdd.Text.ToString(),
                StartTime = txtStartTimeAdd.Text.ToString(),
                MovieDuration = txtMovieDurationAdd.Text.ToString()
            };

            _movieDal.Add(movie);
            MessageBox.Show("Movie info was added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtMovieNameAdd.Clear();
            txtTicketPriceAdd.Clear();
            txtStartTimeAdd.Clear();
            txtMovieDurationAdd.Clear();

            LoadMovies();

        }
        #endregion
        #region dgvMovie

        private void dgvMovie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMovieNameUpdate.Text = dgvMovie.CurrentRow.Cells[1].Value.ToString();
            txtTicketPriceUpdate.Text = dgvMovie.CurrentRow.Cells[2].Value.ToString();
            txtStartTimeUpdate.Text = dgvMovie.CurrentRow.Cells[3].Value.ToString();
            txtMovieDurationUpdate.Text = dgvMovie.CurrentRow.Cells[4].Value.ToString();
        }
        #endregion
        #region btnMovieUpdate
        private void btnMovieUpdate_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie
            {
                Id = Convert.ToInt32(dgvMovie.CurrentRow.Cells[0].Value),
                MovieName = txtMovieNameUpdate.Text,
                TicketPrice = txtTicketPriceUpdate.Text,
                StartTime = txtStartTimeUpdate.Text,
                MovieDuration = txtMovieDurationUpdate.Text
            };

            _movieDal.Update(movie);
            MessageBox.Show("Movie info was updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtMovieNameUpdate.Clear();
            txtTicketPriceUpdate.Clear();
            txtStartTimeUpdate.Clear();
            txtMovieDurationUpdate.Clear();

            LoadMovies();
        }
        #endregion
        #region btnMovieRemove
        private void btnMovieRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvMovie.CurrentRow.Cells[0].Value);
            _movieDal.Delete(id);
            MessageBox.Show("Movie info was removed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtMovieNameUpdate.Clear();
            txtTicketPriceUpdate.Clear();
            txtStartTimeUpdate.Clear();
            txtMovieDurationUpdate.Clear();

            LoadMovies();
        }
        #endregion


        #region btnViewerAdd
        private void btnViewerAdd_Click(object sender, EventArgs e)
        {
            Viewer viewer = new Viewer
            {
                ViewerName = txtViewerNameAdd.Text.ToString(),
                ViewerSurname = txtViewerSurnameAdd.Text.ToString(),
                SeatNumber = txtSeatNumberAdd.Text.ToString(),
                SelectedMovie = txtSelectedMovieAdd.Text.ToString()
            };

            _viewerDal.Add(viewer);
            MessageBox.Show("Viewer info was added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtViewerNameAdd.Clear();
            txtViewerSurnameAdd.Clear();
            txtSeatNumberAdd.Clear();
            txtSelectedMovieAdd.Clear();

            LoadViewer();
        }
        #endregion
        #region dgvViewer
        private void dgvViewer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtViewerNameUpdate.Text = dgvViewer.CurrentRow.Cells[1].Value.ToString();
            txtViewerSurnameUpdate.Text = dgvViewer.CurrentRow.Cells[2].Value.ToString();
            txtSeatNumberUpdate.Text = dgvViewer.CurrentRow.Cells[3].Value.ToString();
            txtSelectedMovieUpdate.Text = dgvViewer.CurrentRow.Cells[4].Value.ToString();
        }
        #endregion
        #region btnViewerUpdate
        private void btnViewerUpdate_Click(object sender, EventArgs e)
        {
            Viewer viewer = new Viewer
            {
                Id = Convert.ToInt32(dgvViewer.CurrentRow.Cells[0].Value),
                ViewerName = txtViewerNameUpdate.Text,
                ViewerSurname = txtViewerSurnameUpdate.Text,
                SeatNumber = txtSeatNumberUpdate.Text,
                SelectedMovie = txtSelectedMovieUpdate.Text
            };

            _viewerDal.Update(viewer);
            MessageBox.Show("Viewer info was updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtViewerNameUpdate.Clear();
            txtViewerSurnameUpdate.Clear();
            txtSeatNumberUpdate.Clear();
            txtSelectedMovieUpdate.Clear();

            LoadViewer();
        }
        #endregion
        #region Remove
        private void btnViewerRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvViewer.CurrentRow.Cells[0].Value);
            _viewerDal.Delete(id);
            MessageBox.Show("Viewer info was removed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtViewerNameUpdate.Clear();
            txtViewerSurnameUpdate.Clear();
            txtSeatNumberUpdate.Clear();
            txtSelectedMovieUpdate.Clear();

            LoadViewer();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
