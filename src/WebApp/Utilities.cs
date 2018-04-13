using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevOpsEnvMgmt
{
    public static class Utilities
    {
        public static string GetDomain(this IIdentity identity)
        {
            //return Regex.Match(identity.Name, "^.[^\\]*").ToString();
            //return identity.Name.SubString(0, identity.Name.IndexOf('\\'));
            if (identity.Name.Length > 0)
                return identity.Name.Substring(0, identity.Name.IndexOf("\\"));
            else
                return "";

        }

        public static string GetLogin(this IIdentity identity)
        {
            if (identity.Name.Length > 0)
                return Regex.Replace(identity.Name, ".*\\\\", "");
            else
                return "";
        }
    }
}
