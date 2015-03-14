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
using GNAy.CSharp.Base.Internal.L4_TryCatchObserver;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L5_ActionObserver
{
    /// <summary>
    /// ActionObserver (Event Observer) (Delegate Extensions)
    /// </summary>
    [Pure]
    internal static class CActionObserver
    {
        internal static void extInvoke(this Action iEventHandler, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            CTryCatchObserver.Register(() => iEventHandler(), iExceptionHandler, iFinalHandler);
        }

        internal static void extInvoke<TArgument>(this Action<TArgument> iEventHandler, TArgument ioArgument, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            CTryCatchObserver.Register(() => iEventHandler(ioArgument), iExceptionHandler, iFinalHandler);
        }

        internal static void extInvoke<TArgument1, TArgument2>(this Action<TArgument1, TArgument2> iEventHandler, TArgument1 ioArgument1, TArgument2 ioArgument2, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            CTryCatchObserver.Register(() => iEventHandler(ioArgument1, ioArgument2), iExceptionHandler, iFinalHandler);
        }

        internal static void extInvoke<TArgument1, TArgument2, TArgument3>(this Action<TArgument1, TArgument2, TArgument3> iEventHandler, TArgument1 ioArgument1, TArgument2 ioArgument2, TArgument3 ioArgument3, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            CTryCatchObserver.Register(() => iEventHandler(ioArgument1, ioArgument2, ioArgument3), iExceptionHandler, iFinalHandler);
        }

        internal static void extInvoke<TArgument1, TArgument2, TArgument3, TArgument4>(this Action<TArgument1, TArgument2, TArgument3, TArgument4> iEventHandler, TArgument1 ioArgument1, TArgument2 ioArgument2, TArgument3 ioArgument3, TArgument4 ioArgument4, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            CTryCatchObserver.Register(() => iEventHandler(ioArgument1, ioArgument2, ioArgument3, ioArgument4), iExceptionHandler, iFinalHandler);
        }

        internal static void extInvoke<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5>(this Action<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5> iEventHandler, TArgument1 ioArgument1, TArgument2 ioArgument2, TArgument3 ioArgument3, TArgument4 ioArgument4, TArgument5 ioArgument5, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            CTryCatchObserver.Register(() => iEventHandler(ioArgument1, ioArgument2, ioArgument3, ioArgument4, ioArgument5), iExceptionHandler, iFinalHandler);
        }

        internal static void extInvoke<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6>(this Action<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6> iEventHandler, TArgument1 ioArgument1, TArgument2 ioArgument2, TArgument3 ioArgument3, TArgument4 ioArgument4, TArgument5 ioArgument5, TArgument6 ioArgument6, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            CTryCatchObserver.Register(() => iEventHandler(ioArgument1, ioArgument2, ioArgument3, ioArgument4, ioArgument5, ioArgument6), iExceptionHandler, iFinalHandler);
        }

        internal static void extInvoke<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7>(this Action<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7> iEventHandler, TArgument1 ioArgument1, TArgument2 ioArgument2, TArgument3 ioArgument3, TArgument4 ioArgument4, TArgument5 ioArgument5, TArgument6 ioArgument6, TArgument7 ioArgument7, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            CTryCatchObserver.Register(() => iEventHandler(ioArgument1, ioArgument2, ioArgument3, ioArgument4, ioArgument5, ioArgument6, ioArgument7), iExceptionHandler, iFinalHandler);
        }

        internal static void extInvoke<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8>(this Action<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8> iEventHandler, TArgument1 ioArgument1, TArgument2 ioArgument2, TArgument3 ioArgument3, TArgument4 ioArgument4, TArgument5 ioArgument5, TArgument6 ioArgument6, TArgument7 ioArgument7, TArgument8 ioArgument8, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            CTryCatchObserver.Register(() => iEventHandler(ioArgument1, ioArgument2, ioArgument3, ioArgument4, ioArgument5, ioArgument6, ioArgument7, ioArgument8), iExceptionHandler, iFinalHandler);
        }
    }
}
