USE [DevOps]
GO
CREATE PROCEDURE [dbo].[spcGetEnvironmentsByAppId]
  @ApplicationID int
AS
SELECT tblEnvironments.EnvironmentID, tblEnvironments.EnvName
FROM tblEnvironments 
	inner join tblAppEnvs on tblAppEnvs.EnvironmentID=tblEnvironments.EnvironmentID
WHERE tblAppEnvs.ApplicationID = @ApplicationID

/*DROP PROC dbo.spcGetEnvironmentsByAppId*/