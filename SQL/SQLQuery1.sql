use master;
go
CREATE DATABASE MobileApp;
GO
use MobileApp;
go
CREATE TABLE dbo.catagory
(
	cat_id INT IDENTITY(1,1) PRIMARY KEY,
	cat_name NVARCHAR(100),
	[description] NVARCHAR(250)
)
GO
CREATE TABLE dbo.color
(
	color_id VARCHAR(30) PRIMARY KEY,
	color_name NVARCHAR(40)
)
GO
--Thêm dữ liệu cho bảng màu
INSERT INTO dbo.color (color_id, color_name)
VALUES
('#FF0000', N'Đỏ'),
('#0000FF', N'Lam'),
('#00FF00', N'Lục'),
('#FFFF00', N'Vàng'),
('#FFA500', N'Cam'),
('#800080', N'Tím'),
('#FFC0CB', N'Hồng'),
('#000000', N'Đen'),
('#FFFFFF', N'Trắng'),
('#FFD700', N'Vàng nghệ'),
('#008000', N'Lục đậm'),
('#FF4500', N'Đỏ cam'),
('#808080', N'Xám'),
('#FF1493', N'Đỏ hồng'),
('#000080', N'Xanh dương'),
('#FF69B4', N'Hồng nóng'),
('#FF8C00', N'Cam đậm'),
('#808000', N'Olive'),
('#C0C0C0', N'Bạc'),
('#800000', N'Đỏ đậm')
GO
-- bảng mobile_detail lưu các thông tin như giá và số lượng
-- lưu giá theo từng sản phẩm và từng màu khác nhau
-- lưu số lượng sản phẩm theo màu
CREATE TABLE dbo.mobile_detail
(
	mobile_detail_id INT IDENTITY(1,1) PRIMARY KEY,
	color_id VARCHAR(30) FOREIGN KEY REFERENCES dbo.color(color_id),
	price DECIMAL(10,2),
	quantity INT
)
GO
-- Bảng thông tin nhà sản xuất
CREATE TABLE dbo.manufacturer
(
	manufacturer_id INT IDENTITY(1,1) PRIMARY KEY,
	manufacturer_name NVARCHAR(200)
)
GO
CREATE TABLE dbo.mobile
(
	mobile_id INT IDENTITY(1,1) PRIMARY KEY,
	mobile_name NVARCHAR(150),
	mobile_detail_id INT FOREIGN KEY REFERENCES dbo.mobile_detail(mobile_detail_id),
	manufacturer_id INT FOREIGN KEY REFERENCES dbo.manufacturer(manufacturer_id),
	screen NVARCHAR(100),
	cpu NVARCHAR(50),
	ram VARCHAR(10),
	rom VARCHAR(10),
	camera VARCHAR(20),
	battery VARCHAR(15),
	operating VARCHAR(30),
	[description] NVARCHAR(250),
	cat_id INT FOREIGN KEY REFERENCES dbo.catagory(cat_id)
)
GO

-- Bảng hình ảnh của điện thoại
CREATE TABLE dbo.mobile_image
(
	image_id INT IDENTITY(1,1) PRIMARY KEY,
	image_path NVARCHAR(500),
	mobile_id INT FOREIGN KEY REFERENCES dbo.mobile(mobile_id)
)
GO
CREATE TABLE dbo.mobile_color
(
	color_id VARCHAR(30) FOREIGN KEY REFERENCES dbo.color(color_id),
	mobile_id INT FOREIGN KEY REFERENCES dbo.mobile(mobile_id),
	PRIMARY KEY(color_id,mobile_id)
)
GO

CREATE TABLE dbo.customer
(
	cus_id INT IDENTITY(1,1) PRIMARY KEY,
	cus_name NVARCHAR(100),
	sex BIT,
	phone_number VARCHAR(15) UNIQUE NOT NULL,
	hash_password VARCHAR(MAX) NOT NULL,
	email VARCHAR(80),
	[address] NVARCHAR(150),
)
GO
CREATE TABLE dbo.staff
(
	staff_id INT IDENTITY(1,1) PRIMARY KEY,
	username VARCHAR(100) UNIQUE NOT NULL,
	hash_password VARCHAR(MAX) NOT NULL,
	[role] VARCHAR(20)
)
GO
CREATE TABLE dbo.[order]
(
	order_id INT IDENTITY(1,1) PRIMARY KEY,
	order_date DATETIME DEFAULT(GETDATE()),
	quantity INT,
	cus_id INT FOREIGN KEY REFERENCES dbo.customer(cus_id),
	staff_id INT FOREIGN KEY REFERENCES dbo.staff(staff_id),
	money_total DECIMAL(10,2)
)
GO
CREATE TABLE dbo.order_detail
(
	mobile_id INT FOREIGN KEY REFERENCES dbo.mobile(mobile_id),
	color_id VARCHAR(30) FOREIGN KEY REFERENCES dbo.color(color_id),
	order_id INT FOREIGN KEY REFERENCES dbo.[order](order_id),
	PRIMARY KEY(mobile_id,color_id,order_id),
	quantity INT,
	price DECIMAL(10,2)
)
GO
CREATE TABLE dbo.[provider]
(
	provider_id INT IDENTITY(1,1) PRIMARY KEY,
	provider_name NVARCHAR(100),
	[address] NVARCHAR(200),
	phone_number VARCHAR(15) UNIQUE NOT NULL,
	email VARCHAR(80) UNIQUE
)
GO
CREATE TABLE dbo.import_bill
(
	imp_id INT IDENTITY(1,1) PRIMARY KEY,
	imp_date DATETIME DEFAULT(GETDATE()),
	staff_id INT FOREIGN KEY REFERENCES dbo.staff(staff_id),
	provider_id INT FOREIGN KEY REFERENCES dbo.[provider](provider_id),
	money_total DECIMAL(10,2)
)
GO
CREATE TABLE dbo.import_bill_detail
(
	mobile_id INT FOREIGN KEY REFERENCES dbo.mobile(mobile_id),
	color_id VARCHAR(30) FOREIGN KEY REFERENCES dbo.color(color_id),
	imp_id INT FOREIGN KEY REFERENCES dbo.import_bill(imp_id),
	quantity INT,
	imp_price DECIMAL(10,2),
	PRIMARY KEY(mobile_id,color_id,imp_id)

)
