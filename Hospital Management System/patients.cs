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
    public partial class patients : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\hp\onedrive\documents\visual studio 2012\Projects\Hospital Management System\Hospital Management System\HMSDatabase.mdf;Integrated Security=True");
        public patients()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnReload_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            doctors Obj = new doctors();
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
        void populate()
        {
            Con.Open();
            string query = "select * from PatientsTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVPatient.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            txtPatientId.Text = "";
            txtPatientName.Text = "";
            txtPatientAddress.Text = "";
            txtPatientPhone.Text = "";
            txtPatientAge.Text = "";
            txtMajorDisease.Text = "";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtPatientId.Text == "" || txtPatientName.Text == "" || txtPatientPhone.Text == "" || txtPatientAge.Text == "" || txtMajorDisease.Text == "")
                MessageBox.Show("Missing Information! See Carefully");
            else
            {
                Con.Open();
                string query = "insert into PatientsTbl values(" + txtPatientId.Text + ", '" + txtPatientName.Text + "', '" + txtPatientAddress.Text + "', '" + txtPatientPhone.Text + "', " + txtPatientAge.Text + ", '" + CbGender.SelectedItem.ToString() +  "','" + CbBloodGrp.SelectedItem.ToString() +  "', '" + txtMajorDisease.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient Added Successfully");
                Con.Close();
                populate();
                Reset();

            }
                
        }

        private void DGVPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPatientId.Text = DGVPatient.SelectedRows[0].Cells[0].Value.ToString();
            txtPatientName.Text = DGVPatient.SelectedRows[0].Cells[1].Value.ToString();
            txtPatientAddress.Text = DGVPatient.SelectedRows[0].Cells[2].Value.ToString();
            txtPatientPhone.Text = DGVPatient.SelectedRows[0].Cells[3].Value.ToString();
            txtPatientAge.Text = DGVPatient.SelectedRows[0].Cells[4].Value.ToString();
            txtMajorDisease.Text = DGVPatient.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void patients_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtPatientId.Text == "")
                MessageBox.Show("Enter Patient id");
            else
            {
                Con.Open();
                string query = "delete from PatientsTbl where PatientId= " + txtPatientId.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient Deleted Successfully");
                Con.Close();
                
            }
        }

        private void txtPatientId_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
