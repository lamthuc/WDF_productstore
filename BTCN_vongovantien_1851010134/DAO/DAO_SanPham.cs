using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCN_vongovantien_1851010134.DAO
{
    class DAO_SanPham
    {
        NorthwindEntities db;
        public DAO_SanPham()
        {
            db = new NorthwindEntities();
        }
        public dynamic LayDSSP() {
            var ds = db.Products.Select(s => new {
                s.ProductID,
                s.ProductName,
                s.UnitPrice,
                s.QuantityPerUnit,
                s.Supplier.CompanyName,
                s.Category.CategoryName
            }).ToList();
            return ds;
        }
        public dynamic LayDSLoaiSP()
        {
            var ds = db.Categories.Select(s => new {
                s.CategoryID,
                s.CategoryName,
            }).ToList();
            return ds;
        }
        public dynamic LayDSNhaCungCap()
        {
            var ds = db.Suppliers.Select(s => new {
                s.SupplierID,
                s.CompanyName,
            }).ToList();
            return ds;
        }

        public Product LayThongTinSanPham(int maSP)
        {
            Product p = db.Products.Where(s=> s.ProductID == maSP)
                                    .FirstOrDefault();
            return p;
        }
    }
}
