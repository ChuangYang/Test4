using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Deployment.Application;
using System.Diagnostics.Contracts;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
using GNAy.CSharp.Base.Internal.L1_TupleExtensions;
using GNAy.CSharp.Base.Internal.L3_ProcessHelper;
#endregion

#region Set the aliases.
using CL0StaticToolbox = GNAy.CSharp.Base.Internal.L0_StaticToolbox.CStaticToolbox;
#endregion

namespace GNAy.CSharp.Base.Internal.L4_StaticToolbox
{
    [Pure]
    internal static class CStaticToolbox
    {
        #region Fields and properties.
        private static readonly Tuple<Version, string> fAppVersion;
        private static readonly string fAppVersionString;
        #endregion

        #region Singleton, factory or constructor.
        static CStaticToolbox()
        {
            fAppVersion = null;
            fAppVersionString = fAppVersion.extGetVersionString();

            try
            {
                Version mVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;

                fAppVersion = new Tuple<Version, string>(mVersion, mVersion.ToString());
            }
            catch //(Exception mException)
            { }
            finally
            { }

            if (fAppVersion.extIsNull())
            {
                fAppVersion = CProcessHelper.GetProcessVersion();
            }

            if (fAppVersion.extIsNull())
            {
                Version mVersion = CL0StaticToolbox.GetLibraryVersion();

                fAppVersion = new Tuple<Version, string>(mVersion, (fAppVersionString = mVersion.ToString()));
            }
            else
            {
                fAppVersionString = fAppVersion.extGetVersionString();
            }
        }
        #endregion

        #region Methods.
        internal static Tuple<Version, string> GetAppVersion()
        {
            return fAppVersion;
        }

        internal static string GetAppVersionString()
        {
            return fAppVersionString;
        }
        #endregion
    }
}
