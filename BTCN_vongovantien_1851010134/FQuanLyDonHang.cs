using BTCN_vongovantien_1851010134.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTCN_vongovantien_1851010134
{
    public partial class FQuanLyDonHang : Form
    {
        BUS_DonHang busDonHang;
        public FQuanLyDonHang()
        {
            InitializeComponent();
            busDonHang = new BUS_DonHang();
        }

        
        private void FQuanLyDonHang_Load(object sender, EventArgs e)
        {
            HienThiDSDonHang();
            busDonHang.LayDSNhanVien(cbNhanVien);
            busDonHang.LayDSKhachHang(cbKhachHang);
        }

        private void HienThiDSDonHang()
        {
            gVDH.DataSource = null;
            busDonHang.LayDSDonHang(gVDH);
            gVDH.Columns[0].Width = (int)(gVDH.Width * 0.1);
            gVDH.Columns[1].Width = (int)(gVDH.Width * 0.3);
            gVDH.Columns[2].Width = (int)(gVDH.Width * 0.3);
            gVDH.Columns[3].Width = (int)(gVDH.Width * 0.3);
        }

        

        private void gVDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVDH.Rows.Count)
            {
                txtMaDH.Enabled = false;
                txtMaDH.Text = gVDH.Rows[e.RowIndex].Cells["0"].Value.ToString();
                dtpNgayDatHang.Text = gVDH.Rows[e.RowIndex].Cells["1"].Value.ToString();
                cbNhanVien.Text = gVDH.Rows[e.RowIndex].Cells["2"].Value.ToString();
                cbKhachHang.Text = gVDH.Rows[e.RowIndex].Cells["4"].Value.ToString();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Order donHang = new Order();

            donHang.OrderDate = dtpNgayDatHang.Value;
            donHang.EmployeeID = Int32.Parse(cbNhanVien.SelectedValue.ToString());
            donHang.CustomerID = cbKhachHang.SelectedValue.ToString();

            if (busDonHang.TaoDonHang(donHang))
            {
                MessageBox.Show("Tạo đơn hàng thành công !!!!!");
                busDonHang.LayDSDonHang(gVDH);
            }
            else { MessageBox.Show("Tạo đơn hàng thất bại"); }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Order donHang = new Order();

            donHang.OrderID = int.Parse(txtMaDH.Text);
            donHang.OrderDate = dtpNgayDatHang.Value;
            donHang.EmployeeID = Int32.Parse(cbNhanVien.SelectedValue.ToString());
            donHang.CustomerID = cbKhachHang.SelectedValue.ToString();

            if (busDonHang.SuaDonHang(donHang))
            {
                MessageBox.Show("Sửa đơn hàng thành công !!!!!");
                busDonHang.LayDSDonHang(gVDH);
            }
            else { MessageBox.Show("Sửa đơn hàng thất bại"); }

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            Order donHang = new Order();
            int maDH = int.Parse(txtMaDH.Text);

            if (busDonHang.XoaDonHang(donHang))
            {
                MessageBox.Show("Xóa đơn hàng thành công !!!!!");
                busDonHang.LayDSDonHang(gVDH);
            }
            else { MessageBox.Show("Xóa đơn hàng thất bại"); }

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gVDH_DoubleClick(object sender, EventArgs e)
        {
            int ma;
            
            ma = int.Parse(gVDH.CurrentRow.Cells[0].Value.ToString());
            FChiTietDonHang f = new FChiTietDonHang();
            f.maDH = ma;
            f.ShowDialog();
        }
    }
}
