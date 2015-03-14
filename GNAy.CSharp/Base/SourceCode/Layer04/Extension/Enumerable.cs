using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Collections;
using System.Diagnostics.Contracts;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
using GNAy.CSharp.Base.Enumeration;
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
using GNAy.CSharp.Base.Internal.L1_NumericExtensions;
using GNAy.CSharp.Base.Internal.L1_ObjectExtensions;
using GNAy.CSharp.Base.Internal.L1_StringExtensions;
using GNAy.CSharp.Base.Internal.L3_ExceptionObserver;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L4_EnumerableExtensions
{
    [Pure]
    internal static class CEnumerableExtensions
    {
        internal static void extGetElementsHashCode(this IEnumerable ioSource, ref int ioHashCode, int iForeachOption, Action<Tuple<Exception, DateTime, string>> iException = null)
        {
            if (iForeachOption.extHasFlag(ECommonOption.Value.TryCatch))
            {
                try
                {
                    extGetElementsHashCode(ioSource, ref ioHashCode, iForeachOption.extRemoveFlag(ECommonOption.Value.TryCatch));
                }
                catch (Exception mException)
                {
                    iException.extInvoke(mException, mException.StackTrace);
                }
                finally
                { }

                return;
            }
            else if (ioHashCode > CConst.Zero)
            {
                iForeachOption.extAddFlag(ECommonOption.Value.WithoutChecking);
            }

            int mForeachOption = (iForeachOption.extHasFlag(ECommonOption.Value.WithoutChecking) ? ECommonOption.Value.WithoutChecking : CConst.Zero);

            if (iForeachOption.extHasFlag(ECommonOption.Value.WithoutNull))
            {
                mForeachOption = mForeachOption.extAddFlag(ECommonOption.Value.WithoutNull);
            }
            else if (iForeachOption.extHasFlag(ECommonOption.Value.WithoutEmpty))
            {
                mForeachOption = mForeachOption.extAddFlag(ECommonOption.Value.WithoutEmpty);
            }
            else if (iForeachOption.extHasFlag(ECommonOption.Value.WithoutWhiteSpace))
            {
                mForeachOption = mForeachOption.extAddFlag(ECommonOption.Value.WithoutWhiteSpace);
            }

            if (iForeachOption.extHasFlag(ECommonOption.Value.IgnoreCase))
            {
                mForeachOption = mForeachOption.extAddFlag(ECommonOption.Value.IgnoreCase);
            }

            switch (mForeachOption)
            {
                case ECommonOption.Value.WithoutChecking:
                    {
                        foreach (var mElement in ioSource)
                        {
                            if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCodeWithoutChecking(ref ioHashCode);
                        }
                    }
                    break;

                case ECommonOption.Value.WithoutNull:
                    {
                        if (ioSource.extIsNull())
                        {
                            return;
                        }

                        foreach (var mElement in ioSource)
                        {
                            if (mElement.extIsNull())
                            {
                                continue;
                            }
                            else if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCode(ref ioHashCode);
                        }
                    }
                    break;

                case ECommonOption.Value.WithoutEmpty:
                    {
                        if (ioSource.extIsNull())
                        {
                            return;
                        }

                        foreach (var mElement in ioSource)
                        {
                            if (mElement.extIsNull())
                            {
                                continue;
                            }
                            else if (mElement is string)
                            {
                                string mString = (mElement as string);

                                if (string.IsNullOrEmpty(mString))
                                {
                                    continue;
                                }

                                mString.extGetHashCode(ref ioHashCode);

                                continue;
                            }
                            else if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCode(ref ioHashCode);
                        }
                    }
                    break;

                case ECommonOption.Value.WithoutWhiteSpace:
                    {
                        if (ioSource.extIsNull())
                        {
                            return;
                        }

                        foreach (var mElement in ioSource)
                        {
                            if (mElement.extIsNull())
                            {
                                continue;
                            }
                            else if (mElement is string)
                            {
                                string mString = (mElement as string);

                                if (string.IsNullOrWhiteSpace(mString))
                                {
                                    continue;
                                }

                                mString.extGetHashCode(ref ioHashCode);

                                continue;
                            }
                            else if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCode(ref ioHashCode);
                        }
                    }
                    break;

                case ECommonOption.Value.IgnoreCase:
                    {
                        foreach (var mElement in ioSource)
                        {
                            if (mElement is string)
                            {
                                (mElement as string).extGetHashCodeWithIgnoreCase(ref ioHashCode);

                                continue;
                            }
                            else if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCode(ref ioHashCode);
                        }
                    }
                    break;

                case (ECommonOption.Value.WithoutChecking | ECommonOption.Value.WithoutNull):
                    {
                        if (ioSource.extIsNull())
                        {
                            return;
                        }

                        foreach (var mElement in ioSource)
                        {
                            if (mElement.extIsNull())
                            {
                                continue;
                            }
                            else if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCodeWithoutChecking(ref ioHashCode);
                        }
                    }
                    break;

                case (ECommonOption.Value.WithoutChecking | ECommonOption.Value.WithoutEmpty):
                    {
                        if (ioSource.extIsNull())
                        {
                            return;
                        }

                        foreach (var mElement in ioSource)
                        {
                            if (mElement.extIsNull())
                            {
                                continue;
                            }
                            else if (mElement is string)
                            {
                                string mString = (mElement as string);

                                if (string.IsNullOrEmpty(mString))
                                {
                                    continue;
                                }

                                mString.extGetHashCodeWithoutChecking(ref ioHashCode);

                                continue;
                            }
                            else if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCodeWithoutChecking(ref ioHashCode);
                        }
                    }
                    break;

                case (ECommonOption.Value.WithoutChecking | ECommonOption.Value.WithoutWhiteSpace):
                    {
                        if (ioSource.extIsNull())
                        {
                            return;
                        }

                        foreach (var mElement in ioSource)
                        {
                            if (mElement.extIsNull())
                            {
                                continue;
                            }
                            else if (mElement is string)
                            {
                                string mString = (mElement as string);

                                if (string.IsNullOrWhiteSpace(mString))
                                {
                                    continue;
                                }

                                mString.extGetHashCodeWithoutChecking(ref ioHashCode);

                                continue;
                            }
                            else if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCodeWithoutChecking(ref ioHashCode);
                        }
                    }
                    break;

                case (ECommonOption.Value.WithoutChecking | ECommonOption.Value.IgnoreCase):
                    {
                        foreach (var mElement in ioSource)
                        {
                            if (mElement is string)
                            {
                                (mElement as string).extGetHashCodeWithIgnoreCaseAndWithoutChecking(ref ioHashCode);

                                continue;
                            }
                            else if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCodeWithoutChecking(ref ioHashCode);
                        }
                    }
                    break;

                case (ECommonOption.Value.WithoutNull | ECommonOption.Value.IgnoreCase):
                    {
                        if (ioSource.extIsNull())
                        {
                            return;
                        }

                        foreach (var mElement in ioSource)
                        {
                            if (mElement.extIsNull())
                            {
                                continue;
                            }
                            else if (mElement is string)
                            {
                                (mElement as string).extGetHashCodeWithIgnoreCase(ref ioHashCode);

                                continue;
                            }
                            else if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCode(ref ioHashCode);
                        }
                    }
                    break;

                case (ECommonOption.Value.WithoutEmpty | ECommonOption.Value.IgnoreCase):
                    {
                        if (ioSource.extIsNull())
                        {
                            return;
                        }

                        foreach (var mElement in ioSource)
                        {
                            if (mElement.extIsNull())
                            {
                                continue;
                            }
                            else if (mElement is string)
                            {
                                string mString = (mElement as string);

                                if (string.IsNullOrEmpty(mString))
                                {
                                    continue;
                                }

                                mString.extGetHashCodeWithIgnoreCase(ref ioHashCode);

                                continue;
                            }
                            else if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCode(ref ioHashCode);
                        }
                    }
                    break;

                case (ECommonOption.Value.WithoutWhiteSpace | ECommonOption.Value.IgnoreCase):
                    {
                        if (ioSource.extIsNull())
                        {
                            return;
                        }

                        foreach (var mElement in ioSource)
                        {
                            if (mElement.extIsNull())
                            {
                                continue;
                            }
                            else if (mElement is string)
                            {
                                string mString = (mElement as string);

                                if (string.IsNullOrWhiteSpace(mString))
                                {
                                    continue;
                                }

                                mString.extGetHashCodeWithIgnoreCase(ref ioHashCode);

                                continue;
                            }
                            else if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCode(ref ioHashCode);
                        }
                    }
                    break;

                case (ECommonOption.Value.WithoutChecking | ECommonOption.Value.WithoutNull | ECommonOption.Value.IgnoreCase):
                    {
                        if (ioSource.extIsNull())
                        {
                            return;
                        }

                        foreach (var mElement in ioSource)
                        {
                            if (mElement.extIsNull())
                            {
                                continue;
                            }
                            else if (mElement is string)
                            {
                                (mElement as string).extGetHashCodeWithIgnoreCaseAndWithoutChecking(ref ioHashCode);

                                continue;
                            }
                            else if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCodeWithoutChecking(ref ioHashCode);
                        }
                    }
                    break;

                case (ECommonOption.Value.WithoutChecking | ECommonOption.Value.WithoutEmpty | ECommonOption.Value.IgnoreCase):
                    {
                        if (ioSource.extIsNull())
                        {
                            return;
                        }

                        foreach (var mElement in ioSource)
                        {
                            if (mElement.extIsNull())
                            {
                                continue;
                            }
                            else if (mElement is string)
                            {
                                string mString = (mElement as string);

                                if (string.IsNullOrEmpty(mString))
                                {
                                    continue;
                                }

                                mString.extGetHashCodeWithIgnoreCaseAndWithoutChecking(ref ioHashCode);

                                continue;
                            }
                            else if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCodeWithoutChecking(ref ioHashCode);
                        }
                    }
                    break;

                case (ECommonOption.Value.WithoutChecking | ECommonOption.Value.WithoutWhiteSpace | ECommonOption.Value.IgnoreCase):
                    {
                        if (ioSource.extIsNull())
                        {
                            return;
                        }

                        foreach (var mElement in ioSource)
                        {
                            if (mElement.extIsNull())
                            {
                                continue;
                            }
                            else if (mElement is string)
                            {
                                string mString = (mElement as string);

                                if (string.IsNullOrWhiteSpace(mString))
                                {
                                    continue;
                                }

                                mString.extGetHashCodeWithIgnoreCaseAndWithoutChecking(ref ioHashCode);

                                continue;
                            }
                            else if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCodeWithoutChecking(ref ioHashCode);
                        }
                    }
                    break;

                default:
                    {
                        foreach (var mElement in ioSource)
                        {
                            if (mElement is IEnumerable)
                            {
                                extGetElementsHashCode((mElement as IEnumerable), ref ioHashCode, mForeachOption);

                                continue;
                            }

                            mElement.extGetHashCode(ref ioHashCode);
                        }
                    }
                    break;
            }
        }

        internal static void extGetElementsHashCode(this IEnumerable ioSource, ref int ioHashCode, ECommonOption.Enum iForeachOption, Action<Tuple<Exception, DateTime, string>> iException = null)
        {
            extGetElementsHashCode(ioSource, ref ioHashCode, (int)iForeachOption, iException);
        }

        internal static int extGetElementsHashCode(this IEnumerable ioSource, int iHashCode, int iForeachOption, Action<Tuple<Exception, DateTime, string>> iException = null)
        {
            extGetElementsHashCode(ioSource, ref iHashCode, iForeachOption, iException);

            return iHashCode;
        }

        internal static int extGetElementsHashCode(this IEnumerable ioSource, int iHashCode, ECommonOption.Enum iForeachOption, Action<Tuple<Exception, DateTime, string>> iException = null)
        {
            extGetElementsHashCode(ioSource, ref iHashCode, (int)iForeachOption, iException);

            return iHashCode;
        }
    }
}
