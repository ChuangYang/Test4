using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Configuration;
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

namespace GNAy.CSharp.Base.Internal.L1_ConfigurationExtensions
{
    [Pure]
    internal static class CConfigurationExtensions
    {
        internal static KeyValueConfigurationCollection extGetSettingCollection(this Configuration ioConfiguration)
        {
            return (ioConfiguration.AppSettings.extIsNull() ? null : ioConfiguration.AppSettings.Settings);
        }
    }
}
