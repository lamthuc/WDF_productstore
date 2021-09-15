using BTCN_vongovantien_1851010134.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace BTCN_vongovantien_1851010134.BUS
{
    class BUS_DonHang
    {
        DAO_DonHang daoDonHang;
        public BUS_DonHang()
        {
            daoDonHang = new DAO_DonHang();

        }
        public void LayDSDonHang( DataGridView dg)
        {
            dg.DataSource = daoDonHang.LayDSDonHang();
        }
        public void LayDSCTDH(DataGridView dg, int maDH)
        {
            dg.DataSource = daoDonHang.LayDSCTDH(maDH);
        }
        public void LayDSNhanVien(ComboBox cb)
        {
            cb.DataSource = daoDonHang.LayDSNhanVien();
            cb.ValueMember = "EmployeeID";
            cb.DisplayMember = "FirstName";
        }
        public void LayDSKhachHang(ComboBox cb)
        {
            cb.DataSource = daoDonHang.LayDSKhachHang();
            cb.ValueMember = "CustomerID";
            cb.DisplayMember = "CompanyName";
        }
        public bool TaoDonHang(Order d) 
        {
            try
            {
                daoDonHang.ThemDonHang(d);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool SuaDonHang(Order d)
        {
            if (daoDonHang.KiemTraDonHang(d))
            {
                try
                {
                    daoDonHang.SuaDonHang(d);
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool XoaDonHang (Order d)
        {
            if (daoDonHang.KiemTraDonHang(d))
            {
                try
                {
                    daoDonHang.XoaDonHang(d);
                    return true;
                }
                catch (DbUpdateException ex)
                {

                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool ThemCTDH(int maDH, DataTable dtDonHang)
        {
            bool ketQua = false;
            using (var tran = new TransactionScope())
            {
                try
                {
                    foreach (DataRow item in dtDonHang.Rows)
                    {
                        Order_Detail d = new Order_Detail();
                        d.OrderID = maDH;
                        d.ProductID = int.Parse(item[0].ToString());
                        d.UnitPrice = int.Parse(item[1].ToString());
                        d.Quantity = short.Parse(item[2].ToString());
                        d.Discount = float.Parse(item[0].ToString());
                        daoDonHang.ThemCTDH(d);
                    }
                    tran.Complete();
                    ketQua = true;
                }
                catch (Exception ex)
                {
                    ketQua = false;
                    MessageBox.Show(ex.Message);

                } 
            }

            return ketQua;
        }

    }
}
