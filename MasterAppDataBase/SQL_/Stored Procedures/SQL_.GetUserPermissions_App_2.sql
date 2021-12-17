

CREATE PROCEDURE SQL_.GetUserPermissions_App_2
(
	@userRole varchar(50)
)
AS

BEGIN
	SELECT DomainGroup FROM SQL_.UserPermission_App_2
	WHERE
		ApplicationRole = @userRole and DictStatus <> 0

return 0

END