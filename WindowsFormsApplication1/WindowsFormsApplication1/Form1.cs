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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string strConnectionString = "Data Source = DESKTOP-VUH1BB2; Initial Catalog = quanlideancongti; Integrated Security = True";
        SqlConnection conn = null;
        SqlDataAdapter danhanvien = null;
        DataTable dtnhanhvien = null;
        SqlDataAdapter daphongban = null;
        DataTable dtphongban = null;

        private void LoadData()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                daphongban = new SqlDataAdapter("select Phongban.TENPHG from Phongban", conn);
                dtphongban = new DataTable();
                dtphongban.Clear();
                daphongban.Fill(dtphongban);
                (this.dataGridView1.Columns["tenphong"] as DataGridViewComboBoxColumn).DataSource = dtphongban;
                (this.dataGridView1.Columns["tenphong"] as DataGridViewComboBoxColumn).DisplayMember = "TENPHG";
                (this.dataGridView1.Columns["tenphong"] as DataGridViewComboBoxColumn).ValueMember = "TENPHG";
                danhanvien = new SqlDataAdapter("select * from Nhanvien", conn);
                dtnhanhvien = new DataTable();
                dtnhanhvien.Clear();
                danhanvien.Fill(dtnhanhvien);
                this.dataGridView1.DataSource = dtnhanhvien;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không tìm thấy dữ liệu trong bảng. Lỗi rồi!", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult rep;
            rep = MessageBox.Show("Bạn chắc không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rep == DialogResult.Yes)
                Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtnhanhvien.Dispose();
            dtnhanhvien = null;
            conn = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                int r = dtnhanhvien.
            }
            catch(SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
    }
}
