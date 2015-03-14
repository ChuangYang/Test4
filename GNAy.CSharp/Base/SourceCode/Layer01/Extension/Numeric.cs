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

namespace GNAy.CSharp.Base.Internal.L1_NumericExtensions
{
    [Pure]
    internal static class CNumericExtensions
    {
        internal static bool extIsEven(this sbyte iSource)
        {
            return ((iSource % 2) == CConst.Zero);
        }

        internal static bool extIsOdd(this sbyte iSource)
        {
            return ((iSource % 2) == 1);
        }

        internal static bool extIsEven(this byte iSource)
        {
            return ((iSource % 2) == CConst.Zero);
        }

        internal static bool extIsOdd(this byte iSource)
        {
            return ((iSource % 2) == 1);
        }

        internal static bool extIsEven(this short iSource)
        {
            return ((iSource % 2) == CConst.Zero);
        }

        internal static bool extIsOdd(this short iSource)
        {
            return ((iSource % 2) == 1);
        }

        internal static bool extIsEven(this ushort iSource)
        {
            return ((iSource % 2) == CConst.Zero);
        }

        internal static bool extIsOdd(this ushort iSource)
        {
            return ((iSource % 2) == 1);
        }

        internal static bool extIsEven(this int iSource)
        {
            return ((iSource % 2) == CConst.Zero);
        }

        internal static bool extIsOdd(this int iSource)
        {
            return ((iSource % 2) == 1);
        }

        internal static bool extIsEven(this uint iSource)
        {
            return ((iSource % 2) == CConst.Zero);
        }

        internal static bool extIsOdd(this uint iSource)
        {
            return ((iSource % 2) == 1);
        }

        internal static bool extIsEven(this long iSource)
        {
            return ((iSource % 2) == CConst.Zero);
        }

        internal static bool extIsOdd(this long iSource)
        {
            return ((iSource % 2) == 1);
        }

        internal static bool extIsEven(this ulong iSource)
        {
            return ((iSource % 2) == CConst.Zero);
        }

        internal static bool extIsOdd(this ulong iSource)
        {
            return ((iSource % 2) == 1);
        }

        internal static bool extIsEven(this decimal iSource)
        {
            return ((iSource % 2) == CConst.Zero);
        }

        internal static bool extIsOdd(this decimal iSource)
        {
            return ((iSource % 2) == 1);
        }

        internal static bool extIsEven(this char iSource)
        {
            return ((iSource % 2) == CConst.Zero);
        }

        internal static bool extIsOdd(this char iSource)
        {
            return ((iSource % 2) == 1);
        }

