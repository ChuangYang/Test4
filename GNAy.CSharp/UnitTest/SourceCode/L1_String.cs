using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#region .NET Framework namespace.
using System.Diagnostics;
using System.Diagnostics.Contracts;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
using GNAy.CSharp.Base.Utility.ContractHelper;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.UnitTest
{
    /// <summary>
    /// String
    /// </summary>
    [TestClass]
    [Pure]
    public class CString
    {
        #region Fields and properties.
        private static string fContractFailedMessage;
        #endregion

        #region Singleton, factory or constructor.
        static CString()
        {
            fContractFailedMessage = CConst.StringEmpty;

            Contract.ContractFailed += ContractFailed;
        }

        /// <summary>
        /// 
        /// </summary>
        public CString()
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
        public void StringEquals1()
        {
            //arrange
            Stopwatch mArgument1 = new Stopwatch();
            long mArgument2 = CConst.StartIndex;
            long mArgument3 = CConst.StartIndex;
            long mArgument4 = CConst.StartIndex;
            string mArgument5 = DateTime.Now.ToString();
            string mArgument6 = null;
            bool mActual1 = false; //mArgument4 < mArgument3
            bool mActual2 = false; //mArgument4 < mArgument2

            //act
            mArgument1.Restart();
            for (int i = CConst.StartIndex; i < (100 * 1000 * 1000); i++)
            {
                if (mArgument5 == mArgument6)
                { }
            }
            mArgument1.Stop();
            mArgument2 = mArgument1.ElapsedMilliseconds;

            mArgument1.Restart();
            for (int i = CConst.StartIndex; i < (100 * 1000 * 1000); i++)
            {
                if (mArgument5.Equals(mArgument6))
                { }
            }
            mArgument1.Stop();
            mArgument3 = mArgument1.ElapsedMilliseconds;

            mArgument1.Restart();
            for (int i = CConst.StartIndex; i < (100 * 1000 * 1000); i++)
            {
                if (object.ReferenceEquals(mArgument5, mArgument6))
                { }
            }
            mArgument1.Stop();
            mArgument4 = mArgument1.ElapsedMilliseconds;

            Trace.WriteLine(mArgument4);
            Trace.WriteLine(mArgument3);
            Trace.WriteLine(mArgument2);

            mActual1 = (mArgument4 < mArgument3);
            mActual2 = (mArgument4 < mArgument2);

            //assert
            fContractFailedMessage = CConst.StringEmpty;
            mActual1.extRequire();
            mActual2.extRequire();
            string.IsNullOrEmpty(fContractFailedMessage).extRequireOrThrow<AssertFailedException>(fContractFailedMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void StringEquals2()
        {
            //arrange
            Stopwatch mArgument1 = new Stopwatch();
            long mArgument2 = CConst.StartIndex;
            long mArgument3 = CConst.StartIndex;
            long mArgument4 = CConst.StartIndex;
            string mArgument5 = Process.GetCurrentProcess().ProcessName;
            string mArgument6 = mArgument5;
            bool mActual1 = false; //mArgument5 == mArgument6
            bool mActual2 = false; //mArgument5.Equals(mArgument6)
            bool mActual3 = false; //object.ReferenceEquals(mArgument5, mArgument6)
            bool mActual4 = false; //mArgument4 < mArgument3
            bool mActual5 = false; //mArgument4 < mArgument2

            //act
            mArgument1.Restart();
            for (int i = CConst.StartIndex; i < (100 * 1000 * 1000); i++)
            {
                if (mArgument5 == mArgument6)
                { }
            }
            mArgument1.Stop();
            mArgument2 = mArgument1.ElapsedMilliseconds;

            mArgument1.Restart();
            for (int i = CConst.StartIndex; i < (100 * 1000 * 1000); i++)
            {
                if (mArgument5.Equals(mArgument6))
                { }
            }
            mArgument1.Stop();
            mArgument3 = mArgument1.ElapsedMilliseconds;

            mArgument1.Restart();
            for (int i = CConst.StartIndex; i < (100 * 1000 * 1000); i++)
            {
                if (object.ReferenceEquals(mArgument5, mArgument6))
                { }
            }
            mArgument1.Stop();
            mArgument4 = mArgument1.ElapsedMilliseconds;

            Trace.WriteLine(mArgument4);
            Trace.WriteLine(mArgument3);
            Trace.WriteLine(mArgument2);

            mActual1 = (mArgument5 == mArgument6);
            mActual2 = mArgument5.Equals(mArgument6);
            mActual3 = object.ReferenceEquals(mArgument5, mArgument6);

            mActual4 = (mArgument4 < mArgument3);
            mActual5 = (mArgument4 < mArgument2);

            //assert
            fContractFailedMessage = CConst.StringEmpty;
            mActual1.extRequire();
            mActual2.extRequire();
            mActual3.extRequire();
            mActual4.extRequire();
            mActual5.extRequire();
            string.IsNullOrEmpty(fContractFailedMessage).extRequireOrThrow<AssertFailedException>(fContractFailedMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void StringEquals3()
        {
            //arrange
            Stopwatch mArgument1 = new Stopwatch();
            long mArgument2 = CConst.StartIndex;
            long mArgument3 = CConst.StartIndex;
            long mArgument4 = CConst.StartIndex;
            Process mArgument5 = Process.GetCurrentProcess();
            string mArgument6 = mArgument5.ProcessName;
            string mArgument7 = mArgument5.ProcessName;
            bool mActual1 = false; //mArgument6 == mArgument7
            bool mActual2 = false; //mArgument6.Equals(mArgument7)
            bool mActual3 = false; //object.ReferenceEquals(mArgument6, mArgument7)
            bool mActual4 = false; //mArgument4 < mArgument3
            bool mActual5 = false; //mArgument4 < mArgument2

            //act
            mArgument1.Restart();
            for (int i = CConst.StartIndex; i < (100 * 1000 * 1000); i++)
            {
                if (mArgument6 == mArgument7)
                { }
            }
            mArgument1.Stop();
            mArgument2 = mArgument1.ElapsedMilliseconds;

            mArgument1.Restart();
            for (int i = CConst.StartIndex; i < (100 * 1000 * 1000); i++)
            {
                if (mArgument6.Equals(mArgument7))
                { }
            }
            mArgument1.Stop();
            mArgument3 = mArgument1.ElapsedMilliseconds;

            mArgument1.Restart();
            for (int i = CConst.StartIndex; i < (100 * 1000 * 1000); i++)
            {
                if (object.ReferenceEquals(mArgument6, mArgument7))
                { }
            }
            mArgument1.Stop();
            mArgument4 = mArgument1.ElapsedMilliseconds;

            Trace.WriteLine(mArgument4);
            Trace.WriteLine(mArgument3);
            Trace.WriteLine(mArgument2);

            mActual1 = (mArgument6 == mArgument7);
            mActual2 = mArgument6.Equals(mArgument7);
            mActual3 = object.ReferenceEquals(mArgument6, mArgument7);

            mActual4 = (mArgument4 < mArgument3);
            mActual5 = (mArgument4 < mArgument2);

            //assert
            fContractFailedMessage = CConst.StringEmpty;
            mActual1.extRequire();
            mActual2.extRequire();
            mActual3.extRequire();
            mActual4.extRequire();
            mActual5.extRequire();
            string.IsNullOrEmpty(fContractFailedMessage).extRequireOrThrow<AssertFailedException>(fContractFailedMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void StringEquals4()
        {
            //arrange
            Stopwatch mArgument1 = new Stopwatch();
            long mArgument2 = CConst.StartIndex;
            long mArgument3 = CConst.StartIndex;
            long mArgument4 = CConst.StartIndex;
            string mArgument5 = string.Intern(Process.GetCurrentProcess().ProcessName);
            string mArgument6 = Process.GetCurrentProcess().ProcessName;
            bool mActual1 = false; //mArgument5 == mArgument6
            bool mActual2 = false; //mArgument5.Equals(mArgument6)
            bool mActual3 = true; //object.ReferenceEquals(mArgument5, mArgument6)
            bool mActual4 = false; //mArgument4 < mArgument3
            bool mActual5 = false; //mArgument4 < mArgument2

            //act
            mArgument1.Restart();
            for (int i = CConst.StartIndex; i < (100 * 1000 * 1000); i++)
            {
                if (mArgument5 == mArgument6)
                { }
            }
            mArgument1.Stop();
            mArgument2 = mArgument1.ElapsedMilliseconds;

            mArgument1.Restart();
            for (int i = CConst.StartIndex; i < (100 * 1000 * 1000); i++)
            {
                if (mArgument5.Equals(mArgument6))
                { }
            }
            mArgument1.Stop();
            mArgument3 = mArgument1.ElapsedMilliseconds;

            mArgument1.Restart();
            for (int i = CConst.StartIndex; i < (100 * 1000 * 1000); i++)
            {
                if (object.ReferenceEquals(mArgument5, mArgument6))
                { }
            }
            mArgument1.Stop();
            mArgument4 = mArgument1.ElapsedMilliseconds;

            Trace.WriteLine(mArgument4);
            Trace.WriteLine(mArgument3);
            Trace.WriteLine(mArgument2);

            mActual1 = (mArgument5 == mArgument6);
            mActual2 = mArgument5.Equals(mArgument6);
            mActual3 = object.ReferenceEquals(mArgument5, mArgument6);

            mActual4 = (mArgument4 < mArgument3);
            mActual5 = (mArgument4 < mArgument2);

            //assert
            fContractFailedMessage = CConst.StringEmpty;
            mActual1.extRequire();
            mActual2.extRequire();
            mActual3.extRequireFalse();
            mActual4.extRequire();
            mActual5.extRequire();
            string.IsNullOrEmpty(fContractFailedMessage).extRequireOrThrow<AssertFailedException>(fContractFailedMessage);
        }
        #endregion
    }
}
