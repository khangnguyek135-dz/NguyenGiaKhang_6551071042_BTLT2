using System;

namespace QuanLySachCoBan
{
    public class Sach
    {
        // ===== Các field private =====
        private string _maSach;
        private string _tenSach;
        private string _tacGia;
        private int _namXuatBan;
        private double _giaBan;

        // ===== Constructor đầy đủ tham số =====
        public Sach(string maSach, string tenSach, string tacGia, int namXuatBan, double giaBan)
        {
            _maSach = maSach;
            TenSach = tenSach;       // gán qua property để tận dụng validate
            _tacGia = tacGia;
            NamXuatBan = namXuatBan; // gán qua property để tận dụng validate
            _giaBan = giaBan;
        }

        // ===== Constructor không tham số - gán giá trị mặc định hợp lý =====
        public Sach()
        {
            _maSach = "SACH000";
            _tenSach = "Chưa đặt tên";
            _tacGia = "Chưa rõ";
            _namXuatBan = DateTime.Now.Year;
            _giaBan = 0;
        }

        // ===== Property =====

        // MaSach: chỉ đọc (không có set)
        public string MaSach
        {
            get { return _maSach; }
        }

        // TenSach: đọc/ghi, validate không rỗng
        public string TenSach
        {
            get { return _tenSach; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên sách không được để trống.", nameof(TenSach));
                _tenSach = value;
            }
        }

        public string TacGia
        {
            get { return _tacGia; }
            set { _tacGia = value; }
        }

        // NamXuatBan: đọc/ghi, validate từ 1900 đến năm hiện tại
        public int NamXuatBan
        {
            get { return _namXuatBan; }
            set
            {
                int namHienTai = DateTime.Now.Year;
                if (value < 1900 || value > namHienTai)
                    throw new ArgumentOutOfRangeException(
                        nameof(NamXuatBan),
                        $"Năm xuất bản phải từ 1900 đến {namHienTai}. Giá trị nhận được: {value}");
                _namXuatBan = value;
            }
        }

        // GiaBan: chỉ đọc từ ngoài (không có set public)
        public double GiaBan
        {
            get { return _giaBan; }
        }

        // ===== Phương thức hiển thị thông tin =====
        public void HienThiThongTin()
        {
            Console.WriteLine("===== THONG TIN SACH =====");
            Console.WriteLine($"Ma sach  : {_maSach}");
            Console.WriteLine($"Ten sach : {_tenSach}");
            Console.WriteLine($"Tac gia  : {_tacGia}");
            Console.WriteLine($"Năm XB   : {_namXuatBan}");
            Console.WriteLine($"Giá bán  : {_giaBan:N0} VNĐ");
            Console.WriteLine("===========================");
        }

        // ===== Override ToString() =====
        public override string ToString()
        {
            return $"[{_maSach}] {_tenSach} - {_tacGia} ({_namXuatBan}) - {_giaBan:N0} VNĐ";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ----- Cách 1: constructor đầy đủ tham số -----
            Sach sach1 = new Sach("S001", "Lap trinh  C# can ban", "Bui The Khiem", 2020, 150000);

            // ----- Cách 2: constructor không tham số rồi gán qua property -----
            Sach sach2 = new Sach();
            sach2.TenSach = "Cau truc du lieu va giai thuat";
            sach2.NamXuatBan = 2019;
         

            // ----- Cách 3: Object Initializer -----
            Sach sach3 = new Sach
            {
                TenSach = "Nhap mon tri tue nhan tao",
                NamXuatBan = 2023
            };

            // ----- Gọi HienThiThongTin() cho từng đối tượng -----
            Console.WriteLine("--- Sách 1 ---");
            sach1.HienThiThongTin();

            Console.WriteLine("\n--- Sách 2 ---");
            sach2.HienThiThongTin();

            Console.WriteLine("\n--- Sách 3 ---");
            sach3.HienThiThongTin();

            // ----- Thử ToString() -----
            Console.WriteLine("\n--- Kiểm tra ToString() ---");
            Console.WriteLine(sach1);
            Console.WriteLine(sach2);
            Console.WriteLine(sach3);

            //// ----- Thử gán giá trị không hợp lệ cho NamXuatBan -----
            //Console.WriteLine("\n--- Thử gán năm xuất bản không hợp lệ ---");

            //try
            //{
            //    sach1.NamXuatBan = 1800; // nhỏ hơn 1900 -> không hợp lệ
            //}
            //catch (ArgumentOutOfRangeException ex)
            //{
            //    Console.WriteLine("Lỗi: " + ex.Message);
            //}

            //try
            //{
            //    sach1.NamXuatBan = 3000; // lớn hơn năm hiện tại -> không hợp lệ
            //}
            //catch (ArgumentOutOfRangeException ex)
            //{
            //    Console.WriteLine("Lỗi: " + ex.Message);
            //}

            //// ----- Thử gán tên sách rỗng để kiểm tra validate -----
            //try
            //{
            //    sach2.TenSach = "   ";
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine("Lỗi: " + ex.Message);
            //}

            //Console.WriteLine("\nChương trình kết thúc.");
        }
    }
}