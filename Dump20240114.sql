-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: quanlychuyenbay
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `chuyenbay`
--

DROP TABLE IF EXISTS `chuyenbay`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `chuyenbay` (
  `MACH` varchar(10) NOT NULL,
  `CHUYEN` varchar(255) DEFAULT NULL,
  `DDI` varchar(255) DEFAULT NULL,
  `DDEN` varchar(255) DEFAULT NULL,
  `NGAY` varchar(20) DEFAULT NULL,
  `GBAY` varchar(20) DEFAULT NULL,
  `GDEN` varchar(20) DEFAULT NULL,
  `THUONG` int DEFAULT NULL,
  `VIP` int DEFAULT NULL,
  `MAMB` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`MACH`),
  KEY `MAMB` (`MAMB`),
  CONSTRAINT `chuyenbay_ibfk_1` FOREIGN KEY (`MAMB`) REFERENCES `maybay` (`MAMB`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chuyenbay`
--

LOCK TABLES `chuyenbay` WRITE;
/*!40000 ALTER TABLE `chuyenbay` DISABLE KEYS */;
INSERT INTO `chuyenbay` VALUES ('CB001','SG_HN','SG','HN','2024-01-01','08:00','10:00',100,20,'MB001'),('CB002','HN_DN','HN','DN','2024-01-02','12:00','14:00',120,30,'MB002'),('CB003','DN_SG','DN','SG','2024-01-03','16:00','18:00',80,15,'MB003'),('CB004','SG_HCM','SG','HCM','2024-01-04','20:00','22:00',130,25,'MB004'),('CB005','HCM_HN','HCM','HN','2024-01-05','09:00','11:00',110,18,'MB005'),('CB006','HN_DAD','HN','DAD','2024-01-06','14:00','16:00',95,22,'MB006'),('CB007','DAD_HCM','DAD','HCM','2024-01-07','18:00','20:00',160,28,'MB007'),('CB008','HCM_SG','HCM','SG','2024-01-08','22:00','00:00',140,23,'MB008'),('CB009','SG_DN','SG','DN','2024-01-09','11:00','13:00',75,12,'MB009'),('CB010','DN_HN','DN','HN','2024-01-10','15:00','17:00',105,19,'MB010');
/*!40000 ALTER TABLE `chuyenbay` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ct_cb`
--

DROP TABLE IF EXISTS `ct_cb`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ct_cb` (
  `MACH` varchar(10) NOT NULL,
  `MAHK` varchar(10) NOT NULL,
  `SOGHE` varchar(5) DEFAULT NULL,
  `LOAIGHE` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`MACH`,`MAHK`),
  KEY `MAHK` (`MAHK`),
  CONSTRAINT `ct_cb_ibfk_1` FOREIGN KEY (`MACH`) REFERENCES `chuyenbay` (`MACH`),
  CONSTRAINT `ct_cb_ibfk_2` FOREIGN KEY (`MAHK`) REFERENCES `hanhkhach` (`MAHK`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ct_cb`
--

LOCK TABLES `ct_cb` WRITE;
/*!40000 ALTER TABLE `ct_cb` DISABLE KEYS */;
INSERT INTO `ct_cb` VALUES ('CB001','HK001','22A',1),('CB001','HK002','27C',1),('CB001','HK005','36C',0),('CB002','HK001','30C',1),('CB002','HK003','30B',0),('CB002','HK004','32D',1),('CB002','HK005','30C',1),('CB003','HK001','30C',1),('CB003','HK003','30C',1),('CB003','HK005','18A',0),('CB003','HK006','20C',1),('CB004','HK007','40B',0),('CB004','HK008','42D',1),('CB005','HK009','15A',0),('CB005','HK010','17C',1);
/*!40000 ALTER TABLE `ct_cb` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hanhkhach`
--

DROP TABLE IF EXISTS `hanhkhach`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hanhkhach` (
  `MAHK` varchar(10) NOT NULL,
  `HOTEN` varchar(255) DEFAULT NULL,
  `DIACHI` varchar(255) DEFAULT NULL,
  `DIENTHOAI` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`MAHK`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hanhkhach`
--

LOCK TABLES `hanhkhach` WRITE;
/*!40000 ALTER TABLE `hanhkhach` DISABLE KEYS */;
INSERT INTO `hanhkhach` VALUES ('HK001','Nguyen Van A','123 ABC Street','123456789'),('HK002','Tran Thi B','456 XYZ Street','987654321'),('HK003','Le Van C','789 DEF Street','111222333'),('HK004','Pham Thi D','321 GHI Street','444555666'),('HK005','Tran Van E','654 JKL Street','777888999'),('HK006','Nguyen Thi F','987 MNO Street','000111222'),('HK007','Le Van G','135 PQR Street','333444555'),('HK008','Do Thi H','246 STU Street','666777888'),('HK009','Tran Van I','789 VWX Street','999000111'),('HK010','Pham Van J','012 YZ Street','222333444'),('HK11',NULL,'BBBBBBBB',NULL),('HK12','AAAAAAAA','BBBBBBBB','1111111');
/*!40000 ALTER TABLE `hanhkhach` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `maybay`
--

DROP TABLE IF EXISTS `maybay`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `maybay` (
  `MAMB` varchar(10) NOT NULL,
  `HANGMB` varchar(255) DEFAULT NULL,
  `SOCHO` int DEFAULT NULL,
  PRIMARY KEY (`MAMB`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `maybay`
--

LOCK TABLES `maybay` WRITE;
/*!40000 ALTER TABLE `maybay` DISABLE KEYS */;
INSERT INTO `maybay` VALUES ('MB001','Vietnam Airlines',150),('MB002','VietJet Air',200),('MB003','Bamboo Airways',180),('MB004','Jetstar Pacific',170),('MB005','Singapore Airlines',250),('MB006','Cathay Pacific',220),('MB007','Qatar Airways',190),('MB008','Emirates',210),('MB009','Thai Airways',230),('MB010','Air Asia',160);
/*!40000 ALTER TABLE `maybay` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-14 16:30:24