        internal static bool extHasFlag(this sbyte iSource, sbyte iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        internal static bool extHasFlag(this byte iSource, byte iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        internal static bool extHasFlag(this short iSource, short iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        internal static bool extHasFlag(this ushort iSource, ushort iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        internal static bool extHasFlag(this int iSource, int iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        internal static bool extHasFlag(this uint iSource, uint iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        internal static bool extHasFlag(this long iSource, long iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        internal static bool extHasFlag(this ulong iSource, ulong iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        internal static bool extHasFlag(this char iSource, char iTarget)
        {
            return ((iSource & iTarget) == iTarget);
        }

        internal static IEnumerable<bool> extHasFlags(this sbyte iSource, params sbyte[] ioCollection)
        {
            foreach (sbyte mFlag in ioCollection)
            {
                yield return extHasFlag(iSource, mFlag);
            }
        }

        internal static IEnumerable<bool> extHasFlags(this byte iSource, params byte[] ioCollection)
        {
            foreach (byte mFlag in ioCollection)
            {
                yield return extHasFlag(iSource, mFlag);
            }
        }

        internal static IEnumerable<bool> extHasFlags(this short iSource, params short[] ioCollection)
        {
            foreach (short mFlag in ioCollection)
            {
                yield return extHasFlag(iSource, mFlag);
            }
        }

        internal static IEnumerable<bool> extHasFlags(this ushort iSource, params ushort[] ioCollection)
        {
            foreach (ushort mFlag in ioCollection)
            {
                yield return extHasFlag(iSource, mFlag);
            }
        }

        internal static IEnumerable<bool> extHasFlags(this int iSource, params int[] ioCollection)
        {
            foreach (int mFlag in ioCollection)
            {
                yield return extHasFlag(iSource, mFlag);
            }
        }

        internal static IEnumerable<bool> extHasFlags(this uint iSource, params uint[] ioCollection)
        {
            foreach (uint mFlag in ioCollection)
            {
                yield return extHasFlag(iSource, mFlag);
            }
        }

        internal static IEnumerable<bool> extHasFlags(this long iSource, params long[] ioCollection)
        {
            foreach (long mFlag in ioCollection)
            {
                yield return extHasFlag(iSource, mFlag);
            }
        }

        internal static IEnumerable<bool> extHasFlags(this ulong iSource, params ulong[] ioCollection)
        {
            foreach (ulong mFlag in ioCollection)
            {
                yield return extHasFlag(iSource, mFlag);
            }
        }

        internal static IEnumerable<bool> extHasFlags(this char iSource, params char[] ioCollection)
        {
            foreach (char mFlag in ioCollection)
            {
                yield return extHasFlag(iSource, mFlag);
            }
        }

        internal static sbyte extAddFlag(this sbyte iSource, sbyte iTarget)
        {
            return (sbyte)(iSource | iTarget);
        }

        internal static byte extAddFlag(this byte iSource, byte iTarget)
        {
            return (byte)(iSource | iTarget);
        }

        internal static short extAddFlag(this short iSource, short iTarget)
        {
            return (short)(iSource | iTarget);
        }

        internal static ushort extAddFlag(this ushort iSource, ushort iTarget)
        {
            return (ushort)(iSource | iTarget);
        }

        internal static int extAddFlag(this int iSource, int iTarget)
        {
            return (iSource | iTarget);
        }

        internal static uint extAddFlag(this uint iSource, uint iTarget)
        {
            return (uint)(iSource | iTarget);
        }

        internal static char extAddFlag(this char iSource, char iTarget)
        {
            return (char)(iSource | iTarget);
        }

        internal static sbyte extAddFlags(this sbyte iSource, params sbyte[] ioCollection)
        {
            foreach (sbyte mFlag in ioCollection)
            {
                iSource = extAddFlag(iSource, mFlag);
            }

            return iSource;
        }

        internal static byte extAddFlags(this byte iSource, params byte[] ioCollection)
        {
            foreach (byte mFlag in ioCollection)
            {
                iSource = extAddFlag(iSource, mFlag);
            }

            return iSource;
        }

        internal static short extAddFlags(this short iSource, params short[] ioCollection)
        {
            foreach (short mFlag in ioCollection)
            {
                iSource = extAddFlag(iSource, mFlag);
            }

            return iSource;
        }

        internal static ushort extAddFlags(this ushort iSource, params ushort[] ioCollection)
        {
            foreach (ushort mFlag in ioCollection)
            {
                iSource = extAddFlag(iSource, mFlag);
            }

            return iSource;
        }

        internal static int extAddFlags(this int iSource, params int[] ioCollection)
        {
            foreach (int mFlag in ioCollection)
            {
                iSource = extAddFlag(iSource, mFlag);
            }

            return iSource;
        }

        internal static uint extAddFlags(this uint iSource, params uint[] ioCollection)
        {
            foreach (uint mFlag in ioCollection)
            {
                iSource = extAddFlag(iSource, mFlag);
            }

            return iSource;
        }

        internal static char extAddFlags(this char iSource, params char[] ioCollection)
        {
            foreach (char mFlag in ioCollection)
            {
                iSource = extAddFlag(iSource, mFlag);
            }

            return iSource;
        }

        internal static sbyte extRemoveFlag(this sbyte iSource, sbyte iTarget)
        {
            return (sbyte)(iSource & ~iTarget);
        }

        internal static byte extRemoveFlag(this byte iSource, byte iTarget)
        {
            return (byte)(iSource & ~iTarget);
        }

        internal static short extRemoveFlag(this short iSource, short iTarget)
        {
            return (short)(iSource & ~iTarget);
        }

        internal static ushort extRemoveFlag(this ushort iSource, ushort iTarget)
        {
            return (ushort)(iSource & ~iTarget);
        }

        internal static int extRemoveFlag(this int iSource, int iTarget)
        {
            return (iSource & ~iTarget);
        }

        internal static uint extRemoveFlag(this uint iSource, uint iTarget)
        {
            return (uint)(iSource & ~iTarget);
        }

        internal static char extRemoveFlag(this char iSource, char iTarget)
        {
            return (char)(iSource & ~iTarget);
        }

        internal static sbyte extRemoveFlags(this sbyte iSource, params sbyte[] ioCollection)
        {
            foreach (sbyte mFlag in ioCollection)
            {
                iSource = extRemoveFlag(iSource, mFlag);
            }

            return iSource;
        }

        internal static byte extRemoveFlags(this byte iSource, params byte[] ioCollection)
        {
            foreach (byte mFlag in ioCollection)
            {
                iSource = extRemoveFlag(iSource, mFlag);
            }

            return iSource;
        }

        internal static short extRemoveFlags(this short iSource, params short[] ioCollection)
        {
            foreach (short mFlag in ioCollection)
            {
                iSource = extRemoveFlag(iSource, mFlag);
            }

            return iSource;
        }

        internal static ushort extRemoveFlags(this ushort iSource, params ushort[] ioCollection)
        {
            foreach (ushort mFlag in ioCollection)
            {
                iSource = extRemoveFlag(iSource, mFlag);
            }

            return iSource;
        }

        internal static int extRemoveFlags(this int iSource, params int[] ioCollection)
        {
            foreach (int mFlag in ioCollection)
            {
                iSource = extRemoveFlag(iSource, mFlag);
            }

            return iSource;
        }

        internal static uint extRemoveFlags(this uint iSource, params uint[] ioCollection)
        {
            foreach (uint mFlag in ioCollection)
            {
                iSource = extRemoveFlag(iSource, mFlag);
            }

            return iSource;
        }

        internal static char extRemoveFlags(this char iSource, params char[] ioCollection)
        {
            foreach (char mFlag in ioCollection)
            {
                iSource = extRemoveFlag(iSource, mFlag);
            }

            return iSource;
        }
    }
}
