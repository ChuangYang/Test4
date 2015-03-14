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

namespace GNAy.CSharp.Base.Internal.L1_StaticToolbox
{
    [Pure]
    internal static class CStaticToolbox
    {
        internal static Tuple<int, int> GetStartIndexAndCount(int iSourceLength)
        {
            if (iSourceLength < CConst.Zero)
            {
                throw new ArgumentOutOfRangeException(iSourceLength.ToString());
            }

            return new Tuple<int, int>(CConst.StartIndex, iSourceLength);
        }

        internal static Tuple<int, int> GetStartIndexAndCount(int iSourceLength, int iStartIndex)
        {
            if (iSourceLength < CConst.Zero)
            {
                throw new ArgumentOutOfRangeException(iSourceLength.ToString());
            }
            else if (iStartIndex < CConst.StartIndex)
            {
                throw new ArgumentOutOfRangeException(iStartIndex.ToString());
            }
            else if (iStartIndex >= iSourceLength)
            {
                return new Tuple<int, int>(iSourceLength, CConst.Empty);
            }

            return new Tuple<int, int>(iStartIndex, (iSourceLength - iStartIndex));
        }

        internal static Tuple<int, int> GetStartIndexAndCount(int iSourceLength, int iStartIndex, int iCount)
        {
            if (iSourceLength < CConst.Zero)
            {
                throw new ArgumentOutOfRangeException(iSourceLength.ToString());
            }
            else if (iStartIndex < CConst.StartIndex)
            {
                throw new ArgumentOutOfRangeException(iStartIndex.ToString());
            }
            else if (iStartIndex >= iSourceLength)
            {
                return new Tuple<int, int>(iSourceLength, CConst.Empty);
            }
            else if ((iStartIndex == CConst.StartIndex) && (iCount < CConst.Zero))
            {
                return new Tuple<int, int>(iStartIndex, iSourceLength);
            }

            return new Tuple<int, int>(iStartIndex, (((iCount < CConst.Zero) || (iCount >= (iSourceLength - iStartIndex))) ? (iSourceLength - iStartIndex) : iCount));
        }
    }
}
