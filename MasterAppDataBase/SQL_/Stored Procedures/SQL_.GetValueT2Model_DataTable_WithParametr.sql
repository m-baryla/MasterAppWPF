





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [SQL_].[GetValueT2Model_DataTable_WithParametr]
(
	@DoubleVaule float,
	@IntValue int,
	@StringValue nvarchar(50) 
)
AS
BEGIN

select u.IntValue, u.StringValue, u.DoubleVaule from SQL_.Users u where u.DoubleVaule  = @DoubleVaule

END