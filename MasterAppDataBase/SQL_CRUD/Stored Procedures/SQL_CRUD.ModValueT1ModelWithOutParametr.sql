

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [SQL_CRUD].[ModValueT1ModelWithOutParametr]
(
	@StringValue varchar(50),
	@DateTimeValue datetime,
	@DoubleVaule float,

	@NewRowId int out,
	@UserMsg nvarchar(2000) out
)

AS
BEGIN

	declare @maxKey int

	if @StringValue is null 
	begin
		set @UserMsg = N'@StringValue is null'
		return @NewRowId
	end

	select @maxKey = max(u.IntValue)
	from SQL_.Users u

	set @NewRowId = coalesce(@maxKey, 0) + 1

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
				DATEADD(YEAR, @NewRowId, @DateTimeValue)
			)

		set @UserMsg = 'OK'
			return @NewRowId
	end
END