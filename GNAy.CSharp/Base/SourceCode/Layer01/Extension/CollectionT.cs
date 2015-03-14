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
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L1_CollectionTExtensions
{
    [Pure]
    internal static class CCollectionTExtensions
    {
        internal static bool extIsNullOrEmpty<T>(this ICollection<T> ioSource)
        {
            return (ioSource.extIsNull() || (ioSource.Count == CConst.Empty));
        }

        internal static bool extIsNotEmpty<T>(this ICollection<T> ioSource)
        {
            return !extIsNullOrEmpty(ioSource);
        }

        internal static int extGetLastIndex<T>(this ICollection<T> ioSource)
        {
            return (ioSource.Count - 1);
        }

        internal static bool extIsReadOnly<T>(this ICollection<T> ioSource)
        {
            return ioSource.IsReadOnly;
        }

        internal static bool extTryAdd<T>(this ICollection<T> ioSource, T ioItem)
        {
            if (ioSource.IsReadOnly)
            {
                return false;
            }

            ioSource.Add(ioItem);

            return true;
        }

        internal static IEnumerable<bool> extTryAdd<T>(this ICollection<T> ioSource, IEnumerable<T> ioItems)
        {
            foreach (T mItem in ioItems)
            {
                yield return extTryAdd(ioSource, mItem);
            }
        }

        internal static bool extTryClear<T>(this ICollection<T> ioSource)
        {
            if (ioSource.IsReadOnly)
            {
                return false;
            }

            ioSource.Clear();

            return true;
        }

        internal static IEnumerable<bool> extContains<T>(this ICollection<T> ioSource, IEnumerable<T> ioItems)
        {
            foreach (T mItem in ioItems)
            {
                yield return ioSource.Contains(mItem);
            }
        }

        internal static T[] extToArray<T>(this ICollection<T> ioSource)
        {
            T[] mCollection = new T[ioSource.Count];

            ioSource.CopyTo(mCollection, CConst.StartIndex);

            return mCollection;
        }

        internal static T[] extToArray<T>(this ICollection<T> ioSource, int iStartIndex)
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

        internal static T[] extToArray<T>(this ICollection<T> ioSource, int iStartIndex, int iCount)
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

        internal static bool extTryRemove<T>(this ICollection<T> ioSource, T ioItem)
        {
            if (ioSource.IsReadOnly)
            {
                return false;
            }

            return ioSource.Remove(ioItem);
        }

        internal static IEnumerable<bool> extTryRemove<T>(this ICollection<T> ioSource, IEnumerable<T> ioItems)
        {
            foreach (T mItem in ioItems)
            {
                yield return extTryRemove(ioSource, mItem);
            }
        }
    }
}
