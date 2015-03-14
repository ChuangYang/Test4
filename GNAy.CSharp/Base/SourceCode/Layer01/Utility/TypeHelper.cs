using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Reflection;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L1_TypeHelper
{
    [Pure]
    internal static class CTypeHelper
    {
        /// <summary>
        /// <para>(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.CreateInstance) =</para>
        /// <para>4 + 8 + 16 + 32 + 256 + 512 = 828</para>
        /// </summary>
        internal const BindingFlags DEFAULT_BINDING_FLAGS = (BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.CreateInstance);

        internal static Type extGetTypeWithoutChecking(this string iName, Assembly ioAssembly)
        {
            return ioAssembly.GetType(iName, true);
        }

        internal static Type extGetType(this string iName, Assembly ioAssembly = null)
        {
            return (ioAssembly.extIsNull() ? Type.GetType(iName, true) : ioAssembly.GetType(iName, true));
        }

        internal static Type extGetTypeWithoutChecking(this string iName, bool iIgnoreCase, Assembly ioAssembly)
        {
            return ioAssembly.GetType(iName, true, iIgnoreCase);
        }

        internal static Type extGetType(this string iName, bool iIgnoreCase, Assembly ioAssembly = null)
        {
            return (ioAssembly.extIsNull() ? Type.GetType(iName, true, iIgnoreCase) : ioAssembly.GetType(iName, true, iIgnoreCase));
        }

        internal static bool extIsStaticClass(this Type ioType)
        {
            ConstructorInfo[] mConstructors = null;

            if (ioType.BaseType.extIsNull())
            {
                return false;
            }
            else if (!ioType.BaseType.Equals(typeof(object)))
            {
                return false;
            }
            else if (!(ioType.IsClass && ioType.IsAbstract && ioType.IsSealed))
            {
                return false;
            }
            else if ((mConstructors = ioType.GetConstructors(BindingFlags.Static | BindingFlags.NonPublic)).Length == CConst.Zero) //If these is no definition in the code.
            {
                return true;
            }
            else if (mConstructors.Length > 1) //Static class only has one constructor.
            {
                return false;
            }

            ConstructorInfo mConstructor = mConstructors[CConst.StartIndex];

            return (mConstructor.IsPrivate && mConstructor.IsSpecialName && mConstructor.IsStatic);
        }

        internal static bool extIsNotStaticClass(this Type ioType)
        {
            return !extIsStaticClass(ioType);
        }

        internal static T[] extGetCustomAttributes<T>(this Type ioType) where T : Attribute
        {
            return (ioType.GetCustomAttributes(typeof(T), false) as T[]);
        }

        internal static DescriptionAttribute[] extGetDescriptions(this Type ioType)
        {
            return extGetCustomAttributes<DescriptionAttribute>(ioType);
        }

        internal static string[] extGetDescriptionStrings(this Type ioType)
        {
            return Array.ConvertAll(extGetDescriptions(ioType), (ioAttribute => ioAttribute.Description));
        }

        internal static T[] extGetMemberCustomAttributes<T>(this Type ioType, string iName, MemberTypes iMemberTypes = MemberTypes.All, BindingFlags iBindingFlags = DEFAULT_BINDING_FLAGS) where T : Attribute
        {
            return ioType.GetMember(iName, iMemberTypes, iBindingFlags).SelectMany(ioMemberInfo => extGetCustomAttributes<T>(ioType)).ToArray();
        }

        internal static DescriptionAttribute[] extGetMemberDescriptions(this Type ioType, string iName, MemberTypes iMemberTypes = MemberTypes.All, BindingFlags iBindingFlags = DEFAULT_BINDING_FLAGS)
        {
            return extGetMemberCustomAttributes<DescriptionAttribute>(ioType, iName, iMemberTypes, iBindingFlags);
        }

        internal static string[] extGetMemberDescriptionStrings(this Type ioType, string iName, MemberTypes iMemberTypes = MemberTypes.All, BindingFlags iBindingFlags = DEFAULT_BINDING_FLAGS)
        {
            return Array.ConvertAll(extGetMemberDescriptions(ioType, iName, iMemberTypes, iBindingFlags), (ioAttribute => ioAttribute.Description));
        }
    }
}
