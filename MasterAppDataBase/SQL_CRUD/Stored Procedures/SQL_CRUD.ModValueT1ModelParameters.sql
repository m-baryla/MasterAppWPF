











-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [SQL_CRUD].[ModValueT1ModelParameters]
(
	@StringValue varchar(50),
	@DateTimeValue datetime,
	@DoubleVaule float,
	@UserMsg nvarchar(2000) out
)

AS
BEGIN

	if @StringValue is null 
	begin
		set @UserMsg = N'@StringValue is null'
		return -1
	end

	begin
		insert into SQL_.Users
		(
			StringValue,
			DoubleVaule,
			DateTimeValue
		)
		values 
		(
			@StringValue,
			@DoubleVaule,
			@DateTimeValue
		)

		set @UserMsg = 'OK'
		return 0
	end
	
	return 0
END