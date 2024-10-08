using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormThongTin
{
    public partial class Form1 : Form
    {
        List<string> listGioiTinh = new List<string>() { "Nam" , "Nữ" , "Không xác định"};
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbbGioiTinh.DataSource = listGioiTinh;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Thoát chương trình !", "Cảnh báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
            e.Cancel = true;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            string hoten = txbHoten.Text;
            string quequan = txbQuequan.Text;


            if (kiemTraNhap())
            {

                XuLyDuLieu.suaChuoi(ref hoten);
                XuLyDuLieu.suaChuoi(ref quequan);

                txbThongTin.Text = "Họ Tên: " + hoten + Environment.NewLine
                                    + "Mã Sinh Viên: " + txbMasv.Text + Environment.NewLine
                                    + "Ngày sinh: " + dtpNgSinh.Value.ToShortDateString() + Environment.NewLine
                                    + "Giới tính: " + cbbGioiTinh.SelectedItem + Environment.NewLine
                                    + "Quê quán: " + quequan;
            }
            //Sau khi nhap xong xoa cac thong tin tren form
            foreach(var item in groupBox1.Controls)
            {
                TextBox item1 = item as TextBox;

                if (item1 != null)
                {
                    item1.Clear();
                }
            }
            dtpNgSinh.Value =DateTime.Now;
        }
        bool kiemTraNhap()
        {
            long ketqua;
            string mssv = txbMasv.Text;
            char[] mangmssv = mssv.ToCharArray();

            if (txbHoten.Text == "")
            {
                MessageBox.Show("Hãy nhập họ tên !!!", "Thông báo");
                txbHoten.Focus();
                return false;
            }

            if (txbMasv.Text == "")
            {
                MessageBox.Show("Hãy nhập Mã số sinh viên !!!", "Thông báo");
                txbMasv.Focus();
                return false;
            }

            if (txbQuequan.Text == "")
            {
                MessageBox.Show("Hãy nhập quê quán !!!", "Thông báo");
                txbQuequan.Focus();
                return false;
            }
            if (!(long.TryParse(mssv, out ketqua)))
            {
                MessageBox.Show("Sai định dạng Mã sinh viên !!!", "Thông báo");
                txbMasv.Focus();
                return false;
            }

            if (ketqua < 0)
            {
                MessageBox.Show("Mã sinh viên không được âm !!!", "Thông báo");
                txbMasv.Focus();
                return false;
            }

            if (mangmssv.Length != 9 )
            {
                MessageBox.Show("Mã sinh viên đúng có 9 số !!!", "Thông báo");
                txbMasv.Focus();
                return false;
            }

            return true;
        }
    }
}
