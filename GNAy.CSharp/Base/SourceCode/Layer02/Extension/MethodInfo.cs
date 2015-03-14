using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Runtime.CompilerServices;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
using GNAy.CSharp.Base.Internal.L1_ListExtensions;
using GNAy.CSharp.Base.Internal.L1_TypeHelper;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L2_MethodInfoExtensions
{
    [Pure]
    internal static class CMethodInfoExtensions
    {
        internal static bool extIsExtensionMethod(this MethodInfo ioSource)
        {
            return (ioSource.DeclaringType.extIsStaticClass() &&
                //ioSource.IsStatic &&
                ioSource.IsDefined(typeof(ExtensionAttribute), false) &&
                ioSource.GetParameters().extIsNotEmpty());
        }

        internal static bool extIsNotExtensionMethod(this MethodInfo ioSource)
        {
            return !extIsExtensionMethod(ioSource);
        }

        internal static Type extGetExtensionType(this MethodInfo ioSource)
        {
            return (extIsExtensionMethod(ioSource) ? ioSource.GetParameters()[CConst.StartIndex].ParameterType : null);
        }
    }
}
