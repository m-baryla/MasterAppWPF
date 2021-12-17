using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_2
{
    static class UserPermissions
    {
        private static Dictionary<ApplicationRoles, bool> _permissionsDict = new Dictionary<ApplicationRoles, bool>();
        public static bool IsAllowed(ApplicationRoles appRole,ISQL sql)
        {
            if (!_permissionsDict.ContainsKey(ApplicationRoles.Admin))
                _permissionsDict[ApplicationRoles.Admin] = sql.GetUserPermission("SQL_.GetUserPermissions_App_2", ApplicationRoles.Admin.ToString());
            if (_permissionsDict[ApplicationRoles.Admin] == true) return true;

            if (!_permissionsDict.ContainsKey(appRole))
                _permissionsDict[appRole] = sql.GetUserPermission("SQL_.GetUserPermissions_App_2", appRole.ToString());
            return _permissionsDict[appRole];
        }
    }
}
