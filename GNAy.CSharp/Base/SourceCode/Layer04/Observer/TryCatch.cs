using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
using System.Threading;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
using GNAy.CSharp.Base.Internal.L3_ExceptionObserver;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L4_TryCatchObserver
{
    /// <summary>
    /// TryCatchObserver
    /// </summary>
    [Pure]
    internal static class CTryCatchObserver
    {
        internal static void Register(Action iTry, Action<Tuple<Exception, DateTime, string>> iException = null, Action iFinally = null)
        {
            try
            {
                iTry();
            }
            catch (Exception mException)
            {
                Register(() => iException.extInvoke(mException, mException.StackTrace));
            }
            finally
            {
                if (iFinally.extIsNotNull())
                {
                    Register(iFinally, iException);
                }
            }
        }

        internal static bool Register<TTryLock>(TTryLock ioSyncRoot, Action iTry, Action<Tuple<Exception, DateTime, string>> iException = null, Action iFinally = null)
        {
            if (!Monitor.TryEnter(ioSyncRoot))
            {
                return false;
            }

            try
            {
                iTry();

                return true;
            }
            catch (Exception mException)
            {
                Register(() => iException.extInvoke(mException, mException.StackTrace));

                return false;
            }
            finally
            {
                if (iFinally.extIsNotNull())
                {
                    Register(iFinally, iException);
                }

                Register(() => Monitor.Exit(ioSyncRoot), iException);
            }
        }

        internal static Tuple<bool, TResult> Register<TResult>(Func<TResult> iTry, Action<Tuple<Exception, DateTime, string>> iException = null, Action iFinally = null)
        {
            try
            {
                return new Tuple<bool, TResult>(true, iTry());
            }
            catch (Exception mException)
            {
                Register(() => iException.extInvoke(mException, mException.StackTrace));

                return new Tuple<bool, TResult>(false, default(TResult));
            }
            finally
            {
                if (iFinally.extIsNotNull())
                {
                    Register(iFinally, iException);
                }
            }
        }

        internal static Tuple<bool, TResult> Register<TTryLock, TResult>(TTryLock ioSyncRoot, Func<TResult> iTry, Action<Tuple<Exception, DateTime, string>> iException = null, Action iFinally = null)
        {
            if (!Monitor.TryEnter(ioSyncRoot))
            {
                return new Tuple<bool, TResult>(false, default(TResult));
            }

            try
            {
                return new Tuple<bool, TResult>(true, iTry());
            }
            catch (Exception mException)
            {
                Register(() => iException.extInvoke(mException, mException.StackTrace));

                return new Tuple<bool, TResult>(false, default(TResult));
            }
            finally
            {
                if (iFinally.extIsNotNull())
                {
                    Register(iFinally, iException);
                }

                Register(() => Monitor.Exit(ioSyncRoot), iException);
            }
        }
    }
}
