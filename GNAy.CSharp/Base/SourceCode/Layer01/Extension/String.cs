using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
using System.IO;
using System.Reflection;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
using GNAy.CSharp.Base.Internal.L0_ProcessHelper;
using GNAy.CSharp.Base.Internal.L0_ReservedWordCollection;
using GNAy.CSharp.Base.Internal.L0_StaticToolbox;
using GNAy.CSharp.Base.Internal.L0_StringExtensions;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L1_StringExtensions
{
    [Pure]
    internal static class CStringExtensions
    {
        internal static void extGetHashCodeWithIgnoreCaseAndWithoutChecking(this string iSource, ref int ioTargetHashCode)
        {
            ioTargetHashCode = (ioTargetHashCode ^ iSource.ToUpper().GetHashCode());
        }

        internal static void extGetHashCodeWithIgnoreCase(this string iSource, ref int ioTargetHashCode)
        {
            ioTargetHashCode = ((ioTargetHashCode > CConst.Zero) ? (ioTargetHashCode ^ iSource.ToUpper().GetHashCode()) : iSource.ToUpper().GetHashCode());
        }

        internal static int extGetHashCodeWithIgnoreCaseAndWithoutChecking(this string iSource, int iTargetHashCode)
        {
            return (iTargetHashCode ^ iSource.ToUpper().GetHashCode());
        }

        internal static int extGetHashCodeWithIgnoreCase(this string iSource, int iTargetHashCode = CConst.NotFound)
        {
            return ((iTargetHashCode > CConst.Zero) ? (iTargetHashCode ^ iSource.ToUpper().GetHashCode()) : iSource.ToUpper().GetHashCode());
        }

        internal static bool extIsTrue(this string iSource)
        {
            return (bool.TrueString.extEqualsWithIgnoreCase(iSource) || CReservedWordCollection.GetTrue().extEqualsWithIgnoreCase(iSource));
        }

        internal static bool extIsFalse(this string iSource)
        {
            return (bool.FalseString.extEqualsWithIgnoreCase(iSource) || CReservedWordCollection.GetFalse().extEqualsWithIgnoreCase(iSource));
        }

        internal static bool extContains(this string iSource, string iTarget)
        {
            return (iSource.IndexOf(iTarget) >= CConst.StartIndex);
        }

        internal static bool extContains(this string iSource, string iTarget, StringComparison iStringComparison)
        {
            return (iSource.IndexOf(iTarget, iStringComparison) >= CConst.StartIndex);
        }

        internal static bool extContainsWithIgnoreCase(this string iSource, string iTarget, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return extContains(iSource, iTarget, iStringComparison);
        }

        internal static bool extContains(this string iSource, string iTarget, int iStartIndex)
        {
            return (iSource.IndexOf(iTarget, iStartIndex) >= CConst.StartIndex);
        }

        internal static bool extContains(this string iSource, string iTarget, int iStartIndex, StringComparison iStringComparison)
        {
            return (iSource.IndexOf(iTarget, iStartIndex, iStringComparison) >= CConst.StartIndex);
        }

        internal static bool extContainsWithIgnoreCase(this string iSource, string iTarget, int iStartIndex, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return extContains(iSource, iTarget, iStartIndex, iStringComparison);
        }

        internal static bool extContains(this string iSource, string iTarget, int iStartIndex, int iCount)
        {
            return (iSource.IndexOf(iTarget, iStartIndex, iCount) >= CConst.StartIndex);
        }

        internal static bool extContains(this string iSource, string iTarget, int iStartIndex, int iCount, StringComparison iStringComparison)
        {
            return (iSource.IndexOf(iTarget, iStartIndex, iCount, iStringComparison) >= CConst.StartIndex);
        }

        internal static bool extContainsWithIgnoreCase(this string iSource, string iTarget, int iStartIndex, int iCount, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return extContains(iSource, iTarget, iStartIndex, iCount, iStringComparison);
        }

        internal static int extIndexOfTail(this string iSource, string iKeyword)
        {
            int mIndex = iSource.IndexOf(iKeyword);

            return ((mIndex < CConst.StartIndex) ? mIndex : (mIndex + iKeyword.Length));
        }

        internal static int extIndexOfTail(this string iSource, string iKeyword, StringComparison iStringComparison)
        {
            int mIndex = iSource.IndexOf(iKeyword, iStringComparison);

            return ((mIndex < CConst.StartIndex) ? mIndex : (mIndex + iKeyword.Length));
        }

        internal static int extIndexOfTailWithIgnoreCase(this string iSource, string iKeyword, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return extIndexOfTail(iSource, iKeyword, iStringComparison);
        }

        internal static int extLastIndexOfTail(this string iSource, string iKeyword)
        {
            int mIndex = iSource.LastIndexOf(iKeyword);

            return ((mIndex < CConst.StartIndex) ? mIndex : (mIndex + iKeyword.Length));
        }

        internal static int extLastIndexOfTail(this string iSource, string iKeyword, StringComparison iStringComparison)
        {
            int mIndex = iSource.LastIndexOf(iKeyword, iStringComparison);

            return ((mIndex < CConst.StartIndex) ? mIndex : (mIndex + iKeyword.Length));
        }

        internal static int extLastIndexOfTailWithIgnoreCase(this string iSource, string iKeyword, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return extLastIndexOfTail(iSource, iKeyword, iStringComparison);
        }

        internal static string extSubstring(this string iSource, string iStart, bool iSearchStartFromHead, string iEnd, bool iSearchEndFromHead)
        {
            int mStartIndex = CConst.NotFound;

            if ((mStartIndex = (iSearchStartFromHead ? extIndexOfTail(iSource, iStart) : extLastIndexOfTail(iSource, iStart))) < CConst.StartIndex)
            {
                return CConst.StringEmpty;
            }

            string mStart = iSource.Substring(mStartIndex);
            int mEndIndex = (iSearchEndFromHead ? mStart.IndexOf(iEnd) : mStart.LastIndexOf(iEnd));

            return ((mEndIndex < CConst.StartIndex) ? mStart : mStart.Substring(CConst.StartIndex, mEndIndex));
        }

        internal static string extSubstring(this string iSource, string iStart, bool iSearchStartFromHead, string iEnd, bool iSearchEndFromHead, StringComparison iStringComparison)
        {
            int mStartIndex = CConst.NotFound;

            if ((mStartIndex = (iSearchStartFromHead ? extIndexOfTail(iSource, iStart, iStringComparison) : extLastIndexOfTail(iSource, iStart, iStringComparison))) < CConst.StartIndex)
            {
                return CConst.StringEmpty;
            }

            string mStart = iSource.Substring(mStartIndex);
            int mEndIndex = (iSearchEndFromHead ? mStart.IndexOf(iEnd, iStringComparison) : mStart.LastIndexOf(iEnd, iStringComparison));

            return ((mEndIndex < CConst.StartIndex) ? mStart : mStart.Substring(CConst.StartIndex, mEndIndex));
        }

        internal static string extSubstringWithIgnoreCase(this string iSource, string iStart, bool iSearchStartFromHead, string iEnd, bool iSearchEndFromHead, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return extSubstring(iSource, iStart, iSearchStartFromHead, iEnd, iSearchEndFromHead, iStringComparison);
        }

        internal static string extFirstSubstring(this string iSource, string iStart, string iEnd)
        {
            return extSubstring(iSource, iStart, true, iEnd, true);
        }

        internal static string extFirstSubstring(this string iSource, string iStart, string iEnd, StringComparison iStringComparison)
        {
            return extSubstring(iSource, iStart, true, iEnd, true, iStringComparison);
        }

        internal static string extFirstSubstringWithIgnoreCase(this string iSource, string iStart, string iEnd, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return extSubstring(iSource, iStart, true, iEnd, true, iStringComparison);
        }

        internal static string extLastSubstring(this string iSource, string iStart, string iEnd)
        {
            return extSubstring(iSource, iStart, false, iEnd, false);
        }

        internal static string extLastSubstring(this string iSource, string iStart, string iEnd, StringComparison iStringComparison)
        {
            return extSubstring(iSource, iStart, false, iEnd, false, iStringComparison);
        }

        internal static string extLastSubstringWithIgnoreCase(this string iSource, string iStart, string iEnd, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return extSubstring(iSource, iStart, false, iEnd, false, iStringComparison);
        }

        internal static Tuple<bool, int> extTryToInt(this string iSource, int iWhileFailed = CConst.NotFound)
        {
            if (string.IsNullOrWhiteSpace(iSource))
            {
                return new Tuple<bool, int>(false, iWhileFailed);
            }
            else if (iSource.Equals(CReservedWordCollection.GetMin(), StringComparison.OrdinalIgnoreCase))
            {
                return new Tuple<bool, int>(true, int.MinValue);
            }
            else if (iSource.Equals(CReservedWordCollection.GetMax(), StringComparison.OrdinalIgnoreCase))
            {
                return new Tuple<bool, int>(true, int.MaxValue);
            }

            int mResult = CConst.Zero;

            return (int.TryParse(iSource, out mResult) ? new Tuple<bool, int>(true, mResult) : new Tuple<bool, int>(false, iWhileFailed));
        }

        internal static Tuple<bool, long> extTryToLong(this string iSource, long iWhileFailed = CConst.NotFound)
        {
            if (string.IsNullOrWhiteSpace(iSource))
            {
                return new Tuple<bool, long>(false, iWhileFailed);
            }
            else if (iSource.Equals(CReservedWordCollection.GetMin(), StringComparison.OrdinalIgnoreCase))
            {
                return new Tuple<bool, long>(true, long.MinValue);
            }
            else if (iSource.Equals(CReservedWordCollection.GetMax(), StringComparison.OrdinalIgnoreCase))
            {
                return new Tuple<bool, long>(true, long.MaxValue);
            }

            long mResult = CConst.Zero;

            return (long.TryParse(iSource, out mResult) ? new Tuple<bool, long>(true, mResult) : new Tuple<bool, long>(false, iWhileFailed));
        }

        internal static string extGetFilePath(this string iFilePath, string iTryRootPath = null)
        {
            if (string.IsNullOrWhiteSpace(iFilePath))
            {
                throw new ArgumentNullException(CErrorMessage.StringIsNullOrWhiteSpace);
            }

            if (File.Exists(iFilePath))
            {
                return iFilePath;
            }
            else if (string.IsNullOrWhiteSpace(iTryRootPath))
            {
                string mPath = Path.Combine(CProcessHelper.GetProcessFileInfo().DirectoryName, iFilePath);

                if (File.Exists(mPath))
                {
                    return mPath;
                }
                else if (File.Exists(mPath = Path.Combine(CStaticToolbox.GetLibraryFileInfo().DirectoryName, iFilePath)))
                {
                    return mPath;
                }
                else if (File.Exists(mPath = Path.Combine(CStaticToolbox.GetDotNetDirectoryInfo().FullName, iFilePath)))
                {
                    return mPath;
                }
            }
            else //if (!string.IsNullOrWhiteSpace(iTryRootPath))
            {
                string mPath = Path.Combine(iTryRootPath, iFilePath);

                if (File.Exists(mPath))
                {
                    return mPath;
                }
            }

            return CConst.StringEmpty;
        }

        internal static FileInfo extGetFileInfo(this string iFilePath, string iTryRootPath = null)
        {
            string mFilePath = extGetFilePath(iTryRootPath);

            return (string.IsNullOrWhiteSpace(mFilePath) ? null : new FileInfo(mFilePath));
        }

        internal static Assembly extGetAssembly(this string iFilePath, string iTryRootPath = null)
        {
            string mFilePath = extGetFilePath(iTryRootPath);

            return (string.IsNullOrWhiteSpace(mFilePath) ? null : Assembly.LoadFile(mFilePath));
        }
    }
}
