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
using GNAy.CSharp.Base.Internal.L0_StaticToolbox;
using GNAy.CSharp.Base.Internal.L1_ContractHelper;
using GNAy.CSharp.Base.Internal.L1_DateTimeHelper;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L2_SequentialKeyGenerator
{
    [Pure]
    internal static class CSequentialKeyGenerator
    {
        #region Fields and properties.
        private static bool fIsSet;

        private static ENumeric.Enum fUniqueKeyType;
        private static bool fIsDefinedUniqueKeyType;

        private static int fUniqueIntBegin;
        private static long fUniqueLongBegin;

        private static readonly object fUniqueInt_SyncRoot;
        private static int fUniqueInt;

        private static readonly object fUniqueLong_SyncRoot;
        private static long fUniqueLong;

        private static readonly object fUniqueTime_SyncRoot;
        #endregion

        #region Singleton, factory or constructor.
        static CSequentialKeyGenerator()
        {
            fIsSet = false;

            //fUniqueKeyType = (ENumeric.Enum)CConst.NotFound;
            fIsDefinedUniqueKeyType = Enum.IsDefined(fUniqueKeyType.GetType(), fUniqueKeyType);

            fUniqueIntBegin = 1;
            fUniqueLongBegin = 1;

            fUniqueInt_SyncRoot = new object();
            fUniqueInt = GetUniqueIntBegin();

            fUniqueLong_SyncRoot = new object();
            fUniqueLong = GetUniqueLongBegin();

            fUniqueTime_SyncRoot = new object();
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
        /// <param name="iUniqueKeyType"></param>
        internal static void Set(ENumeric.Enum iUniqueKeyType)
        {
            IsSet().extRequireFalseOrThrow<SystemException>();

            fIsSet = true;

            fUniqueKeyType = iUniqueKeyType;
            fIsDefinedUniqueKeyType = Enum.IsDefined(fUniqueKeyType.GetType(), fUniqueKeyType);
        }

        /// <summary>
        /// Only for internal.
        /// </summary>
        /// <param name="iUniqueIntBegin"></param>
        internal static void Set(int iUniqueIntBegin)
        {
            IsSet().extRequireFalseOrThrow<SystemException>();

            fIsSet = true;

            fUniqueKeyType = ENumeric.Enum.Int32;
            fIsDefinedUniqueKeyType = Enum.IsDefined(fUniqueKeyType.GetType(), fUniqueKeyType);

            fUniqueIntBegin = iUniqueIntBegin;
        }

        /// <summary>
        /// Only for internal.
        /// </summary>
        /// <param name="iUniqueLongBegin"></param>
        internal static void Set(long iUniqueLongBegin)
        {
            IsSet().extRequireFalseOrThrow<SystemException>();

            fIsSet = true;

            fUniqueKeyType = ENumeric.Enum.Int64;
            fIsDefinedUniqueKeyType = Enum.IsDefined(fUniqueKeyType.GetType(), fUniqueKeyType);

            fUniqueLongBegin = iUniqueLongBegin;
        }

        internal static ENumeric.Enum GetUniqueKeyType()
        {
            return fUniqueKeyType;
        }

        internal static int GetUniqueIntBegin()
        {
            return fUniqueIntBegin;
        }

        internal static long GetUniqueLongBegin()
        {
            return fUniqueLongBegin;
        }

        internal static int GetUniqueInt()
        {
            lock (fUniqueInt_SyncRoot)
            {
                return fUniqueInt++;
            }
        }

        internal static long GetUniqueLong()
        {
            lock (fUniqueLong_SyncRoot)
            {
                return fUniqueLong++;
            }
        }

        internal static DateTime GetUniqueTime()
        {
            lock (fUniqueTime_SyncRoot)
            {
                CStaticToolbox.ThreadMinSleep();

                return CDateTimeHelper.GetNow();
            }
        }

        internal static long GetUniqueTicks()
        {
            return GetUniqueTime().Ticks;
        }

        internal static int GetUniqueIntWithChecking()
        {
            (!fIsDefinedUniqueKeyType || (GetUniqueKeyType() == ENumeric.Enum.Int32)).extRequireOrThrow<SystemException>();

            return GetUniqueInt();
        }

        internal static long GetUniqueLongWithChecking()
        {
            (!fIsDefinedUniqueKeyType || (GetUniqueKeyType() == ENumeric.Enum.Int64)).extRequireOrThrow<SystemException>();

            return GetUniqueLong();
        }

        internal static DateTime GetUniqueTimeWithChecking()
        {
            (!fIsDefinedUniqueKeyType || (GetUniqueKeyType() == ENumeric.Enum.DateTime)).extRequireOrThrow<SystemException>();

            return GetUniqueTime();
        }

        internal static long GetUniqueTicksWithChecking()
        {
            return GetUniqueTimeWithChecking().Ticks;
        }
        #endregion
    }
}
