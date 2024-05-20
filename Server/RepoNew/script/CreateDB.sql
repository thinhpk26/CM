DROP TABLE IF EXISTS layout;
CREATE TABLE layout(
	ID int auto_increment primary key,
    LayoutCode VARCHAR(255) COMMENT 'mã phân hệ',
    LayoutName VARCHAR(255) COMMENT 'tên phân hệ'
);
INSERT INTO layout(LayoutCode, LayoutName)
VALUES
("Account", MD5("Khách hàng")),
("Lead", MD5("Tiềm năng")),
("Order", MD5("Đơn hàng")),
("Contact", MD5("Liên hệ")),
("Product", MD5("Hàng hóa")),
("Pricebook", MD5("Chính sách giá")),
("Dashboard", MD5("Dasboard"));

DROP TABLE IF EXISTS user;
CREATE TABLE user(
	ID int auto_increment primary key,
    UserCode VARCHAR(50) COMMENT 'mã người dùng',
    FullName VARCHAR(150) COMMENT 'Tên đầy đủ',
    Avatar VARCHAR(100) COMMENT 'Ảnh đại diện',
    Email VARCHAR(150) COMMENT 'email',
    Password VARCHAR(100) COMMENT 'mật khẩu',
    PhoneNumber VARCHAR(15) COMMENT 'điện thoại',
    PositionName VARCHAR(255) COMMENT 'chức vụ',
    IsActive bit(1) COMMENT 'Có được phép truy cập ứng dụng không',
    RoleID int COMMENT 'ID của quyền',
    RoleName VARCHAR(255) COMMENT 'tên quyền',
    UserPlatformID int COMMENT 'Người dùng platform',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
DROP TABLE IF EXISTS role;
CREATE TABLE role(
	ID int auto_increment primary key,
    RoleCode VARCHAR(50) COMMENT 'mã quyền',
    RoleName VARCHAR(255) COMMENT 'tên quyền',
    Description	TEXT COMMENT 'mô tả cho quyền',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
DROP TABLE IF EXISTS layout_permission;
CREATE TABLE Layout_Permission(
	ID int auto_increment primary key,
    RoleID int COMMENT 'ID quyền',
    RoleName VARCHAR(255) COMMENT 'tên quyền',
    InforPermission TEXT COMMENT 'danh sách quyền bằng chuỗi string "1,3,..."',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
DROP TABLE IF EXISTS permission;
CREATE TABLE Permission(
	ID int auto_increment primary key,
    LayoutID VARCHAR(150) COMMENT 'ID phân hệ',
    PermissionName VARCHAR(255) COMMENT 'tên quyền'
);
INSERT INTO Permission(LayoutID, PermissionName)
VALUES 
(1, MD5("Xem")),
(1, MD5("Cập nhật")),
(1, MD5("Thêm")),
(1, MD5("Xóa")),
(2, MD5("Xem")),
(2, MD5("Cập nhật")),
(2, MD5("Thêm")),
(2, MD5("Xóa")),
(3, MD5("Xem")),
(3, MD5("Cập nhật")),
(3, MD5("Thêm")),
(3, MD5("Xóa")),
(4, MD5("Xem")),
(4, MD5("Cập nhật")),
(4, MD5("Thêm")),
(4, MD5("Xóa")),
(5, MD5("Xem")),
(5, MD5("Cập nhật")),
(5, MD5("Thêm")),
(5, MD5("Xóa")),
(6, MD5("Xem")),
(6, MD5("Cập nhật")),
(6, MD5("Thêm")),
(6, MD5("Xóa")),
(7, MD5("Xem")),
(7, MD5("Cập nhật")),
(7, MD5("Thêm")),
(7, MD5("Xóa"));

DROP TABLE IF EXISTS `lead`;
CREATE TABLE `lead`(
	ID int auto_increment primary key,
	LeadCode VARCHAR(50) COMMENT 'mã tiềm năng',
	LeadName VARCHAR(255) COMMENT 'tên tiềm năng',
	PronounID INT COMMENT 'ID xưng hô',
	PronounName VARCHAR(100) COMMENT 'xưng hô',
	UserCode VARCHAR(50) COMMENT 'mã người dùng',
	UserName VARCHAR(100) COMMENT 'tên người dùng',
	SearchFromID INT COMMENT 'nguồn tìm kiếm',
	SearchFromText VARCHAR(255) COMMENT 'nguồn tìm kiếm',
	Address TEXT COMMENT 'địa chỉ tiềm năng',
	PhoneNumber VARCHAR(15) COMMENT 'số điện thoại',
	Major VARCHAR(255) COMMENT 'lĩnh vực',
	Email VARCHAR(100) COMMENT 'email',
	BirthDay DATE COMMENT 'ngày sinh/ngày thành lập',
	Gender int COMMENT 'giới tính 1. nữ 2.nam 3. không xác định', 
	Facebook VARCHAR(255) COMMENT 'url facebook',
	Zalo VARCHAR(255) COMMENT 'url zalo',
	Description TEXT COMMENT 'mô tả/chú thích',
	IsDeleted bit(1) COMMENT 'đã bị xóa chưa',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
DROP TABLE IF EXISTS pronoun_data;
CREATE TABLE pronoun_data(
	ID int auto_increment primary key,
    Name VARCHAR(255) COMMENT 'Text cho xưng hô'
);
Insert into pronoun_data(Name)
VALUES
(MD5("Anh")),
(MD5("Em")),
(MD5("Ông")),
(MD5("Bà")),
(MD5("Chị"));

DROP TABLE IF EXISTS searchform_data;
CREATE TABLE searchform_data(
	ID int auto_increment primary key,
    Name VARCHAR(255) COMMENT 'Text cho tìm kiếm từ'
);
Insert into searchform_data(Name)
VALUES
(MD5("Nhân viên kinh doanh tự tìm kiếm")),
(MD5("Nhân viên chăm sóc tìm kiếm")),
(MD5("Người thân của nhân viên")),
(MD5("Người quen của nhân viên"));

DROP TABLE IF EXISTS `account`;
CREATE TABLE `account`(
	ID int auto_increment primary key,
	AccountCode VARCHAR(50) COMMENT 'mã tiềm năng',
	AccountName VARCHAR(255) COMMENT 'tên tiềm năng',
	PronounID INT COMMENT 'ID xưng hô',
	PronounName VARCHAR(100) COMMENT 'xưng hô',
	UserCode VARCHAR(50) COMMENT 'mã người dùng',
	UserName VARCHAR(100) COMMENT 'tên người dùng',
	SearchFrom VARCHAR(255) COMMENT 'nguồn tìm kiếm',
	AddressInvoice TEXT COMMENT 'địa chỉ hóa đơn',
	AddressShipping TEXT COMMENT 'địa chỉ giao hàng',
	PhoneNumber VARCHAR(15) COMMENT 'số điện thoại',
	Major VARCHAR(255) COMMENT 'lĩnh vực',
	Email VARCHAR(100) COMMENT 'email',
	BirthDay DATE COMMENT 'ngày sinh/ngày thành lập',
	Gender int COMMENT 'giới tính 1. nữ 2.nam 3. không xác định', 
	Facebook VARCHAR(255) COMMENT 'url facebook',
	Zalo VARCHAR(255) COMMENT 'url zalo',
	Description TEXT COMMENT 'mô tả/chú thích',
	IsDeleted bit(1) COMMENT 'đã bị xóa chưa',
    AccountType VARCHAR(50) COMMENT 'loại khách hàng',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
DROP TABLE IF EXISTS `order`;
CREATE TABLE `order`(
	ID int auto_increment primary key,
	OrderCode VARCHAR(50) COMMENT 'mã đơn hàng',
	OrderName VARCHAR(255) COMMENT 'tên đơn hàng',
	AccountCode VARCHAR(50) COMMENT 'mã khách hàng',
	AccountName VARCHAR(255) COMMENT 'tên khách hàng',
	BookDate date COMMENT 'ngày ghi sổ',
	PaiedDate date COMMENT 'ngày trả',
	PaiedActual decimal(20,4) COMMENT 'số tiền đã thanh toán',
	OrderValue decimal(20,4) COMMENT 'giá trị đơn hàng',
	Description TEXT COMMENT 'mô tả đơn hàng',
	PaiedStateID INT COMMENT 'ID trạng thái thanh toán',
	PaiedStateText VARCHAR(255) COMMENT 'trạng thái thanh toán',
	StateID INT COMMENT 'ID trạng thái',
	StateIDText VARCHAR(255) COMMENT 'trạng thái',
	ShippingStateID INT COMMENT 'ID trạng thái giao hàng',
	ShippingStateText VARCHAR(255) COMMENT 'trạng thái giao hàng',
	UserCode VARCHAR(50) COMMENT 'mã người dùng',
	UserName VARCHAR(255) COMMENT 'tên người dùng',
	AddressInvoice TEXT COMMENT 'địa chỉ hóa đơn',
	AddressShipping TEXT COMMENT 'địa chỉ giao hàng',
	ContactID INT COMMENT 'ID liên hệ',
	ContactIDText VARCHAR(255) COMMENT 'liên hệ',
    IsDeleted bit(1) COMMENT 'đã xóa chưa',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
DROP TABLE IF EXISTS order_state;
CREATE TABLE order_state(
	ID int auto_increment primary key,
    Text Text COMMENT 'text hiển thị',
    Description Text COMMENT 'mô tả'
);
Insert into order_state(Text, Description)
VALUES
(MD5("Chờ đặt hàng"), "Chờ nhân viên kinh doanh đặt hàng"),
(MD5("Chờ thanh toán"), "Chờ khách hàng thanh toán"),
(MD5("Đã thanh toán một phần"), "Khách hàng đã thanh toán một phần"),
(MD5("Đã thanh toán"), "Khách hàng đã thanh toán");

DROP TABLE IF EXISTS order_shippingstate;
CREATE TABLE order_shippingstate(
	ID int auto_increment primary key,
    Text Text COMMENT 'text hiển thị',
    Description Text COMMENT 'mô tả'
);
Insert into order_shippingstate(Text, Description)
VALUES
(MD5("Chưa giao hàng"), "Đơn hàng chưa được giao"),
(MD5("Đang giao hàng"), "Đơn hàng đang được giao"),
(MD5("Đã giao hàng"), "Đơn hàng đã được giao");

DROP TABLE IF EXISTS order_paiedstate;
CREATE TABLE order_paiedstate(
	ID int auto_increment primary key,
    Text Text COMMENT 'text hiển thị',
    Description Text COMMENT 'mô tả'
);

Insert into order_paiedstate(Text, Description)
VALUES
(MD5("Chưa thanh toán"), "khách hàng chưa thanh toán"),
(MD5("Chờ thanh toán"), "Chờ khách hàng thanh toán"),
(MD5("Đã thanh toán một phần"), "Khách hàng đã thanh toán một phần"),
(MD5("Đã thanh toán"), "Khách hàng đã thanh toán");

DROP TABLE IF EXISTS contact;
CREATE TABLE contact(
	ID int auto_increment primary key,
	ContactCode VARCHAR(50) COMMENT 'mã tiềm năng',
	ContactName VARCHAR(255) COMMENT 'tên tiềm năng',
	PronounID INT COMMENT 'ID xưng hô',
	PronounName VARCHAR(100) COMMENT 'xưng hô',
	UserCode VARCHAR(50) COMMENT 'mã người dùng',
	UserName VARCHAR(100) COMMENT 'tên người dùng',
	Address TEXT COMMENT 'địa chỉ',
	PhoneNumber VARCHAR(15) COMMENT 'số điện thoại',
	Email VARCHAR(100) COMMENT 'email',
	BirthDay DATE COMMENT 'ngày sinh/ngày thành lập',
	Gender int COMMENT 'giới tính 1. nữ 2.nam 3. không xác định', 
	Facebook VARCHAR(255) COMMENT 'url facebook',
	Zalo VARCHAR(255) COMMENT 'url zalo',
	Description TEXT COMMENT 'mô tả/chú thích',
	IsDeleted bit(1) COMMENT 'đã bị xóa chưa',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
DROP TABLE IF EXISTS product;
Create table product(
	ID int auto_increment primary key,
    ProductCode VARCHAR(50) COMMENT 'mã hàng',
    ProductName VARCHAR(255) COMMENT 'tên hàng',
    UnitID int COMMENT 'đơn vị id',
    UnitText VARCHAR(50) COMMENT 'tên đơn vị',
    Price decimal(20,4) COMMENT 'giá',
    Description Text COMMENT 'mô tả',
    Tax int COMMENT 'thuế',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
DROP TABLE IF EXISTS order_product_mapping;
Create table order_product_mapping(
	ID int auto_increment primary key,
    OrderID VARCHAR(50) COMMENT 'mã hàng',
    OrderText VARCHAR(255) COMMENT 'tên hàng',
    ProductID int COMMENT 'mã hàng hóa',
    ProductText VARCHAR(50) COMMENT 'tên hàng hóa',
    Price decimal(20,4) COMMENT 'giá',
    Description Text COMMENT 'mô tả',
    Tax int COMMENT 'thuế',
    MoneyAfterTax decimal(20,4),
    Discount decimal(20,4),
    MoneyAfterDiscount decimal(20,4),
    TotalMoney decimal(20,4),
    Amount int,
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
DROP TABLE IF EXISTS unit;
Create table unit(
	ID int auto_increment primary key,
    Text VARCHAR(50) COMMENT 'text'
);
insert into unit(Text)
VALUES
(MD5("Bộ")),
(MD5("Bình")),
(MD5("Cái")),
(MD5("Lọ")),
(MD5("Chai")),
(MD5("Thùng")),
(MD5("Chiếc"));

DROP TABLE IF EXISTS tax;
Create table tax(
	ID int auto_increment primary key,
    Value int COMMENT 'giá trị của thuế'
);
Insert into tax(Value)
VALUES
(5),
(10),
(15),
(20),
(25),
(30),
(50),
(100);

DROP TABLE IF EXISTS pricebook;
Create table pricebook(
	ID int auto_increment primary key,
	PricebookCode VARCHAR(50) COMMENT 'mã chính sách giá',
	PricebookName VARCHAR(255) COMMENT 'tên chính sách giá',
	FromDate DATE COMMENT 'từ ngày nào',
	ToDate DATE COMMENT 'đến ngày nào',
	Description TEXT COMMENT 'mô tả',
	UserCode VARCHAR(50) COMMENT 'mã người dùng',
	UserText VARCHAR(255) COMMENT 'tên người dùng',
	AccountObject INT COMMENT 'loại đối tượng 1. áp dụng tất cả 2. áp dụng cho khách hàng riêng lẻ',
    AccountIDs TEXT COMMENT 'ID khách hàng cách nhau ,',
	UserObject INT COMMENT 'áp dụng cho người dùng nào 1. áp dụng tất cả 2. áp dụng khách hàng riêng lẻ',
    UserIDs TEXT COMMENT 'ID người dùng cách nhau ,',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
DROP TABLE IF EXISTS pricebook;
Create table pricebook(
	ID int auto_increment primary key,
	PricebookCode VARCHAR(50) COMMENT 'mã chính sách giá',
	PricebookName VARCHAR(255) COMMENT 'tên chính sách giá',
	FromDate DATE COMMENT 'từ ngày nào',
	ToDate DATE COMMENT 'đến ngày nào',
	Description TEXT COMMENT 'mô tả',
	UserCode VARCHAR(50) COMMENT 'mã người dùng',
	UserText VARCHAR(255) COMMENT 'tên người dùng',
	AccountObject INT COMMENT 'loại đối tượng 1. áp dụng tất cả 2. áp dụng cho khách hàng riêng lẻ',
    AccountIDs TEXT COMMENT 'ID khách hàng cách nhau ,',
	UserObject INT COMMENT 'áp dụng cho người dùng nào 1. áp dụng tất cả 2. áp dụng khách hàng riêng lẻ',
    UserIDs TEXT COMMENT 'ID người dùng cách nhau ,',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
DROP TABLE IF EXISTS dashboard;
Create table dashboard(
	ID int auto_increment primary key,
    DashboardKey int COMMENT 'dashboard key',
    DashboardName VARCHAR(255) COMMENT 'dashboard name',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
DROP TABLE IF EXISTS dashboard_group;
Create table dashboard_group(
	ID int auto_increment primary key,
    DashboardGroupName int COMMENT 'group name',
	FromDate Date COMMENT 'dữ liệu từ ngày',
    ToDate Date COMMENT 'dữ liệu đến ngày',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
DROP TABLE IF EXISTS dashboard_group_mapping;
CREATE TABLE dashboard_group_mapping (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    DashboardKey INT COMMENT 'dashboard key',
    DashboardName VARCHAR(255) COMMENT 'tên dashboard',
    DashboardGroupName INT COMMENT 'tên group',
    FromDate DATE COMMENT 'dữ liệu từ ngày',
    ToDate DATE COMMENT 'dữ liệu đến ngày',
    CreatedDate DATETIME COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DATETIME COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
