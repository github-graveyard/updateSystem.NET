/*
	This is the updateLog - uberScript
	It will Install, Upgrade and Massage your updateLog Database.
	You can execute it as often as you like, it won't delete or overwrite tables or data.

	Don't try to rename anything, you'll regret it ;-)

	Copyright (c) 2011 Maximilian Krauﬂ - http://maximiliankrauss.net
	Any suggestions? Please tell me: mail@maximiliankrauss.net
	===================================================================

	Current Version: 0.6 BETA
	
*/

-------------------------------------------
-- Create required Tables, if not exists --
-------------------------------------------

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'update_log')
BEGIN
	CREATE TABLE update_log (
		PKlog_id			INT IDENTITY(1,1)	NOT NULL,
		
		--Client related
		log_client_os_major		INT					NOT NULL,
		log_client_os_minor		INT					NOT NULL,		
		log_client_identifier	VARCHAR(36)			NULL,
		log_client_version		VARCHAR(20)			NOT NULL,
		
		--Project related
		FKlog_prj_id			INT					NOT NULL,
		
		log_timestamp			DATETIME			NOT NULL,
		log_request_type		TINYINT				NOT NULL,
		
		CONSTRAINT [PK_update_log] PRIMARY KEY CLUSTERED
		( 
			PKlog_id ASC
		)	WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'update_log_users')
BEGIN
	CREATE TABLE update_log_users (
		PKusr_id			INT IDENTITY(1,1)	NOT NULL,
		usr_name			VARCHAR(200)		NOT NULL,
		usr_password		VARCHAR(512)		NOT NULL,
		usr_is_admin		TINYINT				NOT NULL DEFAULT 0,
		usr_is_root			TINYINT				NOT NULL DEFAULT 0, -- Roots can't deleted ... never!
		usr_is_active		TINYINT				NOT NULL DEFAULT 1,
		usr_max_projects	INT					NOT NULL DEFAULT -1 -- This Value does not affect Adminuser!
		CONSTRAINT [PK_update_log_users] PRIMARY KEY CLUSTERED
		(
			PKusr_id ASC
		) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'update_log_projects')
BEGIN
	CREATE TABLE update_log_projects (
		PKprj_id		INT IDENTITY(1,1)	NOT NULL,
		FKprj_usr_id	INT					NOT NULL,
		prj_name		VARCHAR(100)		NOT NULL,
		prj_identifier	VARCHAR(36)			NOT NULL,
		prj_is_active	TINYINT				NOT NULL DEFAULT 1,
		CONSTRAINT [PKprj_id] PRIMARY KEY CLUSTERED
		(
			PKprj_id ASC
		) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

-------------------
-- TABLE UPDATES --
-------------------

-- Reserved Space for Table Updates


----------------------------------------
-- Create or Update Stored Procedures --
----------------------------------------

/*
	USER MANAGEMENT
*/
IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_add_update_log_user')
	DROP PROCEDURE stp_add_update_log_user
GO
CREATE PROCEDURE stp_add_update_log_user @usr_name VARCHAR(200), @usr_password VARCHAR(512), @usr_max_projects INT = 0, @usr_is_admin TINYINT = 0
AS BEGIN
	
	-- Check if the Username is already taken
	IF EXISTS ( SELECT * FROM update_log_users WHERE usr_name = @usr_name)
		RETURN -1
	
	INSERT INTO update_log_users	(usr_name, usr_password, usr_is_admin, usr_max_projects) VALUES
									(@usr_name, @usr_password, @usr_is_admin, @usr_max_projects)
	
	RETURN 0	
END
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name= 'stp_edit_update_log_user')
	DROP PROCEDURE stp_edit_update_log_user
