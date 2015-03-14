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
#endregion

#region Set the aliases.
using CL1ContractHelper = GNAy.CSharp.Base.Internal.L1_ContractHelper.CContractHelper;
#endregion

namespace GNAy.CSharp.Base.Utility.ContractHelper
{
    /// <summary>
    /// ContractHelper
    /// </summary>
    [Pure]
    public static class CContractHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCondition"></param>
        /// <returns></returns>
        public static bool extRequire(this bool iCondition)
        {
            return CL1ContractHelper.extRequire(iCondition);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCondition"></param>
        /// <returns></returns>
        public static bool extRequireFalse(this bool iCondition)
        {
            return CL1ContractHelper.extRequireFalse(iCondition);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="iCondition"></param>
        /// <param name="ioException"></param>
        public static void extRequireOrThrow<TException>(this bool iCondition, TException ioException) where TException : Exception, new()
        {
            CL1ContractHelper.extRequireOrThrow<TException>(iCondition, ioException);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="iCondition"></param>
        /// <param name="iExceptionMessage"></param>
        public static void extRequireOrThrow<TException>(this bool iCondition, string iExceptionMessage = null) where TException : Exception, new()
        {
            CL1ContractHelper.extRequireOrThrow<TException>(iCondition, iExceptionMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="iCondition"></param>
        /// <param name="ioException"></param>
        public static void extRequireFalseOrThrow<TException>(this bool iCondition, TException ioException) where TException : Exception, new()
        {
            CL1ContractHelper.extRequireFalseOrThrow<TException>(iCondition, ioException);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="iCondition"></param>
        /// <param name="iExceptionMessage"></param>
        public static void extRequireFalseOrThrow<TException>(this bool iCondition, string iExceptionMessage = null) where TException : Exception, new()
        {
            CL1ContractHelper.extRequireFalseOrThrow<TException>(iCondition, iExceptionMessage);
        }
    }
}
