DROP TABLE IF EXISTS layout;
CREATE TABLE layout(
	ID int auto_increment primary key,
    LayoutCode VARCHAR(255) COMMENT 'mã phân hệ',
    LayoutName VARCHAR(255) COMMENT 'tên phân hệ',
    SortOrder INT COMMENT 'Thứ tự sắp xếp',
    Icon VARCHAR(255) COMMENT 'icon class'
);
INSERT INTO layout(LayoutCode, LayoutName, SortOrder, Icon)
VALUES
("Dashboard", MD5("Dasboard"), 1, "fa-solid fa-chart-simple"),
("Account", MD5("Khách hàng"), 2, "fa-regular fa-user"),
("Contact", MD5("Liên hệ"), 3, "fa-regular fa-address-book"),
("Lead", MD5("Tiềm năng"), 4, "fa-solid fa-pencil"),
("Order", MD5("Đơn hàng"), 5, "fa-solid fa-cart-shopping"),
("Product", MD5("Hàng hóa"), 6, "fa-solid fa-box"),
("Pricebook", MD5("Chính sách giá"), 7, "fa-solid fa-book");

DROP TABLE IF EXISTS table_code;
CREATE TABLE table_code(
	ID int auto_increment primary key,
    LayoutCode VARCHAR(50),
    Prefix VARCHAR(50),
    NumberCurrent int
);

INSERT INTO table_code(LayoutCode, Prefix, NumberCurrent)
VALUES
("Account", "KH", 1),
("Lead", "TN", 1),
("User", "NV", 1),
("Role", "RL", 1),
("Order", "DH", 1),
("Contact", "LH", 1),
("Product", "HH", 1),
("PriceBook", "CSG", 1),
("Dashboard", "DB", 1);

DROP TABLE IF EXISTS layout_Column;
CREATE TABLE layout_Column(
	ID int auto_increment primary key,
    LayoutID int COMMENT 'ID phân hệ',
    LayoutCode VARCHAR(255) COMMENT 'mã phân hệ',
    `Index` VARCHAR(255) COMMENT 'mã định danh của cột',
    `Name` VARCHAR(255) COMMENT 'tên của cột',
    `Type` int COMMENT 'tên phân hệ',
    Width int COMMENT 'chiều dài của column tính theo px',
    Sticky bit(1) COMMENT 'Có đính không',
    IsDisplay bit(1) COMMENT 'Có hiển thị không',
    `Order` int COMMENT 'Thứ tự sắp xếp'
);

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
	UserID INT COMMENT 'ID người dùng',
	UserName VARCHAR(100) COMMENT 'tên người dùng',
	SearchFromID INT COMMENT 'nguồn tìm kiếm',
	SearchFrom VARCHAR(255) COMMENT 'nguồn tìm kiếm',
	Address TEXT COMMENT 'địa chỉ tiềm năng',
	PhoneNumber VARCHAR(15) COMMENT 'số điện thoại',
	Major VARCHAR(255) COMMENT 'lĩnh vực',
	Email VARCHAR(100) COMMENT 'email',
	BirthDay DATE COMMENT 'ngày sinh/ngày thành lập',
	GenderID int COMMENT 'giới tính 1. nữ 2.nam 3. không xác định', 
	GenderIDText VARCHAR(50) COMMENT 'giới tính 1. nữ 2.nam 3. không xác định', 
	Facebook VARCHAR(255) COMMENT 'url facebook',
	Zalo VARCHAR(255) COMMENT 'url zalo',
	Description TEXT COMMENT 'mô tả/chú thích',
	IsDeleted bit(1) COMMENT 'đã bị xóa chưa',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);

SELECT ID INTO @LayoutID FROM layout
where LayoutCode = "Lead";

INSERT INTO layout_Column(LayoutID, LayoutCode, `Index`, Name, `Type`, Width, Sticky, IsDisplay, `Order`)
VALUES 
(@LayoutID, "Lead", "LeadCode", "Mã khách hàng", 1, 100, false, true, 1),
(@LayoutID, "Lead", "LeadName", "Tên khách hàng", 1, 200, false, true, 2),
(@LayoutID, "Lead", "PronounName", "Xưng hô", 1, 100, false, true, 3),
(@LayoutID, "Lead", "UserName", "Người tạo", 1, 200, false, true, 4),
(@LayoutID, "Lead", "SearchFrom", "Nguồn tìm kiếm", 1, 250, false, true, 5),
(@LayoutID, "Lead", "Address", "Địa chỉ", 1, 300, false, true, 6),
(@LayoutID, "Lead", "PhoneNumber", "Số điện thoại", 1, 100, false, true, 8),
(@LayoutID, "Lead", "Major", "Lĩnh vực", 1, 200, false, true, 9),
(@LayoutID, "Lead", "Email", "Email", 1, 150, false, true, 10),
(@LayoutID, "Lead", "BirthDay", "Ngày sinh/Ngày thành lập", 1, 200, false, true, 11),
(@LayoutID, "Lead", "GenderIDText", "Giới tính", 1, 80, false, true, 12),
(@LayoutID, "Lead", "Facebook", "Facebook", 1, 150, false, true, 13),
(@LayoutID, "Lead", "Zalo", "Zalo", 1, 150, false, true, 14),
(@LayoutID, "Lead", "Description", "Mô tả", 1, 300, false, true, 15),
(@LayoutID, "Lead", "AccountType", "Loại khách hàng", 1, 150, false, true, 16);

DROP TABLE IF EXISTS dictionary;
CREATE TABLE dictionary(
	ID int auto_increment primary key,
    FieldName VARCHAR(50) COMMENT 'Tên trường định danh',
    DictionaryKey int COMMENT 'Định danh cho từng loại ditionary',
    Text VARCHAR(255) COMMENT 'Text cho xưng hô'
);

Insert into dictionary(DictionaryKey, FieldName, Text)
VALUES
(1, "PronounID", "Anh"),
(2, "PronounID", "Em"),
(3, "PronounID", "Ông"),
(4, "PronounID", "Bà"),
(5, "PronounID", "Chị");

Insert into dictionary(DictionaryKey, FieldName, Text)
VALUES
(1, "GenderID", "Nam"),
(2, "GenderID", "Nữ"),
(3, "GenderID", "Khác");

Insert into dictionary(DictionaryKey, FieldName, Text)
VALUES
(1, "SearchFromID", "Nhân viên kinh doanh tự tìm kiếm"),
(2, "SearchFromID", "Nhân viên chăm sóc tìm kiếm"),
(3, "SearchFromID", "Người thân của nhân viên"),
(4, "SearchFromID", "Người quen của nhân viên");

