IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'CZPRG3K10\footcha')
CREATE LOGIN [CZPRG3K10\footcha] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO

EXEC master..sp_addsrvrolemember @loginame = N'CZPRG3K10\footcha', @rolename = N'sysadmin'
GO

