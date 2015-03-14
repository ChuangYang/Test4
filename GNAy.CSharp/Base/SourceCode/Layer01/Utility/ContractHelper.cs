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
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L1_ContractHelper
{
    [Pure]
    internal static class CContractHelper
    {
        internal static bool extRequire(this bool iCondition)
        {
            Contract.Requires(iCondition, CErrorMessage.ConditionIsFalse);

            return iCondition;
        }

        internal static Tuple<bool, T> extRequire<T>(this Tuple<bool, T> iSource)
        {
            Contract.Requires(iSource.Item1, CErrorMessage.ConditionIsFalse);

            return iSource;
        }

        internal static bool extRequireFalse(this bool iCondition)
        {
            Contract.Requires(iCondition.Equals(false), CErrorMessage.ConditionIsTrue);

            return iCondition;
        }

        internal static Tuple<bool, T> extRequireFalse<T>(this Tuple<bool, T> iSource)
        {
            Contract.Requires(!iSource.Item1, CErrorMessage.ConditionIsTrue);

            return iSource;
        }

        internal static void extRequireOrThrow<TException>(this bool iCondition, TException ioException) where TException : Exception, new()
        {
            if (extRequire(iCondition))
            {
                return;
            }

            throw (Activator.CreateInstance(typeof(TException), ioException.StackTrace, ioException) as TException);
        }

        internal static void extRequireOrThrow<TException>(this bool iCondition) where TException : Exception, new()
        {
            if (extRequire(iCondition))
            {
                return;
            }

            throw (Activator.CreateInstance(typeof(TException), CErrorMessage.ConditionIsFalse) as TException);
        }

        internal static void extRequireOrThrow<TException>(this bool iCondition, string iExceptionMessage) where TException : Exception, new()
        {
            if (extRequire(iCondition))
            {
                return;
            }

            throw (Activator.CreateInstance(typeof(TException), (string.IsNullOrWhiteSpace(iExceptionMessage) ? CErrorMessage.ConditionIsFalse : iExceptionMessage)) as TException);
        }

        internal static void extRequireFalseOrThrow<TException>(this bool iCondition, TException ioException) where TException : Exception, new()
        {
            if (!extRequireFalse(iCondition))
            {
                return;
            }

            throw (Activator.CreateInstance(typeof(TException), ioException.StackTrace, ioException) as TException);
        }

        internal static void extRequireFalseOrThrow<TException>(this bool iCondition) where TException : Exception, new()
        {
            if (!extRequireFalse(iCondition))
            {
                return;
            }

            throw (Activator.CreateInstance(typeof(TException), CErrorMessage.ConditionIsTrue) as TException);
        }

        internal static void extRequireFalseOrThrow<TException>(this bool iCondition, string iExceptionMessage) where TException : Exception, new()
        {
            if (!extRequireFalse(iCondition))
            {
                return;
            }

            throw (Activator.CreateInstance(typeof(TException), (string.IsNullOrWhiteSpace(iExceptionMessage) ? CErrorMessage.ConditionIsTrue : iExceptionMessage)) as TException);
        }
    }
}
