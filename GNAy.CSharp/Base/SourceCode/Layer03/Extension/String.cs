using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
using GNAy.CSharp.Base.Internal.L2_LibrarySetting;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L3_StringExtensions
{
    [Pure]
    internal static class CStringExtensions
    {
        internal static string extJoin(this string iSeparator, params string[] ioValues)
        {
            if (string.IsNullOrEmpty(iSeparator))
            {
                iSeparator = CLibrarySetting.GetSeparator();
            }

            return (iSeparator.extClassEquals(CLibrarySetting.GetSeparator()) ?
                string.Format(CLibrarySetting.GetBucket(), string.Join(iSeparator, ioValues)) :
                string.Join(iSeparator, ioValues));
        }
    }
}
