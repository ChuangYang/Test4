using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
using GNAy.CSharp.Base.Internal.L1_ContractHelper;
using GNAy.CSharp.Base.Internal.L2_ExceptionHelper;
using GNAy.CSharp.Base.Internal.L2_LibrarySetting;
using GNAy.CSharp.Base.Internal.L2_StaticToolbox;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L3_ExceptionObserver
{
    /// <summary>
    /// ExceptionObserver (Event Observer) (Delegate Extensions)
    /// </summary>
    [Pure]
    internal static class CExceptionObserver
    {
        internal static void extInvoke(this Action<Tuple<Exception, DateTime, string>> iExceptionHandler, Exception ioException, string iStackTrace)
        {
            Tuple<Exception, DateTime, string> mRecord = ioException.extToRecord(iStackTrace);

            if (iExceptionHandler.extIsNull())
            {
                CStaticToolbox.GetDefaultExceptionHandler().extIsNotNull().extRequireOrThrow(ioException);
                (!CStaticToolbox.GetDefaultExceptionHandler()(mRecord) && CLibrarySetting.ThrowUnhandledException()).extRequireFalseOrThrow(ioException);

                return;
            }

            iExceptionHandler(mRecord);
        }

        internal static Tuple<bool, TResult> extInvoke<TResult>(this Func<Tuple<Exception, DateTime, string>, TResult> iExceptionHandler, Exception ioException, string iStackTrace)
        {
            Tuple<Exception, DateTime, string> mRecord = ioException.extToRecord(iStackTrace);

            if (iExceptionHandler.extIsNull())
            {
                CStaticToolbox.GetDefaultExceptionHandler().extIsNotNull().extRequireOrThrow(ioException);
                (!CStaticToolbox.GetDefaultExceptionHandler()(mRecord) && CLibrarySetting.ThrowUnhandledException()).extRequireFalseOrThrow(ioException);

                return new Tuple<bool, TResult>(false, default(TResult));
            }

            return new Tuple<bool, TResult>(true, iExceptionHandler(mRecord));
        }
    }
}
