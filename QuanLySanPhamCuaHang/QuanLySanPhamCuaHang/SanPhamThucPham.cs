using System;
using System.Text;

namespace QuanLySanPhamCuaHang
{
    public class SanPhamThucPham : SanPham
    {
        // ===== Field private thêm =====
        private DateTime _ngayHetHan;
        private int _nhietDoBaoQuan;

        // ===== Constructor: gọi base() để khởi tạo các field chung =====
        public SanPhamThucPham(string maSP, string tenSP, decimal gia, int soLuongTon)
            : base(maSP, tenSP, gia, soLuongTon)
        {
            // NgayHetHan, NhietDoBaoQuan sẽ được gán sau qua Object Initializer ở Main
            _ngayHetHan = DateTime.Now.AddMonths(1); // giá trị mặc định tạm thời
            _nhietDoBaoQuan = 25;
        }

        // ===== Property thêm =====
        public DateTime NgayHetHan
        {
            get { return _ngayHetHan; }
            set { _ngayHetHan = value; }
        }

        public int NhietDoBaoQuan
        {
            get { return _nhietDoBaoQuan; }
            set { _nhietDoBaoQuan = value; }
        }

        // ===== Override TinhGiaBan(): giảm 30% nếu còn <= 3 ngày hết hạn =====
        public override decimal TinhGiaBan()
        {
            decimal giaGoc = base.TinhGiaBan(); // lấy _gia từ lớp cha
            int soNgayConLai = (_ngayHetHan.Date - DateTime.Now.Date).Days;

            if (soNgayConLai <= 3)
                return giaGoc * 0.7m; // giảm 30%

            return giaGoc;
        }

        // ===== Override MoTa() =====
        public override string MoTa()
        {
            string moTaGoc = base.MoTa();
            int soNgayConLai = (_ngayHetHan.Date - DateTime.Now.Date).Days;
            return $"{moTaGoc} | Loai: Thuc pham | HSD: {_ngayHetHan:dd/MM/yyyy} (còn {soNgayConLai} ngày) | Bao quan: {_nhietDoBaoQuan}°C";
        }
    }
}