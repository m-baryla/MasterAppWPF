



CREATE PROCEDURE [SQL_].[GetUserPermissions_App_1]
(
	@userRole varchar(50)
)
AS

BEGIN
	SELECT DomainGroup FROM SQL_.UserPermission_App_1
	WHERE
		ApplicationRole = @userRole and DictStatus <> 0

return 0

END