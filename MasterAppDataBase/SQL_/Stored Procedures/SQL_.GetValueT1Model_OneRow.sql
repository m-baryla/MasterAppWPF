







-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [SQL_].[GetValueT1Model_OneRow]
(
	@IntValue int,
		@UserMsg nvarchar(2000) out
)
AS
BEGIN

select * from SQL_.Users u where u.IntValue  = @IntValue

END