-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: p_dao
-- ------------------------------------------------------
-- Server version	5.7.17-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `device`
--

DROP TABLE IF EXISTS `device`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `device` (
  `device_id` int(11) NOT NULL AUTO_INCREMENT,
  `disability_id` int(11) NOT NULL,
  `dev_name` varchar(45) DEFAULT NULL COMMENT 'Required',
  `dev_desc` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`device_id`),
  KEY `device_disability_id_idx` (`disability_id`),
  CONSTRAINT `device_disability_id` FOREIGN KEY (`disability_id`) REFERENCES `disability` (`disability_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `device`
--

LOCK TABLES `device` WRITE;
/*!40000 ALTER TABLE `device` DISABLE KEYS */;
INSERT INTO `device` VALUES (1,3,'Hearing Aid',NULL),(2,4,'Braille',NULL),(3,4,'Eye Glasses',NULL),(4,7,'Crutches',NULL),(5,7,'Wheelchair',NULL),(6,7,'Walker',NULL),(7,7,'Prostesthesis',NULL);
/*!40000 ALTER TABLE `device` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `device_log`
--

DROP TABLE IF EXISTS `device_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `device_log` (
  `deviceLOG_id` int(11) NOT NULL AUTO_INCREMENT,
  `dp_id` int(11) NOT NULL,
  `pwd_id` int(11) NOT NULL,
  `device_id` int(11) NOT NULL,
  `req_date` date DEFAULT NULL,
  `req_desc` varchar(45) DEFAULT NULL,
  `req_emp_id` int(11) NOT NULL,
  `date_in` date DEFAULT NULL,
  `in_emp_id` int(11) DEFAULT NULL,
  `date_out` date DEFAULT NULL,
  `out_emp_id` int(11) DEFAULT NULL,
  `status` int(11) DEFAULT NULL COMMENT 'Requested\nRecieved\nHanded out',
  PRIMARY KEY (`deviceLOG_id`),
  KEY `dev_log_provider_id_idx` (`dp_id`),
  KEY `dev_log_pwd_id_idx` (`pwd_id`),
  KEY `dev_log_device_id_idx` (`device_id`),
  KEY `dev_log_req_id_idx` (`req_emp_id`),
  KEY `dev_log_in_id_idx` (`in_emp_id`),
  KEY `dev_log_out_id_idx` (`out_emp_id`),
  CONSTRAINT `dev_log_device_id` FOREIGN KEY (`device_id`) REFERENCES `device` (`device_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `dev_log_dp_id` FOREIGN KEY (`dp_id`) REFERENCES `device_provider` (`dp_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `dev_log_in_id` FOREIGN KEY (`in_emp_id`) REFERENCES `employee` (`employee_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `dev_log_out_id` FOREIGN KEY (`out_emp_id`) REFERENCES `employee` (`employee_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `dev_log_pwd_id` FOREIGN KEY (`pwd_id`) REFERENCES `pwd` (`pwd_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `dev_log_req_id` FOREIGN KEY (`req_emp_id`) REFERENCES `employee` (`employee_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `device_log`
--

LOCK TABLES `device_log` WRITE;
/*!40000 ALTER TABLE `device_log` DISABLE KEYS */;
/*!40000 ALTER TABLE `device_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `device_provider`
--

DROP TABLE IF EXISTS `device_provider`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `device_provider` (
  `dp_id` int(11) NOT NULL AUTO_INCREMENT,
  `dp_name` varchar(45) DEFAULT NULL COMMENT 'Required',
  `dp_desc` varchar(45) DEFAULT NULL,
  `dp_type` int(11) DEFAULT NULL COMMENT 'Required\n---------------\n0 - Government\n1 - Sponsor',
  `mobile_no` int(11) DEFAULT NULL,
  `tel_no` varchar(45) DEFAULT NULL,
  `email_add` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`dp_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `device_provider`
--

LOCK TABLES `device_provider` WRITE;
/*!40000 ALTER TABLE `device_provider` DISABLE KEYS */;
INSERT INTO `device_provider` VALUES (1,'Ateneo de Davao University','Can ask for donations.',1,0,'000000',NULL);
/*!40000 ALTER TABLE `device_provider` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `disability`
--

DROP TABLE IF EXISTS `disability`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `disability` (
  `disability_id` int(11) NOT NULL AUTO_INCREMENT,
  `disability_type` varchar(45) DEFAULT NULL COMMENT 'Required',
  `disability_desc` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`disability_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disability`
--

LOCK TABLES `disability` WRITE;
/*!40000 ALTER TABLE `disability` DISABLE KEYS */;
INSERT INTO `disability` VALUES (1,'Psychosocial',NULL),(2,'Mental',NULL),(3,'Hearing',NULL),(4,'Visual',NULL),(5,'Learning',NULL),(6,'Speech Impairment',NULL),(7,'Orthopedic','Musculoskeletal');
/*!40000 ALTER TABLE `disability` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employee` (
  `employee_id` int(11) NOT NULL AUTO_INCREMENT,
  `firstname` varchar(45) DEFAULT NULL COMMENT 'Required',
  `middlename` varchar(45) DEFAULT NULL,
  `lastname` varchar(45) DEFAULT NULL COMMENT 'Required',
  `address` varchar(100) DEFAULT NULL,
  `position` varchar(45) DEFAULT NULL COMMENT 'Required',
  `contact_no` int(11) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `status_id` int(11) DEFAULT '1' COMMENT 'Required\n------------\nActive\nInactive\nBreak',
  `username` varchar(45) NOT NULL COMMENT 'Required',
  `password` varchar(45) NOT NULL COMMENT 'Required',
  PRIMARY KEY (`employee_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,'K Ann','Quinones','Mina','Davao CIty','Admin',NULL,NULL,1,'admin','admin'),(2,'Coleen Pia','Galero','Larena','Davao City','Admin',NULL,NULL,1,'root','root'),(3,'Abigail Blanche','Aquino','Bangay','Davao City','Admin',NULL,NULL,0,'admin','admin');
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parental_info`
--

DROP TABLE IF EXISTS `parental_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parental_info` (
  `pwd_id` int(11) NOT NULL,
  `fatherfn` varchar(45) DEFAULT NULL,
  `fathermn` varchar(45) DEFAULT NULL,
  `fatherln` varchar(45) DEFAULT NULL,
  `motherfn` varchar(45) DEFAULT NULL,
  `mothermn` varchar(45) DEFAULT NULL,
  `motherln` varchar(45) DEFAULT NULL,
  `guardianfn` varchar(45) DEFAULT NULL,
  `guardianmn` varchar(45) DEFAULT NULL,
  `guardianln` varchar(45) DEFAULT NULL,
  KEY `parental_info_pwd_id_idx` (`pwd_id`),
  CONSTRAINT `parental_info_pwd_id` FOREIGN KEY (`pwd_id`) REFERENCES `pwd` (`pwd_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parental_info`
--

LOCK TABLES `parental_info` WRITE;
/*!40000 ALTER TABLE `parental_info` DISABLE KEYS */;
INSERT INTO `parental_info` VALUES (1,'Ricardo','Bayani','Mina','Marichu','Quinones','Mina','Jamie','Hernaez','Marianne'),(2,'Abigail','Aquino','Bangay','Abby','Aquino','Bangay','Food','Drinks','Sleep');
/*!40000 ALTER TABLE `parental_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project`
--

DROP TABLE IF EXISTS `project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `project` (
  `project_id` int(11) NOT NULL AUTO_INCREMENT,
  `employee_id` int(11) NOT NULL,
  `items_id` int(11) NOT NULL,
  `progress_id` int(11) NOT NULL,
  `project_title` varchar(45) DEFAULT NULL COMMENT 'Required',
  `project_desc` varchar(100) DEFAULT NULL,
  `start_time` datetime NOT NULL COMMENT 'Required',
  `end_time` datetime NOT NULL COMMENT 'Required',
  `date_proposed` date DEFAULT NULL COMMENT 'Required',
  `approved_by` varchar(45) DEFAULT NULL COMMENT 'Approved by higher-ups but database to be updated by the PDAO staff and not the higher authority.',
  `event_held` varchar(45) DEFAULT NULL,
  `budget` int(11) NOT NULL COMMENT 'Required\n-----------\ntotal cost can be determined through ''items'' table',
  `budget_desc` varchar(100) DEFAULT NULL,
  `isArchived` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`project_id`),
  KEY `project_emp_id_idx` (`employee_id`),
  KEY `project_items_id_idx` (`items_id`),
  KEY `project_progress_id_idx` (`progress_id`),
  CONSTRAINT `project_employee_id` FOREIGN KEY (`employee_id`) REFERENCES `employee` (`employee_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `project_items_id` FOREIGN KEY (`items_id`) REFERENCES `project_items` (`items_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `project_progress_id` FOREIGN KEY (`progress_id`) REFERENCES `project_progress` (`progress_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project`
--

LOCK TABLES `project` WRITE;
/*!40000 ALTER TABLE `project` DISABLE KEYS */;
/*!40000 ALTER TABLE `project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project_items`
--

DROP TABLE IF EXISTS `project_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `project_items` (
  `items_id` int(11) NOT NULL AUTO_INCREMENT,
  `project_id` int(11) NOT NULL,
  `item_name` varchar(45) DEFAULT NULL COMMENT 'Required',
  `item_desc` varchar(45) DEFAULT NULL,
  `cost` double DEFAULT NULL COMMENT 'Required',
  `quantity` int(11) DEFAULT '1' COMMENT 'Default 1',
  PRIMARY KEY (`items_id`),
  KEY `project_items_project_id_idx` (`project_id`),
  CONSTRAINT `project_items_project_id` FOREIGN KEY (`project_id`) REFERENCES `project` (`project_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project_items`
--

LOCK TABLES `project_items` WRITE;
/*!40000 ALTER TABLE `project_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `project_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project_persons`
--

DROP TABLE IF EXISTS `project_persons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `project_persons` (
  `personsIN_id` int(11) NOT NULL AUTO_INCREMENT,
  `project_id` int(11) NOT NULL,
  `pwd_id` int(11) NOT NULL,
  `attendance` tinyint(4) DEFAULT NULL COMMENT 'Required\n-----------\nIf the PWD attended the event or not.',
  PRIMARY KEY (`personsIN_id`),
  KEY `project_persons_project_id_idx` (`project_id`),
  KEY `project_persons_pwd_id_idx` (`pwd_id`),
  CONSTRAINT `project_persons_project_id` FOREIGN KEY (`project_id`) REFERENCES `project` (`project_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `project_persons_pwd_id` FOREIGN KEY (`pwd_id`) REFERENCES `pwd` (`pwd_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project_persons`
--

LOCK TABLES `project_persons` WRITE;
/*!40000 ALTER TABLE `project_persons` DISABLE KEYS */;
/*!40000 ALTER TABLE `project_persons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `project_progress`
--

DROP TABLE IF EXISTS `project_progress`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `project_progress` (
  `progress_id` int(11) NOT NULL AUTO_INCREMENT,
  `progress_type` varchar(45) DEFAULT NULL COMMENT 'Ongoing\nCacelled\nFinished',
  `datechanged` datetime DEFAULT NULL,
  PRIMARY KEY (`progress_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `project_progress`
--

LOCK TABLES `project_progress` WRITE;
/*!40000 ALTER TABLE `project_progress` DISABLE KEYS */;
/*!40000 ALTER TABLE `project_progress` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pwd`
--

DROP TABLE IF EXISTS `pwd`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pwd` (
  `pwd_id` int(11) NOT NULL AUTO_INCREMENT,
  `employee_id` int(11) DEFAULT NULL,
  `registration_no` int(11) DEFAULT NULL,
  `lastname` varchar(45) NOT NULL COMMENT 'Required',
  `firstname` varchar(45) NOT NULL COMMENT 'Required',
  `middlename` varchar(45) NOT NULL,
  `sex` int(11) NOT NULL COMMENT 'Required\n0 - Male\n1 - Female',
  `disability_id` int(11) NOT NULL,
  `address` varchar(100) NOT NULL COMMENT 'Required',
  `blood_type` varchar(3) DEFAULT NULL,
  `birthdate` varchar(50) DEFAULT NULL COMMENT 'Required',
  `picture` blob,
  `tel_no` int(11) DEFAULT NULL,
  `mobile_no` int(11) DEFAULT NULL,
  `email_add` varchar(45) DEFAULT NULL,
  `civil_status` int(11) DEFAULT NULL COMMENT 'Required',
  `nationality` varchar(45) DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  `added_date` date DEFAULT NULL,
  `application_date` varchar(50) NOT NULL COMMENT 'Required',
  `accomplished_by` varchar(45) DEFAULT NULL,
  `educ_attainment` int(11) DEFAULT NULL,
  `employment_status` int(11) DEFAULT NULL,
  `nature_of_employer` int(11) DEFAULT NULL,
  `type_of_skill` int(11) DEFAULT NULL,
  `status_pwd` int(11) DEFAULT NULL COMMENT 'Required\n-----------\n[Membership status]\nActive\nInactive/Expired',
  `isArchived` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`pwd_id`),
  KEY `pwd_employee_id_idx` (`employee_id`),
  CONSTRAINT `pwd_employee_id` FOREIGN KEY (`employee_id`) REFERENCES `employee` (`employee_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pwd`
--

LOCK TABLES `pwd` WRITE;
/*!40000 ALTER TABLE `pwd` DISABLE KEYS */;
INSERT INTO `pwd` VALUES (1,1,NULL,'Mina','K Ann','Quinones',1,4,'Davao City','A','1998-10-04',NULL,2823159,0,'secret@gmail.com',1,'Filipino',NULL,NULL,'2017-06-20','Marianne Hernaez',1,1,1,2,1,0),(2,2,NULL,'Bangay','Abigail Blanche','Aquino',1,6,'Davao City','B','1999-07-13',NULL,0,0,'food@gmail.com',2,'Filipino',NULL,NULL,'2017-06-20','Jamie Pie Fernandez',2,3,1,4,1,0);
/*!40000 ALTER TABLE `pwd` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pwd_emp_log`
--

DROP TABLE IF EXISTS `pwd_emp_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pwd_emp_log` (
  `emplog_id` int(11) NOT NULL AUTO_INCREMENT,
  `pwd_id` int(11) NOT NULL,
  `recent_emp_id` int(11) NOT NULL,
  `date_updated` datetime DEFAULT NULL,
  PRIMARY KEY (`emplog_id`),
  KEY `pwd_emp_log_pwd_id_idx` (`pwd_id`),
  KEY `pwd_emp_log_emp_id_idx` (`recent_emp_id`),
  CONSTRAINT `pwd_emp_log_emp_id` FOREIGN KEY (`recent_emp_id`) REFERENCES `employee` (`employee_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `pwd_emp_log_pwd_id` FOREIGN KEY (`pwd_id`) REFERENCES `pwd` (`pwd_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pwd_emp_log`
--

LOCK TABLES `pwd_emp_log` WRITE;
/*!40000 ALTER TABLE `pwd_emp_log` DISABLE KEYS */;
/*!40000 ALTER TABLE `pwd_emp_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pwd_otherinfo`
--

DROP TABLE IF EXISTS `pwd_otherinfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pwd_otherinfo` (
  `pwd_id` int(11) NOT NULL,
  `sss_no` int(11) DEFAULT NULL,
  `gsis_no` int(11) DEFAULT NULL,
  `phealth_no` int(11) DEFAULT NULL,
  `phealth_status` int(11) DEFAULT NULL,
  `organization_aff` varchar(45) DEFAULT NULL,
  `contact_person` varchar(45) DEFAULT NULL,
  `office_address` varchar(45) DEFAULT NULL,
  `tel_no` varchar(45) DEFAULT NULL,
  KEY `pwd_otherinfo_pwd_id_idx` (`pwd_id`),
  CONSTRAINT `pwd_otherinfo_pwd_id` FOREIGN KEY (`pwd_id`) REFERENCES `pwd` (`pwd_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pwd_otherinfo`
--

LOCK TABLES `pwd_otherinfo` WRITE;
/*!40000 ALTER TABLE `pwd_otherinfo` DISABLE KEYS */;
/*!40000 ALTER TABLE `pwd_otherinfo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `renew_pwd`
--

DROP TABLE IF EXISTS `renew_pwd`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `renew_pwd` (
  `renewPWD_id` int(11) NOT NULL AUTO_INCREMENT,
  `pwd_id` int(11) NOT NULL,
  `end_date` date NOT NULL,
  `daterenewed` date DEFAULT NULL COMMENT 'Required',
  `dcertificate` tinyint(4) DEFAULT NULL COMMENT 'Required',
  `other_req` tinyint(4) DEFAULT NULL COMMENT 'Required',
  `attachments` blob,
  `is_resolved` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`renewPWD_id`),
  KEY `renew_pwd_id_idx` (`pwd_id`),
  KEY `renew_end_date_idx` (`end_date`),
  CONSTRAINT `renew_pwd_pwd_id` FOREIGN KEY (`pwd_id`) REFERENCES `pwd` (`pwd_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `renew_pwd`
--

LOCK TABLES `renew_pwd` WRITE;
/*!40000 ALTER TABLE `renew_pwd` DISABLE KEYS */;
/*!40000 ALTER TABLE `renew_pwd` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-07-09  8:50:01
