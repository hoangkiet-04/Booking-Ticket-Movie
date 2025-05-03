using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MovieTicketManagementSystem.BusinessLayer;

namespace MovieTicketManagementSystem.PresentationLayer
{
    public partial class dashboardForm : UserControl
    {
        private DashboardBL dashboardBL = new DashboardBL();
        private movieData movieData = new movieData();

        public dashboardForm()
        {
            InitializeComponent();
            displayAvailableMovies();
            displayTotalStaffs();
            displayTotalBuys();
            displayTotalIncome();
            displayAMTable();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayAvailableMovies();
            displayTotalStaffs();
            displayTotalBuys();
            displayTotalIncome();
            displayAMTable();
        }

        public void displayAMTable()
        {
            dataGridView1.DataSource = movieData.movieAvailableListData();
        }

        public void displayAvailableMovies()
        {
            dashboard_AM.Text = dashboardBL.GetAvailableMoviesCount().ToString();
        }

        public void displayTotalStaffs()
        {
            dashboard_TS.Text = dashboardBL.GetTotalStaffsCount().ToString();
        }

        public void displayTotalBuys()
        {
            dashboard_TB.Text = dashboardBL.GetTotalBuysCount().ToString();
        }

        public void displayTotalIncome()
        {
            dashboard_TI.Text = "VND" + dashboardBL.GetTotalIncome().ToString("0.000");
        }

        private void dashboardForm_Load(object sender, EventArgs e)
        {
        }
    }
}