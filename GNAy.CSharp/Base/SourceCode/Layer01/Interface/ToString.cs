using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Interface
{
    /// <summary>
    /// ToString
    /// </summary>
    public interface IToString
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iWithFieldNames"></param>
        /// <returns></returns>
        string[] ToStringCollection(bool iWithFieldNames);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iWithFieldNames"></param>
        /// <returns></returns>
        string ToString(bool iWithFieldNames);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string ToString();
    }
}
