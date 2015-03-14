using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#region .NET Framework namespace.
using System.Collections;
using System.Diagnostics;
using System.Diagnostics.Contracts;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
using GNAy.CSharp.Base.Enumeration;
using GNAy.CSharp.Base.Spread.ObjectExtensions;
using GNAy.CSharp.Base.Utility.ContractHelper;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.UnitTest
{
    /// <summary>
    /// Sample
    /// </summary>
    [TestClass]
    [Pure]
    public class CSample
    {
        #region Fields and properties.
        private static string fContractFailedMessage;
        #endregion

        #region Singleton, factory or constructor.
        static CSample()
        {
            fContractFailedMessage = CConst.StringEmpty;

            Contract.ContractFailed += ContractFailed;
        }

        /// <summary>
        /// 
        /// </summary>
        public CSample()
        { }
        #endregion

        #region Methods.
        private static void ContractFailed(object ioSender, ContractFailedEventArgs ioEventArgs)
        {
            Trace.WriteLine(fContractFailedMessage = ioEventArgs.Message);

            ioEventArgs.SetHandled();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ContractRequiring()
        {
            //arrange
            int mArgument1 = 1;
            int mArgument2 = 2;
            int mActual1 = CConst.Zero;

            //act
            mActual1 = (mArgument1 + mArgument2);

            //assert
            fContractFailedMessage = CConst.StringEmpty;
            (mActual1 < 3).extRequire();
            string.IsNullOrEmpty(fContractFailedMessage).extRequireFalseOrThrow<AssertFailedException>(fContractFailedMessage);

            fContractFailedMessage = CConst.StringEmpty;
            (mActual1 == 3).extRequire();
            string.IsNullOrEmpty(fContractFailedMessage).extRequireOrThrow<AssertFailedException>(fContractFailedMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void NumberCalculating()
        {
            //arrange
            int mArgument1 = int.MaxValue;
            int mArgument2 = int.MinValue;

            //act
            mArgument1++;
            mArgument2--;

            //assert
            fContractFailedMessage = CConst.StringEmpty;
            (mArgument1 == int.MinValue).extRequire();
            (mArgument2 == int.MaxValue).extRequire();
            string.IsNullOrEmpty(fContractFailedMessage).extRequireOrThrow<AssertFailedException>(fContractFailedMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void RemoveFlag()
        {
            //arrange
            int mArgument1 = CConst.Zero;
            int mArgument2 = CConst.Zero;

            //act
            mArgument1 = (ECommonOption.Value.WithoutChecking | ECommonOption.Value.WithoutNull | ECommonOption.Value.IgnoreCase);
            //mArgument2 = (mArgument1 & (ECommonOption.Value.WithoutNull ^ 0xFF));
            mArgument2 = (mArgument1 & ~ECommonOption.Value.WithoutNull);

            //assert
            fContractFailedMessage = CConst.StringEmpty;
            (mArgument1 == 14).extRequire();
            (mArgument2 == 10).extRequire();
            string.IsNullOrEmpty(fContractFailedMessage).extRequireOrThrow<AssertFailedException>(fContractFailedMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void IsSingleInstance()
        {
            //arrange
            Process mArgument1 = null;
            Process[] mArgument2 = null;
            bool mActual1 = false;

            //act
            using (mArgument1 = Process.GetCurrentProcess())
            {
                Trace.WriteLine(mArgument1);
                Trace.WriteLine(mArgument1.ProcessName);

                //mArgument2 = Process.GetProcessesByName("mspaint");
                mArgument2 = Process.GetProcessesByName(mArgument1.ProcessName);

                mActual1 = ((mArgument2.Length == 1) && (mArgument2[CConst.StartIndex].Id == mArgument1.Id));
            }

            //assert
            fContractFailedMessage = CConst.StringEmpty;
            mActual1.extRequire();
            string.IsNullOrEmpty(fContractFailedMessage).extRequireOrThrow<AssertFailedException>(fContractFailedMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetEnvironmentVariables()
        {
            //arrange
            IDictionary mArgument1 = null;
            bool mActual1 = true;

            //act
            mArgument1 = Environment.GetEnvironmentVariables();

            mActual1 = mArgument1.extIsNull();

            //PROCESSOR_ARCHITEW6432 = AMD64
            //COMPUTERNAME = YANG
            //CommonProgramFiles(x86) = C:\Program Files (x86)\Common Files
            //TRACKER_TOOL = 
            //ProgramFiles(x86) = C:\Program Files (x86)
            //PROCESSOR_REVISION = 3a27
            //VS100COMNTOOLS = C:\Program Files (x86)\Microsoft Visual Studio 13.0\Common7\Tools\
            //PATHEXT = .COM;.EXE;.BAT;.CMD;.VBS;.VBE;.JS;.JSE;.WSF;.WSH;.MSC
            //TRACKER_ATTACHED = 
            //TMP = C:\Users\yang\AppData\Local\Temp
            //TEMP = C:\Users\yang\AppData\Local\Temp
            //LOCALAPPDATA = C:\Users\yang\AppData\Local
            //PUBLIC = C:\Users\Public
            //VSPID = 7253
            //ProgramData = C:\ProgramData
            //USERDNSDOMAIN = GAME.COM.TW
            //USERDOMAIN = VRDOMAIN
            //Path = C:\Program Files\Common Files\Microsoft Shared\Windows Live;C:\Program Files (x86)\Common Files\Microsoft Shared\Windows Live;C:\windows\system32;C:\windows;C:\windows\System32\Wbem;C:\windows\System32\WindowsPowerShell\v1.0\;C:\Program Files (x86)\Windows Live\Shared;C:\Program Files (x86)\Intel\OpenCL SDK\2.0\bin\x86;C:\Program Files (x86)\Intel\OpenCL SDK\2.0\bin\x64;c:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn\;c:\Program Files\Microsoft SQL Server\100\Tools\Binn\;c:\Program Files\Microsoft SQL Server\100\DTS\Binn\;C:\Visual Studio Projects\LanguageSpread.CSharp.beta2\packages\Newtonsoft.Json.6.0.5\tools;C:\Visual Studio Projects\LanguageSpread.CSharp.beta2\packages\PostSharp.3.1.51\tools
            //PROCESSOR_LEVEL = 6
            //PROCESSOR_IDENTIFIER = Intel64 Family 6 Model 58 Stepping 9, GenuineIntel
            //PSModulePath = C:\Users\yang\Documents\WindowsPowerShell\Modules;C:\windows\system32\WindowsPowerShell\v1.0\Modules\
            //CommonProgramFiles = C:\Program Files (x86)\Common Files
            //HOMEPATH = \Users\yang
            //VisualStudioDir = C:\Users\yang\Documents\Visual Studio 2013
            //ProgramW6432 = C:\Program Files
            //ProgramFiles = C:\Program Files (x86)
            //FP_NO_HOST_CHECK = NO
            //NUMBER_OF_PROCESSORS = 2
            //SystemRoot = C:\windows
            //SESSIONNAME = Console
            //CommonProgramW6432 = C:\Program Files\Common Files
            //LOGONSERVER = \\SRV-MU5
            //USERPROFILE = C:\Users\yang
            //CodeContractsInstallDir = C:\Program Files (x86)\Microsoft\Contracts\
            //HOMEDRIVE = C:
            //PROCESSOR_ARCHITECTURE = x86
            //USERNAME = yang
            //APPDATA = C:\Users\yang\AppData\Roaming
            //PSExecutionPolicyPreference = RemoteSigned
            //OS = Windows_NT
            //ComSpec = C:\windows\system32\cmd.exe
            //SystemDrive = C:
            //windir = C:\windows
            //ALLUSERSPROFILE = C:\ProgramData
            foreach (object mKey in mArgument1.Keys)
            {
                Trace.WriteLine(string.Format("{0} = {1}", mKey, mArgument1[mKey]));
            }

            //assert
            fContractFailedMessage = CConst.StringEmpty;
            mActual1.extRequireFalse();
            string.IsNullOrEmpty(fContractFailedMessage).extRequireOrThrow<AssertFailedException>(fContractFailedMessage);
        }
        #endregion
    }
}
