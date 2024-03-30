/*
SQLyog Ultimate v8.55 
MySQL - 5.5.25a : Database - blacklotus
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`blacklotus` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `blacklotus`;

/*Table structure for table `category` */

DROP TABLE IF EXISTS `category`;

CREATE TABLE `category` (
  `category` varchar(20) DEFAULT NULL,
  `cat_id` int(6) NOT NULL AUTO_INCREMENT,
  UNIQUE KEY `cat_id` (`cat_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `category` */

insert  into `category`(`category`,`cat_id`) values ('cat 2',2),('cat 3',3),('test 1',4);

/*Table structure for table `customer` */

DROP TABLE IF EXISTS `customer`;

CREATE TABLE `customer` (
  `CID` int(6) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) DEFAULT NULL,
  `tp` int(10) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `addr` varchar(40) DEFAULT NULL,
  UNIQUE KEY `CID` (`CID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `customer` */

insert  into `customer`(`CID`,`name`,`tp`,`email`,`addr`) values (1,'test 1',1234567890,'test1@gmail.com','sadg hdkb sdkhbds 122'),(2,'ikabd',1122334455,'cxv@gmail.com','wefv xd 345');

/*Table structure for table `flowers` */

DROP TABLE IF EXISTS `flowers`;

CREATE TABLE `flowers` (
  `FID` int(6) NOT NULL AUTO_INCREMENT,
  `category` varchar(20) DEFAULT NULL,
  `name` varchar(20) DEFAULT NULL,
  `qunt` int(4) DEFAULT NULL,
  `ppu` float DEFAULT NULL,
  UNIQUE KEY `FID` (`FID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `flowers` */

insert  into `flowers`(`FID`,`category`,`name`,`qunt`,`ppu`) values (2,'cat 2','test2 flower',45,100),(3,'cat 3','test3 flower',10,350),(4,'cat 2','test4 flower',15,200),(5,'cat 3','test 5',35,150),(6,'test 1','test6 flower',40,160),(7,'cat 2','test 7 flower',10,140);

/*Table structure for table `login` */

DROP TABLE IF EXISTS `login`;

CREATE TABLE `login` (
  `LID` int(6) NOT NULL AUTO_INCREMENT,
  `user` varchar(12) DEFAULT NULL,
  `pass` varchar(12) DEFAULT NULL,
  `level` int(1) DEFAULT NULL,
  UNIQUE KEY `LID` (`LID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `login` */

insert  into `login`(`LID`,`user`,`pass`,`level`) values (1,'admin','1234',0),(2,'user1','1111',1),(3,'user2','1234',1);

/*Table structure for table `purches` */

DROP TABLE IF EXISTS `purches`;

CREATE TABLE `purches` (
  `sellID` int(6) NOT NULL AUTO_INCREMENT,
  `cid` int(6) DEFAULT NULL,
  `c_name` varchar(30) DEFAULT NULL,
  `c_tp` int(10) DEFAULT NULL,
  `c_addr` varchar(40) DEFAULT NULL,
  `FID` int(6) DEFAULT NULL,
  `f_cat` varchar(20) DEFAULT NULL,
  `f_name` varchar(20) DEFAULT NULL,
  `qunt` int(5) DEFAULT NULL,
  `tot` float DEFAULT NULL,
  UNIQUE KEY `sellID` (`sellID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `purches` */

/*Table structure for table `salesman` */

DROP TABLE IF EXISTS `salesman`;

CREATE TABLE `salesman` (
  `salesmanID` int(6) NOT NULL AUTO_INCREMENT,
  `name` varchar(20) DEFAULT NULL,
  `tp` int(10) DEFAULT NULL,
  `age` int(2) DEFAULT NULL,
  `addr` varchar(40) DEFAULT NULL,
  UNIQUE KEY `salesmanID` (`salesmanID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `salesman` */

insert  into `salesman`(`salesmanID`,`name`,`tp`,`age`,`addr`) values (1,'test 1',1234567890,25,'gfaszs hidf hiasf asf haesf'),(2,'user2',1111111111,22,'dshdik dsoldgb lsdsd');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
