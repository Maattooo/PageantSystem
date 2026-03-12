-- MariaDB dump 10.19  Distrib 10.4.32-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: pageant
-- ------------------------------------------------------
-- Server version	10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `contestants`
--

DROP TABLE IF EXISTS `contestants`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contestants` (
  `Contestant_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Contestant_Number` int(11) DEFAULT NULL,
  `Full_Name` varchar(100) NOT NULL,
  `Gender_ID` int(11) NOT NULL,
  `Program_ID` int(11) NOT NULL,
  `Picture` longblob DEFAULT NULL,
  PRIMARY KEY (`Contestant_ID`),
  KEY `4` (`Gender_ID`),
  KEY `5` (`Program_ID`),
  CONSTRAINT `4` FOREIGN KEY (`Gender_ID`) REFERENCES `gender` (`Gender_ID`),
  CONSTRAINT `5` FOREIGN KEY (`Program_ID`) REFERENCES `programs` (`Program_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `criteria`
--

DROP TABLE IF EXISTS `criteria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `criteria` (
  `Criteria_ID` int(100) NOT NULL AUTO_INCREMENT,
  `Criteria_Name` varchar(100) NOT NULL,
  PRIMARY KEY (`Criteria_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `departments`
--

DROP TABLE IF EXISTS `departments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departments` (
  `Department_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Department_Name` varchar(100) NOT NULL,
  PRIMARY KEY (`Department_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `gender`
--

DROP TABLE IF EXISTS `gender`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gender` (
  `Gender_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Gender_Name` varchar(100) NOT NULL,
  PRIMARY KEY (`Gender_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `judges`
--

DROP TABLE IF EXISTS `judges`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `judges` (
  `Judge_ID` int(100) NOT NULL AUTO_INCREMENT,
  `Full_Name` varchar(100) NOT NULL,
  `Password` int(11) NOT NULL,
  `Gender_ID` int(100) NOT NULL,
  PRIMARY KEY (`Judge_ID`),
  KEY `10` (`Gender_ID`),
  CONSTRAINT `10` FOREIGN KEY (`Gender_ID`) REFERENCES `gender` (`Gender_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `programs`
--

DROP TABLE IF EXISTS `programs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `programs` (
  `Program_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Program_Name` varchar(100) NOT NULL,
  `Department_ID` int(11) NOT NULL,
  PRIMARY KEY (`Program_ID`),
  KEY `6` (`Department_ID`),
  CONSTRAINT `6` FOREIGN KEY (`Department_ID`) REFERENCES `departments` (`Department_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `scores`
--

DROP TABLE IF EXISTS `scores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `scores` (
  `Score_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Contestant_ID` int(11) NOT NULL,
  `Judge_ID` int(11) NOT NULL,
  `Score` int(11) NOT NULL,
  `Criteria_ID` int(11) NOT NULL,
  `SubCriteria_ID` int(11) DEFAULT NULL,
  PRIMARY KEY (`Score_ID`),
  KEY `1` (`Contestant_ID`),
  KEY `3` (`Judge_ID`),
  KEY `7` (`Criteria_ID`),
  KEY `9` (`SubCriteria_ID`),
  CONSTRAINT `1` FOREIGN KEY (`Contestant_ID`) REFERENCES `contestants` (`Contestant_ID`),
  CONSTRAINT `3` FOREIGN KEY (`Judge_ID`) REFERENCES `judges` (`Judge_ID`),
  CONSTRAINT `7` FOREIGN KEY (`Criteria_ID`) REFERENCES `criteria` (`Criteria_ID`),
  CONSTRAINT `9` FOREIGN KEY (`SubCriteria_ID`) REFERENCES `subcriteria` (`SubCriteria_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=254 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `subcriteria`
--

DROP TABLE IF EXISTS `subcriteria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subcriteria` (
  `SubCriteria_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Criteria_ID` int(11) NOT NULL,
  `SubCriteria_Name` varchar(100) NOT NULL,
  `Min_Score` decimal(5,2) NOT NULL,
  `Max_Score` decimal(5,2) NOT NULL,
  PRIMARY KEY (`SubCriteria_ID`),
  KEY `8` (`Criteria_ID`),
  CONSTRAINT `8` FOREIGN KEY (`Criteria_ID`) REFERENCES `criteria` (`Criteria_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-03-12 20:24:42
