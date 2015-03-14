using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Reflection;
using System.Threading;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L0_StaticToolbox
{
    [Pure]
    internal static class CStaticToolbox
    {
        #region Fields and properties.
        private static readonly Assembly fDotNetCoreAssembly;
        private static readonly FileInfo fDotNetCoreFileInfo;
        private static readonly Configuration fDotNetCoreConfiguration;
        private static readonly DirectoryInfo fDotNetDirectoryInfo;
        private static readonly Version fDotNetCoreVersion;

        private static readonly Assembly fLibraryAssembly;
        private static readonly FileInfo fLibraryFileInfo;
        private static readonly Configuration fLibraryConfiguration;
        private static readonly DirectoryInfo fLibraryDirectoryInfo;
        private static readonly Version fLibraryVersion;

        private static readonly TimeSpan fMinTimeUnit;
        #endregion

        #region Singleton, factory or constructor.
        static CStaticToolbox()
        {
            fDotNetCoreAssembly = typeof(object).Assembly;
            fDotNetCoreFileInfo = new FileInfo(GetDotNetCoreAssembly().Location);
            fDotNetCoreConfiguration = ConfigurationManager.OpenExeConfiguration(GetDotNetCoreFileInfo().FullName);
            fDotNetDirectoryInfo = GetDotNetCoreFileInfo().Directory;
            fDotNetCoreVersion = new Version(FileVersionInfo.GetVersionInfo(GetDotNetCoreFileInfo().FullName).FileVersion);

            //fLibraryAssembly.Location == "C:\Visual Studio Projects\LanguageSpread.CSharp.beta2\LanguageSpread.CSharp.TestWindow\bin\Release\LanguageSpread.CSharp.dll"
            fLibraryAssembly = Assembly.GetExecutingAssembly();
            fLibraryFileInfo = new FileInfo(GetLibraryAssembly().Location);
            fLibraryConfiguration = ConfigurationManager.OpenExeConfiguration(GetLibraryFileInfo().FullName);
            fLibraryDirectoryInfo = GetLibraryFileInfo().Directory;
            fLibraryVersion = new Version(FileVersionInfo.GetVersionInfo(GetLibraryFileInfo().FullName).FileVersion);

            fMinTimeUnit = new TimeSpan(1); //0.0001 millisecond.
        }
        #endregion

        #region Methods.
        internal static Assembly GetDotNetCoreAssembly()
        {
            return fDotNetCoreAssembly;
        }

        internal static FileInfo GetDotNetCoreFileInfo()
        {
            return fDotNetCoreFileInfo;
        }

        internal static Configuration GetDotNetCoreConfiguration()
        {
            return fDotNetCoreConfiguration;
        }

        internal static DirectoryInfo GetDotNetDirectoryInfo()
        {
            return fDotNetDirectoryInfo;
        }

        internal static Version GetDotNetCoreVersion()
        {
            return fDotNetCoreVersion;
        }

        internal static Assembly GetLibraryAssembly()
        {
            return fLibraryAssembly;
        }

        internal static FileInfo GetLibraryFileInfo()
        {
            return fLibraryFileInfo;
        }

        internal static Configuration GetLibraryConfiguration()
        {
            return fLibraryConfiguration;
        }

        internal static DirectoryInfo GetLibraryDirectoryInfo()
        {
            return fLibraryDirectoryInfo;
        }

        internal static Version GetLibraryVersion()
        {
            return fLibraryVersion;
        }

        /// <summary>
        /// 0.0001 millisecond.
        /// </summary>
        /// <returns></returns>
        internal static TimeSpan GetMinTimeUnit()
        {
            return fMinTimeUnit;
        }

        /// <summary>
        /// 0.0001 millisecond.
        /// </summary>
        internal static void ThreadMinSleep()
        {
            //Thread.ThreadSleep(GetMinTimeUnit);
            SpinWait.SpinUntil(() => false, GetMinTimeUnit());
        }

        internal static void ThreadSleep(int iMilliseconds)
        {
            SpinWait.SpinUntil(() => false, iMilliseconds);
        }

        internal static void ThreadSleep(TimeSpan iTimeout)
        {
            SpinWait.SpinUntil(() => false, iTimeout);
        }
        #endregion
    }
}
