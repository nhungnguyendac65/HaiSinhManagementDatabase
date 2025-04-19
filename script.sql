USE master;  
GO  

IF DB_ID (N'QuanLyBanHang') IS NOT NULL  
DROP DATABASE QuanLyBanHang;  
GO  

CREATE DATABASE QuanLyBanHang  
go

use QuanLyBanHang
go

--Tao bang HÀNG HÓA
create table hang_hoa
(
	ma_hh	varchar(10),
	ten_hh	nvarchar(200) not null,
	dvt	nvarchar(50) not null,
	dongia	float not null,
	mamau	varchar(10) not null,
	constraint pk_hang_hoa primary key(ma_hh)
)
go
--Tao bang KHÁCH HÀNG
create table khach_hang
(
	ma_kh varchar(10),
	ten_kh	nvarchar(150) not null,
	diachi	nvarchar(150) not null,
	sdt	varchar(15) not null,
	constraint pk_khach_hang primary key(ma_kh)
)
go
--tao bang BÁN HÀNG
create table ban_hang
(
	ma_dbh	varchar(20),
	ma_kh	varchar(10),
	ngay_bh	date,
	tongtien float,

	constraint pk_ban_hang primary key(ma_dbh),
	constraint fk_bh_kh foreign key (ma_kh) references khach_hang(ma_kh)
)
go
--tao bang CHI TIẾT BÁN HÀNG
create table chitiet_banhang
(
	ma_dbh	varchar(20),
	ma_hh varchar(10),
	sl	int not null ,
	thanhtien float,

	constraint chk_sl check(sl>0),
	constraint chk_thanhtien check(thanhtien>=0),
	constraint pk_ctbh primary key(ma_dbh,ma_hh),
	constraint fk_ctbh_dbh foreign key (ma_dbh) references ban_hang(ma_dbh),
	constraint fk_ctbh_hh foreign key (ma_hh) references hang_hoa(ma_hh)



)
go
