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
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L0_ArrayExtensions
{
    [Pure]
    internal static class CArrayExtensions
    {
        internal static string extToString(this byte[] ioSource)
        {
            return BitConverter.ToString(ioSource);
        }

        internal static string extToString(this byte[] ioSource, int iStartIndex)
        {
            return BitConverter.ToString(ioSource, iStartIndex);
        }

        internal static string extToString(this byte[] ioSource, int iStartIndex, int iCount)
        {
            return BitConverter.ToString(ioSource, iStartIndex, iCount);
        }
    }
}
