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
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Interface
{
    /// <summary>
    /// Disposition
    /// </summary>
    public interface IDisposition : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DateTime GetDisposedTime();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsDisposed();
    }
}
