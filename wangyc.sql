/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 80017
Source Host           : localhost:3306
Source Database       : wangyc

Target Server Type    : MYSQL
Target Server Version : 80017
File Encoding         : 65001

Date: 2020-04-05 11:02:18
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for arrivalnotice
-- ----------------------------
DROP TABLE IF EXISTS `arrivalnotice`;
CREATE TABLE `arrivalnotice` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ObjectId` int(11) DEFAULT NULL,
  `ArrivalNoticeTypeId` int(11) DEFAULT NULL,
  `WarehouseId` int(11) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `State` tinyint(4) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of arrivalnotice
-- ----------------------------

-- ----------------------------
-- Table structure for arrivalnoticedetail
-- ----------------------------
DROP TABLE IF EXISTS `arrivalnoticedetail`;
CREATE TABLE `arrivalnoticedetail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ArrivalNoticeId` int(11) DEFAULT NULL,
  `PurchaseOrderDetailId` int(11) DEFAULT NULL,
  `Qty` int(11) DEFAULT NULL,
  `ArrivalQty` int(11) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `State` tinyint(4) NOT NULL DEFAULT '1',
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ProductId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of arrivalnoticedetail
-- ----------------------------
INSERT INTO `arrivalnoticedetail` VALUES ('12', null, '141', '3', '0', null, '1', 'W006', '2019-09-08 22:47:19', '1');
INSERT INTO `arrivalnoticedetail` VALUES ('13', null, '142', '2', '0', null, '1', 'W006', '2020-01-30 12:59:02', '1');

-- ----------------------------
-- Table structure for arrivalreceipt
-- ----------------------------
DROP TABLE IF EXISTS `arrivalreceipt`;
CREATE TABLE `arrivalreceipt` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Note` varchar(200) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of arrivalreceipt
-- ----------------------------

-- ----------------------------
-- Table structure for arrivalreceiptdetail
-- ----------------------------
DROP TABLE IF EXISTS `arrivalreceiptdetail`;
CREATE TABLE `arrivalreceiptdetail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ArrivalReceiptId` int(11) DEFAULT NULL,
  `ArrivalNoticeDetailId` int(11) DEFAULT NULL,
  `Qty` varchar(20) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of arrivalreceiptdetail
-- ----------------------------

-- ----------------------------
-- Table structure for inoutbound
-- ----------------------------
DROP TABLE IF EXISTS `inoutbound`;
CREATE TABLE `inoutbound` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) DEFAULT NULL,
  `Type` varchar(20) DEFAULT NULL,
  `WarehouseId` int(11) DEFAULT NULL,
  `Qty` int(11) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `Currency` varchar(10) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `ParentId` int(11) DEFAULT NULL,
  `CurrentQty` int(11) DEFAULT NULL,
  `CreateUserId` varchar(10) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  `InOutReasonId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of inoutbound
-- ----------------------------
INSERT INTO `inoutbound` VALUES ('1', '1', '1', '1', '10', '3000', 'RMB', null, null, '-1', 'W001', '2018-06-03 17:22:37', '1');
INSERT INTO `inoutbound` VALUES ('2', '1', '1', '1', '11', '3000', 'RMB', null, null, '11', 'W001', '2018-06-03 17:28:36', '1');
INSERT INTO `inoutbound` VALUES ('3', '1', '1', '1', '1', '200', 'RMB', null, null, '1', 'W001', '2018-06-03 17:33:59', '1');
INSERT INTO `inoutbound` VALUES ('4', '1', '1', '1', '2', '2000', 'RMB', null, null, '2', 'W001', '2018-06-03 17:36:21', '1');
INSERT INTO `inoutbound` VALUES ('5', '1', '1', '1', '1', '3000', 'RMB', null, null, '1', 'W001', '2018-06-03 17:46:21', '1');
INSERT INTO `inoutbound` VALUES ('6', '2', '1', '1', '1', '3000', 'RMB', null, null, '-2', 'W001', '2018-06-03 17:56:29', '1');
INSERT INTO `inoutbound` VALUES ('7', '1', '0', '1', '1', '3000', 'RMB', null, '1', '0', 'W001', '2018-06-03 22:25:43', '2');
INSERT INTO `inoutbound` VALUES ('8', '1', '0', '1', '1', '3000', 'RMB', null, '1', '0', 'W001', '2018-06-03 22:30:13', '2');
INSERT INTO `inoutbound` VALUES ('9', '1', '0', '1', '2', '3000', 'RMB', null, '1', '0', 'W001', '2018-06-03 22:39:33', '2');
INSERT INTO `inoutbound` VALUES ('10', '1', '0', '1', '2', '3000', 'RMB', null, '1', '0', 'W001', '2018-06-03 22:39:41', '2');
INSERT INTO `inoutbound` VALUES ('11', '1', '0', '1', '2', '3000', 'RMB', null, '1', '0', 'W001', '2018-06-03 22:39:44', '2');
INSERT INTO `inoutbound` VALUES ('12', '2', '0', '1', '1', '3000', 'RMB', null, '6', '0', 'W001', '2018-06-03 22:46:07', '2');
INSERT INTO `inoutbound` VALUES ('13', '1', '0', '1', '1', '3000', 'RMB', null, '1', '0', 'W001', '2018-06-03 22:49:00', '2');
INSERT INTO `inoutbound` VALUES ('14', '2', '1', '1', '20', '300', 'RMB', null, null, '20', 'W001', '2018-06-04 11:52:18', '1');
INSERT INTO `inoutbound` VALUES ('15', '2', '0', '1', '2', '3000', 'RMB', null, '6', '0', 'W001', '2018-06-05 17:32:34', '2');

-- ----------------------------
-- Table structure for inoutboundofshelf
-- ----------------------------
DROP TABLE IF EXISTS `inoutboundofshelf`;
CREATE TABLE `inoutboundofshelf` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `InOutBoundId` int(11) DEFAULT NULL,
  `Type` varchar(20) DEFAULT NULL,
  `WarehouseShelfId` int(11) DEFAULT NULL,
  `Qty` int(11) DEFAULT NULL,
  `CurrentQty` int(11) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `ParentId` int(11) DEFAULT NULL,
  `CreateUserId` varchar(10) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of inoutboundofshelf
-- ----------------------------
INSERT INTO `inoutboundofshelf` VALUES ('1', '1', '1', '1', '10', '-1', null, null, 'W001', '2018-06-03 17:22:37');
INSERT INTO `inoutboundofshelf` VALUES ('2', '2', '1', '1', '11', '0', null, null, 'W001', '2018-06-03 17:28:36');
INSERT INTO `inoutboundofshelf` VALUES ('3', '3', '1', '1', '1', '0', null, null, 'W001', '2018-06-03 17:33:59');
INSERT INTO `inoutboundofshelf` VALUES ('4', '4', '1', '1', '2', '0', null, null, 'W001', '2018-06-03 17:36:21');
INSERT INTO `inoutboundofshelf` VALUES ('5', '5', '1', '1', '1', '0', null, null, 'W001', '2018-06-03 17:46:21');
INSERT INTO `inoutboundofshelf` VALUES ('6', '6', '1', '1', '1', '-2', null, null, 'W001', '2018-06-03 17:56:29');
INSERT INTO `inoutboundofshelf` VALUES ('7', '7', '0', '1', '1', '0', null, '1', 'W001', '2018-06-03 22:25:43');
INSERT INTO `inoutboundofshelf` VALUES ('8', '8', '0', '1', '1', '0', null, '1', 'W001', '2018-06-03 22:30:22');
INSERT INTO `inoutboundofshelf` VALUES ('9', '9', '0', '1', '2', '0', null, '1', 'W001', '2018-06-03 22:39:33');
INSERT INTO `inoutboundofshelf` VALUES ('10', '10', '0', '1', '2', '0', null, '1', 'W001', '2018-06-03 22:39:41');
INSERT INTO `inoutboundofshelf` VALUES ('11', '11', '0', '1', '2', '0', null, '1', 'W001', '2018-06-03 22:39:44');
INSERT INTO `inoutboundofshelf` VALUES ('12', '12', '0', '1', '1', '0', null, '6', 'W001', '2018-06-03 22:46:07');
INSERT INTO `inoutboundofshelf` VALUES ('13', '13', '0', '1', '1', '0', null, '1', 'W001', '2018-06-03 22:49:00');
INSERT INTO `inoutboundofshelf` VALUES ('14', '14', '1', '1', '20', '0', null, null, 'W001', '2018-06-04 11:52:18');
INSERT INTO `inoutboundofshelf` VALUES ('15', '15', '0', '1', '2', '0', null, '6', 'W001', '2018-06-05 17:32:34');

-- ----------------------------
-- Table structure for inoutreason
-- ----------------------------
DROP TABLE IF EXISTS `inoutreason`;
CREATE TABLE `inoutreason` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(20) DEFAULT NULL,
  `InOutType` int(11) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of inoutreason
-- ----------------------------
INSERT INTO `inoutreason` VALUES ('1', '采购入库', '1', '1', '采购入库', '2018-06-03 14:43:42');
INSERT INTO `inoutreason` VALUES ('2', '原料领用', '0', '1', '原料领用', '2018-06-03 21:10:28');

-- ----------------------------
-- Table structure for organization
-- ----------------------------
DROP TABLE IF EXISTS `organization`;
CREATE TABLE `organization` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ParentId` int(11) DEFAULT NULL,
  `Name` varchar(64) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  `Level` int(11) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of organization
