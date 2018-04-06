USE [DevOps]
GO

IF EXISTS (
        SELECT 'DROP PROCEDURE ' + name
        FROM sys.procedures WITH(NOLOCK)
        WHERE 0=0
		  -- and NAME = 'spcGetUsers'
            AND type = 'P'
      )
     DROP PROCEDURE dbo.spcGetUsers
GO

CREATE PROC dbo.spcGetUsers

AS

  SELECT [UserID], [FirstName], [LastName], [IsActive]
  FROM [dbo].[tblUsers]
  WHERE IsActive = 1
GO