GO
CREATE PROCEDURE stp_edit_update_log_user @old_usr_name VARCHAR(200), @usr_name VARCHAR(200), @usr_password VARCHAR(512) = '', @usr_max_projects INT, @usr_is_admin TINYINT, @usr_is_active TINYINT
AS BEGIN
	
	-- Check if the new username is not already taken
	IF @old_usr_name <> @usr_name
	BEGIN
		IF EXISTS(SELECT PKusr_id FROM update_log_users WHERE usr_name = @usr_name)
			RETURN -2
	END
	
	-- Get Userid
	DECLARE @PKusr_id INT = -1
	SELECT
		@PKusr_id = ISNULL(PKusr_id, -1)
	FROM update_log_users WITH (NOLOCK)
	WHERE usr_name = @old_usr_name
	
	IF @PKusr_id = -1 RETURN -1
	
	UPDATE usr SET
		usr.usr_name = CASE WHEN @usr_name <> '' THEN @usr_name ELSE usr.usr_name END,
		usr.usr_password = CASE WHEN @usr_password <> '' THEN @usr_password ELSE usr.usr_password END,
		usr.usr_max_projects = CASE WHEN @usr_max_projects <> -1 THEN @usr_max_projects ELSE usr.usr_max_projects END,
		usr.usr_is_admin = CASE WHEN @usr_is_admin <> 2 THEN @usr_is_admin ELSE usr.usr_is_admin END,
		usr.usr_is_active = CASE WHEN @usr_is_active <> 2 THEN @usr_is_active ELSE usr.usr_is_active END		
	FROM update_log_users AS usr WITH (NOLOCK)
	WHERE PKusr_id = @PKusr_id
		
	
	RETURN 0
END
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_check_update_log_user')
	DROP PROCEDURE stp_check_update_log_user
GO
CREATE PROCEDURE stp_check_update_log_user @usr_name VARCHAR(200), @usr_password VARCHAR(512)
AS BEGIN
	/*******************************************************
	stp_check_update_log_user - Validates a Useraccount
	
	Returnvalues:
					-2: Login failed, User is inactive
					-1: Login failed, Username and/or Password is incorrect
					 0: Login successfull
					 1: Login successfull, User is Admin
	*******************************************************/
	
	-- Verify Username and Password
	DECLARE @RET_VALUE INT
	IF EXISTS(SELECT * FROM update_log_users WHERE usr_name = @usr_name AND usr_password = @usr_password)
	BEGIN
		-- Check if the User is active
		IF ISNULL((SELECT TOP 1 usr_is_active FROM update_log_users WITH (NOLOCK) WHERE usr_name = @usr_name), 0) = 1
		BEGIN
			-- Check if the User is Admin
			IF (SELECT TOP 1 usr_is_admin FROM update_log_users WITH (NOLOCK) WHERE usr_name = @usr_name) = 1
				SET @RET_VALUE = 1
			ELSE
				SET @RET_VALUE = 0
				
			SELECT PKusr_id FROM update_log_users WHERE usr_name = @usr_name AND usr_password = @usr_password
		END
		ELSE
			SET @RET_VALUE = -2
	END
	ELSE
		SET @RET_VALUE = -1
	
	RETURN @RET_VALUE
END
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_delete_update_log_user')
	DROP PROCEDURE 	stp_delete_update_log_user
GO
CREATE PROCEDURE stp_delete_update_log_user @usr_name VARCHAR(200)
AS BEGIN
	/*******************************************************
	stp_delete_update_log_user - Deletes and User, his Projects and Logs from DB
	
	Returnvalues:
					-1: User is Root and can't deleted.
					 0: The User and his stuff has been successfully removed
	*******************************************************/
	
	--Check if User is root. As you may know, roots can't deleted
	IF EXISTS(SELECT * FROM update_log_users WHERE usr_name = @usr_name AND usr_is_root = 1)
		RETURN -1
	
	-- Remove all Logentries which belongs to the user
	DELETE update_log
		FROM update_log log
		INNER JOIN update_log_users users WITH (NOLOCK) ON users.usr_name = @usr_name
		INNER JOIN update_log_projects WITH (NOLOCK) ON FKprj_usr_id = users.PKusr_id
	
	--Delete all Projects owned by this User
	DELETE update_log_projects
		FROM update_log_projects
		INNER JOIN update_log_users WITH (NOLOCK) ON usr_name = @usr_name
	WHERE FKprj_usr_id = PKusr_id

	--And finally: Delete the user
	DELETE FROM update_log_users WHERE usr_name = @usr_name

	RETURN 0