-- ----------------------------
INSERT INTO `organization` VALUES ('0', null, '组织架构', '组织架构', '2018-05-19 10:42:19', '0', null);
INSERT INTO `organization` VALUES ('1', '0', '人事部', '人事部', '2017-07-12 13:35:52', '1', null);
INSERT INTO `organization` VALUES ('2', '0', '采购部', '采购部', '2017-07-12 13:35:52', '1', null);
INSERT INTO `organization` VALUES ('3', '0', '生产部', '生产部', '2017-07-12 13:35:52', '1', null);
INSERT INTO `organization` VALUES ('4', '3', '第一生产组', '第一生产组', '2017-07-12 13:36:14', '2', null);
INSERT INTO `organization` VALUES ('5', '3', '第二生产组', '第二生产组', '2017-07-12 13:36:14', '2', null);
INSERT INTO `organization` VALUES ('9', '5', '铺装', '铺装', '2017-07-20 11:00:56', '3', null);
INSERT INTO `organization` VALUES ('10', '5', '板机', '板机', '2017-07-20 11:00:56', '3', null);
INSERT INTO `organization` VALUES ('20', '2', '采购一部', '采购一部', '2017-07-25 19:30:17', '2', null);
INSERT INTO `organization` VALUES ('21', '2', '采购二部', '采购二部', '2017-07-25 19:30:26', '2', null);
INSERT INTO `organization` VALUES ('35', '1', '人事', '人事', '2018-05-26 11:10:10', '2', null);
INSERT INTO `organization` VALUES ('36', '2', '采购三部', '采购三部', '2018-05-26 11:11:21', '2', null);
INSERT INTO `organization` VALUES ('37', '0', '财务部', '财务部', '2018-05-26 11:17:25', '1', null);
INSERT INTO `organization` VALUES ('39', '37', '123', '123', '2019-03-31 15:56:03', '2', null);
INSERT INTO `organization` VALUES ('101', '1', 'cesium', '测试', '2019-08-04 21:21:09', '2', null);
INSERT INTO `organization` VALUES ('102', '0', '后勤部', '负责发运', '2019-08-12 09:40:22', '1', null);

-- ----------------------------
-- Table structure for organizationusers
-- ----------------------------
DROP TABLE IF EXISTS `organizationusers`;
CREATE TABLE `organizationusers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` varchar(20) DEFAULT NULL,
  `OrganizationID` int(11) DEFAULT NULL,
  `Note` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of organizationusers
-- ----------------------------
INSERT INTO `organizationusers` VALUES ('3', '101', '35', null, '2019-03-27 17:28:32');
INSERT INTO `organizationusers` VALUES ('4', 'W005', '35', null, '2019-03-27 17:48:14');
INSERT INTO `organizationusers` VALUES ('5', 'W004', '10', null, '2019-03-27 22:44:00');
INSERT INTO `organizationusers` VALUES ('6', 'W004', '0', null, '2019-03-27 22:44:00');
INSERT INTO `organizationusers` VALUES ('13', 'W006', '9', null, '2019-03-31 15:57:44');
INSERT INTO `organizationusers` VALUES ('15', 'W003', '35', null, '2019-04-02 22:25:07');

