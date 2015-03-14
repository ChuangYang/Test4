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
using GNAy.CSharp.Base.Internal.L1_ListTExtensions;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L2_EnumerableTExtensions
{
    [Pure]
    internal static class CEnumerableTExtensions
    {
        internal static T[] extShuffleItems<T>(this IEnumerable<T> ioBucket, Random ioRandom, int iShufflingTimes = CListTExtensions.DEFAULT_SHUFFLING_TIMES)
        {
            return (CListTExtensions.extShuffleItems(((ioBucket is T[]) ? (ioBucket as T[]) : ioBucket.ToArray()), ioRandom, iShufflingTimes) as T[]);
        }
    }
}
