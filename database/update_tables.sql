-- Pageant Scoring System Database Update Script
-- Apply these changes to your active pageant database in XAMPP phpMyAdmin or MySQL console.

-- 1. Alter Contestant_Number to VARCHAR(50) to support alphanumeric codes and leading zeros.
ALTER TABLE contestants MODIFY COLUMN Contestant_Number VARCHAR(50) DEFAULT NULL;

-- 2. Add Active_Device_ID column to judges table to support single-device logins.
ALTER TABLE judges ADD COLUMN Active_Device_ID VARCHAR(255) DEFAULT NULL;
