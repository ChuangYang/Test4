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
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L0_EnumerableExtensions
{
    [Pure]
    internal static class CEnumerableExtensions
    {
        internal static IEnumerable<T> extToEnumerable<T>(this IEnumerable ioSource)
        {
            foreach (T mItem in ioSource)
            {
                yield return mItem;
            }
        }

        internal static IEnumerable<object> extToEnumerableT(this IEnumerable ioSource)
        {
            return extToEnumerable<object>(ioSource);
        }
    }
}
