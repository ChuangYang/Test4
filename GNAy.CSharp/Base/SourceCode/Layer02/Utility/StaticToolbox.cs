using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics;
using System.Diagnostics.Contracts;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
using GNAy.CSharp.Base.Internal.L0_ObjectExtensions;
using GNAy.CSharp.Base.Internal.L1_ContractHelper;
using GNAy.CSharp.Base.Internal.L1_DateTimeHelper;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L2_StaticToolbox
{
    [Pure]
    internal static class CStaticToolbox
    {
        #region Fields and properties.
        private static Stopwatch fStopwatch { set; get; }
        private static DateTime fCreationTime;

        private static Func<Tuple<Exception, DateTime, string>, bool> fDefaultExceptionHandler;
        #endregion

        #region Singleton, factory or constructor.
        static CStaticToolbox()
        {
            fStopwatch = new Stopwatch();
            //fStopwatch.Start();

            fCreationTime = (CDateTimeHelper.GetNow() - GetElapsedTime());

            fDefaultExceptionHandler = null;
        }
        #endregion

        #region Methods.
        /// <summary>
        /// Only for internal.
        /// </summary>
        /// <param name="ioStopwatch"></param>
        internal static void SetStopwatch(Stopwatch ioStopwatch)
        {
            fStopwatch.IsRunning.extRequireFalseOrThrow<SystemException>();
            (ioStopwatch.extIsNotNull() && ioStopwatch.IsRunning).extRequireOrThrow<SystemException>();

            fStopwatch = ioStopwatch;
            fCreationTime = (CDateTimeHelper.GetNow() - GetElapsedTime());
        }

        internal static DateTime GetCreationTime()
        {
            return fCreationTime;
        }

        internal static TimeSpan GetElapsedTime()
        {
            return fStopwatch.Elapsed;
        }

        internal static void SetDefaultExceptionHandler(Func<Tuple<Exception, DateTime, string>, bool> iDefaultExceptionHandler)
        {
            fDefaultExceptionHandler = iDefaultExceptionHandler;
        }

        internal static Func<Tuple<Exception, DateTime, string>, bool> GetDefaultExceptionHandler()
        {
            return fDefaultExceptionHandler;
        }
        #endregion
    }
}
