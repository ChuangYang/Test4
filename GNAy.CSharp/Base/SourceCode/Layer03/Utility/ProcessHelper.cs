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
using GNAy.CSharp.Base.Internal.L1_TupleExtensions;
using GNAy.CSharp.Base.Internal.L2_StringExtensions;
#endregion

#region Set the aliases.
using CL0ProcessHelper = GNAy.CSharp.Base.Internal.L0_ProcessHelper.CProcessHelper;
#endregion

namespace GNAy.CSharp.Base.Internal.L3_ProcessHelper
{
    [Pure]
    internal static class CProcessHelper
    {
        #region Fields and properties.
        private static readonly Tuple<Version, string> fProcessVersion;
        private static readonly string fProcessVersionString;
        #endregion

        #region Singleton, factory or constructor.
        static CProcessHelper()
        {
            fProcessVersion = CL0ProcessHelper.GetProcessFileInfo().FullName.extTryToGetVersion();
            fProcessVersionString = fProcessVersion.extGetVersionString();
        }
        #endregion

        #region Methods.
        internal static Tuple<Version, string> GetProcessVersion()
        {
            return fProcessVersion;
        }

        internal static string GetProcessVersionString()
        {
            return fProcessVersionString;
        }
        #endregion
    }
}