END --stp_delete_update_log_user
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type= 'P' AND name = 'stp_get_update_log_user')
	DROP PROCEDURE stp_get_update_log_user
GO
CREATE PROCEDURE stp_get_update_log_user @usr_name VARCHAR(200)
AS BEGIN

	-- Is User Admin?
	DECLARE @is_admin TINYINT
	SELECT @is_admin = ISNULL(usr_is_admin, 0)
	  FROM update_log_users WITH (NOLOCK)
	WHERE usr_name = @usr_name
	
	IF @is_admin = 1
		SELECT usr_name, usr_is_admin, usr_max_projects, usr_is_active
			FROM update_log_users WITH (NOLOCK)
	ELSE
		SELECT usr_name, usr_is_admin, usr_max_projects, usr_is_active
			FROM update_log_users WITH(NOLOCK)
		WHERE usr_name = @usr_name
		
	RETURN 0
END
GO

/*
	PROJECT MANAGEMENT
*/
IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_add_update_log_project')
	DROP PROCEDURE stp_add_update_log_project
GO
CREATE PROCEDURE stp_add_update_log_project @prj_identifier VARCHAR(36), @usr_name VARCHAR(200), @prj_name VARCHAR(100), @prj_is_active TINYINT
AS BEGIN
	/*******************************************************
	stp_add_update_log_project - Adds a new Updateproject to the DB
	
	Returnvalues:
					-2: The Number of allowed Projects exceeded
					-1: User not found or User is not active
					 0: The Projects was successfully added
	*******************************************************/
	
	DECLARE @user_id INT
	SELECT @user_id = ISNULL(PKusr_id, -1) FROM update_log_users WHERE usr_name = @usr_name AND usr_is_active <> 0
	IF @user_id = -1
		RETURN -1
	
	-- Check the allowed Projectcount
	DECLARE @current_project_count	INT
	DECLARE @allowed_project_count	INT
	DECLARE @usr_is_admin			INT
	
	SELECT @current_project_count = COUNT(PKprj_id) FROM update_log_projects WITH(NOLOCK)
		WHERE FKprj_usr_id = @user_id
	
	SELECT @allowed_project_count = usr_max_projects, @usr_is_admin = usr_is_admin FROM update_log_users WITH (NOLOCK)
		WHERE PKusr_id = @user_id

	IF @current_project_count >= @allowed_project_count AND @usr_is_admin = 0
		RETURN -2
	
	INSERT INTO update_log_projects (	prj_identifier, FKprj_usr_id, prj_name, prj_is_active)
							VALUES	(	@prj_identifier, @user_id, @prj_name, @prj_is_active)
	
	RETURN 0
END
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_delete_update_log_project')
	DROP PROCEDURE stp_delete_update_log_project
GO
CREATE PROCEDURE stp_delete_update_log_project @prj_identifier VARCHAR(36), @usr_name VARCHAR(200)
AS BEGIN
	/*******************************************************
	stp_delete_update_log_project - Deletes a Project and all of it's Logentries from the DB
	
	Returnvalues:
					-1: User has no permission to delete this Project
					 0: Project successfully deleted
	*******************************************************/
	
	-- Let's check whether the User can delete the project or not
	DECLARE @can_delete TINYINT
	SELECT ISNULL(PKprj_id, 0) FROM update_log_projects WITH (NOLOCK)
		LEFT JOIN update_log_users owner	WITH (NOLOCK) ON owner.PKusr_id = FKprj_usr_id -- This is the one who owns this project
		LEFT JOIN update_log_users request	WITH (NOLOCK) ON request.usr_name = @usr_name -- This is the one who has sent the delete-request
	WHERE prj_identifier = @prj_identifier
		AND (ISNULL(owner.PKusr_id, -1) > -1 OR request.usr_is_admin <> 0)
	
	IF @can_delete <= 0
		RETURN -1

	-- Delete all Updatelog entries which references to this Project-Id
	DELETE ulog
	FROM update_log ulog
		JOIN update_log_projects WITH(NOLOCK) ON prj_identifier = @prj_identifier
	WHERE ulog.FKlog_prj_id = PKprj_id
	
	-- And finally, delete the Project
	DELETE FROM update_log_projects WHERE prj_identifier = @prj_identifier
		
	RETURN 0
