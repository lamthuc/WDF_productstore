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
    public partial class FQuanLySanPham : Form
    {
        BUS_SanPham busSanPham;
        public FQuanLySanPham()
        {
            InitializeComponent();
            busSanPham = new BUS_SanPham();
        }
        private void HienThiDSSanPham() {
            gVSanPham.DataSource = null;
            busSanPham.LayDSSanPham(gVSanPham);
            gVSanPham.Columns[0].Width = (int)(gVSanPham.Width * 0.1);
            gVSanPham.Columns[1].Width = (int)(gVSanPham.Width * 0.2);
            gVSanPham.Columns[2].Width = (int)(gVSanPham.Width * 0.2);
            gVSanPham.Columns[3].Width = (int)(gVSanPham.Width * 0.2);
            gVSanPham.Columns[4].Width = (int)(gVSanPham.Width * 0.15);
            gVSanPham.Columns[5].Width = (int)(gVSanPham.Width * 0.15);
        }
        private void FQuanLySanPham_Load(object sender, EventArgs e)
        {
            HienThiDSSanPham();
            busSanPham.LayDSLoaiSanPham(cbLoaiSP);
            busSanPham.LayDSNhaCungCap(cbNCC);
        }

        private void gVSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVSanPham.Rows.Count)
            {
                txtTenSP.Text = gVSanPham.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();
                txtSoLuong.Text = gVSanPham.Rows[e.RowIndex].Cells["1"].Value.ToString();
                txtDonGia.Text = gVSanPham.Rows[e.RowIndex].Cells["2"].Value.ToString();
                cbLoaiSP.Text = gVSanPham.Rows[e.RowIndex].Cells["3"].Value.ToString();
                cbNCC.Text = gVSanPham.Rows[e.RowIndex].Cells["4"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Vùng chọn không hợp lệ");
            }  
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            Order donHang = new Order();
        }
    }
}
