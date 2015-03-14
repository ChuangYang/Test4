using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Reflection;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L1_StackFrameExtensions
{
    [Pure]
    internal static class CStackFrameExtensions
    {
        internal static Type extGetDeclaringType(this StackFrame ioStackFrame)
        {
            return ioStackFrame.GetMethod().DeclaringType;
        }

        internal static string extGetNamespace(this StackFrame ioStackFrame)
        {
            Type mType = extGetDeclaringType(ioStackFrame);

            return (mType.extIsNull() ? CConst.StringEmpty : mType.Namespace);
        }

        internal static string extGetClassName(this StackFrame ioStackFrame)
        {
            Type mType = extGetDeclaringType(ioStackFrame);

            return (mType.extIsNull() ? CConst.StringEmpty : mType.Name);
        }

        internal static string extGetMethodName(this StackFrame ioStackFrame)
        {
            return ioStackFrame.GetMethod().Name;
        }

        internal static ParameterInfo[] extGetParameters(this StackFrame ioStackFrame)
        {
            return ioStackFrame.GetMethod().GetParameters();
        }

        internal static string[] extGetParametersNames(this StackFrame ioStackFrame)
        {
            ParameterInfo[] mParameterInfos = extGetParameters(ioStackFrame);

            return Array.ConvertAll(mParameterInfos, mParameterInfo => mParameterInfo.Name);
        }

        //TODO:
        //internal static string extGetFullMethodName(this StackFrame ioStackFrame)
        //{
        //    return string.Format("{0}({1})", extGetMethodName(ioStackFrame), string.Join(",", extGetParametersNames(ioStackFrame)));
        //}
    }
}
