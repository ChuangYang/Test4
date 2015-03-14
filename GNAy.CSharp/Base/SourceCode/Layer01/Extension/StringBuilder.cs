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
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L1_StringBuilderExtensions
{
    [Pure]
    internal static class CStringBuilderExtensions
    {
        internal static bool extIsNullOrEmpty(this StringBuilder ioSource)
        {
            return (ioSource.extIsNull() || (ioSource.Length == CConst.Empty));
        }

        internal static bool extIsNotEmpty(this StringBuilder ioSource)
        {
            return !extIsNullOrEmpty(ioSource);
        }

        internal static int extGetLastIndex(this StringBuilder ioSource)
        {
            return (ioSource.Length - 1);
        }

        internal static char extGetLastItem(this StringBuilder ioSource)
        {
            return ioSource[extGetLastIndex(ioSource)];
        }
    }
}
