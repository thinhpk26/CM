DROP DATABASE IF EXISTS db_manager;
CREATE DATABASE db_manager;
USE db_manager;
DROP TABLE IF EXISTS company;
CREATE TABLE company(
	ID int auto_increment primary key,
	CompanyCode VARCHAR(10),
    CompanyName VARCHAR(255),
    MST VARCHAR(13),
    Description TEXT,
    DBSave VARCHAR(50),
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
DROP TABLE IF EXISTS user_platform;
CREATE TABLE user_platform(
	ID int auto_increment primary key,
    UserCode VARCHAR(50),
    FullName VARCHAR(150),
    Avatar VARCHAR(100),
    Email VARCHAR(150),
    Password VARCHAR(100),
    PhoneNumber VARCHAR(15),
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
DROP TABLE IF EXISTS company_user_mapping;
CREATE TABLE company_user_mapping(
	ID int auto_increment primary key,
    CompanyID int,
    UserID int,
    CompanyCode VARCHAR(10), 
    CompanyName VARCHAR(255),
    UserCode VARCHAR(50),
    UserName VARCHAR(150),
    IsAllowAccess bit(1),
    FOREIGN KEY (CompanyID) REFERENCES company(ID),
    FOREIGN KEY (UserID) REFERENCES user(ID)
);
DROP TABLE IF EXISTS confirm_code;
CREATE TABLE confirm_code(
	ID int auto_increment primary key,
    ConfirmCode VARCHAR(150),
    CreateTime datetime,
    Timeout int,
    CompanyID int,
    CompanyCode VARCHAR(10),
    IsUsed bit(1),
	CreatedDate DateTime COMMENT 'ngày tạo',
    CreatedBy VARCHAR(150) COMMENT 'người tạo',
    ModifiedDate DateTime COMMENT 'ngày sửa',
    ModifiedBy VARCHAR(150) COMMENT 'người sửa'
);
