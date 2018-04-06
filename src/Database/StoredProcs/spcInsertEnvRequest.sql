USE [DevOps]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spcInsertEnvRequest]
(
    @RequestorID int,
    @OwnerID int,
    @ReleaseID int,
	@ApplicationID int,
	@DateFrom date,
	@TimeFrom time(0),
	@DateTo date,
	@TimeTo time(0),
	@EnvReqStatusTypesID int,
	@Notes nvarchar(4000),

	@EnvRequestID  int OUTPUT
)

AS
INSERT INTO [tblEnvRequests]
( 
	RequestorID,
	OwnerID,
	ReleaseID,
	ApplicationID,
	DateFrom,
	TimeFrom,
	DateTo,
	TimeTo,
	EnvReqStatusTypesID,
	Notes
)
VALUES 
(
	@RequestorID,
	@OwnerID,
	@ReleaseID,
	@ApplicationID,
	@DateFrom,
	@TimeFrom,
	@DateTo,
	@TimeTo,
	@EnvReqStatusTypesID,
	@Notes
)

SET @EnvRequestID= @@IDENTITY
 Return @EnvRequestID

GO


