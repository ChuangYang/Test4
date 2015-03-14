using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
using System.Reflection;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L0_ParameterInfoExtensions
{
    [Pure]
    internal static class CParameterInfoExtensions
    {
        internal static bool extIsRef(this ParameterInfo ioSource)
        {
            return ioSource.ParameterType.IsByRef;
        }
    }
}
