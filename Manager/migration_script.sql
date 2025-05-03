-- ----------------------------------------------------------------------------
-- MySQL Workbench Migration
-- Migrated Schemata: db_dentistry1
-- Source Schemata: db_dentistry
-- Created: Tue Apr 29 19:59:19 2025
-- Workbench Version: 8.0.40
-- ----------------------------------------------------------------------------

SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------------------------------------------------------
-- Schema db_dentistry1
-- ----------------------------------------------------------------------------
DROP SCHEMA IF EXISTS `db_dentistry1` ;
CREATE SCHEMA IF NOT EXISTS `db_dentistry1` ;

-- ----------------------------------------------------------------------------
-- Table db_dentistry1.entry
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dentistry1`.`entry` (
  `entry_id` INT NOT NULL AUTO_INCREMENT,
  `date_time` DATETIME NULL DEFAULT NULL,
  `user_name` VARCHAR(25) NULL DEFAULT NULL,
  `user_email` VARCHAR(50) NULL DEFAULT NULL,
  `entry_status` VARCHAR(11) NULL DEFAULT NULL,
  PRIMARY KEY (`entry_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table db_dentistry1.manager
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dentistry1`.`manager` (
  `manager_id` INT NOT NULL AUTO_INCREMENT,
  `manager_password` VARCHAR(64) NOT NULL,
  PRIMARY KEY (`manager_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 1006
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table db_dentistry1.news
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dentistry1`.`news` (
  `news_id` INT NOT NULL AUTO_INCREMENT,
  `news_title` VARCHAR(100) NULL DEFAULT NULL,
  `news_desc` TEXT NULL DEFAULT NULL,
  `date_publish` DATE NULL DEFAULT NULL,
  `news_image` VARCHAR(70) NULL DEFAULT NULL,
  PRIMARY KEY (`news_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table db_dentistry1.reviews
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dentistry1`.`reviews` (
  `reviews_id` INT NOT NULL AUTO_INCREMENT,
  `reviews_date` DATETIME NULL DEFAULT NULL,
  `reviews_text` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`reviews_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table db_dentistry1.services
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dentistry1`.`services` (
  `services_id` INT NOT NULL AUTO_INCREMENT,
  `services_title` VARCHAR(100) NULL DEFAULT NULL,
  `services_desc` TEXT NULL DEFAULT NULL,
  `services_price` INT NULL DEFAULT NULL,
  `services_type_id` INT NULL DEFAULT NULL,
  PRIMARY KEY (`services_id`),
  INDEX `fk_services_type_idx` (`services_type_id` ASC) VISIBLE,
  CONSTRAINT `fk_services_type`
    FOREIGN KEY (`services_type_id`)
    REFERENCES `db_dentistry1`.`services_type` (`services_type_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 24
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Table db_dentistry1.services_type
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_dentistry1`.`services_type` (
  `services_type_id` INT NOT NULL AUTO_INCREMENT,
  `services_type_title` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`services_type_id`))
ENGINE = InnoDB
AUTO_INCREMENT = 10
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;

-- ----------------------------------------------------------------------------
-- Trigger db_dentistry1.manager_BEFORE_INSERT
-- ----------------------------------------------------------------------------
DELIMITER $$
USE `db_dentistry1`$$
CREATE DEFINER=`root`@`localhost` TRIGGER `manager_BEFORE_INSERT` BEFORE INSERT ON `manager` FOR EACH ROW BEGIN
    DECLARE existing_count INT;
    
    SET @hashed_password = SHA2((NEW.manager_password), 256);
    SELECT COUNT(*) INTO existing_count 
    FROM manager 
    WHERE manager_password = @hashed_password;
    
    IF existing_count > 0 THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Ошибка: этот пароль уже используется другим менеджером';
    END IF;
    SET NEW.manager_password = @hashed_password;
    IF NEW.manager_id IS NULL THEN
        SET NEW.manager_id = (SELECT IFNULL(MAX(manager_id), 0) + 1 FROM manager);
    END IF;
    
END;
SET FOREIGN_KEY_CHECKS = 1;
