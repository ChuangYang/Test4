using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Collections;
using System.Diagnostics.Contracts;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L1_ListExtensions
{
    [Pure]
    internal static class CListExtensions
    {
        internal static bool extIsNullOrEmpty(this IList ioSource)
        {
            return (ioSource.extIsNull() || (ioSource.Count == CConst.Empty));
        }

        internal static bool extIsNotEmpty(this IList ioSource)
        {
            return !extIsNullOrEmpty(ioSource);
        }

        internal static int extGetLastIndex(this IList ioSource)
        {
            return (ioSource.Count - 1);
        }
    }
}
