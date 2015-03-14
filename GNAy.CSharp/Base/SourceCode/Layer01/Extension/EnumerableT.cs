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
using GNAy.CSharp.Base.Const;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L1_EnumerableTExtensions
{
    [Pure]
    internal static class CEnumerableTExtensions
    {
        internal static IEnumerable<T> SkipThanTake<T>(this IEnumerable<T> ioSource, int iStartIndex, int iCount)
        {
            if (iStartIndex < CConst.StartIndex)
            {
                throw new ArgumentOutOfRangeException(iStartIndex.ToString());
            }
            else if (iCount == CConst.Zero)
            {
                return new T[CConst.Empty];
            }
            else if (iStartIndex == CConst.StartIndex)
            {
                return ((iCount < CConst.Zero) ? ioSource : ioSource.Take(iCount));
            }

            return ((iCount < CConst.Zero) ? ioSource.Skip(iStartIndex) : ioSource.Skip(iStartIndex).Take(iCount));
        }
    }
}
