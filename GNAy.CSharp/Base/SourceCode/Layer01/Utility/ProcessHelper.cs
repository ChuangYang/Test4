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
using GNAy.CSharp.Base.Const;
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L1_ProcessHelper
{
    [Pure]
    internal static class CProcessHelper
    {
        internal static bool extCloseOrKill(this Process ioProcess, int iMilliseconds)
        {
            if (!ioProcess.CloseMainWindow())
            {
                if (!ioProcess.WaitForExit((iMilliseconds < CConst.Zero) ? int.MaxValue : iMilliseconds))
                {
                    ioProcess.Kill();

                    return false;
                }
            }

            return true;
        }

        internal static bool[] extCloseOrKillAll(this string iProcessName, ushort iMilliseconds)
        {
            Process[] mProcesses = Process.GetProcessesByName(iProcessName);
            bool[] mResults = new bool[mProcesses.Length];

            if (mProcesses.Length == CConst.Zero)
            {
                return mResults;
            }
            else if (!Parallel.For(CConst.StartIndex, mProcesses.Length, iIndex =>
                {
                    mResults[iIndex] = extCloseOrKill(mProcesses[iIndex], iMilliseconds);
                }).IsCompleted)
            {
                throw new TaskCanceledException(CErrorMessage.TaskIsNotCompleted);
            }

            return mResults;
        }
    }
}
