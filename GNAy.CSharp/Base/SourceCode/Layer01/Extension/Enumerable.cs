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
using GNAy.CSharp.Base.Internal.L0_EnumerableExtensions;
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L1_EnumerableExtensions
{
    [Pure]
    internal static class CEnumerableExtensions
    {
        internal static bool extIsNullOrEmpty(this IEnumerable ioSource)
        {
            if (ioSource.extIsNull())
            {
                return true;
            }

            foreach (var mItem in ioSource)
            {
                return false;
            }

            return true;
        }

        internal static bool extIsNotEmpty(this IEnumerable ioSource)
        {
            return !extIsNullOrEmpty(ioSource);
        }

        internal static Type extTryToGetItemType(this IEnumerable ioSource)
        {
            if (ioSource.extIsNull())
            {
                return null;
            }

            foreach (var mItem in ioSource)
            {
                if (mItem.extIsNotNull())
                {
                    return mItem.GetType();
                }
            }

            return null;
        }

        internal static int extGetLastIndex(this IEnumerable ioSource)
        {
            return (ioSource.extToEnumerableT().Count() - 1);
        }
    }
}
