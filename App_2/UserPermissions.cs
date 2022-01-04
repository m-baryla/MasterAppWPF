using Interface;
using System.Collections.Generic;

namespace App_2
{
    static class UserPermissions
    {
        private static Dictionary<ApplicationRoles, bool> _permissionsDict = new Dictionary<ApplicationRoles, bool>();
        public static bool IsAllowed(ApplicationRoles appRole,ISQL sql)
        {
            #if DEBUG
            return true;
            #endif

            if (!_permissionsDict.ContainsKey(ApplicationRoles.Admin))
                _permissionsDict[ApplicationRoles.Admin] = sql.GetUserPermissionLogin("SQL_.GetUserPermissions_App_2", ApplicationRoles.Admin.ToString());
            if (_permissionsDict[ApplicationRoles.Admin] == true) return true;

            if (!_permissionsDict.ContainsKey(appRole))
                _permissionsDict[appRole] = sql.GetUserPermissionLogin("SQL_.GetUserPermissions_App_2", appRole.ToString());
            return _permissionsDict[appRole];
        }
    }
}
