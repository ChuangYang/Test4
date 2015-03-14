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
    /// DispositionStackCollection
    /// </summary>
    public interface IDispositionStackCollection : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string[] GetDisposeStackCollection();
    }
}