-- ----------------------------
-- Table structure for payment
-- ----------------------------
DROP TABLE IF EXISTS `payment`;
CREATE TABLE `payment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `PurchaseOrderId` int(11) DEFAULT NULL,
  `SupplierId` int(11) DEFAULT NULL,
  `PaymentTypeId` int(11) DEFAULT NULL,
  `ExpectedDate` timestamp NULL DEFAULT NULL,
  `Amount` double DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of payment
-- ----------------------------

-- ----------------------------
-- Table structure for paymenttype
-- ----------------------------
DROP TABLE IF EXISTS `paymenttype`;
CREATE TABLE `paymenttype` (
  `Id` int(11) NOT NULL,
  `Name` varchar(20) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of paymenttype
-- ----------------------------
INSERT INTO `paymenttype` VALUES ('1', '后付款', '到货后付款', '1', 'W001', '2018-06-30 16:31:31');
INSERT INTO `paymenttype` VALUES ('2', '先付款', '先付款后到货', '1', 'W001', '2018-06-30 16:31:38');

-- ----------------------------
-- Table structure for product
-- ----------------------------
DROP TABLE IF EXISTS `product`;
CREATE TABLE `product` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ChineseName` varchar(200) DEFAULT NULL,
  `EnglishName` varchar(200) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `Currency` varchar(10) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `ProductTypeId` int(11) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of product
-- ----------------------------
INSERT INTO `product` VALUES ('1', 'OPPO R11', 'OPPO R11', '3000', null, '不打折', null, '2017-11-27 23:21:22');
INSERT INTO `product` VALUES ('2', '华为P10', 'hauweiP10', '5000', null, '不打折', null, '2017-11-27 23:42:23');

