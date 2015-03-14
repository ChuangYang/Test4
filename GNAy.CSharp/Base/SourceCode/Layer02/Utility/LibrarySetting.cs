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
using GNAy.CSharp.Base.Enumeration;
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
using GNAy.CSharp.Base.Internal.L1_ContractHelper;
using GNAy.CSharp.Base.Internal.L1_EnumerableExtensions;
using GNAy.CSharp.Base.Internal.L1_ProcessHelper;
#endregion

#region Set the aliases.
using CL0ProcessHelper = GNAy.CSharp.Base.Internal.L0_ProcessHelper.CProcessHelper;
#endregion

namespace GNAy.CSharp.Base.Internal.L2_LibrarySetting
{
    [Pure]
    internal static class CLibrarySetting
    {
        #region Fields and properties.
        private static bool fIsSet;

        private static bool fComVisible;

        private static int fProcessCountLimit;

        private static string fSeparatorHead;
        private static string fSeparatorTail;
        private static string fSeparator;
        private static string fBucket;

        private static int fStackFramesMax;

        private static bool fThrowUnhandledException;
        private static EExceptionFormat.Enum fExceptionFormatCollection;

        private static bool fStartsWithUnitTest;
        #endregion

        #region Singleton, factory or constructor.
        static CLibrarySetting()
        {
            fIsSet = false;

            fComVisible = true;

            fProcessCountLimit = CConst.Infinite;

            fSeparatorHead = "[";
            fSeparatorTail = "]";
            fSeparator = string.Intern(string.Format("{0}{1}", fSeparatorTail, fSeparatorHead)); //"]["
            fBucket = string.Intern(string.Format("{0}{1}{2}", fSeparatorHead, CConst.FormatInitial, fSeparatorTail)); //"[{0}]"

            fStackFramesMax = (16 - 1);

            fThrowUnhandledException = true;
            fExceptionFormatCollection = (EExceptionFormat.Enum.Time |
                                          EExceptionFormat.Enum.Type |
                                          EExceptionFormat.Enum.Message |
                                          EExceptionFormat.Enum.ResponseString |
                                          EExceptionFormat.Enum.HelpLink |
                                          EExceptionFormat.Enum.ResponseUri |
                                          EExceptionFormat.Enum.StackTrace);

            fStartsWithUnitTest = true;
        }
        #endregion

        #region Methods.
        internal static bool IsSet()
        {
            return fIsSet;
        }

        /// <summary>
        /// Only for internal.
        /// </summary>
        /// <param name="iComVisible"></param>
        /// <param name="iProcessCountLimit"></param>
        /// <param name="iSeparatorHead"></param>
        /// <param name="iSeparatorTail"></param>
        /// <param name="iStackFramesMax"></param>
        /// <param name="iThrowUnhandledException"></param>
        /// <param name="iExceptionFormatCollection"></param>
        /// <param name="iStartsWithUnitTest"></param>
        [ContractVerification(false)]
        internal static void Set(
            bool iComVisible,
            int iProcessCountLimit,
            string iSeparatorHead,
            string iSeparatorTail,
            int iStackFramesMax,
            bool iThrowUnhandledException,
            EExceptionFormat.Enum iExceptionFormatCollection,
            bool iStartsWithUnitTest
            )
        {
            IsSet().extRequireFalseOrThrow<SystemException>();
            fIsSet = true;

            fComVisible = iComVisible;

            if ((fProcessCountLimit = iProcessCountLimit) >= CConst.Zero)
            {
                if (CL0ProcessHelper.GetProcessCount() > GetProcessCountLimit())
                {
                    CL0ProcessHelper.GetCurrentProcess().extCloseOrKill(5 * 1000);
                }
            }

            fSeparatorHead = string.Intern((iSeparatorHead.extIsNull() ? CConst.StringEmpty : iSeparatorHead));
            fSeparatorTail = string.Intern((iSeparatorTail.extIsNull() ? CConst.StringEmpty : iSeparatorTail));
            fSeparator = string.Intern(string.Format("{0}{1}", GetSeparatorTail(), GetSeparatorHead()));

            fBucket = string.Intern((
                (string.IsNullOrWhiteSpace(GetSeparatorHead()) || GetSeparatorTail().Contains(CConst.NewLine)) ?
                CConst.FormatInitial :
                string.Format("{0}{1}{2}", GetSeparatorHead(), CConst.FormatInitial, GetSeparatorTail())
                ));

            if (iStackFramesMax >= CConst.StartIndex)
            {
                fStackFramesMax = iStackFramesMax;
            }

            fThrowUnhandledException = iThrowUnhandledException;

            if (iExceptionFormatCollection > CConst.StartIndex)
            {
                fExceptionFormatCollection = iExceptionFormatCollection;
            }

            fStartsWithUnitTest = iStartsWithUnitTest;
        }

        internal static bool IsComVisible()
        {
            return fComVisible;
        }

        internal static int GetProcessCountLimit()
        {
            return fProcessCountLimit;
        }

        internal static string GetSeparatorHead()
        {
            return fSeparatorHead;
        }

        internal static string GetSeparatorTail()
        {
            return fSeparatorTail;
        }

        internal static string GetSeparator()
        {
            return fSeparator;
        }

        internal static string GetBucket()
        {
            return fBucket;
        }

        internal static int GetStackFramesMax()
        {
            return fStackFramesMax;
        }

        internal static bool ThrowUnhandledException()
        {
            return fThrowUnhandledException;
        }

        internal static EExceptionFormat.Enum GetExceptionFormatCollection()
        {
            return fExceptionFormatCollection;
        }

        internal static bool StartsWithUnitTest()
        {
            return fStartsWithUnitTest;
        }
        #endregion
    }
}