END
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_get_update_log_projects')
	DROP PROCEDURE stp_get_update_log_projects
GO
CREATE PROCEDURE stp_get_update_log_projects @usr_name VARCHAR(200)
AS BEGIN

	-- Get Userid from Username
	DECLARE @PKusr_id INT = -1
	SELECT
		@PKusr_id = ISNULL(PKusr_id, -1)
	FROM update_log_users WITH (NOLOCK)
	WHERE usr_name = @usr_name
	
	-- No user found
	IF @PKusr_id = -1 RETURN -1
	
	-- Return all projects related to that user
	SELECT	prj_identifier,
			prj_name,
			prj_is_active
		FROM update_log_projects WITH (NOLOCK) WHERE FKprj_usr_id = @PKusr_id
	
	RETURN 0
END
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_get_update_log_project')
	DROP PROCEDURE stp_get_update_log_project
GO
CREATE PROCEDURE stp_get_update_log_project @prj_identifier VARCHAR(36), @usr_name VARCHAR(200)
AS BEGIN
	
	SELECT 
		prj_identifier,
		prj_name,
		prj_is_active
	FROM update_log_projects WITH (NOLOCK)
		INNER JOIN update_log_users WITH (NOLOCK) ON usr_name = @usr_name
	WHERE prj_identifier = @prj_identifier
	
	RETURN 0
END
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_edit_update_log_project')
	DROP PROCEDURE stp_edit_update_log_project
GO
CREATE PROCEDURE stp_edit_update_log_project @prj_identifier VARCHAR(36), @prj_name VARCHAR(100), @prj_is_active TINYINT, @usr_name VARCHAR(200)
AS BEGIN
	UPDATE prj SET
		prj.prj_name = @prj_name,
		prj.prj_is_active = @prj_is_active
	FROM update_log_projects prj WITH (NOLOCK)
	  INNER JOIN update_log_users ON usr_name = @usr_name
	WHERE	prj.prj_identifier = @prj_identifier
			AND prj.FKprj_usr_id = PKusr_id
	
	RETURN 0
END
GO

/*
	UPDATE - LOG
*/
IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_add_update_log')
	DROP PROCEDURE stp_add_update_log
GO	
CREATE PROCEDURE stp_add_update_log	@client_os_major INT, @client_os_minor INT, @client_identifier VARCHAR(36) = NULL,
									@project_identifier VARCHAR(36), @client_version VARCHAR(20), @request_type TINYINT
AS BEGIN

	/*******************************************************
	stp_insert_update_log - Inserts a new Entry in the Log
	
	Returnvalues:
					-1: Project not found or Project is inactive or User is inactive
					 0: Entry successfully added
	*******************************************************/
	DECLARE @project_id	INT

	--Try to determine the PK 
	SELECT @project_id = ISNULL(PKprj_id, -1)
		FROM update_log_projects WITH (NOLOCK)
		INNER JOIN update_log_users ON PKusr_id = FKprj_usr_id
			AND usr_is_active = 1
		WHERE prj_identifier = @project_identifier
				AND prj_is_active = 1
	
	IF @project_id = -1
		RETURN -1
		
	INSERT INTO update_log	(	log_client_os_major, log_client_os_minor, log_client_identifier,
								FKlog_prj_id, log_client_version, log_timestamp, log_request_type)
				VALUES		(	@client_os_major, @client_os_minor, @client_identifier,
								@project_id, @client_version, GETDATE(), @request_type)
	RETURN 0
END
GO

IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_get_update_log')
	DROP PROCEDURE stp_get_update_log
GO
CREATE PROCEDURE stp_get_update_log @date_from DATETIME, @date_to DATETIME, @min_os_major INT = -1,
									@min_os_minor INT = -1, @project_identifier VARCHAR(36),
									@client_identifier VARCHAR(36) = NULL, @client_version VARCHAR(20) = NULL
