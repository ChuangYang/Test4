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
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L0_ProcessHelper
{
    [Pure]
    internal static class CProcessHelper
    {
        #region Fields and properties.
        private static readonly Process fCurrentProcess;

        private static readonly Assembly fProcessAssembly;
        private static readonly FileInfo fProcessFileInfo;
        private static readonly Configuration fProcessConfiguration;
        private static readonly DirectoryInfo fProcessDirectoryInfo;
        #endregion

        #region Singleton, factory or constructor.
        static CProcessHelper()
        {
            fCurrentProcess = Process.GetCurrentProcess();

            //fProcessAssembly.Location == "C:\Visual Studio Projects\LanguageSpread.CSharp.beta2\LanguageSpread.CSharp.TestWindow\bin\Release\LanguageSpread.CSharp.TestWindow.exe"
            fProcessAssembly = Assembly.LoadFile(extGetProcessFilePath(GetCurrentProcess()));
            fProcessFileInfo = new FileInfo(GetProcessAssembly().Location);
            fProcessConfiguration = ConfigurationManager.OpenExeConfiguration(GetProcessFileInfo().FullName);
            fProcessDirectoryInfo = GetProcessFileInfo().Directory;
        }
        #endregion

        #region Methods.
        internal static Process GetCurrentProcess()
        {
            return fCurrentProcess;
        }

        internal static Assembly GetProcessAssembly()
        {
            return fProcessAssembly;
        }

        internal static FileInfo GetProcessFileInfo()
        {
            return fProcessFileInfo;
        }

        internal static Configuration GetProcessConfiguration()
        {
            return fProcessConfiguration;
        }

        internal static DirectoryInfo GetProcessDirectoryInfo()
        {
            return fProcessDirectoryInfo;
        }

        internal static string extGetProcessFilePath(this Process ioProcess)
        {
            return ioProcess.MainModule.FileName;
        }

        internal static Assembly extGetProcessAssembly(this Process ioProcess)
        {
            return Assembly.LoadFile(extGetProcessFilePath(ioProcess));
        }

        internal static FileInfo extGetProcessFileInfo(this Process ioProcess)
        {
            return new FileInfo(extGetProcessFilePath(ioProcess));
        }

        internal static Configuration extGetProcessConfiguration(this Process ioProcess)
        {
            return ConfigurationManager.OpenExeConfiguration(extGetProcessFilePath(ioProcess));
        }

        internal static DirectoryInfo extGetProcessDirectoryInfo(this Process ioProcess)
        {
            return extGetProcessFileInfo(ioProcess).Directory;
        }

        internal static int extGetProcessCount(this string iProcessName)
        {
            Process[] mProcesses = Process.GetProcessesByName(iProcessName);

            foreach (Process mProcess in mProcesses)
            {
                mProcess.Dispose();
            }

            return mProcesses.Length;
        }

        internal static int extGetProcessCount(this Process ioProcess)
        {
            Process[] mProcesses = Process.GetProcessesByName(ioProcess.ProcessName);

            foreach (Process mProcess in mProcesses)
            {
                if (mProcess.Id == ioProcess.Id)
                {
                    continue;
                }

                mProcess.Dispose();
            }

            return mProcesses.Length;
        }

        internal static int GetProcessCount()
        {
            Process mProcess = GetCurrentProcess();
            string mProcessName = mProcess.ProcessName;

            mProcess.Dispose();

            return extGetProcessCount(mProcessName);
        }

        internal static bool extIsSingleInstance(this string iProcessName)
        {
            return (extGetProcessCount(iProcessName) == 1);
        }

        internal static bool extIsSingleInstance(this Process ioProcess)
        {
            return (extGetProcessCount(ioProcess) == 1);
        }

        internal static bool IsSingleInstance()
        {
            return (GetProcessCount() == 1);
        }
        #endregion
    }
}
