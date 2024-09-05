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
    public partial class medicine : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\hp\onedrive\documents\visual studio 2012\Projects\Hospital Management System\Hospital Management System\HMSDatabase.mdf;Integrated Security=True");
        public medicine()
        {
            InitializeComponent();
        }

        private void lblDoctorDetails_Click(object sender, EventArgs e)
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

        private void btnPatient_Click(object sender, EventArgs e)
        {
            patients Obj = new patients();
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
            string query = "select * from MedicineTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVMedicine.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            txtMedicineId.Text = "";
            txtMedicineName.Text = "";
            txtMedicineType.Text = "";
            txtByDoctor.Text = "";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMedicineId.Text == "" || txtMedicineName.Text == "" || txtMedicineType.Text == "" || txtByDoctor.Text == "")
                MessageBox.Show("Missing Information! Fill all The Details");
            else
            {
                Con.Open();
                string query = "insert into MedicineTbl values(" + txtMedicineId.Text + ", '" + txtMedicineName.Text + "', '" + txtMedicineType.Text + "', '" + txtByDoctor.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Medicine Added Successfully");
                Con.Close();
                populate();
                Reset();
            }
        }

        private void medicine_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void DGVMedicine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMedicineId.Text = DGVMedicine.SelectedRows[0].Cells[0].Value.ToString();
            txtMedicineName.Text = DGVMedicine.SelectedRows[0].Cells[1].Value.ToString();
            txtMedicineType.Text = DGVMedicine.SelectedRows[0].Cells[2].Value.ToString();
            txtByDoctor.Text = DGVMedicine.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMedicineId.Text == "")
                MessageBox.Show("Enter Medicine id ");
            else
            {
                Con.Open();
                string query = "Delete from   MedicineTbl where MedicineId=" + txtMedicineId.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Medicine Deleted Successfully");
                Con.Close();
                populate();
                Reset();

            }
        }

        private void btnMedicine_Click(object sender, EventArgs e)
        {

        }
    }
}
