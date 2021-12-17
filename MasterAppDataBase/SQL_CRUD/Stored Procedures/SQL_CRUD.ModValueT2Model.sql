










-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [SQL_CRUD].[ModValueT2Model]
(
	@StringValue varchar(50),
	@IntValue int
)

AS
BEGIN

	if @StringValue is null 
	begin
		return -1
	end

	begin
		update SQL_.Users
		set DateTimeValue = GETDATE()
		where StringValue = @StringValue and IntValue = @IntValue
		return 0
	end
	
	return 0
END