DROP TABLE IF EXISTS `account`;
CREATE TABLE `account`(
	ID int auto_increment primary key,
	AccountCode VARCHAR(50) COMMENT 'mã khách hàng',
	AccountName VARCHAR(255) COMMENT 'tên khách hàng',
	PronounID INT COMMENT 'ID xưng hô',
	PronounName VARCHAR(100) COMMENT 'xưng hô',
	UserID VARCHAR(50) COMMENT 'ID người dùng',
	UserName VARCHAR(100) COMMENT 'tên người dùng',
	SearchFromID VARCHAR(255) COMMENT 'ID nguồn tìm kiếm',
	SearchFrom VARCHAR(255) COMMENT 'nguồn tìm kiếm',
	AddressInvoice TEXT COMMENT 'địa chỉ hóa đơn',
    ContactInvoiceID VARCHAR(255) COMMENT 'liên hệ hóa đơn',
    ContactInvoiceIDText VARCHAR(255) COMMENT 'liên hệ hóa đơn',
	AddressShipping TEXT COMMENT 'địa chỉ giao hàng',
    ContactShippingID VARCHAR(255) COMMENT 'liên hệ giao hàng',
    ContactShippingIDText VARCHAR(255) COMMENT 'liên hệ giao hàng',
	PhoneNumber VARCHAR(15) COMMENT 'số điện thoại',
	Major VARCHAR(255) COMMENT 'lĩnh vực',
	Email VARCHAR(100) COMMENT 'email',
	BirthDay DateTime COMMENT 'ngày sinh/ngày thành lập',
	GenderID int COMMENT 'giới tính 1. nữ 2.nam 3. không xác định', 
	GenderIDText VARCHAR(50) COMMENT 'giới tính 1. nữ 2.nam 3. không xác định', 
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

SELECT ID INTO @LayoutID FROM layout
where LayoutCode = "Account";

SET SQL_SAFE_UPDATES = 0;
DELETE FROM layout_Column WHERE LayoutCode = "Account";
INSERT INTO layout_Column(LayoutID, LayoutCode, `Index`, Name, `Type`, Width, Sticky, IsDisplay, `Order`)
VALUES 
(@LayoutID, "Account", "AccountCode", "Mã khách hàng", 1, 100, false, true, 1),
(@LayoutID, "Account", "AccountName", "Tên khách hàng", 1, 200, false, true, 2),
(@LayoutID, "Account", "PronounName", "Xưng hô", 1, 100, false, true, 3),
(@LayoutID, "Account", "UserName", "Người tạo", 1, 200, false, true, 4),
(@LayoutID, "Account", "SearchFrom", "Nguồn tìm kiếm", 1, 250, false, true, 5),
(@LayoutID, "Account", "AddressInvoice", "Địa chỉ hóa đơn", 1, 300, false, true, 6),
(@LayoutID, "Account", "ContactInvoiceIDText", "Liên hệ hóa đơn", 1, 300, false, true, 7),
(@LayoutID, "Account", "AddressShipping", "Địa chỉ giao hàng", 1, 300, false, true, 8),
(@LayoutID, "Account", "ContactShippingIDText", "Liên hệ giao hàng", 1, 300, false, true, 9),
(@LayoutID, "Account", "PhoneNumber", "Số điện thoại", 1, 100, false, true, 10),
(@LayoutID, "Account", "Major", "Lĩnh vực", 1, 200, false, true, 11),
(@LayoutID, "Account", "Email", "Email", 1, 150, false, true, 12),
(@LayoutID, "Account", "BirthDay", "Ngày sinh/Ngày thành lập", 1, 200, false, true, 13),
(@LayoutID, "Account", "GenderIDText", "Giới tính", 1, 80, false, true, 14),
(@LayoutID, "Account", "Facebook", "Facebook", 1, 150, false, true, 15),
(@LayoutID, "Account", "Zalo", "Zalo", 1, 150, false, true, 16),
(@LayoutID, "Account", "Description", "Mô tả", 1, 300, false, true, 17),
(@LayoutID, "Account", "AccountType", "Loại khách hàng", 1, 150, false, true, 18);

Insert into dictionary(DictionaryKey, FieldName, Text)
VALUES
(1, "StateID", "Bản nháp"),
(2, "StateID", "Chờ đặt hàng"),
(3, "StateID", "Đã đặt hàng"),
(4, "StateID", "Đã hủy");

Insert into dictionary(DictionaryKey, FieldName, Text)
VALUES
(1, "ShippingStateID", "Chưa giao hàng"),
(2, "ShippingStateID", "Đang giao hàng"),
(3, "ShippingStateID", "Đã giao hàng");

Insert into dictionary(DictionaryKey, FieldName, Text)
VALUES
(1, "PaiedStateID", "Khách hàng chưa thanh toán"),
(2, "PaiedStateID", "Chờ khách hàng thanh toán"),
(3, "PaiedStateID", "Khách hàng đã thanh toán một phần"),
(4, "PaiedStateID", "Khách hàng đã thanh toán");

DROP TABLE IF EXISTS contact;
CREATE TABLE contact(
	ID int auto_increment primary key,
	ContactCode VARCHAR(50) COMMENT 'mã tiềm năng',
	ContactName VARCHAR(255) COMMENT 'tên tiềm năng',
	PronounID INT COMMENT 'ID xưng hô',
	PronounName VARCHAR(100) COMMENT 'xưng hô',
	UserID VARCHAR(50) COMMENT 'ID người dùng',
	UserName VARCHAR(100) COMMENT 'tên người dùng',
	Address TEXT COMMENT 'địa chỉ',
	PhoneNumber VARCHAR(15) COMMENT 'số điện thoại',
	Email VARCHAR(100) COMMENT 'email',
	BirthDay DATE COMMENT 'ngày sinh/ngày thành lập',
	GenderID int COMMENT 'giới tính 1. nữ 2.nam 3. không xác định', 
	GenderIDText VARCHAR(50) COMMENT 'giới tính 1. nữ 2.nam 3. không xác định', 
	Facebook VARCHAR(255) COMMENT 'url facebook',
	Zalo VARCHAR(255) COMMENT 'url zalo',
	Description TEXT COMMENT 'mô tả/chú thích',
	IsDeleted bit(1) COMMENT 'đã bị xóa chưa',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);

SELECT ID INTO @LayoutID FROM layout
where LayoutCode = "Contact";

INSERT INTO layout_Column(LayoutID, LayoutCode, `Index`, Name, `Type`, Width, Sticky, IsDisplay, `Order`)
VALUES 
(@LayoutID, "Contact", "ContactCode", "Mã tiềm năng", 1, 100, false, true, 1),
(@LayoutID, "Contact", "ContactName", "Tên tiềm năng", 1, 200, false, true, 2),
(@LayoutID, "Contact", "PronounName", "Xưng hô", 1, 100, false, true, 3),
(@LayoutID, "Contact", "UserName", "Người thực hiện", 1, 200, false, true, 4),
(@LayoutID, "Contact", "Address", "Địa chỉ", 1, 300, false, true, 5),
(@LayoutID, "Contact", "PhoneNumber", "Số điện thoại", 1, 100, false, true, 6),
(@LayoutID, "Contact", "Major", "Lĩnh vực", 1, 200, false, true, 7),
(@LayoutID, "Contact", "Email", "Email", 1, 150, false, true, 8),
(@LayoutID, "Contact", "BirthDay", "Ngày sinh", 1, 200, false, true, 9),
(@LayoutID, "Contact", "GenderIDText", "Giới tính", 1, 80, false, true, 10),
(@LayoutID, "Contact", "Facebook", "Facebook", 1, 150, false, true, 11),
(@LayoutID, "Contact", "Zalo", "Zalo", 1, 150, false, true, 12),
(@LayoutID, "Contact", "Description", "Mô tả", 1, 300, false, true, 13);

DROP TABLE IF EXISTS `order`;
CREATE TABLE `order`(
	ID int auto_increment primary key,
	OrderCode VARCHAR(50) COMMENT 'mã đơn hàng',
	OrderName VARCHAR(255) COMMENT 'tên đơn hàng',
	AccountID VARCHAR(50) COMMENT 'mã khách hàng',
	AccountName VARCHAR(255) COMMENT 'tên khách hàng',
	BookDate date COMMENT 'ngày ghi sổ',
	PaiedDate date COMMENT 'ngày trả',
	PaiedActual decimal(20,4) COMMENT 'số tiền đã thanh toán',
	OrderValue decimal(20,4) COMMENT 'giá trị đơn hàng',
	Description TEXT COMMENT 'mô tả đơn hàng',
	PaiedStateID INT COMMENT 'ID trạng thái thanh toán',
	PaiedStateIDText VARCHAR(255) COMMENT 'trạng thái thanh toán',
	StateID INT COMMENT 'ID trạng thái',
	StateIDText VARCHAR(255) COMMENT 'trạng thái',
	ShippingStateID INT COMMENT 'ID trạng thái giao hàng',
	ShippingStateIDText VARCHAR(255) COMMENT 'trạng thái giao hàng',
	UserID VARCHAR(50) COMMENT 'mã người dùng',
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

SELECT ID INTO @LayoutID FROM layout
where LayoutCode = "Order";

INSERT INTO layout_Column(LayoutID, LayoutCode, `Index`, Name, `Type`, Width, Sticky, IsDisplay, `Order`)
VALUES 
(@LayoutID, "Order", "OrderCode", "Mã đơn hàng", 1, 100, false, true, 1),
(@LayoutID, "Order", "OrderName", "Tên đơn hàng", 1, 200, false, true, 2),
(@LayoutID, "Order", "AccountName", "Tên khách hàng", 1, 200, false, true, 3),
(@LayoutID, "Order", "BookDate", "Ngày ghi sổ", 4, 100, false, true, 4),
(@LayoutID, "Order", "PaiedDate", "Ngày trả", 4, 100, false, true, 5),
(@LayoutID, "Order", "PaiedActual", "Thực thu", 1, 100, false, true, 6),
(@LayoutID, "Order", "OrderValue", "Giá trị đơn hàng", 1, 100, false, true, 7),
(@LayoutID, "Order", "PaiedStateIDText", "Trạng thái thanh toán", 1, 200, false, true, 8),
(@LayoutID, "Order", "StateIDText", "Trạng thái đơn hàng", 1, 200, false, true, 9),
(@LayoutID, "Order", "ShippingStateIDText", "Trạng thái giao hàng", 1, 200, false, true, 10),
(@LayoutID, "Order", "UserName", "Người thực hiện", 1, 200, false, true, 11),
(@LayoutID, "Order", "AddressInvoice", "Địa chỉ hóa đơn", 1, 300, false, true, 12),
(@LayoutID, "Order", "AddressShipping", "Địa chỉ giao hàng", 1, 300, false, true, 13),
(@LayoutID, "Order", "ContactIDText", "Liên hệ", 1, 100, false, true, 14);

DROP TABLE IF EXISTS product;
Create table product(
	ID int auto_increment primary key,
    ProductCode VARCHAR(50) COMMENT 'mã hàng',
    ProductName VARCHAR(255) COMMENT 'tên hàng',
    UnitID int COMMENT 'đơn vị id',
    UnitText VARCHAR(50) COMMENT 'tên đơn vị',
    Price decimal(20,4) COMMENT 'giá',
    Description Text COMMENT 'mô tả',
    TaxID int COMMENT 'thuế',
    TaxIDText VARCHAR(50) COMMENT 'thuế',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);

SELECT ID INTO @LayoutID FROM layout
where LayoutCode = "Product";

INSERT INTO layout_Column(LayoutID, LayoutCode, `Index`, Name, `Type`, Width, Sticky, IsDisplay, `Order`)
VALUES 
(@LayoutID, "Product", "ProductCode", "Mã hàng hóa", 1, 100, false, true, 1),
(@LayoutID, "Product", "ProductName", "Tên hàng hóa", 1, 200, false, true, 2),
(@LayoutID, "Product", "UnitText", "Đơn vị tính", 1, 100, false, true, 3),
(@LayoutID, "Product", "UserName", "Người tạo", 1, 200, false, true, 4),
(@LayoutID, "Product", "Price", "Giá", 1, 200, false, true, 5),
(@LayoutID, "Product", "Description", "Mô tả", 1, 300, false, true, 6),
(@LayoutID, "Product", "TaxIDText", "Thuế", 1, 100, false, true, 7);


DROP TABLE IF EXISTS order_product_mapping;
Create table order_product_mapping(
	ID int auto_increment primary key,
    OrderID VARCHAR(50) COMMENT 'mã hàng',
    OrderText VARCHAR(255) COMMENT 'tên hàng',
    ProductID int COMMENT 'mã hàng hóa',
    ProductText VARCHAR(50) COMMENT 'tên hàng hóa',
    UnitID int COMMENT 'đơn vị id',
    UnitText VARCHAR(50) COMMENT 'tên đơn vị',
    Price decimal(20,4) COMMENT 'giá',
    Description Text COMMENT 'mô tả',
    TaxID int COMMENT 'thuế',
    TaxIDText VARCHAR(50) COMMENT 'thuế',
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

Insert into dictionary(DictionaryKey, FieldName, Text)
VALUES
(1, "UnitID", "Bộ"),
(2, "UnitID", "Bình"),
(3, "UnitID", "Cái"),
(4, "UnitID", "Lọ"),
(5, "UnitID", "Chai"),
(6, "UnitID", "Thùng"),
(7, "UnitID", "Chiếc"),
(8, "UnitID", "Quả"),
(9, "UnitID", "Trái");

Insert into dictionary(DictionaryKey, FieldName, Text)
VALUES
(1, "TaxID", "5%"),
(2, "TaxID", "10%"),
(3, "TaxID", "20%"),
(4, "TaxID", "30%"),
(5, "TaxID", "50%"),
(6, "TaxID", "70%"),
(7, "TaxID", "100%");

DROP TABLE IF EXISTS pricebook;
Create table pricebook(
	ID int auto_increment primary key,
	PricebookCode VARCHAR(50) COMMENT 'mã chính sách giá',
	PricebookName VARCHAR(255) COMMENT 'tên chính sách giá',
	FromDate DATE COMMENT 'từ ngày nào',
	ToDate DATE COMMENT 'đến ngày nào',
	Description TEXT COMMENT 'mô tả',
	AccountObjectID INT COMMENT 'loại đối tượng 1. áp dụng tất cả 2. áp dụng cho khách hàng riêng lẻ',
	AccountObjectIDText Text COMMENT 'áp dụng cho người dùng nào 1. áp dụng tất cả 2. áp dụng khách hàng riêng lẻ',
    AccountIDs TEXT COMMENT 'ID khách hàng cách nhau ,',
    AccountIDsText TEXT COMMENT 'ID khách hàng cách nhau ,',
	UserObjectID INT COMMENT 'áp dụng cho người dùng nào 1. áp dụng tất cả 2. áp dụng người dùng nào riêng lẻ',
	UserObjectIDText Text COMMENT 'áp dụng cho người dùng nào 1. áp dụng tất cả 2. áp dụng người dùng nào riêng lẻ',
    UserIDs TEXT COMMENT 'ID người dùng cách nhau ,',
    UserIDsText TEXT COMMENT 'ID khách hàng cách nhau ,',
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);

DROP TABLE IF EXISTS pricebook_product_mapping;
Create table pricebook_product_mapping(
	ID int auto_increment primary key,
    PricebookID int,
    ProductID int,
    ProductIDText VARCHAR(255),
    Price decimal(20,4),
    Discount int
);

Insert into dictionary(DictionaryKey, FieldName, Text)
VALUES
(1, "AccountObjectID", "Tất cả khách hàng"),
(2, "AccountObjectID", "Khách hàng xác định"),
(1, "UserObjectID", "Tất cả nhân viên"),
(2, "UserObjectID", "Nhân viên xác định");

SELECT ID INTO @LayoutID FROM layout
where LayoutCode = "Pricebook";

INSERT INTO layout_Column(LayoutID, LayoutCode, `Index`, Name, `Type`, Width, Sticky, IsDisplay, `Order`)
VALUES 
(@LayoutID, "Pricebook", "PricebookCode", "Mã hàng hóa", 1, 100, false, true, 1),
(@LayoutID, "Pricebook", "PricebookName", "Tên hàng hóa", 1, 200, false, true, 2),
(@LayoutID, "Pricebook", "FromDate", "Ngày bắt đầu", 1, 150, false, true, 3),
(@LayoutID, "Pricebook", "ToDate", "Ngày kết thúc", 1, 150, false, true, 4),
(@LayoutID, "Pricebook", "TaxIDText", "Thuế", 1, 100, false, true, 5),
(@LayoutID, "Pricebook", "AccountObjectIDText", "Loại đối tượng", 1, 350, false, true, 6),
(@LayoutID, "Pricebook", "AccountIDsText", "Khách hàng áp dụng", 1, 200, false, true, 7),
(@LayoutID, "Pricebook", "UserObjectIDText", "Loại nhân viên", 1, 350, false, true, 8),
(@LayoutID, "Pricebook", "UserIDsText", "Nhân viên được áp dụng", 1, 200, false, true, 9),
(@LayoutID, "Pricebook", "Description", "Mô tả", 1, 300, false, true, 10);

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

DROP TABLE IF EXISTS group_box;
CREATE TABLE group_box(
	ID INT AUTO_INCREMENT PRIMARY KEY,
    GroupBoxKey INT,
    LayoutCode VARCHAR(50),
    Title Text,
    SortOrder INT
);

DROP TABLE IF EXISTS group_box_item;
CREATE TABLE group_box_item(
  ID INT AUTO_INCREMENT PRIMARY KEY,
  GroupBoxKey INT,
  `Index` VARCHAR(100) COMMENT 'Field sẽ dùng để định danh trường dữ liệu',
  IndexText VARCHAR(100) COMMENT 'Field sẽ dùng để định danh trường dữ liệu hiển thị',
  LayoutCode VARCHAR(50),
  SortOrder INT,
  Title VARCHAR(255),
  DataUrl Text,
  Placeholder text,
  TypeControl int,
  IsRequired bit(1),
  DefaultValue text,
  ValueID Text,
  ValueIDText Text,
  FieldID Text,
  FieldText Text,
  Method INT,
  BodyRequest Text,
  IsCustomHost bit(1) COMMENT 'Có custom host không => dùng khi không muốn gọi từ dictionary',
  ColumnGrid INT
);

--- form sửa, form thêm khách hàng
INSERT INTO group_box(GroupBoxKey, LayoutCode, Title, SortOrder)
VALUES 
(1, "Account", "Thông tin chung", 1),
(2, "Account", "Thông tin địa chỉ", 2),
(3, "Account", "Thông tin hệ thống", 3);

DELETE FROM group_box_item WHERE LayoutCode = "Account";
INSERT INTO group_box_item
(
GroupBoxKey, `Index`, IndexText, LayoutCode, SortOrder, Title, DataUrl, Placeholder, TypeControl, 
IsRequired, DefaultValue, ValueID, ValueIDText, FieldID, FieldText, Method, BodyRequest, IsCustomHost, ColumnGrid
)
VALUES
(1, "AccountCode", null, "Account", 1, "Mã khách hàng", null, "Tự động điền nếu trống", 1,
false, null, "", null, null, null, null, null, null, 3),
(1, "AccountName", null, "Account", 2, "Tên khách hàng", null, "", 1,
true, null, "", null, null, null, null, null, null, 3),
(1, "PronounID", "PronounName", "Account", 3, "Xưng hô", "/Dictionary/PronounID", "", 6,
false, null, "", null, "ID", "Text", null, null, null, 3),
(1, "SearchFromID", "SearchFrom", "Account", 4, "Nguồn gốc", "/Dictionary/SearchFromID", "", 6,
false, null, "", null, "ID", "Text", null, null, null, 3),
(1, "PhoneNumber", null, "Account", 5, "Điện thoại", null, "", 1,
false, null, "", null, null, null, null, null, null, 3),
(1, "Major", null, "Account", 6, "Lĩnh vực", null, "", 1,
false, null, "", null, null, null, null, null, null, 3),
(1, "Email", null, "Account", 7, "Email", null, "", 1,
false, null, "", null, null, null, null, null, null, 3),
(1, "BirthDay", null, "Account", 8, "Ngày sinh/Ngày thành lập", null, "", 4,
false, null, "", null, null, null, null, null, null, 3),
(1, "GenderID", "GenderIDText", "Account", 9, "Giới tính", "/Dictionary/GenderID", "", 5,
false, null, "", null, "ID", "Text", null, null, null, 3),
(1, "Facebook", null, "Account", 10, "Facebook", null, "", 1,
false, null, "", null, null, null, null, null, null, 3),
(1, "Zalo", null, "Account", 11, "Zalo", null, "", 1,
false, null, "", null, null, null, null, null, null, 3),
(1, "AccountType", null, "Account", 12, "Loại khách hàng", null, "", 1,
false, null, "", null, null, null, null, null, null, 3),

(2, "ContactID", "ContactIDText", "Order", 1, "Liên hệ", "/Contact/Paging", "Chọn liên hệ", 6,
false, null, "", null, "ID", "ContactName", 2, null, true, 3), 
(2, "AddressInvoice", null, "Account", 2, "Địa chỉ hóa đơn", null, "Nhập địa điểm", 1,
false, null, "", null, null, null, null, null, null, 3),
(2, "ContactID", "ContactIDText", "Order", 3, "Liên hệ", "/Contact/Paging", "Chọn liên hệ", 6,
false, null, "", null, "ID", "ContactName", 2, null, true, 3), 
(2, "AddressShipping", null, "Account", 4, "Địa chỉ giao hàng", null, "Nhập địa điểm", 1,
false, null, "", null, null, null, null, null, null, 3),

(3, "UserID", "UserName", "Account", 1, "Người thực hiện", "/User/Paging", "Chọn nhân viên công ty", 6,
false, null, "", null, "ID", "FullName", 2, null, true, 3), 
(3, "Description", null, "Account", 2, "Mô tả", null, "", 1,
false, null, "", null, null, null, null, null, null, 6);

--- form thêm, form sửa liên hệ
INSERT INTO group_box(GroupBoxKey, LayoutCode, Title, SortOrder)
VALUES 
(4, "Contact", "Thông tin chung", 1),
(5, "Contact", "Thông tin địa chỉ", 2),
(6, "Contact", "Thông tin hệ thống", 3);

INSERT INTO group_box_item
(
GroupBoxKey, `Index`, IndexText, LayoutCode, SortOrder, Title, DataUrl, Placeholder, TypeControl, 
IsRequired, DefaultValue, ValueID, ValueIDText, FieldID, FieldText, Method, BodyRequest, IsCustomHost, ColumnGrid
)
VALUES
(4, "ContactCode", null, "Contact", 1, "Mã liên hệ", null, "Tự động điền nếu trống", 1,
false, null, "", null, null, null, null, null, null, 3),
(4, "ContactName", null, "Contact", 2, "Tên liên hệ", null, "", 1,
true, null, "", null, null, null, null, null, null, 3),
(4, "PronounID", "PronounName", "Contact", 3, "Xưng hô", "/Dictionary/PronounID", "", 6,
false, null, "", null, "ID", "Text", null, null, null, 3),
(4, "PhoneNumber", null, "Contact", 4, "Điện thoại", null, "", 1,
false, null, "", null, null, null, null, null, null, 3),
(4, "Email", null, "Contact", 5, "Email", null, "", 1,
false, null, "", null, null, null, null, null, null, 3),
(4, "BirthDay", null, "Contact", 6, "Ngày sinh", null, "", 4,
false, null, "", null, null, null, null, null, null, 3),
(4, "GenderID", "GenderIDText", "Contact", 7, "Giới tính", "/Dictionary/GenderID", "", 5,
false, null, "", null, "ID", "Text", null, null, null, 3),
(4, "Facebook", null, "Contact", 8, "Facebook", null, "", 1,
false, null, "", null, null, null, null, null, null, 3),
(4, "Zalo", null, "Contact", 9, "Zalo", null, "", 1,
false, null, "", null, null, null, null, null, null, 3),

(5, "Address", null, "Contact", 1, "Địa chỉ", null, "Nhập địa điểm", 1,
false, null, "", null, null, null, null, null, null, 3),

(6, "UserID", "UserName", "Contact", 1, "Người thực hiện", "/User/Paging", "Chọn nhân viên công ty", 6,
false, null, "", null, "ID", "FullName", 2, null, true, 3), 
(6, "Description", null, "Contact", 2, "Mô tả", null, "", 1,
false, null, "", null, null, null, null, null, null, 6);

--- Tiềm năng
INSERT INTO group_box(GroupBoxKey, LayoutCode, Title, SortOrder)
VALUES 
(7, "Lead", "Thông tin chung", 1),
(8, "Lead", "Thông tin địa chỉ", 2),
(9, "Lead", "Thông tin hệ thống", 3);

INSERT INTO group_box_item
(
GroupBoxKey, `Index`, IndexText, LayoutCode, SortOrder, Title, DataUrl, Placeholder, TypeControl, 
IsRequired, DefaultValue, ValueID, ValueIDText, FieldID, FieldText, Method, BodyRequest, IsCustomHost, ColumnGrid
)
VALUES
(7, "LeadCode", null, "Lead", 1, "Mã tiềm năng", null, "Tự động điền nếu trống", 1,
false, null, "", null, null, null, null, null, null, 3),
(7, "LeadName", null, "Lead", 2, "Tên tiềm năng", null, "", 1,
true, null, "", null, null, null, null, null, null, 3),
(7, "PronounID", "PronounName", "Lead", 3, "Xưng hô", "/Dictionary/PronounID", "", 6,
false, null, "", null, "ID", "Text", null, null, null, 3),
(7, "SearchFromID", "SearchFrom", "Lead", 4, "Nguồn gốc", "/Dictionary/SearchFromID", "", 6,
false, null, "", null, "ID", "Text", null, null, null, 3),
(7, "PhoneNumber", null, "Lead", 5, "Điện thoại", null, "", 1,
false, null, "", null, null, null, null, null, null, 3),
(7, "Major", null, "Lead", 6, "Lĩnh vực", null, "", 1,
false, null, "", null, null, null, null, null, null, 3),
(7, "Email", null, "Lead", 7, "Email", null, "", 1,
false, null, "", null, null, null, null, null, null, 3),
(7, "BirthDay", null, "Lead", 8, "Ngày sinh/Ngày thành lập", null, "", 4,
false, null, "", null, null, null, null, null, null, 3),
(7, "GenderID", "GenderIDText", "Lead", 9, "Giới tính", "/Dictionary/GenderID", "", 5,
false, null, "", null, "ID", "Text", null, null, null, 3),
(7, "Facebook", null, "Lead", 10, "Facebook", null, "", 1,
false, null, "", null, null, null, null, null, null, 3),
(7, "Zalo", null, "Lead", 11, "Zalo", null, "", 1,
false, null, "", null, null, null, null, null, null, 3),

(8, "Address", null, "Lead", 1, "Địa chỉ", null, "Nhập địa điểm", 1,
false, null, "", null, null, null, null, null, null, 3),

(9, "UserID", "UserName", "Lead", 1, "Người thực hiện", "/User/Paging", "Chọn nhân viên công ty", 6,
false, null, "", null, "ID", "FullName", 2, null, true, 3), 
(9, "Description", null, "Lead", 2, "Mô tả", null, "", 1,
false, null, "", null, null, null, null, null, null, 6);

--- Hàng hóa
INSERT INTO group_box(GroupBoxKey, LayoutCode, Title, SortOrder)
VALUES 
(10, "Product", "Thông tin chung", 1),
(11, "Product", "Thông tin hệ thống", 2);

INSERT INTO group_box_item
(
GroupBoxKey, `Index`, IndexText, LayoutCode, SortOrder, Title, DataUrl, Placeholder, TypeControl, 
IsRequired, DefaultValue, ValueID, ValueIDText, FieldID, FieldText, Method, BodyRequest, IsCustomHost, ColumnGrid
)
VALUES
(10, "ProductCode", null, "Product", 1, "Mã hàng hóa", null, "Tự động điền nếu trống", 1,
false, null, "", null, null, null, null, null, null, 3),
(10, "ProductName", null, "Product", 2, "Tên hàng hóa", null, "", 1,
true, null, "", null, null, null, null, null, null, 3),
(10, "UnitID", "UnitText", "Product", 3, "Đơn vị tính", "/Dictionary/UnitID", "", 6,
false, null, "", null, "ID", "Text", null, null, null, 3),
(10, "Price", null, "Product", 4, "Giá", null, "", 2,
false, null, "", null, null, null, null, null, null, 3),
(10, "TaxID", "TaxIDText", "Product", 5, "Thuế", "/Dictionary/TaxID", "", 6,
false, null, "", null, "ID", "Text", null, null, null, 3),

(11, "Description", null, "Product", 2, "Mô tả", null, "", 1,
false, null, "", null, null, null, null, null, null, 6);


--- Chính sách giá
INSERT INTO group_box(GroupBoxKey, LayoutCode, Title, SortOrder)
VALUES 
(12, "Pricebook", "Thông tin chung", 1),
(13, "Pricebook", "Thông tin hàng hóa", 2),
(14, "Pricebook", "Thông tin hệ thống", 3);

INSERT INTO group_box_item
(
GroupBoxKey, `Index`, IndexText, LayoutCode, SortOrder, Title, DataUrl, Placeholder, TypeControl, 
IsRequired, DefaultValue, ValueID, ValueIDText, FieldID, FieldText, Method, BodyRequest, IsCustomHost, ColumnGrid
)
VALUES
(12, "PricebookCode", null, "Pricebook", 1, "Mã chính sách giá", null, "Tự động điền nếu trống", 1,
false, null, "", null, null, null, null, null, null, 3),
(12, "PricebookName", null, "Pricebook", 2, "Tên chính sách giá", null, "", 1,
true, null, "", null, null, null, null, null, null, 3),
(12, "FromDate", null, "Pricebook", 3, "Ngày bắt đầu", null, "", 4,
false, null, "", null, null, null, null, null, null, 3),
(12, "ToDate", null, "Pricebook", 4, "Ngày kết thúc", null, "", 4,
false, null, "", null, null, null, null, null, null, 3),
(12, "AccountObjectID", "AccountObjectIDText", "Pricebook", 5, "Loại đối tượng", "/Dictionary/AccountObjectID", "", 6,
false, null, "", null, "ID", "Text", null, null, null, 3),
(12, "AccountIDs", "AccountIDsText", "Pricebook", 6, "Khách hàng áp dụng", "/Account/Paging", "Chọn khách hàng", 7,
false, null, "", null, "ID", "AccountName", 2, null, true, 3), 
(12, "UserObjectID", "UserObjectIDText", "Pricebook", 7, "Loại nhân viên", "/Dictionary/UserObjectID", "", 6,
false, null, "", null, "ID", "Text", null, null, null, 3),
(12, "UserIDs", "UserIDsText", "Pricebook", 8, "Nhân viên áp dụng", "/User/Paging", "Chọn nhân viên", 7,
false, null, "", null, "ID", "FullName", 2, null, true, 3), 

(13, "ProductMapping", null, "Pricebook", 8, "Nhân viên áp dụng", "/Common/GridProductColumn", null, 8,
true, null, "", null, NULL, NULL, 2, null, true, 3), 

(14, "Description", null, "Pricebook", 2, "Mô tả", null, "", 1,
false, null, "", null, null, null, null, null, null, 6);

--- đơn hàng
INSERT INTO group_box(GroupBoxKey, LayoutCode, Title, SortOrder)
VALUES 
(15, "Order", "Thông tin chung", 1),
(16, "Order", "Thông tin hàng hóa", 2),
(17, "Order", "Thông tin địa chỉ", 3),
(18, "Order", "Thông tin hệ thống", 4);

INSERT INTO group_box_item
(
GroupBoxKey, `Index`, IndexText, LayoutCode, SortOrder, Title, DataUrl, Placeholder, TypeControl, 
IsRequired, DefaultValue, ValueID, ValueIDText, FieldID, FieldText, Method, BodyRequest, IsCustomHost, ColumnGrid
)
VALUES
(15, "OrderCode", null, "Order", 1, "Mã đơn hàng", null, "Tự động điền nếu trống", 1,
false, null, "", null, null, null, null, null, null, 3),
(15, "OrderName", null, "Order", 2, "Tên đơn hàng", null, "", 1,
true, null, "", null, null, null, null, null, null, 3),
(15, "AccountID", "AccountName", "Order", 3, "Khách hàng", "/Account/Paging", "Chọn khách hàng", 6,
false, null, "", null, "ID", "AccountName", 2, null, true, 3),
(15, "BookDate", null, "Order", 4, "Ngày ghi sổ", null, "", 4,
false, null, "", null, null, null, null, null, null, 3),
(15, "PaiedDate", null, "Order", 5, "Ngày trả", null, "", 4,
false, null, "", null, null, null, null, null, null, 3),
(15, "PaiedActual", null, "Order", 6, "Thực thu", null, "", 2,
false, null, "", null, null, null, null, null, null, 3),
(15, "OrderValue", null, "Order", 7, "Giá trị đơn hàng", null, "", 2,
false, null, "", null, null, null, null, null, null, 3),
(15, "PaiedStateID", "PaiedStateIDText", "Order", 8, "Trạng thái thanh toán", "/Dictionary/PaiedStateID", "", 6,
false, null, "", null, "ID", "Text", null, null, null, 3),
(15, "StateID", "StateIDText", "Order", 9, "Trạng thái đơn hàng", "/Dictionary/StateID", "", 6,
false, null, "", null, "ID", "Text", null, null, null, 3),
(15, "ShippingStateID", "ShippingStateIDText", "Order", 10, "Trạng thái giao hàng", "/Dictionary/ShippingStateID", "", 6,
false, null, "", null, "ID", "Text", null, null, null, 3),
(15, "ContactID", "ContactIDText", "Order", 11, "Liên hệ", "/Contact/Paging", "Chọn liên hệ", 6,
false, null, "", null, "ID", "ContactName", 2, null, true, 3), 

(16, "ProductMapping", null, "Order", 1, "Nhân viên áp dụng", "/Common/GridProductColumn", null, 8,
false, null, "", null, NULL, NULL, 2, null, true, 6), 

(17, "AddressInvoice", null, "Order", 1, "Địa chỉ hóa đơn", null, "Nhập địa điểm", 1,
false, null, "", null, null, null, null, null, null, 3),
(17, "AddressShipping", null, "Order", 2, "Địa chỉ giao hàng", null, "Nhập địa điểm", 1,
false, null, "", null, null, null, null, null, null, 3),

(18, "UserID", "UserName", "Order", 1, "Người thực hiện", "/User/Paging", "Chọn nhân viên công ty", 6,
false, null, "", null, "ID", "FullName", 2, null, true, 3),
(18, "Description", null, "Order", 2, "Mô tả", null, "", 1,
false, null, "", null, null, null, null, null, null, 6);


DROP TABLE IF EXISTS grid_edit;
CREATE TABLE grid_edit(
  ID INT AUTO_INCREMENT PRIMARY KEY,
  `Index` VARCHAR(100) COMMENT 'Field sẽ dùng để định danh trường dữ liệu',
  IndexText VARCHAR(100) COMMENT 'Field sẽ dùng để định danh trường dữ liệu hiển thị',
  LayoutCode VARCHAR(50),
  SortOrder INT,
  Title VARCHAR(255),
  DataUrl Text,
  Placeholder text,
  TypeControl int,
  ValueID Text,
  ValueIDText Text,
  FieldID Text,
  FieldText Text,
  Method INT,
  BodyRequest Text,
  IsCustomHost bit(1),
  Sticky bit(1),
  Width int,
  IsDisplay bit(1)
);

Insert into grid_edit
(`Index`, IndexText, LayoutCode, SortOrder, Title, DataUrl, Placeholder, TypeControl, 
ValueID, ValueIDText, FieldID, FieldText, Method, BodyRequest, IsCustomHost, Sticky, Width, IsDisplay)
VALUES
("ProductID", "ProductIDText", "Pricebook", 1, "Hàng Hóa", "/Product/Paging", "Chọn hàng hóa", 6,
"", null, "ID", "ProductCode", 2, null, true, false, 200, true),
("Price", null, "Pricebook", 2, "Giá bán", null, "Giá bán", 2,
"", null, Null, Null, NULL, null, NULL, NULL, 150, true),
("Discount", null, "Pricebook", 3, "Chiết khấu (%)", null, "Nhập tỉ lệ", 2,
"", null, NULL, NULL, 2, null, true, false, 150, true);

Insert into grid_edit
(`Index`, IndexText, LayoutCode, SortOrder, Title, DataUrl, Placeholder, TypeControl, 
ValueID, ValueIDText, FieldID, FieldText, Method, BodyRequest, IsCustomHost, Sticky, Width, IsDisplay)
VALUES
("ProductCode", NULL, "PricebookProductDetail", 1, "Mã hàng Hóa", NULL, NULL, 6,
"", null, "ID", "ProductCode", 2, null, true, false, 200, true),
("ProductName", NULL, "PricebookProductDetail", 2, "Tên hàng Hóa", NULL, NULL, 6,
"", null, "ID", "ProductCode", 2, null, true, false, 200, true),
("Price", null, "PricebookProductDetail", 3, "Giá bán", null, NULL, 2,
"", null, Null, Null, NULL, null, NULL, NULL, 150, true),
("Discount", null, "PricebookProductDetail", 4, "Chiết khấu (%)", null, "Nhập tỉ lệ", 2,
"", null, NULL, NULL, 2, null, true, false, 150, true);

Insert into grid_edit
(`Index`, IndexText, LayoutCode, SortOrder, Title, DataUrl, Placeholder, TypeControl, 
ValueID, ValueIDText, FieldID, FieldText, Method, BodyRequest, IsCustomHost, Sticky, Width, IsDisplay)
VALUES
("ProductID", "ProductIDText", "Order", 1, "Hàng Hóa", "/Product/Paging", "Chọn hàng hóa", 6,
"", null, "ID", "ProductCode", 2, null, true, false, 200, true),
("Price", null, "Order", 3, "Giá bán", null, "Giá bán", 2,
"", null, Null, Null, NULL, null, NULL, NULL, 150, true),
("UnitID", "UnitText", "Order", 4, "Đơn vị tính", "/Dictionary/UnitID", "Chọn đơn vị", 6,
"", null, "ID", "Text", 1, null, null, false, 150, true),
("Amount", null, "Order", 5, "Số lượng", null, "", 2,
"", null, NULL, NULL, 2, null, true, false, 100, true),
("Discount", null, "Order", 6, "Chiết khấu (%)", null, "Nhập tỉ lệ", 2,
"", null, NULL, NULL, null, null, true, false, 100, true),
("TaxID", "TaxIDText", "Order", 7, "Thuế", "/Dictionary/TaxID", "", 6,
"", null, "ID", "Text", 1, null, null, null, 150, true),
("MoneyAfterDiscount", null, "Order", 8, "Tiền sau chiết khấu", null, "", 2,
"", null, NULL, NULL, null, null, true, false, 100, true),
("MoneyAfterTax", null, "Order", 9, "Tiền sau thuế", null, "", 2,
"", null, NULL, NULL, null, null, true, false, 100, true),
("TotalMoney", null, "Order", 10, "Tổng tiền", null, "", 2,
"", null, NULL, NULL, null, null, true, false, 200, true);	

Insert into grid_edit
(`Index`, IndexText, LayoutCode, SortOrder, Title, DataUrl, Placeholder, TypeControl, 
ValueID, ValueIDText, FieldID, FieldText, Method, BodyRequest, IsCustomHost, Sticky, Width, IsDisplay)
VALUES
("ProductCode", NULL, "OrderProductDetail", 1, "Mã hàng hóa", NULL, NULL, 2,
"", null, "ID", "ProductCode", 2, null, true, false, 200, true),
("ProductText", NULL, "OrderProductDetail", 2, "Tên hàng hóa", NULL, NULL, 2,
"", null, "ID", "ProductCode", 2, null, true, false, 200, true),
("UnitText", null, "OrderProductDetail", 3, "Đơn vị tính", null, NULL, 2,
"", null, Null, Null, NULL, null, NULL, NULL, 50, true),
("Price", null, "OrderProductDetail", 4, "Giá", null, NULL, 2,
"", null, NULL, NULL, 2, null, true, false, 150, true),
("Amount", null, "OrderProductDetail", 5, "Số lượng", null, NULL, 2,
"", null, NULL, NULL, 2, null, true, false, 50, true),
("Discount", null, "OrderProductDetail", 6, "Chiết khấu", null, NULL, 2,
"", null, NULL, NULL, 2, null, true, false, 150, true),
("MoneyAfterDiscount", null, "OrderProductDetail", 7, "Giá sau chiết khấu", null, NULL, 2,
"", null, NULL, NULL, 2, null, true, false, 200, true),
("TaxIDText", null, "OrderProductDetail", 8, "Thuế", null, NULL, 2,
"", null, NULL, NULL, 2, null, true, false, 50, true),
("MoneyAfterTax", null, "OrderProductDetail", 9, "Giá sau thuế", null, NULL, 2,
"", null, NULL, NULL, 2, null, true, false, 200, true),
("TotalMoney", null, "OrderProductDetail", 10, "Tổng tiền", null, NULL, 2,
"", null, NULL, NULL, 2, null, true, false, 200, true);

DROP PROCEDURE IF EXISTS execute_Proc;
DELIMITER $$
CREATE PROCEDURE execute_Proc(
    IN query_text TEXT
)
BEGIN
    SET @query = query_text;
    PREPARE myquery FROM @query;
    EXECUTE myquery;
    DEALLOCATE PREPARE myquery;
END $$
DELIMITER ;

DROP PROCEDURE IF EXISTS convert_tax;
DELIMITER $$
CREATE PROCEDURE convert_tax(
    IN v_taxIDText TEXT
)
BEGIN
    SELECT CASE 
		WHEN LOCATE('%', v_taxIDText) > 0 THEN 
			CONVERT(SUBSTRING_INDEX(v_taxIDText, '%', 1), UNSIGNED INTEGER)
		ELSE 
			CONVERT(v_taxIDText, UNSIGNED INTEGER)
	END;
END $$
DELIMITER ;

DROP procedure if exists Proc_ProductApplyPricebook;
DELIMITER $$
CREATE procedure Proc_ProductApplyPricebook(
    IN v_employee VARCHAR(255),
    IN v_account VARCHAR(255)
)
BEGIN
	drop temporary table if exists temp_product_pricebook;
	create temporary table temp_product_pricebook(
		ID int,
		ProductCode TEXT,
        ProductName TEXT,
        Price decimal(20,4),
        UnitID int,
        UnitText TEXT,
        TaxID int,
        TaxIDText TEXT,
        Discount int,
        MoneyAfterDiscount decimal(20,4),
        MoneyAfterTax decimal(20,4),
        TotalMoney decimal(20,4)
    );
    
    SET @WhereEmployee = "1=1";
    if(IFNULL(v_employee, "") <> "") THEN
		SET @WhereEmployee = CONCAT("pri.UserObjectID = 2 AND pri.UserIDs IN (", v_employee, ")");
	end if;
    
    SET @WhereAccount = "1=1";
    if(IFNULL(v_account, "") <> "") THEN
		SET @WhereAccount = CONCAT("pri.AccountObjectID = 2 AND pri.AccountIDs IN (", v_account, ")");
	end if;
    
    
    SET @queryEmployee  = CONCAT("
    INSERT INTO temp_product_pricebook 
    SELECT pro.ID, pro.ProductCode, pro.ProductName, IFNULL(ppm.Price, pro.Price), pro.UnitID, pro.UnitText, 
    pro.TaxID, pro.TaxIDText, ppm.Discount, IFNULL(ppm.Price * (1 - ppm.Discount/100), pro.Price), NULL, IFNULL(ppm.Price * (1 - ppm.Discount/100), pro.Price) 
    FROM product pro
			LEFT JOIN pricebook_product_mapping ppm ON pro.ID = ppm.ProductID
            JOIN pricebook pri ON pri.ID = ppm.PricebookID
    Where ((", @WhereEmployee,") OR (pri.UserObjectID <> 2)) AND (NOW() BETWEEN pri.FromDate AND pri.ToDate) "); 
    CALL execute_Proc(@queryEmployee);
    
    SET @queryAccount = CONCAT("
    INSERT INTO temp_product_pricebook 
    SELECT pro.ID, pro.ProductCode, pro.ProductName, IFNULL(ppm.Price, pro.Price), pro.UnitID, pro.UnitText, 
    pro.TaxID, pro.TaxIDText, ppm.Discount, IFNULL(ppm.Price * (1 - ppm.Discount/100), pro.Price), NULL, IFNULL(ppm.Price * (1 - ppm.Discount/100), pro.Price) 
	FROM product pro
		LEFT JOIN pricebook_product_mapping ppm ON pro.ID = ppm.ProductID
		LEFT JOIN pricebook pri ON pri.ID = ppm.PricebookID
	Where ((", @WhereAccount,") OR (AccountObjectID <> 2)) AND (NOW() BETWEEN pri.FromDate AND pri.ToDate) ");
    CALL execute_Proc(@queryAccount);
    
    SET SQL_SAFE_UPDATES = 0;
    UPDATE temp_product_pricebook 
    SET MoneyAfterTax = (1 + ((CASE 
			WHEN LOCATE('%', TaxIDText) > 0 THEN 
				CONVERT(SUBSTRING_INDEX(TaxIDText, '%', 1), UNSIGNED INTEGER)
			ELSE 
				0
		END) / 100)) * MoneyAfterDiscount,
        TotalMoney = (1 + ((CASE 
			WHEN LOCATE('%', TaxIDText) > 0 THEN 
				CONVERT(SUBSTRING_INDEX(TaxIDText, '%', 1), UNSIGNED INTEGER)
			ELSE 
				0
		END) / 100)) * MoneyAfterDiscount;
    
    SELECT ID, ProductCode, ProductName, Price, UnitID, UnitText, TaxID, TaxIDText, Discount, MoneyAfterDiscount,  MoneyAfterTax, TotalMoney
	FROM (
		SELECT 
			ID, ProductCode, ProductName, Price, UnitID, UnitText, TaxID, TaxIDText, Discount, MoneyAfterDiscount, MoneyAfterTax, TotalMoney,
			ROW_NUMBER() OVER (PARTITION BY ID ORDER BY TotalMoney) AS row_num
		FROM temp_product_pricebook
	) AS temp
	WHERE row_num = 1;
    
END $$
DELIMITER ;


