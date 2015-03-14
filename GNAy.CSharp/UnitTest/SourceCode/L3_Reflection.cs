using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#region .NET Framework namespace.
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Reflection;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
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
    public class CReflection
    {
        #region Fields and properties.
        private static string fContractFailedMessage;
        #endregion

        #region Singleton, factory or constructor.
        static CReflection()
        {
            fContractFailedMessage = CConst.StringEmpty;

            Contract.ContractFailed += ContractFailed;
        }

        /// <summary>
        /// 
        /// </summary>
        public CReflection()
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
        public void GetMethods()
        {
            //arrange
            MethodInfo[] mArgument1 = null;
            bool mActual1 = true;

            //act
            mArgument1 = typeof(CObjectExtensions).GetMethods();

            mActual1 = mArgument1.extIsNull();

            //[Boolean extIsNotNull[T](T)][True][True]
            //[Boolean extIsNull[T](T)][True][True]
            //[Boolean extEquals[T,U](T, U)][True][True]
            //[Boolean extNotEquals[T,U](T, U)][True][True]
            //[System.String extToString[T](T, Boolean)][True][True]
            //[System.String extToStringPool[T](T)][True][True]
            //[Void extGetHashCode[T](T, Int32 ByRef)][True][True]
            //[Int32 extGetHashCode[T](T, Int32)][True][True]
            //[System.String ToString()][False][False]
            //[Boolean Equals(System.Object)][False][False]
            //[Int32 GetHashCode()][False][False]
            //[System.Type GetType()][False][False]
            foreach (MethodInfo mMethodInfo in mArgument1)
            {
                Trace.WriteLine(string.Format("[{0}][{1}][{2}]", mMethodInfo, mMethodInfo.IsGenericMethod, mMethodInfo.IsGenericMethodDefinition));
            }

            //assert
            fContractFailedMessage = CConst.StringEmpty;
            mActual1.extRequireFalse();
            string.IsNullOrEmpty(fContractFailedMessage).extRequireOrThrow<AssertFailedException>(fContractFailedMessage);
        }
        #endregion
    }
}
