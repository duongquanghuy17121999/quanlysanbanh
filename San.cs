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
namespace week8
{
    public partial class San : Form
    {

        SqlConnection con;
        public San()
        {
            InitializeComponent();
        }

        private void San_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=ANDONGNHI\SQLEXPRESS;Initial Catalog=week8;Integrated Security=True");
            con.Open();
            HienThi();
            Load_Phong();
        }

        public void HienThi()
        {
            string sqlSelect = "SELECT * FROM San";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            dataGridView1.DataSource = dt;
            Program.sql = sqlSelect;

        }

        private void Load_Phong()
        {
            String connectionStr = @"Data Source=ANDONGNHI\SQLEXPRESS;Initial Catalog=week8;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();

            String query = "Select id from LoaiSan2";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            comboBox1.DisplayMember = "id";
            comboBox1.DataSource = data;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlInsert = "INSERT INTO San VALUES (@id,@name,@status,@idLoaiSan)";
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("id", textBox1.Text);
            cmd.Parameters.AddWithValue("name", textBox2.Text);
            //cmd.Parameters.AddWithValue("ngaysinh", dateTimePicker1.Value);
            // cmd.Parameters.AddWithValue("gioitinh", radioButton1.Checked ? true : false);
            //cmd.Parameters.AddWithValue("maNhanVien", textBox2.Text);
             cmd.Parameters.AddWithValue("status", textBox3.Text);
            cmd.Parameters.AddWithValue("idLoaiSan", comboBox1.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baoCaoSan f = new baoCaoSan();
            f.Show();
        }
    }
}
