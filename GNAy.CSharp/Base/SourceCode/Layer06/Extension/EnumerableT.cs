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
using GNAy.CSharp.Base.Const;
using GNAy.CSharp.Base.Internal.L0_TupleExtensions;
using GNAy.CSharp.Base.Internal.L4_TryCatchObserver;
using GNAy.CSharp.Base.Internal.L5_ActionObserver;
using GNAy.CSharp.Base.Internal.L5_FuncObserver;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L6_EnumerableTExtensions
{
    [Pure]
    internal static class CEnumerableTExtension
    {
        internal static void extForeach<T>(this IEnumerable<T> ioSource, Action<T> iAction, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null)
        {
            CTryCatchObserver.Register(
                () =>
                {
                    foreach (T mItem in ioSource)
                    {
                        iAction.extInvoke(mItem, iExceptionHandler);
                    }
                },
                iExceptionHandler
                );
        }

        internal static void extForeach<T>(this IEnumerable<T> ioSource, Func<T, bool> iFunc, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null)
        {
            CTryCatchObserver.Register(
                () =>
                {
                    foreach (T mItem in ioSource)
                    {
                        if (iFunc.extInvoke(mItem, iExceptionHandler).extGetReturn())
                        {
                            break;
                        }
                    }
                },
                iExceptionHandler
                );
        }

        internal static void extForeach<T>(this IEnumerable<T> ioSource, Action<T, int> iAction, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null)
        {
            CTryCatchObserver.Register(
                () =>
                {
                    int mIndex = CConst.NotFound;

                    foreach (T mItem in ioSource)
                    {
                        iAction.extInvoke(mItem, ++mIndex, iExceptionHandler);
                    }
                },
                iExceptionHandler
                );
        }

        internal static void extForeach<T>(this IEnumerable<T> ioSource, Func<T, int, bool> iFunc, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null)
        {
            CTryCatchObserver.Register(
                () =>
                {
                    int mIndex = CConst.NotFound;

                    foreach (T mItem in ioSource)
                    {
                        if (iFunc.extInvoke(mItem, ++mIndex, iExceptionHandler).extGetReturn())
                        {
                            break;
                        }
                    }
                },
                iExceptionHandler
                );
        }

        internal static ParallelLoopResult extParallelForeach<T>(this IEnumerable<T> ioSource, Action<T> iAction, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null)
        {
            ParallelLoopResult mParallelLoopResult = default(ParallelLoopResult);

            CTryCatchObserver.Register(
                () =>
                {
                    if (!(mParallelLoopResult = Parallel.ForEach(ioSource, ioItem => iAction.extInvoke(ioItem, iExceptionHandler))).IsCompleted)
                    {
                        throw new TaskSchedulerException(CErrorMessage.TaskIsNotCompleted);
                    }
                },
                iExceptionHandler
                );

            return mParallelLoopResult;
        }

        internal static ParallelLoopResult extParallelForeach<T>(this IEnumerable<T> ioSource, ParallelOptions ioParallelOptions, Action<T> iAction, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null)
        {
            ParallelLoopResult mParallelLoopResult = default(ParallelLoopResult);

            CTryCatchObserver.Register(
                () =>
                {
                    if (!(mParallelLoopResult = Parallel.ForEach(ioSource, ioParallelOptions, ioItem => iAction.extInvoke(ioItem, iExceptionHandler))).IsCompleted)
                    {
                        throw new TaskSchedulerException(CErrorMessage.TaskIsNotCompleted);
                    }
                },
                iExceptionHandler
                );

            return mParallelLoopResult;
        }

        internal static ParallelLoopResult extParallelForeach<T>(this IEnumerable<T> ioSource, Action<T, ParallelLoopState> iAction, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null)
        {
            ParallelLoopResult mParallelLoopResult = default(ParallelLoopResult);

            CTryCatchObserver.Register(
                () =>
                {
                    if (!(mParallelLoopResult = Parallel.ForEach(ioSource, (ioItem, ioParallelLoopState) => iAction.extInvoke(ioItem, ioParallelLoopState, iExceptionHandler))).IsCompleted)
                    {
                        throw new TaskSchedulerException(CErrorMessage.TaskIsNotCompleted);
                    }
                },
                iExceptionHandler
                );

            return mParallelLoopResult;
        }

        internal static ParallelLoopResult extParallelForeach<T>(this IEnumerable<T> ioSource, ParallelOptions ioParallelOptions, Action<T, ParallelLoopState> iAction, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null)
        {
            ParallelLoopResult mParallelLoopResult = default(ParallelLoopResult);

            CTryCatchObserver.Register(
                () =>
                {
                    if (!(mParallelLoopResult = Parallel.ForEach(ioSource, ioParallelOptions, (ioItem, ioParallelLoopState) => iAction.extInvoke(ioItem, ioParallelLoopState, iExceptionHandler))).IsCompleted)
                    {
                        throw new TaskSchedulerException(CErrorMessage.TaskIsNotCompleted);
                    }
                },
                iExceptionHandler
                );

            return mParallelLoopResult;
        }

        internal static ParallelLoopResult extParallelForeach<T>(this IEnumerable<T> ioSource, Action<T, ParallelLoopState, long> iAction, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null)
        {
            ParallelLoopResult mParallelLoopResult = default(ParallelLoopResult);

            CTryCatchObserver.Register(
                () =>
                {
                    if (!(mParallelLoopResult = Parallel.ForEach(ioSource, (ioItem, ioParallelLoopState, iIndex) => iAction.extInvoke(ioItem, ioParallelLoopState, iIndex, iExceptionHandler))).IsCompleted)
                    {
                        throw new TaskSchedulerException(CErrorMessage.TaskIsNotCompleted);
                    }
                },
                iExceptionHandler
                );

            return mParallelLoopResult;
        }

        internal static ParallelLoopResult extParallelForeach<T>(this IEnumerable<T> ioSource, ParallelOptions ioParallelOptions, Action<T, ParallelLoopState, long> iAction, Action<Tuple<Exception, DateTime, string>> iExceptionHandler = null)
        {
            ParallelLoopResult mParallelLoopResult = default(ParallelLoopResult);

            CTryCatchObserver.Register(
                () =>
                {
                    if (!(mParallelLoopResult = Parallel.ForEach(ioSource, ioParallelOptions, (ioItem, ioParallelLoopState, iIndex) => iAction.extInvoke(ioItem, ioParallelLoopState, iIndex, iExceptionHandler))).IsCompleted)
                    {
                        throw new TaskSchedulerException(CErrorMessage.TaskIsNotCompleted);
                    }
                },
                iExceptionHandler
                );

            return mParallelLoopResult;
        }
    }
}
