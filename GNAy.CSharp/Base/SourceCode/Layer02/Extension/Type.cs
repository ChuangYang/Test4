using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Runtime.CompilerServices;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
using GNAy.CSharp.Base.Internal.L0_ProcessHelper;
using GNAy.CSharp.Base.Internal.L0_StaticToolbox;
using GNAy.CSharp.Base.Internal.L1_ListExtensions;
using GNAy.CSharp.Base.Internal.L1_TypeHelper;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L2_TypeExtensions
{
    [Pure]
    internal static class CTypeExtensions
    {
        /// <summary>
        /// <para>(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.CreateInstance) =</para>
        /// <para>4 + 8 + 16 + 32 + 256 + 512 = 828</para>
        /// </summary>
        internal const BindingFlags DEFAULT_BINDING_FLAGS = (BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.CreateInstance);

        internal static FieldInfo extGetField(this Type ioType, string iName, BindingFlags iBindingFlags = DEFAULT_BINDING_FLAGS)
        {
            return ioType.GetField(iName, iBindingFlags);
        }

        internal static FieldInfo[] extGetFields(this Type ioType, BindingFlags iBindingFlags = DEFAULT_BINDING_FLAGS)
        {
            return ioType.GetFields(iBindingFlags);
        }

        internal static FieldInfo[] extGetFields(this Type ioType, IEnumerable<string> ioNames, BindingFlags iBindingFlags = DEFAULT_BINDING_FLAGS)
        {
            return ioNames.Select(iName => extGetField(ioType, iName, iBindingFlags)).ToArray();
        }

        internal static PropertyInfo extGetProperty(this Type ioType, string iName, BindingFlags iBindingFlags = DEFAULT_BINDING_FLAGS)
        {
            return ioType.GetProperty(iName, iBindingFlags);
        }

        internal static PropertyInfo[] extGetProperties(this Type ioType, BindingFlags iBindingFlags = DEFAULT_BINDING_FLAGS)
        {
            return ioType.GetProperties(iBindingFlags);
        }

        internal static PropertyInfo[] extGetProperties(this Type ioType, IEnumerable<string> ioNames, BindingFlags iBindingFlags = DEFAULT_BINDING_FLAGS)
        {
            return ioNames.Select(iName => extGetProperty(ioType, iName, iBindingFlags)).ToArray();
        }

        private static MethodInfo getMethod(this Type ioType, string iName, BindingFlags iBindingFlags, params Type[] ioParameterTypes)
        {
            MethodInfo mResult = null;

            if (ioParameterTypes.extIsNullOrEmpty() || ioParameterTypes.Any(ioParameterType => ioParameterType.extIsNull()))
            {
                ioParameterTypes = null;

                mResult = ioType.GetMethod(iName, iBindingFlags);
            }
            else
            {
                mResult = ioType.GetMethod(iName, iBindingFlags, null, ioParameterTypes, null);
            }

            if (mResult.extIsNotNull())
            {
                return mResult;
            }
            else if (ioParameterTypes.extIsNullOrEmpty())
            {
                return null;
            }

            MethodInfo[] mMethods = ioType.GetMethods(iBindingFlags);

            if ((mResult = mMethods.SingleOrDefault(ioMethodInfo =>
                {
                    ParameterInfo[] mParameters = null;

                    if (ioMethodInfo.Name != iName)
                    {
                        return false;
                    }
                    else if ((mParameters = ioMethodInfo.GetParameters()).Length < ioParameterTypes.Length)
                    {
                        return false;
                    }

                    for (int i = CConst.StartIndex; i < mParameters.Length; i++)
                    {
                        if (mParameters[i].IsOptional && (i >= ioParameterTypes.Length))
                        {
                            continue;
                        }
                        else if (!mParameters[i].ParameterType.IsAssignableFrom(ioParameterTypes[i]))
                        {
                            return false;
                        }
                    }

                    return true;
                }
            )).extIsNotNull())
            {
                return mResult;
            }

            return mMethods.SingleOrDefault(ioMethodInfo =>
            {
                ParameterInfo[] mParameters = null;

                if (ioMethodInfo.Name != iName)
                {
                    return false;
                }
                else if ((mParameters = ioMethodInfo.GetParameters()).Length < ioParameterTypes.Length)
                {
                    return false;
                }

                for (int i = CConst.StartIndex; i < mParameters.Length; i++)
                {
                    if (mParameters[i].IsOptional && (i >= ioParameterTypes.Length))
                    {
                        continue;
                    }
                    else if (!mParameters[i].ParameterType.IsAssignableFrom(ioParameterTypes[i]))
                    {
                        if (typeof(Delegate).IsAssignableFrom(mParameters[i].ParameterType) &&
                            typeof(MethodInfo).IsAssignableFrom(ioParameterTypes[i]))
                        {
                            continue;
                        }

                        return false;
                    }
                }

                return true;
            });
        }

        private static MethodInfo getMethod(this Type ioType, string iName, params Type[] ioParameterTypes)
        {
            return getMethod(ioType, iName, DEFAULT_BINDING_FLAGS, ioParameterTypes);
        }

        internal static MethodInfo extGetMethod(this Type ioType, string iName, Type ioExtensionType, BindingFlags iBindingFlags, params Type[] ioParameterTypes)
        {
            if (ioExtensionType.extIsNull())
            {
                return getMethod(ioType, iName, iBindingFlags, ioParameterTypes);
            }

            List<Type> mParameterTypes = new List<Type>() { ioType };

            if (ioParameterTypes.extIsNotEmpty() && !ioParameterTypes.Any(ioParameterType => ioParameterType.extIsNull()))
            {
                mParameterTypes.AddRange(ioParameterTypes);
            }

            MethodInfo mResult = null;
            MethodInfo[] mMethods = ioExtensionType.GetMethods(iBindingFlags);

            if ((mResult = mMethods.SingleOrDefault(ioMethodInfo =>
            {
                ParameterInfo[] mParameters = null;

                if (ioMethodInfo.Name != iName)
                {
                    return false;
                }
                else if (!ioMethodInfo.IsDefined(typeof(ExtensionAttribute), false))
                {
                    return false;
                }
                else if ((mParameters = ioMethodInfo.GetParameters()).Length < mParameterTypes.Count)
                {
                    return false;
                }

                for (int i = CConst.StartIndex; i < mParameters.Length; i++)
                {
                    if (mParameters[i].IsOptional && (i >= mParameterTypes.Count))
                    {
                        continue;
                    }
                    else if (!mParameters[i].ParameterType.IsAssignableFrom(mParameterTypes[i]))
                    {
                        return false;
                    }
                }

                return true;
            })).extIsNotNull())
            {
                return mResult;
            }

            return mMethods.SingleOrDefault(ioMethodInfo =>
            {
                ParameterInfo[] mParameters = null;

                if (ioMethodInfo.Name != iName)
                {
                    return false;
                }
                else if (!ioMethodInfo.IsDefined(typeof(ExtensionAttribute), false))
                {
                    return false;
                }
                else if ((mParameters = ioMethodInfo.GetParameters()).Length < mParameterTypes.Count)
                {
                    return false;
                }

                for (int i = CConst.StartIndex; i < mParameters.Length; i++)
                {
                    if (mParameters[i].IsOptional && (i >= mParameterTypes.Count))
                    {
                        continue;
                    }
                    else if (!mParameters[i].ParameterType.IsAssignableFrom(mParameterTypes[i]))
                    {
                        if (typeof(Delegate).IsAssignableFrom(mParameters[i].ParameterType) &&
                            typeof(MethodInfo).IsAssignableFrom(mParameterTypes[i]))
                        {
                            continue;
                        }

                        return false;
                    }
                }

                return true;
            });
        }

        internal static MethodInfo extGetMethod(this Type ioType, string iName, Type ioExtensionType, params Type[] ioParameterTypes)
        {
            return extGetMethod(ioType, iName, ioExtensionType, DEFAULT_BINDING_FLAGS, ioParameterTypes);
        }

        private static MethodInfo getMethod(Assembly ioExtensionAssembly, Type ioType, string iName, BindingFlags iBindingFlags, params Type[] ioParameterTypes)
        {
            MethodInfo mResult = null;

            ioExtensionAssembly.GetTypes().SingleOrDefault(ioExtensionType =>
            {
                if (ioExtensionType.extIsNotStaticClass())
                {
                    return false;
                }
                else if ((mResult = extGetMethod(ioType, iName, ioExtensionType, iBindingFlags, ioParameterTypes)).extIsNull())
                {
                    return false;
                }

                return true;
            });

            return mResult;
        }

        internal static MethodInfo extGetMethod(this Type ioType, string iName, BindingFlags iBindingFlags, Assembly ioExtensionAssembly = null, params Type[] ioParameterTypes)
        {
            MethodInfo mResult = getMethod(ioType, iName, iBindingFlags, ioParameterTypes);

            if (mResult.extIsNotNull())
            {
                return mResult;
            }
            else if ((mResult = getMethod((ioExtensionAssembly ?? ioType.Assembly), ioType, iName, iBindingFlags, ioParameterTypes)).extIsNotNull())
            {
                return mResult;
            }
            else if (ioExtensionAssembly.extIsNotNull())
            {
                return null;
            }
            else if ((mResult = getMethod(CProcessHelper.GetProcessAssembly(), ioType, iName, iBindingFlags, ioParameterTypes)).extIsNotNull())
            {
                return mResult;
            }
            else if ((mResult = getMethod(CStaticToolbox.GetLibraryAssembly(), ioType, iName, iBindingFlags, ioParameterTypes)).extIsNotNull())
            {
                return mResult;
            }

            return getMethod(CStaticToolbox.GetDotNetCoreAssembly(), ioType, iName, iBindingFlags, ioParameterTypes);
        }

        internal static MethodInfo extGetMethod(this Type ioType, string iName, Assembly ioExtensionAssembly = null, params Type[] ioParameterTypes)
        {
            return extGetMethod(ioType, iName, DEFAULT_BINDING_FLAGS, ioExtensionAssembly, ioParameterTypes);
        }

        internal static MethodInfo[] extGetMethods(this Type ioType, BindingFlags iBindingFlags = DEFAULT_BINDING_FLAGS)
        {
            return ioType.GetMethods(iBindingFlags);
        }

        internal static EventInfo extGetEvent(this Type ioType, string iName, BindingFlags iBindingFlags = DEFAULT_BINDING_FLAGS)
        {
            return ioType.GetEvent(iName, iBindingFlags);
        }

        internal static EventInfo[] extGetEvents(this Type ioType, BindingFlags iBindingFlags = DEFAULT_BINDING_FLAGS)
        {
            return ioType.GetEvents(iBindingFlags);
        }

        internal static EventInfo[] extGetEvents(this Type ioType, IEnumerable<string> ioNames, BindingFlags iBindingFlags = DEFAULT_BINDING_FLAGS)
        {
            return ioNames.Select(iName => extGetEvent(ioType, iName, iBindingFlags)).ToArray();
        }

        internal static Delegate extGetDelegate(this Type ioDelegateType, MethodInfo ioMethodInfo, EventInfo ioTryEvent = null)
        {
            if (!typeof(Delegate).IsAssignableFrom(ioDelegateType))
            {
                throw new InvalidCastException(CErrorMessage.ObjectIsNotT);
            }

            try
            {
                return Delegate.CreateDelegate(ioDelegateType, ioMethodInfo, true);
            }
            catch //(Exception mException)
            {
                if (ioTryEvent.extIsNull())
                {
                    throw;
                }

                return Delegate.CreateDelegate(ioTryEvent.EventHandlerType, ioMethodInfo, true);
            }
            finally
            { }
        }

        internal static object extGetDelegateOrValue(this Type ioValueType, object ioValue, EventInfo ioTryEvent = null)
        {
            if (ioValue.extIsNull())
            {
                return null;
            }
            else if (typeof(Delegate).IsAssignableFrom(ioValueType) && (ioValue is MethodInfo))
            {
                return extGetDelegate(ioValueType, (ioValue as MethodInfo), ioTryEvent);
            }

            return ioValue;
        }

        internal static T extGetDelegateOrValue<T>(this Type ioValueType, object ioValue, EventInfo ioTryEvent = null)
        {
            return (T)extGetDelegateOrValue(ioValueType, ioValue, ioTryEvent);
        }
    }
}
