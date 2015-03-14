using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#endregion

#region Set the aliases.
#endregion

namespace GNAy.CSharp.Base.Internal.L0_StringExtensions
{
    [Pure]
    internal static class CStringExtensions
    {
        internal static bool extEquals(this string iSource, string iTarget, StringComparison iStringComparison)
        {
            if (object.ReferenceEquals(iSource, iTarget))
            {
                return true;
            }
            else if (iSource == null)
            {
                return (iTarget == null);
            }
            else if (iTarget == null)
            {
                return false;
            }

            return iTarget.Equals(iSource, iStringComparison);
        }

        internal static bool extEqualsWithIgnoreCase(this string iSource, string iTarget, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return extEquals(iSource, iTarget, iStringComparison);
        }

        internal static bool extNotEquals(this string iSource, string iTarget, StringComparison iStringComparison)
        {
            return !extEquals(iSource, iTarget, iStringComparison);
        }

        internal static bool extNotEqualsWithIgnoreCase(this string iSource, string iTarget, StringComparison iStringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return !extEquals(iSource, iTarget, iStringComparison);
        }

        internal static bool extIsInterned(this string iSource)
        {
            return (string.IsInterned(iSource) != null);
        }

        internal static bool extIsNotInterned(this string iSource)
        {
            return (string.IsInterned(iSource) == null);
        }

        internal static Guid extToGUID(this string iSource)
        {
            return new Guid(iSource);
        }

        internal static string extToValidString(this string iSource, Regex ioEscapes, string iReplacement)
        {
            return ioEscapes.Replace(iSource, iReplacement);
        }

        internal static string extToValidString(this string iSource, string iInvalidChars, string iReplacement)
        {
            return extToValidString(iSource, new Regex(string.Format("[{0}]", Regex.Escape(iInvalidChars))), iReplacement);
        }

        internal static string extToValidString(this string iSource, IEnumerable<char> ioInvalidChars, string iReplacement)
        {
            return extToValidString(iSource, new string((ioInvalidChars is char[]) ? (ioInvalidChars as char[]) : ioInvalidChars.ToArray()), iReplacement);
        }
    }
}
