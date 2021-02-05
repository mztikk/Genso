using Microsoft.CodeAnalysis;

namespace Genso.Code.CSharp.CodeRepresentation
{
#pragma warning disable CS1572 // XML comment has a param tag, but there is no parameter by that name
    /// <summary>
    /// Represents a CSharp Field
    /// </summary>
    /// <param name="Accessibility"><see cref="Microsoft.CodeAnalysis.Accessibility"/> of the field</param>
    /// <param name="Readonly">If the field is readonly</param>
    /// <param name="Const">If the field is const</param>
    /// <param name="Static">If the field is static</param>
    /// <param name="Type">Type of the field</param>
    /// <param name="Name">Name of the field</param>
    /// <param name="DefaultValue">Optional default value of the field</param>
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public record CSharpField(Accessibility Accessibility, bool Readonly, bool Const, bool Static, string Type, string Name, string? DefaultValue);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CS1572 // XML comment has a param tag, but there is no parameter by that name
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
}
