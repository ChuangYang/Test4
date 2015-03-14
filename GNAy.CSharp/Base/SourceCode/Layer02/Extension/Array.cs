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
using GNAy.CSharp.Base.Internal.L1_StaticToolbox;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L2_ArrayExtensions
{
    [Pure]
    internal static class CArrayExtensions
    {
        internal static string extToString(this char[] ioSource, int iStartIndex)
        {
            Tuple<int, int> mStartIndexAndCount = CStaticToolbox.GetStartIndexAndCount(ioSource.Length, iStartIndex);

            return new string(ioSource, mStartIndexAndCount.Item1, mStartIndexAndCount.Item2);
        }

        internal static string extToString(this char[] ioSource, int iStartIndex, int iCount)
        {
            Tuple<int, int> mStartIndexAndCount = CStaticToolbox.GetStartIndexAndCount(ioSource.Length, iStartIndex, iCount);

            return new string(ioSource, mStartIndexAndCount.Item1, mStartIndexAndCount.Item2);
        }
    }
}
