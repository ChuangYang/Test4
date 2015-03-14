using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.Serialization.Json;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L0_JsonHelper
{
    [Pure]
    internal static class CJsonHelper
    {
        internal static object extDeserializeJsonString(this string iJsonString, Type ioConversionType, Encoding ioEncoding)
        {
            using (MemoryStream mMemoryStream = new MemoryStream(ioEncoding.GetBytes(iJsonString)))
            {
                return new DataContractJsonSerializer(ioConversionType).ReadObject(mMemoryStream);
            }
        }

        internal static object extDeserializeJsonString(this string iJsonString, Type ioConversionType)
        {
            return extDeserializeJsonString(iJsonString, ioConversionType, Encoding.UTF8);
        }

        internal static T extDeserializeJsonString<T>(this string iJsonString, Type ioConversionType, Encoding ioEncoding)
        {
            return (T)extDeserializeJsonString(iJsonString, ioConversionType, ioEncoding);
        }

        internal static T extDeserializeJsonString<T>(this string iJsonString, Type ioConversionType)
        {
            return (T)extDeserializeJsonString(iJsonString, ioConversionType, Encoding.UTF8);
        }

        internal static T extDeserializeJsonString<T>(this string iJsonString, Encoding ioEncoding)
        {
            return (T)extDeserializeJsonString(iJsonString, typeof(T), ioEncoding);
        }

        internal static T extDeserializeJsonString<T>(this string iJsonString)
        {
            return (T)extDeserializeJsonString(iJsonString, typeof(T), Encoding.UTF8);
        }
    }
}
