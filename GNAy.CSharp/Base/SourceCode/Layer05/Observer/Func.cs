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

namespace GNAy.CSharp.Base.Internal.L5_FuncObserver
{
    /// <summary>
    /// FuncObserver (Event Observer) (Delegate Extensions)
    /// </summary>
    [Pure]
    internal static class CFuncObserver
    {
        internal static Tuple<bool, TResult> extInvoke<TResult>(this Func<TResult> iFunc, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            return CTryCatchObserver.Register(() => iFunc(), iExceptionHandler, iFinalHandler);
        }

        internal static Tuple<bool, TResult> extInvoke<TArgument, TResult>(this Func<TArgument, TResult> iFunc, TArgument ioArgument, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            return CTryCatchObserver.Register(() => iFunc(ioArgument), iExceptionHandler, iFinalHandler);
        }

        internal static Tuple<bool, TResult> extInvoke<TArgument1, TArgument2, TResult>(this Func<TArgument1, TArgument2, TResult> iFunc, TArgument1 ioArgument1, TArgument2 ioArgument2, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            return CTryCatchObserver.Register(() => iFunc(ioArgument1, ioArgument2), iExceptionHandler, iFinalHandler);
        }

        internal static Tuple<bool, TResult> extInvoke<TArgument1, TArgument2, TArgument3, TResult>(this Func<TArgument1, TArgument2, TArgument3, TResult> iFunc, TArgument1 ioArgument1, TArgument2 ioArgument2, TArgument3 ioArgument3, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            return CTryCatchObserver.Register(() => iFunc(ioArgument1, ioArgument2, ioArgument3), iExceptionHandler, iFinalHandler);
        }

        internal static Tuple<bool, TResult> extInvoke<TArgument1, TArgument2, TArgument3, TArgument4, TResult>(this Func<TArgument1, TArgument2, TArgument3, TArgument4, TResult> iFunc, TArgument1 ioArgument1, TArgument2 ioArgument2, TArgument3 ioArgument3, TArgument4 ioArgument4, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            return CTryCatchObserver.Register(() => iFunc(ioArgument1, ioArgument2, ioArgument3, ioArgument4), iExceptionHandler, iFinalHandler);
        }

        internal static Tuple<bool, TResult> extInvoke<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TResult>(this Func<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TResult> iFunc, TArgument1 ioArgument1, TArgument2 ioArgument2, TArgument3 ioArgument3, TArgument4 ioArgument4, TArgument5 ioArgument5, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            return CTryCatchObserver.Register(() => iFunc(ioArgument1, ioArgument2, ioArgument3, ioArgument4, ioArgument5), iExceptionHandler, iFinalHandler);
        }

        internal static Tuple<bool, TResult> extInvoke<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TResult>(this Func<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TResult> iFunc, TArgument1 ioArgument1, TArgument2 ioArgument2, TArgument3 ioArgument3, TArgument4 ioArgument4, TArgument5 ioArgument5, TArgument6 ioArgument6, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            return CTryCatchObserver.Register(() => iFunc(ioArgument1, ioArgument2, ioArgument3, ioArgument4, ioArgument5, ioArgument6), iExceptionHandler, iFinalHandler);
        }

        internal static Tuple<bool, TResult> extInvoke<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TResult>(this Func<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TResult> iFunc, TArgument1 ioArgument1, TArgument2 ioArgument2, TArgument3 ioArgument3, TArgument4 ioArgument4, TArgument5 ioArgument5, TArgument6 ioArgument6, TArgument7 ioArgument7, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            return CTryCatchObserver.Register(() => iFunc(ioArgument1, ioArgument2, ioArgument3, ioArgument4, ioArgument5, ioArgument6, ioArgument7), iExceptionHandler, iFinalHandler);
        }

        internal static Tuple<bool, TResult> extInvoke<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TResult>(this Func<TArgument1, TArgument2, TArgument3, TArgument4, TArgument5, TArgument6, TArgument7, TArgument8, TResult> iFunc, TArgument1 ioArgument1, TArgument2 ioArgument2, TArgument3 ioArgument3, TArgument4 ioArgument4, TArgument5 ioArgument5, TArgument6 ioArgument6, TArgument7 ioArgument7, TArgument8 ioArgument8, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null, Action iFinalHandler = null)
        {
            return CTryCatchObserver.Register(() => iFunc(ioArgument1, ioArgument2, ioArgument3, ioArgument4, ioArgument5, ioArgument6, ioArgument7, ioArgument8), iExceptionHandler, iFinalHandler);
        }
    }
}
