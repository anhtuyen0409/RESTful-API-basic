using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestAPI.Models;
using System.Data.Entity;

namespace TestAPI.Controllers
{
    public class SanPhamController : ApiController
    {
        TestAPIContext dbContext = new TestAPIContext();
        //lấy sản phẩm => get
        [HttpGet]
        public List<SanPham> LayToanBoSanPham()
        {
            List<SanPham> dssp = dbContext.SanPhams.ToList();
            /*foreach (SanPham sp in dssp)
            {
                sp.LoaiSanPham = null;
                
            }*/
            return dssp;
        }
        [HttpGet]
        public SanPham ChiTietSanPham(int id)
        {
            SanPham sp = dbContext.SanPhams.FirstOrDefault(x => x.MaSP == id);
            if (sp != null)
            {
                sp.LoaiSanPham = null;
            }
            return sp;
        }
        [HttpGet]
        public List<SanPham> DanhSachSanPhamTheoLoai(int maloai)
        {
            List<SanPham> dssp = dbContext.SanPhams.Where(p => p.MaLoai == maloai).ToList();
            foreach (SanPham sp in dssp)
            {
                sp.LoaiSanPham = null;
                
            }
            return dssp;
        }
        [HttpGet]
        public List<SanPham> LayDanhSachSanPhamCoGiaTriTuADenB(int a, int b)
        {
            List<SanPham> dssp = dbContext.SanPhams.Where(x => x.DonGia >= a && x.DonGia <= b).ToList();
            foreach (SanPham sp in dssp)
            {
                sp.LoaiSanPham = null;
               
            }
            return dssp;
        }
        //lưu sản phẩm => post
        [HttpPost]
        public bool LuuSanPham(string tenSP, int gia, int maLoai)
        {
            try
            {
                SanPham sp = new SanPham();
                sp.TenSP = tenSP;
                sp.DonGia = gia;
                sp.MaLoai = maLoai;
                dbContext.SanPhams.Add(sp);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {

            }
            return false;
        }
        //sửa sản phẩm => put
        [HttpGet]
        public bool SuaSanPham(int maSP, string tenSP, int gia, int maLoai)
        {
            try
            {
                SanPham sp = dbContext.SanPhams.FirstOrDefault(x => x.MaSP == maSP);
                if (sp != null)
                {
                    sp.TenSP = tenSP;
                    sp.DonGia = gia;
                    sp.MaLoai = maLoai;
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch
            {

            }
            return false;

        }
        //xoá sản phẩm => delete
        [HttpGet]
        public bool XoaSanPham(int maSP)
        {
            try
            {
                SanPham sp = dbContext.SanPhams.FirstOrDefault(x => x.MaSP == maSP);
                if (sp != null)
                {
                    dbContext.SanPhams.Remove(sp);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch
            {

            }
            return false;

        }
    }
}
