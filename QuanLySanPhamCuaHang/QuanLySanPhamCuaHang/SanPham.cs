using System;
using System.Text;

namespace QuanLySanPhamCuaHang
{
    public class SanPham
    {
        // ===== Field private =====
        private string _maSP;
        private string _tenSP;
        private decimal _gia;
        private int _soLuongTon;

        // ===== Constructor đầy đủ =====
        public SanPham(string maSP, string tenSP, decimal gia, int soLuongTon)
        {
            _maSP = maSP;
            TenSP = tenSP;
            Gia = gia;
            SoLuongTon = soLuongTon;
        }

        // ===== Property tương ứng =====
        public string MaSP
        {
            get { return _maSP; }
        }

        public string TenSP
        {
            get { return _tenSP; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ten san pham khong duoc de trong.", nameof(TenSP));
                _tenSP = value;
            }
        }

        public decimal Gia
        {
            get { return _gia; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Gia), "Gia khong duoc am.");
                _gia = value;
            }
        }

        public int SoLuongTon
        {
            get { return _soLuongTon; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(SoLuongTon), "So luong ton khong duoc am.");
                _soLuongTon = value;
            }
        }

        // ===== Phương thức virtual: TinhGiaBan =====
        // Lớp cơ sở: giá bán mặc định = giá gốc.
        // Lớp con sẽ override để áp dụng giảm giá / phụ phí riêng.
        public virtual decimal TinhGiaBan()
        {
            return _gia;
        }

        // ===== Phương thức virtual: MoTa =====
        public virtual string MoTa()
        {
            return $"[{_maSP}] {_tenSP} - Gia goc: {_gia:N0} VNĐ - Ton kho: {_soLuongTon}";
        }
    }
}