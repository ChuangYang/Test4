using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
using System.Xml;
using System.Xml.Serialization;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L0_XmlHelper
{
    [Pure]
    internal static class CXmlHelper
    {
        internal static object extDeserializeXmlString(this string iXmlString, Type ioConversionType)
        {
            XmlDocument mXmlDocument = new XmlDocument();

            mXmlDocument.LoadXml(iXmlString);

            using (XmlNodeReader mXmlNodeReader = new XmlNodeReader(mXmlDocument.DocumentElement))
            {
                return new XmlSerializer(ioConversionType).Deserialize(mXmlNodeReader);
            }
        }

        internal static T extDeserializeXmlString<T>(this string iXmlString, Type ioConversionType)
        {
            return (T)extDeserializeXmlString(iXmlString, ioConversionType);
        }

        internal static T extDeserializeXmlString<T>(this string iXmlString)
        {
            return (T)extDeserializeXmlString(iXmlString, typeof(T));
        }

        internal static object extDeserializeXmlURL(this string iXmlURL, Type ioConversionType)
        {
            XmlDocument mXmlDocument = new XmlDocument();

            mXmlDocument.Load(iXmlURL);

            using (XmlNodeReader mXmlNodeReader = new XmlNodeReader(mXmlDocument.DocumentElement))
            {
                return new XmlSerializer(ioConversionType).Deserialize(mXmlNodeReader);
            }
        }

        internal static T extDeserializeXmlURL<T>(this string iXmlURL, Type ioConversionType)
        {
            return (T)extDeserializeXmlURL(iXmlURL, ioConversionType);
        }

        internal static T extDeserializeXmlURL<T>(this string iXmlURL)
        {
            return (T)extDeserializeXmlURL(iXmlURL, typeof(T));
        }
    }
}
