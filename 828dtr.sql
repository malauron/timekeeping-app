/*
SQLyog Ultimate v12.09 (64 bit)
MySQL - 10.1.32-MariaDB : Database - 828dtr
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`828dtr` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_general_ci */;

USE `828dtr`;

/*Table structure for table `company_violations` */

DROP TABLE IF EXISTS `company_violations`;

CREATE TABLE `company_violations` (
  `violation_id` int(11) NOT NULL AUTO_INCREMENT,
  `violation_code` varchar(20) COLLATE latin1_general_ci DEFAULT NULL,
  `violation_description` text COLLATE latin1_general_ci,
  PRIMARY KEY (`violation_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `cutoff_periods` */

DROP TABLE IF EXISTS `cutoff_periods`;

CREATE TABLE `cutoff_periods` (
  `cutoff_period_id` int(11) NOT NULL AUTO_INCREMENT,
  `start_date` date DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  PRIMARY KEY (`cutoff_period_id`)
) ENGINE=InnoDB AUTO_INCREMENT=263 DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `departments` */

DROP TABLE IF EXISTS `departments`;

CREATE TABLE `departments` (
  `department_id` int(11) NOT NULL,
  `Description` varchar(100) COLLATE latin1_general_ci DEFAULT NULL,
  PRIMARY KEY (`department_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `dtr_summary` */

DROP TABLE IF EXISTS `dtr_summary`;

CREATE TABLE `dtr_summary` (
  `employee_id` int(11) NOT NULL,
  `work_date` date NOT NULL,
  `days_wrkd` double DEFAULT '0',
  `days_absent` double DEFAULT '0',
  `hrs_wrkd` double DEFAULT '0',
  `late` decimal(18,5) DEFAULT '0.00000',
  `undertime` decimal(18,5) DEFAULT '0.00000',
  `reg_holiday` double DEFAULT '0',
  `spc_holiday` double DEFAULT '0',
  PRIMARY KEY (`employee_id`,`work_date`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `educationbackground` */

DROP TABLE IF EXISTS `educationbackground`;

CREATE TABLE `educationbackground` (
  `employeecode` int(11) DEFAULT NULL,
  `line_no` int(11) DEFAULT NULL,
  `school_name` varchar(50) COLLATE latin1_general_ci DEFAULT NULL,
  `datestarted` date DEFAULT NULL,
  `dategraduate` date DEFAULT NULL,
  `degree` varchar(20) COLLATE latin1_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `employee_dtr_adjustments` */

DROP TABLE IF EXISTS `employee_dtr_adjustments`;

CREATE TABLE `employee_dtr_adjustments` (
  `employee_id` int(11) NOT NULL,
  `work_date` date NOT NULL,
  `log1` datetime DEFAULT NULL,
  `log2` datetime DEFAULT NULL,
  `log3` datetime DEFAULT NULL,
  `log4` datetime DEFAULT NULL,
  `log5` datetime DEFAULT NULL,
  `log6` datetime DEFAULT NULL,
  PRIMARY KEY (`employee_id`,`work_date`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `employee_dtrs` */

DROP TABLE IF EXISTS `employee_dtrs`;

CREATE TABLE `employee_dtrs` (
  `employee_id` int(11) NOT NULL,
  `work_date` date NOT NULL,
  `log1` datetime DEFAULT NULL,
  `log2` datetime DEFAULT NULL,
  `log3` datetime DEFAULT NULL,
  `log4` datetime DEFAULT NULL,
  `log5` datetime DEFAULT NULL,
  `log6` datetime DEFAULT NULL,
  PRIMARY KEY (`employee_id`,`work_date`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `employee_fingerprints` */

DROP TABLE IF EXISTS `employee_fingerprints`;

CREATE TABLE `employee_fingerprints` (
  `employee_id` int(11) NOT NULL,
  `finger_position` int(11) DEFAULT '8',
  `file_size` mediumint(9) NOT NULL,
  `file` mediumblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `employee_logs` */

DROP TABLE IF EXISTS `employee_logs`;

CREATE TABLE `employee_logs` (
  `employee_id` int(11) DEFAULT NULL,
  `employee_bio_id` varchar(30) COLLATE latin1_general_ci NOT NULL,
  `datetime_log` datetime NOT NULL,
  `log_status` int(1) DEFAULT '1',
  `is_edited` varchar(1) COLLATE latin1_general_ci DEFAULT 'N',
  PRIMARY KEY (`employee_bio_id`,`datetime_log`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `employee_offenses` */

DROP TABLE IF EXISTS `employee_offenses`;

CREATE TABLE `employee_offenses` (
  `offense_id` int(11) NOT NULL AUTO_INCREMENT,
  `employeecode` int(11) DEFAULT NULL,
  `costcentercode` int(11) DEFAULT NULL,
  `date_nte_issued` date DEFAULT NULL,
  `date_incident` date DEFAULT NULL,
  `time_incident` time DEFAULT NULL,
  `place_incident` varchar(50) COLLATE latin1_general_ci DEFAULT NULL,
  `offense_commited` text COLLATE latin1_general_ci,
  `rules_violated` text COLLATE latin1_general_ci,
  `date_da_issued` date DEFAULT NULL,
  `disc_action` enum('WARNING','SUSPENSION','CLEARED') COLLATE latin1_general_ci DEFAULT NULL,
  `warning_type` enum('VERBAL','WRITTEN','FINAL') COLLATE latin1_general_ci DEFAULT NULL,
  `suspension_start` date DEFAULT NULL,
  `suspension_end` date DEFAULT NULL,
  `total_days` int(11) DEFAULT NULL,
  PRIMARY KEY (`offense_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `employee_pictures` */

DROP TABLE IF EXISTS `employee_pictures`;

CREATE TABLE `employee_pictures` (
  `employee_id` int(11) NOT NULL,
  `file_size` mediumint(9) NOT NULL,
  `file` mediumblob NOT NULL,
  PRIMARY KEY (`employee_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `employee_signatures` */

DROP TABLE IF EXISTS `employee_signatures`;

CREATE TABLE `employee_signatures` (
  `employee_id` int(11) NOT NULL,
  `file_size` mediumint(9) NOT NULL,
  `file` mediumblob NOT NULL,
  PRIMARY KEY (`employee_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `employees` */

DROP TABLE IF EXISTS `employees`;

CREATE TABLE `employees` (
  `employee_id` int(11) NOT NULL AUTO_INCREMENT,
  `employee_bio_id` varchar(30) COLLATE latin1_general_ci DEFAULT NULL,
  `lastname` varchar(20) COLLATE latin1_general_ci DEFAULT NULL,
  `firstname` varchar(20) COLLATE latin1_general_ci DEFAULT NULL,
  `middlename` varchar(20) COLLATE latin1_general_ci DEFAULT NULL,
  `department_id` int(11) DEFAULT NULL,
  `logstatus` varchar(1) COLLATE latin1_general_ci DEFAULT 'O',
  `colstatus` int(1) DEFAULT '6',
  `datetimelog` datetime DEFAULT '2013-01-01 00:00:00',
  `currentdatelog` date DEFAULT '2013-01-01',
  `schedule_id` int(11) DEFAULT '0',
  `pay_type` varchar(1) COLLATE latin1_general_ci DEFAULT 'D',
  PRIMARY KEY (`employee_id`),
  UNIQUE KEY `unq_Employee_Bio_ID` (`employee_bio_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2487 DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `familybackground` */

DROP TABLE IF EXISTS `familybackground`;

CREATE TABLE `familybackground` (
  `employeecode` int(11) DEFAULT NULL,
  `line_no` int(11) DEFAULT NULL,
  `rel_name` varchar(50) COLLATE latin1_general_ci DEFAULT NULL,
  `relationship` enum('Father','Mother','Child','Husband','Wife') COLLATE latin1_general_ci DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `gender` enum('Male','Female') COLLATE latin1_general_ci DEFAULT NULL,
  `occupation` varchar(20) COLLATE latin1_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `holidays_header` */

DROP TABLE IF EXISTS `holidays_header`;

CREATE TABLE `holidays_header` (
  `holiday_id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(50) COLLATE latin1_general_ci DEFAULT NULL,
  `work_date` date DEFAULT NULL,
  `holiday_type` varchar(3) COLLATE latin1_general_ci DEFAULT NULL,
  PRIMARY KEY (`holiday_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `holidays_line` */

DROP TABLE IF EXISTS `holidays_line`;

CREATE TABLE `holidays_line` (
  `holiday_id` int(11) DEFAULT NULL,
  `department_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `schedules` */

DROP TABLE IF EXISTS `schedules`;

CREATE TABLE `schedules` (
  `schedule_id` int(11) NOT NULL AUTO_INCREMENT,
  `description` varchar(50) COLLATE latin1_general_ci DEFAULT NULL,
  `1st_insched` time DEFAULT NULL,
  `1st_outsched` time DEFAULT NULL,
  `2nd_insched` time DEFAULT NULL,
  `2nd_outsched` time DEFAULT NULL,
  `3rd_insched` time DEFAULT NULL,
  `3rd_outsched` time DEFAULT NULL,
  `flexibreak` int(1) DEFAULT '0',
  PRIMARY KEY (`schedule_id`)
) ENGINE=InnoDB AUTO_INCREMENT=248 DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `schedules_assignment` */

DROP TABLE IF EXISTS `schedules_assignment`;

CREATE TABLE `schedules_assignment` (
  `employee_id` int(11) NOT NULL,
  `schedule_id` int(11) DEFAULT '0',
  `work_date` date NOT NULL,
  `department_id` int(11) DEFAULT '0',
  PRIMARY KEY (`employee_id`,`work_date`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `system_parameters` */

DROP TABLE IF EXISTS `system_parameters`;

CREATE TABLE `system_parameters` (
  `gracePeriod` int(11) DEFAULT '5',
  `roundMinutes` int(11) DEFAULT '30',
  `dtr_report` varchar(255) COLLATE latin1_general_ci DEFAULT 'DTRs.rpt',
  `add_employee` int(1) DEFAULT '0',
  `autoimportemployees` tinyint(1) DEFAULT '1',
  `autoimportusers` tinyint(1) DEFAULT '1',
  `autoimportpayrollperiods` tinyint(1) DEFAULT '1',
  `payroll_db` varchar(255) COLLATE latin1_general_ci DEFAULT 'payroll',
  `bio_ipaddress` varchar(20) COLLATE latin1_general_ci DEFAULT '192.168.0.201',
  `bio_portno` varchar(6) COLLATE latin1_general_ci DEFAULT '4370',
  `employee_bio_id_payroll_map` varchar(30) COLLATE latin1_general_ci DEFAULT 'idno',
  `flexibreak_hrs` decimal(10,2) DEFAULT '1.00',
  `nextDayMinDiff` decimal(10,2) DEFAULT '240.00',
  `editDTR` int(1) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `trans_lock` */

DROP TABLE IF EXISTS `trans_lock`;

CREATE TABLE `trans_lock` (
  `trans_lock_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `fullname` varchar(50) COLLATE latin1_general_ci DEFAULT NULL,
  `username` varchar(20) COLLATE latin1_general_ci DEFAULT NULL,
  `user_password` char(41) COLLATE latin1_general_ci DEFAULT NULL,
  `mnu_user` int(11) DEFAULT '1',
  `mnu_employee_info` int(11) DEFAULT '1',
  `mnu_schedules` int(11) DEFAULT '1',
  `mnu_cutoff_periods` int(11) DEFAULT '1',
  `mnu_assign_schedules` int(11) DEFAULT '1',
  `mnu_generate_dtr` int(11) DEFAULT '1',
  `mnu_dtr_adjustments` int(11) DEFAULT '1',
  `mnu_print_dtr` int(11) DEFAULT '1',
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*Table structure for table `wt` */

DROP TABLE IF EXISTS `wt`;

CREATE TABLE `wt` (
  `WTCode` int(11) NOT NULL,
  `dummycode` varchar(10) COLLATE latin1_general_ci DEFAULT NULL,
  `Description` varchar(100) COLLATE latin1_general_ci DEFAULT NULL,
  `payfreqcode` int(1) DEFAULT NULL,
  `qualification` int(1) DEFAULT NULL,
  `Exemption` decimal(18,2) DEFAULT NULL,
  `B1` decimal(18,2) DEFAULT NULL,
  `F1` decimal(18,2) DEFAULT NULL,
  `A1` decimal(18,2) DEFAULT NULL,
  `B2` decimal(18,2) DEFAULT NULL,
  `F2` decimal(18,2) DEFAULT NULL,
  `A2` decimal(18,2) DEFAULT NULL,
  `B3` decimal(18,2) DEFAULT NULL,
  `F3` decimal(18,2) DEFAULT NULL,
  `A3` decimal(18,2) DEFAULT NULL,
  `B4` decimal(18,2) DEFAULT NULL,
  `F4` decimal(18,2) DEFAULT NULL,
  `A4` decimal(18,2) DEFAULT NULL,
  `B5` decimal(18,2) DEFAULT NULL,
  `F5` decimal(18,2) DEFAULT NULL,
  `A5` decimal(18,2) DEFAULT NULL,
  `B6` decimal(18,2) DEFAULT NULL,
  `F6` decimal(18,2) DEFAULT NULL,
  `A6` decimal(18,2) DEFAULT NULL,
  `B7` decimal(18,2) DEFAULT NULL,
  `F7` decimal(18,2) DEFAULT NULL,
  `A7` decimal(18,2) DEFAULT NULL,
  `B8` decimal(18,2) DEFAULT NULL,
  `F8` decimal(18,2) DEFAULT NULL,
  `A8` decimal(18,2) DEFAULT NULL,
  `B9` decimal(18,2) DEFAULT NULL,
  `F9` decimal(18,2) DEFAULT NULL,
  `A9` decimal(18,2) DEFAULT NULL,
  `B10` decimal(18,2) DEFAULT NULL,
  `F10` decimal(18,2) DEFAULT NULL,
  `A10` decimal(18,2) DEFAULT NULL,
  PRIMARY KEY (`WTCode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
