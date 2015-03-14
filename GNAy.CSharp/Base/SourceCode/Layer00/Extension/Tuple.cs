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

namespace GNAy.CSharp.Base.Internal.L0_TupleExtensions
{
    [Pure]
    internal static class CTupleExtensions
    {
        internal static bool extIsCompleted<T>(this Tuple<bool, T> ioSource)
        {
            return ioSource.Item1;
        }

        internal static T extGetReturn<T>(this Tuple<bool, T> ioSource)
        {
            return ioSource.Item2;
        }
    }
}
