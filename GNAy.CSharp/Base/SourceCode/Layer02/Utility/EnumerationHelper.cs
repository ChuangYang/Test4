using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Collections.Concurrent;
using System.Diagnostics.Contracts;
#endregion

#region Third party libraries.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
using GNAy.CSharp.Base.Internal.L1_CollectionTExtensions;
using GNAy.CSharp.Base.Internal.L1_NumericExtensions;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L2_EnumerationHelper
{
    /// <summary>
    /// EnumerationHelper
    /// </summary>
    [Pure]
    internal static class CEnumerationHelper
    {
        #region Fields and properties.
        /// <summary>
        /// Tuple&lt;IntValue, Name, IsDefined, Position, IsFlagEnum, Enum[], IntValue[], Name[]&gt;
        /// </summary>
        private static readonly ConcurrentDictionary<Enum, Tuple<int, string, bool, int, bool, Enum[], int[], string[]>> fCache;
        #endregion

        #region Singleton, factory or constructor.
        static CEnumerationHelper() //The CLR guarantees that the static constructor will be invoked only once for the entire lifetime of the application domain.
        {
            fCache = new ConcurrentDictionary<Enum, Tuple<int, string, bool, int, bool, Enum[], int[], string[]>>();
        }
        #endregion

        #region Methods.
        internal static int Count()
        {
            return fCache.Count;
        }

        /// <summary>
        /// Tuple&lt;IntValue, Name, IsDefined, Position, IsFlagEnum, Enum[], IntValue[], Name[]&gt;
        /// </summary>
        /// <returns></returns>
        internal static IEnumerable<KeyValuePair<Enum, Tuple<int, string, bool, int, bool, Enum[], int[], string[]>>> Watch()
        {
            foreach (KeyValuePair<Enum, Tuple<int, string, bool, int, bool, Enum[], int[], string[]>> mTarget in fCache)
            {
                yield return mTarget;
            }
        }

        internal static bool extIsFlagEnum(this Type ioType)
        {
            return (ioType.IsEnum ? ioType.GetCustomAttributes(typeof(FlagsAttribute), false).extIsNotEmpty() : false);
        }

        internal static bool extIsNotFlagEnum(this Type ioType)
        {
            return !extIsFlagEnum(ioType);
        }

        [ContractVerification(false)]
        internal static void extCacheEnum(this Type ioEnum)
        {
            Array mRawCollection = ioEnum.GetEnumValues();
            Enum[] mEnumCollection = (mRawCollection as Enum[]);

            if (fCache.ContainsKey(mEnumCollection[CConst.StartIndex]))
            {
                return;
            }

            bool mIsFlag = extIsFlagEnum(ioEnum);
            int[] mIntValueCollection = (mRawCollection as int[]);
            string[] mNameCollection = ioEnum.GetEnumNames();

            for (int i = CConst.StartIndex; i < mEnumCollection.Length; i++)
            {
                fCache[mEnumCollection[i]] = new Tuple<int, string, bool, int, bool, Enum[], int[], string[]>(
                    mIntValueCollection[i], mNameCollection[i], true, i, mIsFlag, mEnumCollection, mIntValueCollection, mNameCollection
                    );
            }
        }

        internal static void Cache<TEnum>() where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            extCacheEnum(typeof(TEnum));
        }

        private static void cacheEnum(this Type ioEnum, Enum iValue)
        {
            extCacheEnum(ioEnum);

            if (fCache.ContainsKey(iValue))
            {
                return;
            }

            Tuple<int, string, bool, int, bool, Enum[], int[], string[]> mCache = fCache[(ioEnum.GetEnumValues() as Enum[])[CConst.StartIndex]];

            fCache[iValue] = new Tuple<int, string, bool, int, bool, Enum[], int[], string[]>(
                    (int)(object)iValue, iValue.ToString(), false, CConst.NotFound, mCache.Item5, mCache.Item6, mCache.Item7, mCache.Rest
                    );
        }

        internal static void extCache(this Enum iSource)
        {
            cacheEnum(iSource.GetType(), iSource);
        }

        internal static void extCacheEnum(this Type ioEnum, int iUndefinedValue)
        {
            cacheEnum(ioEnum, (Enum.ToObject(ioEnum, iUndefinedValue) as Enum));
        }

        internal static void Cache<TEnum>(int iUndefinedValue) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            extCacheEnum(typeof(TEnum), iUndefinedValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSource"></param>
        /// <returns>Tuple&lt;IntValue, Name, IsDefined, Position, IsFlagEnum, Enum[], IntValue[], Name[]&gt;</returns>
        internal static Tuple<int, string, bool, int, bool, Enum[], int[], string[]> extGetCache(this Enum iSource)
        {
            if (fCache.ContainsKey(iSource))
            {
                return fCache[iSource];
            }

            extCache(iSource);

            return fCache[iSource];
        }

        internal static int extGetIntValue(this Enum iSource)
        {
            return extGetCache(iSource).Item1;
        }

        internal static string extToString(this Enum iSource)
        {
            return extGetCache(iSource).Item2;
        }

        internal static bool extIsDefined(this Enum iSource)
        {
            return extGetCache(iSource).Item3;
        }

        internal static bool extIsUndefined(this Enum iSource)
        {
            return !extIsDefined(iSource);
        }

        internal static int extGetPosition(this Enum iSource)
        {
            return extGetCache(iSource).Item4;
        }

        internal static bool extIsFlagEnum(this Enum iSource)
        {
            return extGetCache(iSource).Item5;
        }

        internal static bool extIsNotFlagEnum(this Enum iSource)
        {
            return !extIsFlagEnum(iSource);
        }

        internal static int extGetCount(this Enum iSource)
        {
            return extGetCache(iSource).Item6.Length;
        }

        internal static Enum[] extGetEnumCollection(this Enum iSource)
        {
            return extGetCache(iSource).Item6;
        }

        internal static int[] extGetIntValueCollection(this Enum iSource)
        {
            return extGetCache(iSource).Item7;
        }

        internal static string[] extGetNameCollection(this Enum iSource)
        {
            return extGetCache(iSource).Rest;
        }

        internal static IEnumerable<Tuple<int, string, bool, int, bool, Enum[], int[], string[]>> extForeachRecordFlag(this Enum iFlagCollection)
        {
            Tuple<int, string, bool, int, bool, Enum[], int[], string[]> mCache = extGetCache(iFlagCollection);
            if (!mCache.Item5)
            {
                yield return mCache;
            }

            int mSourceValue = mCache.Item1;

            for (int i = CConst.StartIndex; i < mCache.Item7.Length; i++)
            {
                if (mSourceValue.extHasFlag(mCache.Item7[i]))
                {
                    yield return fCache[mCache.Item6[i]];
                }
            }
        }

        internal static IEnumerable<Tuple<int, string, bool, int, bool, Enum[], int[], string[]>> extForeachRecordFlag(this int iFlagCollection, Type ioEnumType)
        {
            return extForeachRecordFlag(Enum.ToObject(ioEnumType, iFlagCollection) as Enum);
        }

        internal static IEnumerable<Tuple<int, string, bool, int, bool, Enum[], int[], string[]>> extForeachRecordFlag<TEnum>(this int iFlagCollection) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return extForeachRecordFlag(iFlagCollection, typeof(TEnum));
        }

        internal static IEnumerable<Enum> extForeachEnumFlag(this Enum iFlagCollection)
        {
            Tuple<int, string, bool, int, bool, Enum[], int[], string[]> mCache = extGetCache(iFlagCollection);
            if (!mCache.Item5)
            {
                yield return iFlagCollection;
            }

            int mSourceValue = mCache.Item1;

            for (int i = CConst.StartIndex; i < mCache.Item7.Length; i++)
            {
                if (mSourceValue.extHasFlag(mCache.Item7[i]))
                {
                    yield return mCache.Item6[i];
                }
            }
        }

        internal static IEnumerable<Enum> extForeachEnumFlag(this int iFlagCollection, Type ioEnumType)
        {
            return extForeachEnumFlag(Enum.ToObject(ioEnumType, iFlagCollection) as Enum);
        }

        internal static IEnumerable<Enum> extForeachEnumFlag<TEnum>(this int iFlagCollection) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return extForeachEnumFlag(iFlagCollection, typeof(TEnum));
        }

        internal static IEnumerable<int> extForeachIntFlag(this Enum iFlagCollection)
        {
            Tuple<int, string, bool, int, bool, Enum[], int[], string[]> mCache = extGetCache(iFlagCollection);
            int mSourceValue = mCache.Item1;

            if (!mCache.Item5)
            {
                yield return mSourceValue;
            }

            for (int i = CConst.StartIndex; i < mCache.Item7.Length; i++)
            {
                if (mSourceValue.extHasFlag(mCache.Item7[i]))
                {
                    yield return mCache.Item7[i];
                }
            }
        }

        internal static IEnumerable<int> extForeachIntFlag(this int iFlagCollection, Type ioEnumType)
        {
            return extForeachIntFlag(Enum.ToObject(ioEnumType, iFlagCollection) as Enum);
        }

        internal static IEnumerable<int> extForeachIntFlag<TEnum>(this int iFlagCollection) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return extForeachIntFlag(iFlagCollection, typeof(TEnum));
        }

        internal static IEnumerable<string> extForeachNameFlag(this Enum iFlagCollection)
        {
            Tuple<int, string, bool, int, bool, Enum[], int[], string[]> mCache = extGetCache(iFlagCollection);
            if (!mCache.Item5)
            {
                yield return mCache.Item2;
            }

            int mSourceValue = mCache.Item1;

            for (int i = CConst.StartIndex; i < mCache.Item7.Length; i++)
            {
                if (mSourceValue.extHasFlag(mCache.Item7[i]))
                {
                    yield return mCache.Rest[i];
                }
            }
        }

        internal static IEnumerable<string> extForeachNameFlag(this int iFlagCollection, Type ioEnumType)
        {
            return extForeachNameFlag(Enum.ToObject(ioEnumType, iFlagCollection) as Enum);
        }

        internal static IEnumerable<string> extForeachNameFlag<TEnum>(this int iFlagCollection) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return extForeachNameFlag(iFlagCollection, typeof(TEnum));
        }
        #endregion
    }
}
