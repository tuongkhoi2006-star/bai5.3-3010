CREATE DATABASE CafePOSDB;
GO
USE CafePOSDB;
GO

-- 1. Bảng BanAn
CREATE TABLE BanAn (
    MaBan INT IDENTITY(1,1) PRIMARY KEY,
    TenBan NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(20) DEFAULT N'Trống' -- 'Trống' hoặc 'Có khách'
);
GO

-- 2. Bảng DanhMuc
CREATE TABLE DanhMuc (
    MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL
);
GO

-- 3. Bảng MonAn
CREATE TABLE MonAn (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    MaDanhMuc INT FOREIGN KEY REFERENCES DanhMuc(MaDanhMuc) ON DELETE CASCADE,
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0)
);
GO

-- 4. Bảng HoaDon
CREATE TABLE HoaDon (
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaBan INT FOREIGN KEY REFERENCES BanAn(MaBan),
    GioVao DATETIME DEFAULT GETDATE(),
    GioRa DATETIME NULL,
    TongTien DECIMAL(18,2) DEFAULT 0,
    TrangThai BIT DEFAULT 0 -- 0: Chưa thanh toán, 1: Đã thanh toán
);
GO

-- 5. Bảng ChiTietHoaDon
CREATE TABLE ChiTietHoaDon (
    MaHoaDon INT FOREIGN KEY REFERENCES HoaDon(MaHoaDon) ON DELETE CASCADE,
    MaMon INT FOREIGN KEY REFERENCES MonAn(MaMon),
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (MaHoaDon, MaMon)
);
GO

-- ===================================================
-- NẠP DỮ LIỆU BAN ĐẦU (SEED DATA)
-- ===================================================
-- Tạo 12 bàn ăn
INSERT INTO BanAn (TenBan, TrangThai) VALUES 
(N'Bàn 01', N'Trống'), (N'Bàn 02', N'Trống'), (N'Bàn 03', N'Trống'), (N'Bàn 04', N'Trống'),
(N'Bàn 05', N'Trống'), (N'Bàn 06', N'Trống'), (N'Bàn 07', N'Trống'), (N'Bàn 08', N'Trống'),
(N'Bàn 09', N'Trống'), (N'Bàn 10', N'Trống'), (N'Bàn 11', N'Trống'), (N'Bàn 12', N'Trống');

-- Danh mục món
INSERT INTO DanhMuc (TenDanhMuc) VALUES 
(N'Cà phê'), (N'Trà sữa & Trà trái cây'), (N'Đá xay & Sinh tố'), (N'Đồ ăn nhẹ');

-- Thực đơn món
INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia) VALUES
(N'Cà phê Đen Đá', 1, 20000),
(N'Cà phê Sữa Đá', 1, 25000),
(N'Bạc Xỉu', 1, 28000),
(N'Trà Đào Cam Sả', 2, 35000),
(N'Trà Sữa Trân Châu', 2, 32000),
(N'Matcha Đá Xay', 3, 40000),
(N'Hướng Dương Vị Dừa', 4, 15000),
(N'Khô Bò Vắt Chanh', 4, 30000);
GO