using System;
using Genso.Code.CSharp.Generator;
using Microsoft.CodeAnalysis;

namespace Genso.Code.CSharp.CodeRepresentation
{
#pragma warning disable CS1572 // XML comment has a param tag, but there is no parameter by that name
    /// <summary>
    /// Represents a CSharp Property
    /// </summary>
    /// <param name="Accessibility"><see cref="Microsoft.CodeAnalysis.Accessibility"/> of the property</param>
    /// <param name="Static">If the field is static</param>
    /// <param name="Type">Type of the property</param>
    /// <param name="Name">Name of the property</param>
    /// <param name="GetterAccessibility"><see cref="Microsoft.CodeAnalysis.Accessibility"/> of the get method, can be null</param>
    /// <param name="GetterBody">Body block of the get method, can be null</param>
    /// <param name="SetterAccessibility"><see cref="Microsoft.CodeAnalysis.Accessibility"/> of the set method, can be null</param>
    /// <param name="SetterBody">Body block of the set method, can be null</param>
    /// <param name="DefaultValue">Optional default value of the property</param>
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public record CSharpProperty(
        Accessibility Accessibility,
        bool Static,
        string Type,
        string Name,
        Accessibility? GetterAccessibility,
        Action<BodyGenerator>? GetterBody,
        Accessibility? SetterAccessibility,
        Action<BodyGenerator>? SetterBody,
        string? DefaultValue);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CS1572 // XML comment has a param tag, but there is no parameter by that name
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
}
