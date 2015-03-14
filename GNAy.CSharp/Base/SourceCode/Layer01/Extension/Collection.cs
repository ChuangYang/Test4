using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Collections;
using System.Diagnostics.Contracts;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L1_CollectionExtensions
{
    [Pure]
    internal static class CCollectionExtensions
    {
        internal static bool extIsNullOrEmpty(this ICollection ioSource)
        {
            return (ioSource.extIsNull() || (ioSource.Count == CConst.Empty));
        }

        internal static bool extIsNotEmpty(this ICollection ioSource)
        {
            return !extIsNullOrEmpty(ioSource);
        }

        internal static int extGetLastIndex(this ICollection ioSource)
        {
            return (ioSource.Count - 1);
        }

        internal static object extIsSynchronized(this ICollection ioSource)
        {
            return ioSource.IsSynchronized;
        }

        internal static object extGetSyncRoot(this ICollection ioSource)
        {
            return ioSource.SyncRoot;
        }

        internal static T[] extToArray<T>(this ICollection ioSource)
        {
            T[] mCollection = new T[ioSource.Count];

            ioSource.CopyTo(mCollection, CConst.StartIndex);

            return mCollection;
        }

        internal static T[] extToArray<T>(this ICollection ioSource, int iStartIndex)
        {
            if (iStartIndex < CConst.StartIndex)
            {
                throw new ArgumentOutOfRangeException(iStartIndex.ToString());
            }
            else if (iStartIndex == CConst.StartIndex)
            {
                return extToArray<T>(ioSource);
            }
            else if (iStartIndex >= ioSource.Count)
            {
                return new T[CConst.Empty];
            }

            T[] mCollection = new T[ioSource.Count - iStartIndex];
            int mIndex = CConst.NotFound;

            foreach (T mItem in ioSource)
            {
                if (++mIndex < iStartIndex)
                {
                    continue;
                }

                mCollection[mIndex - iStartIndex] = mItem;
            }

            return mCollection;
        }

        internal static T[] extToArray<T>(this ICollection ioSource, int iStartIndex, int iCount)
        {
            if (iCount < CConst.StartIndex)
            {
                return extToArray<T>(ioSource, iStartIndex);
            }
            else if (iStartIndex < CConst.StartIndex)
            {
                throw new ArgumentOutOfRangeException(iStartIndex.ToString());
            }

            T[] mCollection = new T[ioSource.Count - iStartIndex];
            int mCount = CConst.Zero;

            if (iStartIndex == CConst.StartIndex)
            {
                foreach (T mItem in ioSource)
                {
                    if (++mCount > iCount)
                    {
                        break;
                    }

                    mCollection[mCount - 1] = mItem;
                }
            }
            else
            {
                int mIndex = CConst.NotFound;

                foreach (T mItem in ioSource)
                {
                    if (++mIndex < iStartIndex)
                    {
                        continue;
                    }
                    else if (++mCount > iCount)
                    {
                        break;
                    }

                    mCollection[mIndex - iStartIndex] = mItem;
                }
            }

            return mCollection;
        }

        internal static object[] extToArray(this ICollection ioSource)
        {
            return extToArray<object>(ioSource);
        }

        internal static object[] extToArray(this ICollection ioSource, int iStartIndex)
        {
            return extToArray<object>(ioSource, iStartIndex);
        }

        internal static object[] extToArray(this ICollection ioSource, int iStartIndex, int iCount)
        {
            return extToArray<object>(ioSource, iStartIndex, iCount);
        }
    }
}
