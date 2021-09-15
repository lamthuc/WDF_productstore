using BTCN_vongovantien_1851010134.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTCN_vongovantien_1851010134.BUS
{
    class BUS_SanPham
    {
        DAO_SanPham daoSanPham;
        public BUS_SanPham() {
            daoSanPham = new DAO_SanPham();
        }
        public void LayDSSanPham(DataGridView dg)
        {
            dg.DataSource = daoSanPham.LayDSSP();
        }
        public void LayDSSanPham(ComboBox cb)
        {
            cb.DataSource = daoSanPham.LayDSSP();
            cb.ValueMember = "ProductID";
            cb.DisplayMember = "ProductName";
        }

        public void LayDSLoaiSanPham(ComboBox cb)
        {
            cb.DataSource = daoSanPham.LayDSLoaiSP();
            cb.ValueMember = "CategoryID";
            cb.DisplayMember = "CategoryName";
        }
        public void LayDSNhaCungCap(ComboBox cb)
        {
            cb.DataSource = daoSanPham.LayDSNhaCungCap();
            cb.ValueMember = "SupplierID";
            cb.DisplayMember = "CompanyName";
        }
        public Product LayThongTinSanPham(int maSP){
            return daoSanPham.LayThongTinSanPham(maSP);
        }
    }
}
