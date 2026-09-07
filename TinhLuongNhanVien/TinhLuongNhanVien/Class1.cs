using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhLuongNhanVien
{
    class Program
    {
        static void Main(string[] args)
        {
            // ----- Nhân viên 1: constructor không tham số, rồi gán property -----
            NhanVien nv1 = new NhanVien();
            nv1.HoTen = "Trần Thị Bích";
            nv1.LuongCoBan = 8_500_000;
            nv1.SoNgayLam = 24; // nghỉ 2 ngày trong tháng

            // ----- Nhân viên 2: constructor đầy đủ tham số -----
            NhanVien nv2 = new NhanVien(
                maNV: "NV002",
                hoTen: "Lê Văn Hùng",
                luongCoBan: 12_000_000,
                soNgayLam: 26,
                soNgayNghiPhep: 3
            );

            // ----- Nhân viên 3: constructor có Optional Parameters, dùng Named Arguments -----
            // maNV, hoTen bắt buộc; soNgayLam truyền vào, luong lấy mặc định 5.000.000
            NhanVien nv3 = new NhanVien(maNV: "NV003", hoTen: "Nguyễn Thị An", soNgayLam: 20);

            // ----- In thông tin từng nhân viên -----
            Console.WriteLine("--- Nhân viên 1 ---");
            nv1.HienThiThongTin();

            Console.WriteLine("\n--- Nhân viên 2 ---");
            nv2.HienThiThongTin();

            Console.WriteLine("\n--- Nhân viên 3 ---");
            nv3.HienThiThongTin();

            // ----- Gọi cả 3 overload TinhThuong và so sánh -----
            Console.WriteLine("\n===== SO SÁNH TIỀN THƯỞNG (Nhân viên 2 - Lê Văn Hùng) =====");

            decimal thuongKhongCo = nv2.TinhThuong();
            decimal thuongTheoHeSo = nv2.TinhThuong(0.5m); // thưởng bằng 50% lương cơ bản
            decimal thuongCoPhucLoi = nv2.TinhThuong(0.5m, true); // thêm 500.000 phúc lợi

            Console.WriteLine($"TinhThuong()                     = {thuongKhongCo:N0} VNĐ");
            Console.WriteLine($"TinhThuong(0.5)                  = {thuongTheoHeSo:N0} VNĐ");
            Console.WriteLine($"TinhThuong(0.5, coPhucLoi: true)  = {thuongCoPhucLoi:N0} VNĐ");

            // ----- Áp dụng tương tự cho nhân viên 3 để thấy sự khác biệt -----
            Console.WriteLine("\n===== SO SÁNH TIỀN THƯỞNG (Nhân viên 3 - Nguyễn Thị An) =====");
            Console.WriteLine($"TinhThuong()                      = {nv3.TinhThuong():N0} VNĐ");
            Console.WriteLine($"TinhThuong(0.3)                   = {nv3.TinhThuong(0.3m):N0} VNĐ");
            Console.WriteLine($"TinhThuong(0.3, coPhucLoi: false) = {nv3.TinhThuong(0.3m, false):N0} VNĐ");

            Console.WriteLine("\nChương trình kết thúc.");
        }
    }
}