AS BEGIN
	
	SET @client_identifier	= ISNULL(@client_identifier, '')
	SET @client_version		= ISNULL(@client_version, '')
		
	SELECT 
		log_client_os_major, log_client_os_minor, ISNULL(log_client_identifier, '') as log_client_identifier,
		log_client_version, log_timestamp, log_request_type
	 FROM update_log WITH(NOLOCK)
		INNER JOIN update_log_projects WITH(NOLOCK) ON prj_identifier = @project_identifier
	WHERE
		log_timestamp BETWEEN @date_from AND @date_to
		AND (log_client_os_major >= @min_os_major OR @min_os_major = -1)
		AND (log_client_os_minor >= @min_os_minor OR @min_os_minor = -1)
		AND prj_identifier = @project_identifier
		AND FKlog_prj_id = PKprj_id
		AND (log_client_identifier = @client_identifier OR @client_identifier = '')
		AND (log_client_version = @client_version OR @client_version = '')
	
	RETURN 0
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_add_update_log_debug')
	DROP PROCEDURE stp_add_update_log_debug
GO
CREATE PROCEDURE stp_add_update_log_debug	@client_os_major INT, @client_os_minor INT, @client_identifier VARCHAR(36) = NULL,
											@project_identifier VARCHAR(36), @client_version VARCHAR(20), @request_type TINYINT,
											@timestamp DATETIME
AS BEGIN

	/*******************************************************
	stp_insert_update_log_debug - Inserts a new Entry in the Log for Debugreasons.
	
	Returnvalues:
					-1: Project not found or Project is inactive or User is inactive
					 0: Entry successfully added
	*******************************************************/
	DECLARE @project_id	INT

	--Try to determine the PK 
	SELECT @project_id = ISNULL(PKprj_id, -1)
		FROM update_log_projects WITH (NOLOCK)
		INNER JOIN update_log_users ON PKusr_id = FKprj_usr_id
			AND usr_is_active = 1
		WHERE prj_identifier = @project_identifier
				AND prj_is_active = 1
	
	IF @project_id = -1
		RETURN -1
		
	INSERT INTO update_log	(	log_client_os_major, log_client_os_minor, log_client_identifier,
								FKlog_prj_id, log_client_version, log_timestamp, log_request_type)
				VALUES		(	@client_os_major, @client_os_minor, @client_identifier,
								@project_id, @client_version, @timestamp, @request_type)
	RETURN 0
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'stp_cleanup_update_log')
	DROP PROCEDURE stp_cleanup_update_log
GO
CREATE PROCEDURE stp_cleanup_update_log @usr_name VARCHAR(200), @project_identifier VARCHAR(36), @cleanup_date DATETIME
AS BEGIN
	DELETE upd_log
	FROM update_log AS upd_log
	  INNER JOIN update_log_projects WITH(NOLOCK) ON PKprj_id = upd_log.FKlog_prj_id
	  INNER JOIN update_log_users WITH(NOLOCK) ON FKprj_usr_id = PKusr_id
	WHERE prj_identifier = @project_identifier
	  AND usr_name = @usr_name
	  AND upd_log.log_timestamp < @cleanup_date
	
	SELECT ISNULL(@@ROWCOUNT, -1) AS removed_entries
	
	RETURN 0
END
GO

/*
	FIRST RUN
*/

-- This one adds the default root-admin if no other users exists. You shold change the Password as soon as possible!
IF (SELECT COUNT(*) FROM update_log_users) = 0
BEGIN
	INSERT INTO update_log_users VALUES (
		'admin',
		'B8315ACA1E22E347EDAD38F4A25DF40C1AC06259D31F5DF0FB467136F16979F0989804ACC31889371ADD3D90B5B053417E48BA72485DBFB76AEE297012A4A733', -- this is the Hashvalue for "LetMeIn!" (without the quotes)
		1 /*is_admin*/, 1 /*is_root*/, 1 /*is_active*/, 0
	)
END