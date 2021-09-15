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
    public partial class FCTDatHang : Form
    {
        #region Khai bao bien
        public int maDH;
        private BUS_SanPham busSanPham;
        private BUS_DonHang busDonHang;
        bool flag = false;
        DataTable dtDonHang;
        #endregion
        public FCTDatHang()
        {
            InitializeComponent();
            busSanPham = new BUS_SanPham();
        }

        private void FCTDatHang_Load(object sender, EventArgs e)
        {
            busSanPham.LayDSSanPham(cbSP);
            flag = true;
            txtMaDH.Text = maDH.ToString();

        }

        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product p;
            int maSP;
            maSP = Int32.Parse(cbSP.SelectedValue.ToString());
            p = busSanPham.LayThongTinSanPham(maSP);

            txtLoaiSP.Text = p.Category.CategoryName.ToString();
            txtNhaCC.Text = p.Supplier.CompanyName.ToString();
            txtDonGia.Text = p.UnitPrice.ToString();

            dtDonHang = new DataTable();
            dtDonHang.Columns.Add("ProductID");
            dtDonHang.Columns.Add("UnitPrice");
            dtDonHang.Columns.Add("Quantity");
            dtDonHang.Columns.Add("Discount");
            dGSP.DataSource = dtDonHang;
            
            dGSP.Columns[0].Width = (int)(dGSP.Width * 0.1);
            dGSP.Columns[1].Width = (int)(dGSP.Width * 0.2);
            dGSP.Columns[2].Width = (int)(dGSP.Width * 0.2);
            dGSP.Columns[3].Width = (int)(dGSP.Width * 0.2);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DataRow r;
            bool kiemTraSP = true;
            foreach (DataRow item in dtDonHang.Rows)
            {
                if(cbSP.SelectedValue.ToString() == item[0].ToString()){
                    item[2] = int.Parse(item[2].ToString()) + numSoLuong.Value;
                    kiemTraSP = false;
                    break;
                }
            }
            if (true)
            {
                r = dtDonHang.NewRow();
                r[0] = Int32.Parse(cbSP.SelectedValue.ToString());
                r[1] = Int32.Parse(txtDonGia.Text.Replace(",", ""));
                r[2] = Convert.ToInt32(numSoLuong.Value);
                r[3] = Int32.Parse(txtGiamGia.Text);
                dtDonHang.Rows.Add(r);
            }
        }

        private void btTaoDonHang_Click(object sender, EventArgs e)
        {
            busDonHang = new BUS_DonHang();
            if (busDonHang.ThemCTDH(maDH, dtDonHang))
            {
                MessageBox.Show("Đặt hàng thành công !!!!");
                Close();
            }
            else
            {
                MessageBox.Show("Đặt hàng thất bại !!!!");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
