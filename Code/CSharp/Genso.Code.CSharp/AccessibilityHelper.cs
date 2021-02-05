using System;
using Microsoft.CodeAnalysis;

namespace Genso.Code.CSharp
{
    /// <summary>
    /// Provides helper methods for <see cref="Accessibility"/>
    /// </summary>
    public static class AccessibilityHelper
    {
        /// <summary>
        /// Creates the string to generate from <see cref="Accessibility"/>
        /// </summary>
        /// <param name="accessibility"></param>
        /// <exception cref="NotImplementedException">Thrown when the specified <see cref="Accessibility"/> is not implemented</exception>
        public static string ToGeneratorString(this Accessibility accessibility) => accessibility switch
        {
            Accessibility.Public => "public",
            Accessibility.Protected => "protected",
            Accessibility.Internal => "internal",
            Accessibility.ProtectedAndInternal => "protected internal",
            Accessibility.Private => "private",
            Accessibility.NotApplicable => "",
            _ => throw new NotImplementedException(accessibility.ToString()),
        };
    }
}
