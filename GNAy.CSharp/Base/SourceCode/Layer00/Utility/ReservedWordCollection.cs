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
#endregion

namespace GNAy.CSharp.Base.Internal.L0_ReservedWordCollection
{
    /// <summary>
    /// ReservedWordCollection
    /// </summary>
    [Pure]
    public static class CReservedWordCollection
    {
        #region Fields and properties.
        private static string fTrue;
        private static string fFalse;

        private static string fMin;
        private static string fMax;
        #endregion

        #region Singleton, factory or constructor.
        static CReservedWordCollection() //TODO:
        {
            fTrue = "1";
            fFalse = "0";

            fMin = "MIN";
            fMax = "MAX";
        }
        #endregion

        #region Methods.
        internal static string GetTrue()
        {
            return fTrue;
        }

        internal static string GetFalse()
        {
            return fFalse;
        }

        internal static string GetMin()
        {
            return fMin;
        }

        internal static string GetMax()
        {
            return fMax;
        }
        #endregion
    }
}
