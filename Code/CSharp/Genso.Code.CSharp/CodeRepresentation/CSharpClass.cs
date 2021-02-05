using System.Collections.Immutable;
using Genso.Code.CodeRepresentation;
using Microsoft.CodeAnalysis;

namespace Genso.Code.CSharp.CodeRepresentation
{
#pragma warning disable CS1572 // XML comment has a param tag, but there is no parameter by that name
    /// <summary>
    /// Represents a CSharp class
    /// </summary>
    /// <param name="Name">Name of the class</param>
    /// <param name="Namespace">Namespace the class is in</param>
    /// <param name="Accessibility"><see cref="Microsoft.CodeAnalysis.Accessibility"/> of the class</param>
    /// <param name="Usings">Usings the class uses</param>
    /// <param name="Static">If the class is static</param>
    /// <param name="Partial">If the class is partial</param>
    /// <param name="Fields">Fields of the class</param>
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public record CSharpClass(string Name, string? Namespace, Accessibility? Accessibility, ImmutableArray<string> Usings, bool Static, bool Partial, ImmutableArray<CSharpField> Fields) : Class(Name);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CS1572 // XML comment has a param tag, but there is no parameter by that name
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
}
