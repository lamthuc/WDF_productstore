using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCN_vongovantien_1851010134.DAO
{

    class DAO_DonHang
    {
        NorthwindEntities db;
        public DAO_DonHang()
        {
            db = new NorthwindEntities();
        }
        public dynamic LayDSDonHang()
        {
            var ds = db.Orders.Select(s => new {
                s.OrderID,
                s.OrderDate,
                s.Employee.FirstName,
                s.Customer.CompanyName
            }).ToList();
            return ds;
        }

        public dynamic LayDSNhanVien()
        {
            var ds = db.Employees.Select(s => new {
                s.EmployeeID,
                s.FirstName
            }).ToList();
            return ds;
        }
        public dynamic LayDSKhachHang()
        {
            var ds = db.Customers.Select(s => new {
                s.CustomerID,
                s.CompanyName
            }).ToList();
            return ds;
        }
        public void ThemDonHang(Order d) {
            db.Orders.Add(d);
            db.SaveChanges();
        }

        public bool KiemTraDonHang(Order d)
        {
            Order o = db.Orders.Find(d.OrderID);
            if (d != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SuaDonHang(Order d)
        {
            Order o = db.Orders.Find(d.OrderID);
            o.OrderDate = d.OrderDate;
            o.CustomerID = d.CustomerID;
            o.EmployeeID = d.EmployeeID;
            db.SaveChanges();
        }
        public void XoaDonHang(Order d)
        {
            Order o = db.Orders.Find(d.OrderID);
            db.Orders.Remove(o);
            db.SaveChanges();
        }

        public dynamic LayDSCTDH(int maDH)
        {
            var ds = db.Order_Details.Select(s => new {
                s.OrderID,
                s.Product.ProductName,
                s.UnitPrice,
                s.Quantity
            }).ToList();
            return ds;
        }
        public void ThemCTDH (Order_Detail d)
        {
            db.Order_Details.Add(d);
            db.SaveChanges();
        }
    }
}
