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

namespace Hospital_Management_System
{
    public partial class doctors : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\hp\onedrive\documents\visual studio 2012\Projects\Hospital Management System\Hospital Management System\HMSDatabase.mdf;Integrated Security=True");
        public doctors()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            patients Obj = new patients();
            Obj.Show();
            this.Hide();
        }

        private void btnMedicine_Click(object sender, EventArgs e)
        {
            medicine Obj = new medicine();
            Obj.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            admin_login Obj = new admin_login();
            Obj.Show();
            this.Hide();
        }

        private void btnPatient_Click_1(object sender, EventArgs e)
        {
            patients Obj = new patients();
            Obj.Show();
            this.Hide();
        }

        private void btnMedicine_Click_1(object sender, EventArgs e)
        {
            medicine Obj = new medicine();
            Obj.Show();
            this.Hide();
        }
        void populate()
        {
            Con.Open();
            string query = "select * from DoctorsTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVDoctors.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            txtDoctorId.Text = "";
            txtDoctorName.Text = "";
            txtYearsofExperience.Text = "";
            txtPassword.Text = "";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDoctorId.Text == "" || txtDoctorName.Text == "" || txtYearsofExperience.Text == "" || txtPassword.Text == "")
                MessageBox.Show("Missing Information! Fill all The Details");
            else
            {
                Con.Open();
                string query = "insert into DoctorsTbl values(" + txtDoctorId.Text + ", '" + txtDoctorName.Text + "', '" + txtYearsofExperience.Text + "', '" + txtPassword.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Added Successfully");
                Con.Close();
                populate();
                Reset();
            }
        }

        private void DCVDoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDoctorId.Text = DGVDoctors.SelectedRows[0].Cells[0].Value.ToString();
            txtDoctorName.Text = DGVDoctors.SelectedRows[0].Cells[1].Value.ToString();
            txtYearsofExperience.Text = DGVDoctors.SelectedRows[0].Cells[2].Value.ToString();
            txtPassword.Text = DGVDoctors.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void doctors_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDoctorId.Text == "")
                MessageBox.Show("Enter Doctor id ");
            else
            {
                Con.Open();
                string query = "Delete from   DoctorsTbl where DoctorId=" + txtDoctorId.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Deleted Successfully");
                Con.Close();
                populate();
                Reset();
                
            }
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            admin_login Obj = new admin_login();
            Obj.Show();
            this.Hide();
        }

    }
}
