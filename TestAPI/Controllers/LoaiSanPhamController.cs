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
    public class LoaiSanPhamController : ApiController
    {
        TestAPIContext dbContext = new TestAPIContext();
        [HttpGet]
        public List<LoaiSanPham> LayToanBoLoaiSanPham()
        {
            List<LoaiSanPham> dslsp = dbContext.LoaiSanPhams.ToList();
            foreach (LoaiSanPham lsp in dslsp)
            {
                lsp.SanPhams.Clear();
            }
            return dslsp;
        }
        [HttpGet]
        public LoaiSanPham LayChiTietLoaiSanPham(int id)
        {
            LoaiSanPham lsp = dbContext.LoaiSanPhams.FirstOrDefault(x => x.MaLoai == id);
            if (lsp != null)
            {
                lsp.SanPhams.Clear();
            }
            return lsp;
        }
        [HttpPost]
        public bool ThemLoaiSanPham(string tenLoai)
        {
            try
            {
                LoaiSanPham lsp = new LoaiSanPham();
                lsp.TenLoai = tenLoai;
                dbContext.LoaiSanPhams.Add(lsp);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {

            }
            return false;
        }
        [HttpGet]
        public bool SuaLoaiSanPham(int maLoai, string tenLoai)
        {
            try
            {
                LoaiSanPham lsp = dbContext.LoaiSanPhams.FirstOrDefault(x => x.MaLoai == maLoai);
                if (lsp != null)
                {
                    lsp.TenLoai = tenLoai;
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }
        [HttpGet]
        public bool XoaLoaiSanPham(int maLoai)
        {
            try
            {
                LoaiSanPham lsp = dbContext.LoaiSanPhams.FirstOrDefault(x => x.MaLoai == maLoai);
                if (lsp != null)
                {
                    if (lsp.SanPhams.Count > 0)
                    {
                        return false;
                    }
                    dbContext.LoaiSanPhams.Remove(lsp);
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
