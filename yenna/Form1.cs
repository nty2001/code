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

namespace yenna
{
    public partial class Form1 : Form
    {

        //tạo biến lưu chuỗi kết nối
        private string conStr = @"Data Source=NTTRANG2\MSSQLSERVERYEN;Initial Catalog=yensql;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter MyAdapter;
        private SqlCommand comm;
        private DataSet ds;
        private DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            // tạo phương thức lấy dữ liệu 
            conn = new SqlConnection(conStr);
            conn.Open();

            string sqlStr = "SELECT * From sanpham";
            MyAdapter = new SqlDataAdapter(sqlStr, conn);

            ds = new DataSet();
            MyAdapter.Fill(ds, "sanpham");
            dt = ds.Tables["sanpham"];
            // Tắt tự động thêm thuộc tính , trường thuộc tính vào cột 
            //dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;

            conn.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            textBox1.Text = dt.Rows[row]["MaSP"].ToString();
            textBox2.Text = dt.Rows[row]["tenSp"].ToString();
            textBox3.Text = dt.Rows[row]["gia"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            conn.Open();

            string sqlStr = "UPDATE  sanpham SET tenSp= N'" + textBox2.Text + "' Where MaSP='" + textBox1.Text + "' ";
            //thực hiện câu lệnh
            comm = new SqlCommand(sqlStr, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            LoadData();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Ban muon xoa", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                conn = new SqlConnection(conStr);
                conn.Open();

                // khai báo câu lệnh SQl để thêm 
                string sqlStr = "Delete From  sanpham  Where MaSP='" + textBox1.Text + "' ";
                //thực hiện câu lệnh
                comm = new SqlCommand(sqlStr, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                LoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            conn.Open();

            // khai báo câu lệnh SQl để thêm 
            string sqlStr = "INSERT INTO sanpham(MaSP,tenSp,gia) VALUES ('" + textBox1.Text + "',N'" + textBox2.Text + "','" + textBox3.Text + "')";
            //thực hiện câu lệnh
            comm = new SqlCommand(sqlStr, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            LoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
