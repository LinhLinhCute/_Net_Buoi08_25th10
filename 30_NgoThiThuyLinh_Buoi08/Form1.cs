using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _30_NgoThiThuyLinh_Buoi08
{
    public partial class Form1 : Form
    {
        ConnectDB cont = new ConnectDB();
        SqlConnection consql;
        public Form1()
        {
            InitializeComponent();
            consql = cont.connect;
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            try
            {
                if (consql.State == ConnectionState.Closed)
                {
                    consql.Open();
                }
                string insert;
                insert = "insert into SinhVien values ('" + txt_Id.Text + "',N'" + txt_Name.Text + "')";
                SqlCommand cmd = new SqlCommand(insert, consql);
                cmd.ExecuteNonQuery();
                if (consql.State == ConnectionState.Open)
                {
                    consql.Close();
                }
                MessageBox.Show("Them Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }
        void Load_Dgv()
        {
            consql.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from SinhVien", consql);
            da.Fill(ds,"SinhVien");
            dataGridView1.DataSource = ds.Tables["SinhVien"];
        }

        private void btn_Read_Click(object sender, EventArgs e)
        {
            try
            {
                if (consql.State == ConnectionState.Closed)
                {
                    consql.Open();
                }
                string read;
                read = "select * from SinhVien";
                SqlCommand cmd = new SqlCommand(read, consql);
                SqlDataReader rdr = cmd.ExecuteReader();
                // hai lenh nay dung de xoa nhung item co san de doc lai cai moi ne
                cbB_Id.Items.Clear();
                cbB_Name.Items.Clear();
                while (rdr.Read())
                {
                  cbB_Id.Items.Add(rdr["Id"].ToString());
                  cbB_Name.Items.Add(rdr["Ten"].ToString());
                }
                consql.Close();
                Load_Dgv();
                if (consql.State == ConnectionState.Open)
                {
                    consql.Close();
                }
                MessageBox.Show("Doc Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool KT(string idtest)
        {
            consql.Open();
            string find = "select * from SinhVien where Id='" + idtest+"'";
            SqlCommand cmd = new SqlCommand(find, consql);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                consql.Close();
                return true;
            }
            return false;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (KT(txt_Id.Text) == true)
                {
                    if (consql.State == ConnectionState.Closed)
                    {
                        consql.Open();
                    }
                    string update;
                    update = "update SinhVien set Ten='" + txt_Name.Text + "' where Id='" + txt_Id.Text + "'";
                    SqlCommand cmd = new SqlCommand(update, consql);
                    cmd.ExecuteNonQuery();
                    if (consql.State == ConnectionState.Open)
                    {
                        consql.Close();
                    }
                    MessageBox.Show("Cap nhat Thanh Cong");
                }
                else
                {
                    consql.Close();
                    MessageBox.Show("Co bang ghi dau con quy");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (consql.State == ConnectionState.Closed)
                {
                    consql.Open();
                }
                string delete = "delete SinhVien where Id='" + txt_Id.Text + "'";
                SqlCommand cmd = new SqlCommand(delete, consql);
                cmd.ExecuteNonQuery();
                if (consql.State == ConnectionState.Open)
                {
                    consql.Close();
                }
                MessageBox.Show("Xoa thanh cong");
            }
            catch
            {
                MessageBox.Show("That Bai");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void txt_Id_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
