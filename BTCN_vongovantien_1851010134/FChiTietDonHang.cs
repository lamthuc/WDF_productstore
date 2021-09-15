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
    public partial class FChiTietDonHang : Form
    {
        public int maDH;
        BUS_DonHang busDonHang;
        public FChiTietDonHang()
        {
            InitializeComponent();
            busDonHang = new BUS_DonHang();
        }

        private void LayDSCTDH(int ma)
        {
            gVCTDH.DataSource = null;
            busDonHang.LayDSCTDH(gVCTDH, ma);
            gVCTDH.Columns[0].Width = (int)(gVCTDH.Width * 0.25);
            gVCTDH.Columns[1].Width = (int)(gVCTDH.Width * 0.25);
            gVCTDH.Columns[2].Width = (int)(gVCTDH.Width * 0.25);
            gVCTDH.Columns[3].Width = (int)(gVCTDH.Width * 0.25);
        }
        private void FChiTietDonHang_Load(object sender, EventArgs e)
        {
        
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            FChiTietDonHang f = new FChiTietDonHang();
            f.maDH = this.maDH;
            f.ShowDialog();
        }

        private void FChiTietDonHang_Activated(object sender, EventArgs e)
        {
            LayDSCTDH(maDH);
        }
    }
}
