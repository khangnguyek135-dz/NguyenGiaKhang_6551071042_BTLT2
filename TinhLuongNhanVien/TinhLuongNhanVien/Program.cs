using System;

namespace TinhLuongNhanVien
{
    public class NhanVien
    {
        // ===== Field private =====
        private string _maNV;
        private string _hoTen;
        private decimal _luongCoBan;
        private int _soNgayLam;
        private int _soNgayNghiPhep;

        // ===== Constructor 1: không tham số =====
        public NhanVien()
        {
            _maNV = "NV000";
            _hoTen = "Chưa đặt tên";
            _luongCoBan = 5_000_000;
            _soNgayLam = 26;
            _soNgayNghiPhep = 0;
        }

        // ===== Constructor 2: chỉ nhận mã NV và họ tên =====
        public NhanVien(string maNV, string hoTen)
        {
            _maNV = maNV;
            HoTen = hoTen;          // gán qua property để validate luôn
            _luongCoBan = 5_000_000;
            _soNgayLam = 26;
            _soNgayNghiPhep = 0;
        }

        // ===== Constructor 3: đầy đủ tham số =====
        public NhanVien(string maNV, string hoTen, decimal luongCoBan, int soNgayLam, int soNgayNghiPhep)
        {
            _maNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
            SoNgayLam = soNgayLam;
            _soNgayNghiPhep = soNgayNghiPhep;
        }

        // ===== Constructor 4: có Optional Parameters ====
        public NhanVien(string maNV, string hoTen, decimal luong = 5_000_000, int soNgayLam = 26)
        {
            _maNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luong;
            SoNgayLam = soNgayLam;
            _soNgayNghiPhep = 0;
        }

        // ===== Property =====

        // MaNV: chỉ đọc (không nằm trong yêu cầu bắt buộc nhưng cần để hiển thị/kiểm tra ở Main)
        public string MaNV
        {
            get { return _maNV; }
        }

        // HoTen: đọc/ghi
        public string HoTen
        {
            get { return _hoTen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Họ tên không được để trống.", nameof(HoTen));
                _hoTen = value;
            }
        }

        // LuongCoBan: đọc/ghi, validate >= 0
        public decimal LuongCoBan
        {
            get { return _luongCoBan; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(LuongCoBan), "Lương cơ bản không được âm.");
                _luongCoBan = value;
            }
        }

        // SoNgayLam: đọc/ghi, validate 0-31
        public int SoNgayLam
        {
            get { return _soNgayLam; }
            set
            {
                if (value < 0 || value > 31)
                    throw new ArgumentOutOfRangeException(nameof(SoNgayLam), "Số ngày làm phải trong khoảng 0-31.");
                _soNgayLam = value;
            }
        }

        // SoNgayNghiPhep: đọc/ghi (thêm cho đầy đủ dữ liệu, không có yêu cầu validate riêng)
        public int SoNgayNghiPhep
        {
            get { return _soNgayNghiPhep; }
            set { _soNgayNghiPhep = value; }
        }

        // LuongThucNhan: chỉ đọc, tính tự động
        // Công thức: LuongCoBan / 26 * SoNgayLam - KhauTruBHXH (8% lương cơ bản)
        public decimal LuongThucNhan
        {
            get
            {
                decimal luongTheoNgayCong = _luongCoBan / 26m * _soNgayLam;
                decimal khauTruBHXH = _luongCoBan * 0.08m;
                return luongTheoNgayCong - khauTruBHXH;
            }
        }

        // ===== 3 overload phương thức TinhThuong =====

        // Không tham số -> trả về 0
        public decimal TinhThuong()
        {
            return 0;
        }

        // Có hệ số -> LuongCoBan * heSo
        public decimal TinhThuong(decimal heSo)
        {
            return _luongCoBan * heSo;
        }

        // Có hệ số + cờ phúc lợi -> cộng thêm 500.000 nếu coPhucLoi = true
        public decimal TinhThuong(decimal heSo, bool coPhucLoi)
        {
            decimal thuong = TinhThuong(heSo);
            if (coPhucLoi)
                thuong += 500_000;
            return thuong;
        }

        // ===== Hiển thị thông tin (tiện cho việc in ở Main) =====
        public void HienThiThongTin()
        {
            Console.WriteLine("===== THÔNG TIN NHÂN VIÊN =====");
            Console.WriteLine($"Mã NV        : {_maNV}");
            Console.WriteLine($"Họ tên       : {_hoTen}");
            Console.WriteLine($"Lương CB     : {_luongCoBan:N0} VNĐ");
            Console.WriteLine($"Số ngày làm  : {_soNgayLam}");
            Console.WriteLine($"Nghỉ phép    : {_soNgayNghiPhep} ngày");
            Console.WriteLine($"Lương thực nhận: {LuongThucNhan:N0} VNĐ");
            Console.WriteLine("================================");
        }

        public override string ToString()
        {
            return $"[{_maNV}] {_hoTen} - Lương thực nhận: {LuongThucNhan:N0} VNĐ";
        }
    }
}