-- ----------------------------
-- Table structure for producttype
-- ----------------------------
DROP TABLE IF EXISTS `producttype`;
CREATE TABLE `producttype` (
  `Id` int(11) NOT NULL,
  `Name` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of producttype
-- ----------------------------

-- ----------------------------
-- Table structure for project
-- ----------------------------
DROP TABLE IF EXISTS `project`;
CREATE TABLE `project` (
  `Id` int(11) DEFAULT NULL,
  `TypeId` int(11) DEFAULT NULL,
  `ChargeId` varchar(20) DEFAULT NULL,
  `ApproveId` varchar(20) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `State` int(11) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of project
-- ----------------------------

-- ----------------------------
-- Table structure for projectattendance
-- ----------------------------
DROP TABLE IF EXISTS `projectattendance`;
CREATE TABLE `projectattendance` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ProjectId` int(11) DEFAULT NULL,
  `UserId` varchar(20) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of projectattendance
-- ----------------------------

-- ----------------------------
-- Table structure for projectmaterial
-- ----------------------------
DROP TABLE IF EXISTS `projectmaterial`;
CREATE TABLE `projectmaterial` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ProjectId` int(11) DEFAULT NULL,
  `ProductId` int(11) DEFAULT NULL,
  `Qty` int(11) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `Type` int(11) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of projectmaterial
-- ----------------------------

-- ----------------------------
-- Table structure for projectproduct
-- ----------------------------
DROP TABLE IF EXISTS `projectproduct`;
CREATE TABLE `projectproduct` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ProjectId` int(11) DEFAULT NULL,
  `ProductId` int(11) DEFAULT NULL,
  `Qty` int(11) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of projectproduct
-- ----------------------------

-- ----------------------------
-- Table structure for projecttype
-- ----------------------------
DROP TABLE IF EXISTS `projecttype`;
CREATE TABLE `projecttype` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` int(11) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `LaborCost` double DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of projecttype
-- ----------------------------

-- ----------------------------
-- Table structure for purchaseorder
-- ----------------------------
DROP TABLE IF EXISTS `purchaseorder`;
CREATE TABLE `purchaseorder` (
  `Id` varchar(30) DEFAULT NULL,
  `PurchaseTypeId` int(11) DEFAULT NULL,
  `PaymentTypeId` int(11) DEFAULT NULL,
  `SupplierId` int(11) DEFAULT NULL,
  `StatuId` varchar(20) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  KEY `indexName` (`StatuId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of purchaseorder
-- ----------------------------
INSERT INTO `purchaseorder` VALUES ('PO-20190908-001', '1', '1', '1', 'PO-030', null, '1', 'W006', '2019-09-08 22:46:58');
INSERT INTO `purchaseorder` VALUES ('PO-20200130-001', '1', '1', '1', 'PO-030', null, '1', 'W006', '2020-01-30 12:58:08');

-- ----------------------------
-- Table structure for purchaseorderdetail
-- ----------------------------
DROP TABLE IF EXISTS `purchaseorderdetail`;
CREATE TABLE `purchaseorderdetail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `PurchaseOrderId` varchar(30) DEFAULT NULL,
  `ProductId` int(11) DEFAULT NULL,
  `Qty` int(11) DEFAULT NULL,
  `ArrivalQty` int(11) DEFAULT NULL,
  `UnitPrice` double DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=143 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of purchaseorderdetail
-- ----------------------------
INSERT INTO `purchaseorderdetail` VALUES ('141', 'PO-20190908-001', '1', '3', '0', '4', null, '1', 'W001', '2019-09-08 22:47:07');
INSERT INTO `purchaseorderdetail` VALUES ('142', 'PO-20200130-001', '1', '2', '0', '2', null, '1', 'W001', '2020-01-30 12:58:26');

-- ----------------------------
-- Table structure for purchasetype
-- ----------------------------
DROP TABLE IF EXISTS `purchasetype`;
CREATE TABLE `purchasetype` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(20) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of purchasetype
-- ----------------------------
INSERT INTO `purchasetype` VALUES ('1', '原料采购', '有实物且需要存放', '1', 'W001', '2018-06-10 11:16:07');
INSERT INTO `purchasetype` VALUES ('2', '费用采购', '如电费水费交通费不是真实的实物', '1', 'W001', '2018-06-10 11:16:57');

-- ----------------------------
-- Table structure for rights
-- ----------------------------
DROP TABLE IF EXISTS `rights`;
CREATE TABLE `rights` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `ParentId` int(11) DEFAULT NULL,
  `Name` varchar(64) DEFAULT NULL,
  `Url` varchar(200) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `Level` int(11) DEFAULT NULL,
  `IsShow` tinyint(4) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `IsLeaf` tinyint(4) DEFAULT NULL,
  `PathName` varchar(200) DEFAULT NULL,
  `icon` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=123 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of rights
-- ----------------------------
INSERT INTO `rights` VALUES ('0', null, '优木头管理系统', null, '优木头管理系统', '0', '0', '2018-05-20 15:54:38', null, '0', null, 'el-icon-setting');
INSERT INTO `rights` VALUES ('1', '0', '系统管理', '1', '人事管理系统1', '1', '1', '2018-05-20 15:55:27', null, '0', null, 'iconfont iconkongzhitai');
INSERT INTO `rights` VALUES ('2', '0', '库存', '2', '库存管理系统', '1', '1', '2018-05-20 16:52:02', null, '0', null, 'iconfont iconkufang');
INSERT INTO `rights` VALUES ('3', '1', '组织管理', 'organization', '组织架构', '2', '1', '2018-05-20 16:53:45', null, '0', '人事管理系统', 'el-icon-setting');
INSERT INTO `rights` VALUES ('4', '1', '员工管理', 'user', '员工管理系统', '2', '1', '2018-05-20 16:55:20', null, '0', '人事管理系统', 'el-icon-setting');
INSERT INTO `rights` VALUES ('5', '1', '权限管理', 'rights', '功能管理', '2', '1', '2018-05-20 16:56:13', null, '0', '人事管理系统', 'el-icon-setting');
INSERT INTO `rights` VALUES ('6', '3', '添加', null, '添加功能', '3', '0', '2018-05-20 17:00:46', null, '1', '人事管理系统/组织管理', 'el-icon-setting');
INSERT INTO `rights` VALUES ('7', '3', '删除', null, '删除功能', '3', '0', '2018-05-20 17:00:58', null, '1', '人事管理系统/组织管理', 'el-icon-setting');
INSERT INTO `rights` VALUES ('8', '3', '查看', null, '只有查看浏览的功能', '3', '1', '2018-05-20 21:44:57', null, '1', '人事管理系统/组织管理', 'el-icon-setting');
INSERT INTO `rights` VALUES ('9', '0', '财务', '9', '财务管理系统', '1', '1', '2018-05-23 20:32:45', null, '0', null, 'iconfont iconiconfontcaiwu');
INSERT INTO `rights` VALUES ('19', '4', '添加', null, '添加', '3', '0', '2018-05-24 23:11:36', null, '1', '人事管理系统/员工管理', 'el-icon-setting');
INSERT INTO `rights` VALUES ('20', '4', '修改', null, '修改', '3', '0', '2018-05-24 23:13:04', null, '1', '人事管理系统/员工管理', 'el-icon-setting');
INSERT INTO `rights` VALUES ('21', '4', '删除', null, '删除', '3', '0', '2018-05-24 23:13:19', null, '1', '人事管理系统/员工管理', 'el-icon-setting');
INSERT INTO `rights` VALUES ('22', '0', '生产', '22', '生产管理系统', '1', '0', '2018-05-24 23:22:33', null, '0', null, 'iconfont iconshengchan');
INSERT INTO `rights` VALUES ('23', '5', '添加', null, '添加', '3', '0', '2018-05-24 23:24:44', null, '1', null, 'el-icon-setting');
INSERT INTO `rights` VALUES ('24', '0', '采购', '24', '采购管理系统', '1', '0', '2018-05-26 11:19:47', null, '0', null, 'iconfont iconcaigou');
INSERT INTO `rights` VALUES ('28', '1', '角色管理', 'role', '角色管理', '2', '1', '2019-03-27 16:14:39', null, '1', '人事管理系统', 'el-icon-setting');
INSERT INTO `rights` VALUES ('30', '2', '现货库存', 'spotinventory', '现货库存', '2', '0', '2019-03-31 22:19:31', null, '1', '库存管理系统', 'el-icon-setting');
INSERT INTO `rights` VALUES ('31', '2', '添加入库', 'addinbound', '添加入库', '2', '0', '2019-03-31 22:20:03', null, '1', '库存管理系统', 'el-icon-setting');
INSERT INTO `rights` VALUES ('32', '2', '待到货', 'purchasereceipt', '接受货物页面', '2', '0', '2019-03-31 23:03:15', null, '1', '库存', null);
INSERT INTO `rights` VALUES ('33', '2', '库存盘点', '123', '库存盘点', '2', '0', '2019-04-01 12:04:01', null, '1', '库存管理系统', null);
INSERT INTO `rights` VALUES ('34', '0', '产品', '34', '产品', '1', '0', '2019-04-01 17:41:44', null, '0', null, 'iconfont iconchanpin');
INSERT INTO `rights` VALUES ('35', '0', '质检', '35', '质检', '1', '0', '2019-04-01 17:44:05', null, '1', null, 'iconfont iconzhijian');
INSERT INTO `rights` VALUES ('100', '24', '我的采购单', 'mypurchaseorder', null, '2', '0', '2019-08-01 23:27:09', null, '1', '采购', null);
INSERT INTO `rights` VALUES ('101', '24', '添加采购单', 'addpurchaseorder', null, '2', '0', '2019-08-01 23:27:40', null, '1', '采购', null);
INSERT INTO `rights` VALUES ('102', '24', '审批采购单', 'approvalpurchase', 'approvalpurchase', '2', '0', '2019-08-04 21:32:05', null, '1', '采购', null);
INSERT INTO `rights` VALUES ('103', '2', '出入库记录', '99', '1', '2', '0', '2019-08-05 09:49:06', null, '1', '库存', null);
INSERT INTO `rights` VALUES ('104', '0', '销售', '98', '客户订单', '1', '1', '2019-08-05 09:55:55', null, '0', null, 'iconfont iconxiaoshoushichang');
INSERT INTO `rights` VALUES ('105', '2', '库房维护', '102', null, '2', '0', '2019-08-09 09:33:27', null, '1', '库存', null);
INSERT INTO `rights` VALUES ('106', '104', '客户管理', '订单管理', null, '2', '0', '2019-08-09 09:43:26', null, '1', '销售', null);
INSERT INTO `rights` VALUES ('107', '104', '订单管理', '订单管理1', null, '2', '0', '2019-08-09 09:43:43', null, '1', '销售', null);
INSERT INTO `rights` VALUES ('108', '24', '供应商管理', '供应商管理', null, '2', '0', '2019-08-09 09:45:02', null, '1', '采购', null);
INSERT INTO `rights` VALUES ('109', '22', '员工考勤', '员工考勤', null, '2', '0', '2019-08-09 09:47:04', null, '1', '生产', null);
INSERT INTO `rights` VALUES ('110', '22', '生产计划', '生产计划', null, '2', '0', '2019-08-09 09:48:14', null, '1', '生产', null);
INSERT INTO `rights` VALUES ('111', '22', '质量检测', '质量检测', null, '2', '1', '2019-08-09 09:49:00', null, '1', '生产', null);
INSERT INTO `rights` VALUES ('112', '22', '物料申请', '物料申请', null, '2', '0', '2019-08-09 09:49:43', null, '1', '生产', null);
INSERT INTO `rights` VALUES ('113', '9', '应收任务', '应收任务', null, '2', '0', '2019-08-09 09:54:00', null, '1', '财务', null);
INSERT INTO `rights` VALUES ('114', '9', '应付任务', '应付任务', null, '2', '0', '2019-08-09 09:54:13', null, '1', '财务', null);
INSERT INTO `rights` VALUES ('115', '9', '财务报表', '财务报表', null, '2', '0', '2019-08-09 09:55:17', null, '1', '财务', null);
INSERT INTO `rights` VALUES ('116', '34', '目录管理', '目录管理', null, '2', '0', '2019-08-09 10:04:11', null, '1', '产品', null);
INSERT INTO `rights` VALUES ('117', '34', '产品管理', '产品管理', null, '2', '0', '2019-08-09 10:04:23', null, '1', '产品', null);

-- ----------------------------
-- Table structure for role
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `ParentId` int(11) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of role
-- ----------------------------
INSERT INTO `role` VALUES ('1', '优木头管理系统', '优木头管理系统', null, '1', '2019-03-27 14:04:21');
INSERT INTO `role` VALUES ('2', '人事部经理', '人事部经理', '1', '1', '2019-03-27 14:05:19');
INSERT INTO `role` VALUES ('3', '后勤部经理', '后勤部经理', '1', '1', '2019-03-27 15:02:29');
INSERT INTO `role` VALUES ('4', '后勤部经理', '后勤部经理', '1', '0', '2019-03-27 15:02:33');
INSERT INTO `role` VALUES ('5', '后勤部经理', '后勤部经理', '1', '0', '2019-03-27 15:03:24');
INSERT INTO `role` VALUES ('6', '后勤部经理', '后勤部经理', '1', '0', '2019-03-27 15:04:45');
INSERT INTO `role` VALUES ('7', '123', '123', '1', '0', '2019-03-27 15:06:40');
INSERT INTO `role` VALUES ('8', '123', '123', '1', '0', '2019-03-27 15:06:41');
INSERT INTO `role` VALUES ('9', '人事部办事员', '人事部办事员', '2', '1', '2019-03-27 15:08:59');
INSERT INTO `role` VALUES ('10', '123', '123', '1', '0', '2019-03-31 16:46:20');
INSERT INTO `role` VALUES ('11', '123', '123', '1', '0', '2019-03-31 16:46:44');
INSERT INTO `role` VALUES ('12', '123', '123', '1', '0', '2019-03-31 16:48:37');
INSERT INTO `role` VALUES ('13', '123', '123', '1', '0', '2019-03-31 16:56:43');
INSERT INTO `role` VALUES ('14', '123', '123', '1', '0', '2019-03-31 17:00:59');
INSERT INTO `role` VALUES ('17', '2', '2', '3', '1', '2019-03-31 17:06:07');
INSERT INTO `role` VALUES ('18', '3', '3', '17', '1', '2019-03-31 17:06:20');
INSERT INTO `role` VALUES ('19', '4', '4', '18', '1', '2019-03-31 17:13:01');
INSERT INTO `role` VALUES ('20', '管理员', '管理员', '1', '1', '2019-03-31 22:14:10');

-- ----------------------------
-- Table structure for rolerights
-- ----------------------------
DROP TABLE IF EXISTS `rolerights`;
CREATE TABLE `rolerights` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(20) DEFAULT NULL,
  `RightsId` varchar(200) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=602 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of rolerights
-- ----------------------------
INSERT INTO `rolerights` VALUES ('297', '1', '6', '2019-03-26 17:59:49');
INSERT INTO `rolerights` VALUES ('298', '1', '7', '2019-03-26 17:59:49');
INSERT INTO `rolerights` VALUES ('299', '1', '19', '2019-03-26 17:59:49');
INSERT INTO `rolerights` VALUES ('300', '1', '21', '2019-03-26 17:59:49');
INSERT INTO `rolerights` VALUES ('301', '1', '23', '2019-03-26 17:59:49');
INSERT INTO `rolerights` VALUES ('302', '1', '8', '2019-03-26 17:59:49');
INSERT INTO `rolerights` VALUES ('313', '4', '6', '2019-03-27 15:17:00');
INSERT INTO `rolerights` VALUES ('314', '4', '7', '2019-03-27 15:17:00');
INSERT INTO `rolerights` VALUES ('358', '3', '30', '2019-04-01 14:25:46');
INSERT INTO `rolerights` VALUES ('359', '3', '31', '2019-04-01 14:25:46');
INSERT INTO `rolerights` VALUES ('360', '3', '32', '2019-04-01 14:25:46');
INSERT INTO `rolerights` VALUES ('361', '3', '33', '2019-04-01 14:25:46');
INSERT INTO `rolerights` VALUES ('362', '2', '6', '2019-04-01 14:25:55');
INSERT INTO `rolerights` VALUES ('363', '2', '7', '2019-04-01 14:25:55');
INSERT INTO `rolerights` VALUES ('364', '2', '19', '2019-04-01 14:25:55');
INSERT INTO `rolerights` VALUES ('365', '2', '20', '2019-04-01 14:25:55');
INSERT INTO `rolerights` VALUES ('366', '2', '21', '2019-04-01 14:25:55');
INSERT INTO `rolerights` VALUES ('367', '2', '23', '2019-04-01 14:25:55');
INSERT INTO `rolerights` VALUES ('368', '2', '28', '2019-04-01 14:25:55');
INSERT INTO `rolerights` VALUES ('369', '2', '8', '2019-04-01 14:25:55');
INSERT INTO `rolerights` VALUES ('575', '20', '6', null);
INSERT INTO `rolerights` VALUES ('576', '20', '7', null);
INSERT INTO `rolerights` VALUES ('577', '20', '8', null);
INSERT INTO `rolerights` VALUES ('578', '20', '19', null);
INSERT INTO `rolerights` VALUES ('579', '20', '20', null);
INSERT INTO `rolerights` VALUES ('580', '20', '21', null);
INSERT INTO `rolerights` VALUES ('581', '20', '23', null);
INSERT INTO `rolerights` VALUES ('582', '20', '28', null);
INSERT INTO `rolerights` VALUES ('583', '20', '30', null);
INSERT INTO `rolerights` VALUES ('584', '20', '31', null);
INSERT INTO `rolerights` VALUES ('585', '20', '32', null);
INSERT INTO `rolerights` VALUES ('586', '20', '33', null);
INSERT INTO `rolerights` VALUES ('587', '20', '35', null);
INSERT INTO `rolerights` VALUES ('588', '20', '100', null);
INSERT INTO `rolerights` VALUES ('589', '20', '101', null);
INSERT INTO `rolerights` VALUES ('590', '20', '102', null);
INSERT INTO `rolerights` VALUES ('591', '20', '103', null);
INSERT INTO `rolerights` VALUES ('592', '20', '105', null);
INSERT INTO `rolerights` VALUES ('593', '20', '106', null);
INSERT INTO `rolerights` VALUES ('594', '20', '107', null);
INSERT INTO `rolerights` VALUES ('595', '20', '108', null);
INSERT INTO `rolerights` VALUES ('596', '20', '109', null);
INSERT INTO `rolerights` VALUES ('597', '20', '110', null);
INSERT INTO `rolerights` VALUES ('598', '20', '111', null);
INSERT INTO `rolerights` VALUES ('599', '20', '112', null);
INSERT INTO `rolerights` VALUES ('600', '20', '113', null);
INSERT INTO `rolerights` VALUES ('601', '20', '114', null);

-- ----------------------------
-- Table structure for spotinventory
-- ----------------------------
DROP TABLE IF EXISTS `spotinventory`;
CREATE TABLE `spotinventory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) DEFAULT NULL,
  `WarehouseId` int(11) DEFAULT NULL,
  `Qty` int(11) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `Currency` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of spotinventory
-- ----------------------------
INSERT INTO `spotinventory` VALUES ('2', '1', '1', '16', '2817.98315', 'RMB');
INSERT INTO `spotinventory` VALUES ('3', '2', '1', '18', '1650', 'RMB');

-- ----------------------------
-- Table structure for supplier
-- ----------------------------
DROP TABLE IF EXISTS `supplier`;
CREATE TABLE `supplier` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) DEFAULT NULL,
  `MobilePhone` varchar(20) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of supplier
-- ----------------------------
INSERT INTO `supplier` VALUES ('1', '王彦彩', '15010215094', '测试', '1', 'W001', '2018-06-30 10:25:54');
INSERT INTO `supplier` VALUES ('2', '李文文', '18264016038', '测试', '1', 'L001', '2018-06-30 10:48:06');

-- ----------------------------
-- Table structure for supplierproduct
-- ----------------------------
DROP TABLE IF EXISTS `supplierproduct`;
CREATE TABLE `supplierproduct` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `SupplierId` int(11) DEFAULT NULL,
  `ProductId` int(11) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of supplierproduct
-- ----------------------------

-- ----------------------------
-- Table structure for userdevice
-- ----------------------------
DROP TABLE IF EXISTS `userdevice`;
CREATE TABLE `userdevice` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(10) DEFAULT NULL,
  `CreateTime` timestamp NULL DEFAULT NULL,
  `ActiveTime` timestamp NULL DEFAULT NULL,
  `ExpiredTime` timestamp NULL DEFAULT NULL,
  `DeviceType` varchar(10) DEFAULT NULL,
  `SessionKey` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2957441 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of userdevice
-- ----------------------------
INSERT INTO `userdevice` VALUES ('2957424', 'W006', '2019-09-10 00:03:23', '2019-09-10 00:03:23', '2019-09-10 00:37:43', 'win', 'CHGo1NQavQcUJUXa8PruiBwPWU3XIofvY0aUnFDW0Jvo9LG/ngjpXOD0SPg3Rpv4');
INSERT INTO `userdevice` VALUES ('2957425', 'W003', '2019-10-17 10:27:46', '2019-10-17 10:27:46', '2019-10-17 10:58:46', 'win', 'AeObgNIzghEc7+w2LkowbYrVeC4DYiHOvAJfvTZ7Dq7dWbBnEdK+uvafD0WHGC2E');
INSERT INTO `userdevice` VALUES ('2957426', 'W003', '2019-10-17 10:31:10', '2019-10-17 10:31:10', '2019-10-17 11:03:26', 'win', 'AeObgNIzghEIDLy/4BKbfIC116kvda1k3ew0N4po3MLRHD5ZlfLdLkHcbkZ0JvQq');
INSERT INTO `userdevice` VALUES ('2957427', 'W003', '2019-10-17 13:54:14', '2019-10-17 13:54:14', '2019-10-17 15:05:58', 'win', 'AeObgNIzghGwyFuQUzDlpkNU9rIz/NF0QHpsqm5Yo/U5l6DdlnGdgdWslsgQ1JfE');
INSERT INTO `userdevice` VALUES ('2957428', 'W003', '2019-10-17 14:51:09', '2019-10-17 14:51:09', '2019-10-17 15:27:47', 'win', 'AeObgNIzghE13GZku+hH2kU25GnDuu64pJ0InVnc95S17tyays/LcxsNB3WT3Z/1');
INSERT INTO `userdevice` VALUES ('2957429', 'W003', '2019-10-17 15:45:39', '2019-10-17 15:45:39', '2019-10-17 16:33:58', 'win', 'AeObgNIzghGlohOXQUWN19yci1jRPMc5w2tE4WzdTuv6YtNZgAQkJrdpj2mpXAP6');
INSERT INTO `userdevice` VALUES ('2957430', 'W003', '2019-10-17 17:55:11', '2019-10-17 17:55:11', '2019-10-17 18:28:42', 'win', 'AeObgNIzghHx00FquJ+XIe7EvWdrXYs38wW1W+mXr0wI0M9d/NDQ8otdgPnQKiFE');
INSERT INTO `userdevice` VALUES ('2957431', 'W003', '2019-10-17 19:16:31', '2019-10-17 19:16:31', '2019-10-17 20:00:46', 'win', 'AeObgNIzghGRJyjqDQq4ro2BIP55aFgFKMzTxygWM2MO7gRvaPFaBASIQo98lO1x');
INSERT INTO `userdevice` VALUES ('2957432', 'W003', '2019-10-18 12:12:37', '2019-10-18 12:12:37', '2019-10-18 12:45:18', 'win', 'AeObgNIzghGwRywb2+0IV4pT4a3OkehikyJSVRH0l0QNy4l9gpIsVuy2MDTgd9gQ');
INSERT INTO `userdevice` VALUES ('2957433', 'W003', '2019-10-19 11:03:27', '2019-10-19 11:03:27', '2019-10-19 11:33:35', 'win', 'AeObgNIzghG7epqqku2Ks4WirsLWX65/l/yEyvpdn7z083oW4Dz0amLSRuGb3mu4');
INSERT INTO `userdevice` VALUES ('2957434', 'W006', '2020-01-27 11:20:53', '2020-01-27 11:20:53', '2020-01-27 11:50:54', 'win', 'CHGo1NQavQfUzcHfDMG5A5YKGl2FDOLjvi4K29dKjbh5lWWuFLJOi3iYE9ijgCpR');
INSERT INTO `userdevice` VALUES ('2957435', 'W006', '2020-01-27 13:53:55', '2020-01-27 13:53:55', '2020-01-27 14:23:56', 'win', 'CHGo1NQavQdF288Mpgy3lYh9MTvxyf9tlQXFr/O48/ehoEAx9sizFoj5YJJiowNu');
INSERT INTO `userdevice` VALUES ('2957436', 'W006', '2020-01-30 12:53:00', '2020-01-30 12:53:00', '2020-01-30 13:40:26', 'win', 'CHGo1NQavQe+YzTPDCzBpLcamp7ZOZ5rDyOzcgVhYF1sQZJ3Wq8XVZpu9SX4fXn3');
INSERT INTO `userdevice` VALUES ('2957437', 'W006', '2020-01-30 13:02:33', '2020-01-30 13:02:33', '2020-01-30 13:40:26', 'win', 'CHGo1NQavQf84aV7BlTARNz7eep6RreCNY4srOAvQXZ8iFhDQdANCDlDI4wYH6of');
INSERT INTO `userdevice` VALUES ('2957438', 'W006', '2020-01-30 13:41:10', '2020-01-30 13:41:10', '2020-01-30 14:11:10', 'win', 'CHGo1NQavQfxzpKTRltV/6Bfe2h1qD9q2MSTw3I6HlOUB+rFJ8pPGpD5nYnhnwTJ');
INSERT INTO `userdevice` VALUES ('2957439', 'W006', '2020-01-30 13:41:16', '2020-01-30 13:41:16', '2020-01-30 14:11:36', 'win', 'CHGo1NQavQe9Bet80Wx7Xrqu1qmSlbZ840YaaOOYunal8gAG4T4QCg02MAag/q1p');
INSERT INTO `userdevice` VALUES ('2957440', 'W003', '2020-03-04 16:25:42', '2020-03-04 16:25:42', '2020-03-04 16:55:43', 'win', 'AeObgNIzghFk5qWRtMn3Cy6iVhrhfSVY1L0d5yrysCGdJktNn2uJRONRVyKBlTLK');

-- ----------------------------
-- Table structure for userlevel
-- ----------------------------
DROP TABLE IF EXISTS `userlevel`;
CREATE TABLE `userlevel` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(20) DEFAULT NULL,
  `UserWorkTypeId` int(11) DEFAULT NULL,
  `LaborCost` double DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of userlevel
-- ----------------------------

-- ----------------------------
-- Table structure for userrole
-- ----------------------------
DROP TABLE IF EXISTS `userrole`;
CREATE TABLE `userrole` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` varchar(20) DEFAULT NULL,
  `RoleID` varchar(20) DEFAULT NULL,
  `UserRoleNote` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of userrole
-- ----------------------------
INSERT INTO `userrole` VALUES ('9', 'W003', '20', null, '2019-03-31 22:14:48');
INSERT INTO `userrole` VALUES ('10', 'W005', '20', null, '2019-03-31 22:16:05');
INSERT INTO `userrole` VALUES ('11', 'W003', '20', null, '2019-03-31 22:20:45');
INSERT INTO `userrole` VALUES ('16', 'W006', '20', null, null);

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `UserID` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserName` varchar(20) DEFAULT NULL,
  `UserPwd` varchar(20) DEFAULT NULL,
  `LastSignTime` timestamp NULL DEFAULT NULL,
  `SignState` int(11) DEFAULT NULL,
  `TickeID` varchar(20) DEFAULT NULL,
  `Telephone` varchar(20) DEFAULT NULL,
  `OrganizationId` int(11) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES ('1001', '111', '111111', null, '1', null, '111', '1', '2018-12-09 16:01:00');
INSERT INTO `users` VALUES ('101', '123', '111111', null, '0', null, '123', null, '2019-03-27 17:28:32');
INSERT INTO `users` VALUES ('2001', '222', '111111', null, '1', null, '222', '20', '2018-12-09 16:01:00');
INSERT INTO `users` VALUES ('a001', 'asdf', '111111', null, '1', null, 'asdf', '35', '2018-12-09 16:01:00');
INSERT INTO `users` VALUES ('d001', 'ddd', '111111', null, '1', null, 'ddd', '35', '2018-12-09 16:01:00');
INSERT INTO `users` VALUES ('L002', '李文文', '111111', null, '1', null, '123123', '21', '2018-12-09 16:01:00');
INSERT INTO `users` VALUES ('N001', '你好', '111111', '2018-12-08 17:26:21', '1', null, '你好', '4', '2018-12-09 16:01:00');
INSERT INTO `users` VALUES ('W001', '王彦彩', 'liwenwen851126', null, '1', null, '15010215094', '1', '2018-12-09 16:01:00');
INSERT INTO `users` VALUES ('W002', '嗡嗡嗡', '111111', null, '1', null, '威威', '9', '2018-12-09 16:01:00');
INSERT INTO `users` VALUES ('W003', '王彦彩', '111111', null, '1', null, '15010215094', null, '2018-12-09 16:01:00');
INSERT INTO `users` VALUES ('W004', '王明', '111111', null, '0', null, '15012015093', null, '2019-03-21 11:06:06');
INSERT INTO `users` VALUES ('W005', '王彦彩', '111111', null, '0', null, '15010215093', null, '2019-03-27 17:48:14');
INSERT INTO `users` VALUES ('W006', '王明', '111111', null, '1', null, '15010210598', null, '2019-03-27 22:46:55');
INSERT INTO `users` VALUES ('WYC001', '王彦彩', 'liwenwen851126', null, '0', null, '15010215094', '1', '2018-12-09 16:01:00');
INSERT INTO `users` VALUES ('Y001', '王彦彩', 'liwenwen851126', null, '0', null, '15010215094', '1', '2018-12-09 16:01:00');

-- ----------------------------
-- Table structure for userworktype
-- ----------------------------
DROP TABLE IF EXISTS `userworktype`;
CREATE TABLE `userworktype` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Description` varchar(20) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of userworktype
-- ----------------------------

-- ----------------------------
-- Table structure for waitarrival
-- ----------------------------
DROP TABLE IF EXISTS `waitarrival`;
CREATE TABLE `waitarrival` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `PurchaseOrderDetailId` int(11) DEFAULT NULL,
  `ProductId` int(11) DEFAULT NULL,
  `Qty` int(11) DEFAULT NULL,
  `ArrivalQty` int(11) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of waitarrival
-- ----------------------------

-- ----------------------------
-- Table structure for warehouse
-- ----------------------------
DROP TABLE IF EXISTS `warehouse`;
CREATE TABLE `warehouse` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `WarehouseTypeId` int(11) DEFAULT NULL,
  `IsValid` tinyint(4) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of warehouse
-- ----------------------------
INSERT INTO `warehouse` VALUES ('1', '第一库房', '第一库房', '1', '1', '2018-06-03 12:17:27');
INSERT INTO `warehouse` VALUES ('2', '第二库房', '第二库房', '1', '1', '2018-06-03 12:17:42');

-- ----------------------------
-- Table structure for warehouseshelf
-- ----------------------------
DROP TABLE IF EXISTS `warehouseshelf`;
CREATE TABLE `warehouseshelf` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) DEFAULT NULL,
  `Capacity` int(11) DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `WarehouseId` int(11) DEFAULT NULL,
  `CreateDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of warehouseshelf
-- ----------------------------
INSERT INTO `warehouseshelf` VALUES ('1', '货架一', '100', '货架一', '1', '2017-11-24 23:33:40');
INSERT INTO `warehouseshelf` VALUES ('2', '货架二', '100', '货架二', '1', '2017-11-24 23:33:40');
INSERT INTO `warehouseshelf` VALUES ('5', '货架三', '100', '货架三', '1', '2017-11-26 22:09:35');
INSERT INTO `warehouseshelf` VALUES ('6', '货架四', '100', '货架四', '1', '2017-11-26 22:10:08');

-- ----------------------------
-- Table structure for workflowactivity
-- ----------------------------
DROP TABLE IF EXISTS `workflowactivity`;
CREATE TABLE `workflowactivity` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ObjectId` varchar(50) DEFAULT NULL,
  `ObjectTypeId` varchar(20) DEFAULT NULL,
  `WorkflowNodeId` varchar(20) DEFAULT NULL,
  `StartTime` timestamp NULL DEFAULT NULL,
  `Note` varchar(200) DEFAULT NULL,
  `EndTime` timestamp NULL DEFAULT NULL,
  `CreateUserId` varchar(20) DEFAULT NULL,
  `ParentId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `indexName` (`ObjectId`),
  KEY `workflowactivity_WorkflowNodeId` (`WorkflowNodeId`),
  KEY `workflowactivity_ObjectId` (`ObjectId`)
) ENGINE=InnoDB AUTO_INCREMENT=246 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of workflowactivity
-- ----------------------------
INSERT INTO `workflowactivity` VALUES ('240', 'PO-20190908-001', 'PurchaseOrder', 'PO-010', '2019-09-08 22:46:59', null, '2019-09-08 22:47:12', 'W006', null);
INSERT INTO `workflowactivity` VALUES ('241', 'PO-20190908-001', 'PurchaseOrder', 'PO-020', '2019-09-08 22:47:12', null, '2019-09-08 22:47:19', 'W006', '240');
INSERT INTO `workflowactivity` VALUES ('242', 'PO-20190908-001', 'PurchaseOrder', 'PO-030', '2019-09-08 22:47:19', null, null, 'W006', '241');
INSERT INTO `workflowactivity` VALUES ('243', 'PO-20200130-001', 'PurchaseOrder', 'PO-010', '2020-01-30 12:58:08', null, '2020-01-30 12:58:40', 'W006', null);
INSERT INTO `workflowactivity` VALUES ('244', 'PO-20200130-001', 'PurchaseOrder', 'PO-020', '2020-01-30 12:58:40', null, '2020-01-30 12:59:02', 'W006', '243');
INSERT INTO `workflowactivity` VALUES ('245', 'PO-20200130-001', 'PurchaseOrder', 'PO-030', '2020-01-30 12:59:02', null, null, 'W006', '244');

-- ----------------------------
-- Table structure for workflowactivitynode
-- ----------------------------
DROP TABLE IF EXISTS `workflowactivitynode`;
CREATE TABLE `workflowactivitynode` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `StatusId` varchar(50) DEFAULT NULL,
  `StatusName` varchar(50) DEFAULT NULL,
  `StatusNote` varchar(200) DEFAULT NULL,
  `WorkFlowType` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of workflowactivitynode
-- ----------------------------
INSERT INTO `workflowactivitynode` VALUES ('1', 'PO-010', '待提交', '', 'Purchase');
INSERT INTO `workflowactivitynode` VALUES ('2', 'PO-020', '待审批', '', 'Purchase');
INSERT INTO `workflowactivitynode` VALUES ('3', 'PO-030', '待到货', '', 'Purchase');
INSERT INTO `workflowactivitynode` VALUES ('4', 'PO-040', '被驳回', '', 'Purchase');
INSERT INTO `workflowactivitynode` VALUES ('5', 'PO-050', '待付款', '', 'Purchase');
INSERT INTO `workflowactivitynode` VALUES ('6', 'PO-060', '已完结', '', 'Purchase');
INSERT INTO `workflowactivitynode` VALUES ('7', 'PO-000', '已撤销', null, 'Purchase');
