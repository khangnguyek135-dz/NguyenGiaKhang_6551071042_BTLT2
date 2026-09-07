using System;
using System.Text;

namespace QuanLySanPhamCuaHang
{
    public class SanPhamDienTu : SanPham
    {
        // ===== Field private thêm =====
        private int _baoHanhThang;
        private string _hangSanXuat;

        // ===== Constructor: gọi base() để khởi tạo các field chung =====
        public SanPhamDienTu(string maSP, string tenSP, decimal gia, int soLuongTon)
            : base(maSP, tenSP, gia, soLuongTon)
        {
            _baoHanhThang = 12;
            _hangSanXuat = "Chua ro";
        }

        // ===== Property thêm =====
        public int BaoHanhThang
        {
            get { return _baoHanhThang; }
            set { _baoHanhThang = value; }
        }

        public string HangSanXuat
        {
            get { return _hangSanXuat; }
            set { _hangSanXuat = value; }
        }

        // ===== Override TinhGiaBan(): cộng thêm 10% phí bảo hành nếu bảo hành > 12 tháng =====
        public override decimal TinhGiaBan()
        {
            decimal giaGoc = base.TinhGiaBan(); // lấy _gia từ lớp cha

            if (_baoHanhThang > 12)
                return giaGoc * 1.1m;

            return giaGoc;
        }

        // ===== Override MoTa() =====
        public override string MoTa()
        {
            string moTaGoc = base.MoTa();
            return $"{moTaGoc} | Loai: Đien tu | Hang: {_hangSanXuat} | Bao hanh: {_baoHanhThang} thang";
        }
    }
}