namespace Genso.CodeRepresentation.CSharp
{
#pragma warning disable CS1572 // XML comment has a param tag, but there is no parameter by that name
    /// <summary>
    /// Represents a CSharp class
    /// </summary>
    /// <param name="Name">Name of the class</param>
#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public record CSharpClass(string Name, string? @namespace, bool @static, bool partial) : Class(Name);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CS1572 // XML comment has a param tag, but there is no parameter by that name
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
}
