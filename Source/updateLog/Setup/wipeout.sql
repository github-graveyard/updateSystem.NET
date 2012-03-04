/*

	updateLog - Wipeout Script
	This Script will remove all updateLog-Traces from your selected Database

*/


-- Remove Tables
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'update_log')
	DROP TABLE update_log
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'update_log_users')	
	DROP TABLE update_log_users
GO
	
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'update_log_projects')
	DROP TABLE update_log_projects
GO

-- Remove Procedures
IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_add_update_log_user')
	DROP PROCEDURE stp_add_update_log_user
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name= 'stp_edit_update_log_user')
	DROP PROCEDURE stp_edit_update_log_user
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_check_update_log_user')
	DROP PROCEDURE stp_check_update_log_user
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_delete_update_log_user')
	DROP PROCEDURE 	stp_delete_update_log_user
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type= 'P' AND name = 'stp_get_update_log_user')
	DROP PROCEDURE stp_get_update_log_user
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_add_update_log_project')
	DROP PROCEDURE stp_add_update_log_project
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_delete_update_log_project')
	DROP PROCEDURE stp_delete_update_log_project
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_add_update_log')
	DROP PROCEDURE stp_add_update_log
GO	

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_get_update_log')
	DROP PROCEDURE stp_get_update_log
GO

