





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [SQL_].GetValueT1ModelWithParametr
(
	@IntValue int
)
AS
BEGIN

select * from SQL_.Users u where u.IntValue = @IntValue

END