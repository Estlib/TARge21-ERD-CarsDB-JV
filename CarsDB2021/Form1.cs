using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarsDB2021
{
    public partial class Form1 : Form
    {
        string connectionString;
        SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["CarsDB2021.Properties.Settings.CarsDBConnectionString"].ConnectionString;
        }
        private void PopulateCarMakerTable()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM CarMark", connection))
            {
                DataTable carTable = new DataTable();
                adapter.Fill(carTable);

                listCarMaker.DisplayMember = "CarMarkName";
                listCarMaker.ValueMember = "Id";
                listCarMaker.DataSource = carTable;
            }
        }
        private void PopulateCarModelTable()
        {
            string query = "SELECT CarInGarage.CarModelName FROM CarMark INNER JOIN CarInGarage ON CarInGarage.CarMarkId = CarMark.Id WHERE CarMark.Id = @CarMarkId";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@CarMarkId", listCarMaker.SelectedValue);
                DataTable carModelTable = new DataTable();
                adapter.Fill(carModelTable);

                listCarModel.DisplayMember = "CarModelName";
                listCarModel.ValueMember = "CarMarkId";
                listCarModel.DataSource = carModelTable;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateCarMakerTable();
        }

        private void listCarMaker_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCarModelTable();
        }
    }
}
