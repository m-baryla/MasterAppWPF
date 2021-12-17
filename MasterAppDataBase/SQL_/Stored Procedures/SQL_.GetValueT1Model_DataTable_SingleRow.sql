







-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [SQL_].[GetValueT1Model_DataTable_SingleRow]
(
	@StringValue varchar(50)
)
AS
BEGIN

select TOP 1 * from SQL_.Users u where u.StringValue = @StringValue

END