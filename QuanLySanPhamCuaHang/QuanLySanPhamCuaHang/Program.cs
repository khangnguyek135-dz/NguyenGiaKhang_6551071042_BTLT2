using System;
using System.Text;
using System.Collections.Generic;

namespace QuanLySanPhamCuaHang
{
    class Program
    {
        static void Main(string[] args)
        {
            // ===== Tạo danh sách hỗn hợp cả 3 loại đối tượng =====
            // Cú pháp: gọi constructor (truyền field chung của SanPham),
            // sau đó dùng Object Initializer { } để gán các field riêng của lớp con.
            List<SanPham> danhSachSanPham = new List<SanPham>
            {
                new SanPham("SP001", "Ban hoc go", 1_200_000, 15),

                new SanPhamThucPham("SP002", "Sua tuoi Vinamilk 1L", 32_000, 100)
                {
                    NgayHetHan = DateTime.Now.AddDays(2),   // sắp hết hạn -> sẽ được giảm giá
                    NhietDoBaoQuan = 4
                },

                new SanPhamThucPham("SP003", "Banh mi sandwich", 15_000, 40)
                {
                    NgayHetHan = DateTime.Now.AddDays(15),  // còn hạn dài -> không giảm giá
                    NhietDoBaoQuan = 25
                },

                new SanPhamDienTu("SP004", "Tai nghe Bluetooth Sony", 890_000, 25)
                {
                    BaoHanhThang = 24,                      // > 12 tháng -> cộng thêm 10% phí bảo hành
                    HangSanXuat = "Sony"
                },

                new SanPhamDienTu("SP005", "Sac du phong Anker", 350_000, 60)
                {
                    BaoHanhThang = 6,                       // <= 12 tháng -> không cộng phí
                    HangSanXuat = "Anker"
                }
            };

            // ===== Duyệt danh sách, gọi TinhGiaBan() và MoTa() -> thấy đa hình tại runtime =====
            Console.WriteLine("===== DANH SACH SAN PHAM TRONG KHO =====\n");

            decimal tongGiaTriKho = 0;

            foreach (SanPham sp in danhSachSanPham)
            {
                // Dù khai báo biến kiểu SanPham, nhưng CLR sẽ gọi đúng phiên bản
                // TinhGiaBan()/MoTa() của lớp con thực sự tại thời điểm chạy (runtime polymorphism)
                Console.WriteLine(sp.MoTa());
                Console.WriteLine($"  -> Gia ban ap dung: {sp.TinhGiaBan():N0} VNĐ (x{sp.SoLuongTon} san pham)");
                Console.WriteLine();

                tongGiaTriKho += sp.TinhGiaBan() * sp.SoLuongTon;
            }

            // ===== In tổng giá trị kho hàng =====
            Console.WriteLine("=========================================");
            Console.WriteLine($"TONG GIA TRI KHO HÀNG: {tongGiaTriKho:N0} VNĐ");
            Console.WriteLine("=========================================");
        }
    }
}