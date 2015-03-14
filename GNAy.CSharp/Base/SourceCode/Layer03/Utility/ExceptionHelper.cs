using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Net;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Const;
using GNAy.CSharp.Base.Enumeration;
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
using GNAy.CSharp.Base.Internal.L0_TupleExtensions;
using GNAy.CSharp.Base.Internal.L1_ContractHelper;
using GNAy.CSharp.Base.Internal.L2_EnumerationHelper;
using GNAy.CSharp.Base.Internal.L2_ExceptionHelper;
using GNAy.CSharp.Base.Internal.L2_LibrarySetting;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L3_ExceptionHelper
{
    [Pure]
    internal static class CExceptionHelper
    {
        private static bool continueToGetExceptions(ref Tuple<Exception, DateTime, string> ioRecord, ref Exception ioException)
        {
            if ((ioException = ioException.InnerException).extIsNull())
            {
                return false;
            }

            ioRecord = ioException.extToRecord(ioRecord.extGetEventTime(), ioException.StackTrace, false);

            return true;
        }

        /// <summary>
        /// Get the exceptions that each exception has Message.
        /// </summary>
        /// <param name="ioSource"></param>
        /// <param name="iThrowException"></param>
        /// <returns>The exceptions that each exception has Message.</returns>
        internal static IEnumerable<Tuple<Exception, DateTime, string>> extGetAllExceptions(this Tuple<Exception, DateTime, string> ioSource, bool iThrowException = false)
        {
            if (ioSource.extIsNull())
            {
                if (iThrowException)
                {
                    throw new ArgumentNullException(CErrorMessage.ObjectIsNull);
                }

                false.extRequire();

                yield break;
            }

            Tuple<Exception, DateTime, string> mSource = ioSource;
            Exception mSourceException = ioSource.extGetException();

            if (mSourceException.extIsNull())
            {
                if (iThrowException)
                {
                    throw new ArgumentNullException(CErrorMessage.ObjectIsNull);
                }

                false.extRequire();

                yield break;
            }

            do
            {
                string mMessage = CConst.StringEmpty;

                try
                {
                    mMessage = mSourceException.Message;
                }
                catch //(Exception mException)
                {
                    if (iThrowException)
                    {
                        throw;
                    }
                }
                finally
                { }

                if (string.IsNullOrWhiteSpace(mMessage).extRequireFalse())
                {
                    continue;
                }

                yield return mSource;

                if (!(mSourceException is AggregateException))
                {
                    continue;
                }

                foreach (Exception mInnerException in (mSourceException as AggregateException).InnerExceptions)
                {
                    if (mInnerException.extIsNull().extRequireFalse())
                    {
                        continue;
                    }

                    foreach (Tuple<Exception, DateTime, string> mExceptionRecord in extGetAllExceptions(mInnerException.extToRecord(mSource.extGetEventTime(), mInnerException.StackTrace, false), iThrowException))
                    {
                        yield return mExceptionRecord;
                    }
                }
            } while (continueToGetExceptions(ref mSource, ref mSourceException));
        }

        internal static Tuple<bool, string> extGetResponseString(this WebException ioSource, bool iThrowException = true)
        {
            try
            {
                using (StreamReader mStreamReader = new StreamReader(ioSource.Response.GetResponseStream()))
                {
                    return new Tuple<bool, string>(true, mStreamReader.ReadToEnd());
                }
            }
            catch (Exception mException)
            {
                if (iThrowException)
                {
                    throw;
                }

                return new Tuple<bool, string>(false, extToString(mException.extToRecord(mException.StackTrace), iThrowException));
            }
            finally
            { }
        }

        private static void convertFlag(int iFlag, Tuple<Exception, DateTime, string> ioRecord, StringBuilder ioExceptionString, ref string ioTemp, bool iThrowException = false)
        {
            try
            {
                Exception mException = ioRecord.extGetException();

                switch (iFlag)
                {
                    case EExceptionFormat.Value.Time:
                        {
                            ioExceptionString.Append(ioRecord.extGetEventTime()).Append(CLibrarySetting.GetSeparator());
                        }
                        break;

                    case EExceptionFormat.Value.Type:
                        {
                            ioExceptionString.Append(mException.GetType().FullName).Append(CLibrarySetting.GetSeparator());
                        }
                        break;

                    case EExceptionFormat.Value.Message:
                        {
                            ioExceptionString.Append(mException.Message).Append(CLibrarySetting.GetSeparator());
                        }
                        break;

                    case EExceptionFormat.Value.HResult:
                        {
                            ioExceptionString.Append(mException.HResult).Append(CLibrarySetting.GetSeparator());
                        }
                        break;

                    case EExceptionFormat.Value.ResponseString:
                        {
                            WebException mWebException = (mException as WebException);

                            if (mWebException.extIsNull())
                            {
                                break;
                            }
                            else if (string.IsNullOrWhiteSpace(ioTemp = extGetResponseString(mWebException, iThrowException).extGetReturn()))
                            {
                                break;
                            }

                            ioExceptionString.Append(ioTemp).Append(CLibrarySetting.GetSeparator());
                        }
                        break;

                    case EExceptionFormat.Value.HelpLink:
                        {
                            if (string.IsNullOrWhiteSpace(ioTemp = mException.HelpLink))
                            {
                                break;
                            }

                            ioExceptionString.Append(ioTemp).Append(CLibrarySetting.GetSeparator());
                        }
                        break;

                    case EExceptionFormat.Value.ResponseUri:
                        {
                            WebException mWebException = (mException as WebException);

                            if (mWebException.extIsNull())
                            {
                                break;
                            }

                            Uri mURI = mWebException.Response.ResponseUri;

                            if (mURI.extIsNull())
                            {
                                break;
                            }

                            ioExceptionString.Append(mURI).Append(CLibrarySetting.GetSeparator());
                        }
                        break;

                    case EExceptionFormat.Value.Source:
                        {
                            if (string.IsNullOrWhiteSpace(ioTemp = mException.Source))
                            {
                                break;
                            }

                            ioExceptionString.Append(ioTemp).Append(CLibrarySetting.GetSeparator());
                        }
                        break;

                    case EExceptionFormat.Value.StackTrace:
                        {
                            if (string.IsNullOrWhiteSpace(ioTemp = ioRecord.extGetStackTrace()))
                            {
                                break;
                            }

                            ioExceptionString.Append(ioTemp).Append(CLibrarySetting.GetSeparator());
                        }
                        break;

                    case EExceptionFormat.Value.String:
                        {
                            if (string.IsNullOrWhiteSpace(ioTemp = mException.ToString()))
                            {
                                break;
                            }

                            ioExceptionString.Append(ioTemp).Append(CLibrarySetting.GetSeparator());
                        }
                        break;

                    default:
                        throw new ArgumentException(string.Format("[{0}][{1}]", CErrorMessage.UnknownCase, iFlag));
                }
            }
            catch //(Exception mException)
            {
                if (iThrowException)
                {
                    throw;
                }

                false.extRequire();
            }
            finally
            { }
        }

        private static string toFormatString(Tuple<Exception, DateTime, string> ioRecord, StringBuilder ioExceptionString, ref string ioTemp, ref int ioHeadLength, bool iThrowException = false)
        {
            try
            {
                ioExceptionString.Clear();

                foreach (int mFlag in CLibrarySetting.GetExceptionFormatCollection().extForeachIntFlag())
                {
                    convertFlag(mFlag, ioRecord, ioExceptionString, ref ioTemp, iThrowException);
                }

                if ((ioHeadLength > CConst.Zero) && (ioExceptionString.Length >= ioHeadLength))
                {
                    ioExceptionString.Insert(CConst.StartIndex, CLibrarySetting.GetSeparatorHead());
                    ioExceptionString.Replace(CLibrarySetting.GetSeparatorHead(), CConst.StringEmpty, (ioExceptionString.Length - ioHeadLength), ioHeadLength);
                }

                if (!CLibrarySetting.GetBucket().extClassEquals(CConst.FormatInitial))
                {
                    ioExceptionString = ioExceptionString.Insert(CConst.StartIndex, CLibrarySetting.GetSeparatorHead()).Append(CLibrarySetting.GetSeparatorTail());
                }
            }
            catch //(Exception mException)
            {
                if (iThrowException)
                {
                    throw;
                }

                false.extRequire();
            }
            finally
            { }

            return ioExceptionString.ToString();
        }

        /// <summary>
        /// <para>Get the exceptions that each exception has Message.</para>
        /// <para>Then merging all the exceptions to be one string.</para>
        /// </summary>
        /// <param name="ioSource"></param>
        /// <param name="iThrowException"></param>
        /// <param name="iSeparator"></param>
        /// <returns>The exceptions that each exception has Message.</returns>
        internal static string extToString(this Tuple<Exception, DateTime, string> ioSource, bool iThrowException = false, string iSeparator = CConst.NewLine)
        {
            string mTemp = CConst.StringEmpty;
            int mHeadLength = CLibrarySetting.GetSeparatorHead().Length;

            return string.Join(iSeparator, extGetAllExceptions(ioSource, iThrowException).Select(ioRecord => toFormatString(ioRecord, new StringBuilder(), ref mTemp, ref mHeadLength, iThrowException)));
        }
    }
}
