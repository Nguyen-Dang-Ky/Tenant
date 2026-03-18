using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TENANT_MANAGEMENT.Migrations
{
    /// <inheritdoc />
    public partial class ChoThuePhongTro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChuTros",
                columns: table => new
                {
                    MaChuTro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoVaTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuTros", x => x.MaChuTro);
                });

            migrationBuilder.CreateTable(
                name: "DangNhaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangNhaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DichVus",
                columns: table => new
                {
                    MaDV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDV = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GiaDV = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVus", x => x.MaDV);
                });

            migrationBuilder.CreateTable(
                name: "KhachThues",
                columns: table => new
                {
                    MaKhachThue = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachThues", x => x.MaKhachThue);
                });

            migrationBuilder.CreateTable(
                name: "KhuTros",
                columns: table => new
                {
                    MaKhuTro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaChuTro = table.Column<int>(type: "int", nullable: false),
                    TenKhuTro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuTros", x => x.MaKhuTro);
                    table.ForeignKey(
                        name: "FK_KhuTros_ChuTros_MaChuTro",
                        column: x => x.MaChuTro,
                        principalTable: "ChuTros",
                        principalColumn: "MaChuTro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhongTros",
                columns: table => new
                {
                    MaPhongTro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhongtroBusinessCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaKhuTro = table.Column<int>(type: "int", nullable: false),
                    DienTich = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    GiaPhong = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongTros", x => x.MaPhongTro);
                    table.ForeignKey(
                        name: "FK_PhongTros_KhuTros_MaKhuTro",
                        column: x => x.MaKhuTro,
                        principalTable: "KhuTros",
                        principalColumn: "MaKhuTro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoadonBusinessCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaPhongTro = table.Column<int>(type: "int", nullable: false),
                    ThangHoaDon = table.Column<DateOnly>(type: "date", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HoaDons_PhongTros_MaPhongTro",
                        column: x => x.MaPhongTro,
                        principalTable: "PhongTros",
                        principalColumn: "MaPhongTro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDongs",
                columns: table => new
                {
                    MaHopDong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HopdongBusinessCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaPhongTro = table.Column<int>(type: "int", nullable: false),
                    MaKhachThue = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateOnly>(type: "date", nullable: false),
                    NgayKetThuc = table.Column<DateOnly>(type: "date", nullable: false),
                    TienCoc = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TienThueHangThang = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongs", x => x.MaHopDong);
                    table.ForeignKey(
                        name: "FK_HopDongs_KhachThues_MaKhachThue",
                        column: x => x.MaKhachThue,
                        principalTable: "KhachThues",
                        principalColumn: "MaKhachThue",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDongs_PhongTros_MaPhongTro",
                        column: x => x.MaPhongTro,
                        principalTable: "PhongTros",
                        principalColumn: "MaPhongTro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    MaCTHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHD = table.Column<int>(type: "int", nullable: false),
                    MaDV = table.Column<int>(type: "int", nullable: false),
                    TenDV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoLuong = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => x.MaCTHD);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_DichVus_MaDV",
                        column: x => x.MaDV,
                        principalTable: "DichVus",
                        principalColumn: "MaDV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_MaHD",
                        column: x => x.MaHD,
                        principalTable: "HoaDons",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_MaDV",
                table: "ChiTietHoaDons",
                column: "MaDV");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_MaHD",
                table: "ChiTietHoaDons",
                column: "MaHD");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_HoadonBusinessCode",
                table: "HoaDons",
                column: "HoadonBusinessCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaPhongTro_ThangHoaDon",
                table: "HoaDons",
                columns: new[] { "MaPhongTro", "ThangHoaDon" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_HopdongBusinessCode",
                table: "HopDongs",
                column: "HopdongBusinessCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_MaKhachThue",
                table: "HopDongs",
                column: "MaKhachThue");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongs_MaPhongTro",
                table: "HopDongs",
                column: "MaPhongTro");

            migrationBuilder.CreateIndex(
                name: "IX_KhachThues_CCCD",
                table: "KhachThues",
                column: "CCCD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KhuTros_MaChuTro",
                table: "KhuTros",
                column: "MaChuTro");

            migrationBuilder.CreateIndex(
                name: "IX_PhongTros_MaKhuTro",
                table: "PhongTros",
                column: "MaKhuTro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhongTros_PhongtroBusinessCode",
                table: "PhongTros",
                column: "PhongtroBusinessCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "DangNhaps");

            migrationBuilder.DropTable(
                name: "HopDongs");

            migrationBuilder.DropTable(
                name: "DichVus");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "KhachThues");

            migrationBuilder.DropTable(
                name: "PhongTros");

            migrationBuilder.DropTable(
                name: "KhuTros");

            migrationBuilder.DropTable(
                name: "ChuTros");
        }
    }
}
