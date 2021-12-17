












-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [SQL_CRUD].[ModValueT1ModelAddTable]
(
	@DateTimeValue datetime,
	@AddTable SQL_.AddTable READONLY,
	@ReturnCode int out,
	@UserMsg nvarchar(2000) out
)

AS
BEGIN

	declare @IntVal int

	if @DateTimeValue is null 
	begin
		set @UserMsg = N'@DateTimeValue is null'
		set @ReturnCode = -1;
		return @ReturnCode
	end
	
	begin
	select 
		*
	from 
		SQL_.Users u
		inner join @AddTable a on (a.StringValue = u.StringValue)

		set @UserMsg = 'OK'
		set @ReturnCode = 0;
		return @ReturnCode
	end
return @ReturnCode
END