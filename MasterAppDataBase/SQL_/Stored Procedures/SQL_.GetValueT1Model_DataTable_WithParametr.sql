





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [SQL_].[GetValueT1Model_DataTable_WithParametr]
(
	@IntValue int
)
AS
BEGIN

select u.IntValue from SQL_.Users u where u.IntValue  = @IntValue

END