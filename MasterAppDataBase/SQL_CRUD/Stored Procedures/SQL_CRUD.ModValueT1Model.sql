









-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [SQL_CRUD].[ModValueT1Model]
(
	@StringValue varchar(50),
	@DateTimeValue datetime,
	@IntValue int,
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
		update SQL_.Users
		set DateTimeValue = DATEADD(YEAR, 2, @DateTimeValue)
		where StringValue = @StringValue and IntValue = @IntValue
		set @UserMsg = 'OK'
		return 0
	end
	
	return 0
END