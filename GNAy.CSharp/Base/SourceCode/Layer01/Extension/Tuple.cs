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

namespace GNAy.CSharp.Base.Internal.L1_TupleExtensions
{
    [Pure]
    internal static class CTupleExtensions
    {
        internal static string extGetVersionString(this Tuple<Version, string> ioSource)
        {
            if (ioSource.extIsNull())
            {
                return CConst.StringEmpty;
            }
            else if (ioSource.Item1 == null)
            {
                return ioSource.Item2;
            }

            return ioSource.Item1.ToString();
        }
    }
}
