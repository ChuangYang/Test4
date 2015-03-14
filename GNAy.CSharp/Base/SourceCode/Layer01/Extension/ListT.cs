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
using GNAy.CSharp.Base.Internal.L0_StringExtensions;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L1_ListTExtensions
{
    [Pure]
    internal static class CListTExtensions
    {
        /// <summary>
        /// 2
        /// </summary>
        internal const int DEFAULT_SHUFFLING_TIMES = 2;

        internal static bool extElementEquals<T>(this IList<T> ioSource, IList<T> ioTarget)
        {
            if (ioSource.extIsNull())
            {
                return (ioTarget.extIsNull());
            }
            else if (ioTarget.extIsNull())
            {
                return false;
            }
            else if (ioSource.Count != ioTarget.Count)
            {
                return false;
            }

            for (int i = CConst.StartIndex; i < ioSource.Count; i++)
            {
                if (ioSource[i].extNotEquals(ioTarget[i]))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool extElementEquals(this IList<string> ioSource, IList<string> ioTarget, StringComparison iStringComparison)
        {
            if (ioSource.extIsNull())
            {
                return (ioTarget.extIsNull());
            }
            else if (ioTarget.extIsNull())
            {
                return false;
            }
            else if (ioSource.Count != ioTarget.Count)
            {
                return false;
            }


            for (int i = CConst.StartIndex; i < ioSource.Count; i++)
            {
                if (ioSource[i].extNotEquals(ioTarget[i], iStringComparison))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool extElementEqualsWithIgnoreCase(this IList<string> ioSource, IList<string> ioTarget, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return extElementEquals(ioSource, ioTarget, iStringComparison);
        }

        [ContractVerification(false)]
        internal static IList<T> extShuffleItems<T>(this IList<T> ioBucket, Random ioRandom, int iShufflingTimes = DEFAULT_SHUFFLING_TIMES)
        {
            int mCount = ioBucket.Count;

            if (mCount <= 1)
            {
                return ioBucket;
            }
            else if (iShufflingTimes <= CConst.Zero)
            {
                return ioBucket;
            }

            int mHelfRight = ((int)Math.Ceiling(mCount / 2.0f) + 1);
            int mHelfLeft = ((int)Math.Floor(mCount / 2.0f) - 1);

            for (int i = CConst.StartIndex; i < mHelfRight; i++)
            {
                int mRandomNumber = (ioRandom.Next(mHelfRight) + mHelfLeft);

                T mItem = ioBucket[i];
                ioBucket[i] = ioBucket[mRandomNumber];
                ioBucket[mRandomNumber] = mItem;
            }

            if (--iShufflingTimes > CConst.Zero)
            {
                ioBucket = extShuffleItems(ioBucket, ioRandom, iShufflingTimes);
            }

            return ioBucket;
        }
    }
}
