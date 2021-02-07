using System.Collections.Generic;
using Genso.Code.CSharp.CodeRepresentation;
using Genso.Generator;
using Genso.IO;

namespace Genso.Code.CSharp.Generator
{
    /// <summary>
    /// Class to generate a C# Property
    /// </summary>
    public class PropertyGenerator : BaseGenerator
    {
        private readonly CSharpProperty _property;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyGenerator"/> class for the specified <see cref="IndentedStreamWriter"/>
        /// </summary>
        /// <param name="property">Property to generate</param>
        /// <param name="writer"><see cref="IndentedStreamWriter"/> used to write to</param>
        public PropertyGenerator(CSharpProperty property, IndentedStreamWriter writer) : base(writer) => _property = property;

        /// <summary>
        /// Begins writing the namespace
        /// </summary>
        /// <returns><see langword="true"/> if it wrote anything</returns>
        public override bool Begin()
        {
            Write(string.Join(" ", GetPropertyDescription()));

            Write(" { ");

            if (_property.GetterAccessibility.HasValue)
            {
                Write(_property.GetterAccessibility.Value.ToGeneratorString());
                Write(" ");
            }
            Write("get;");

            Write(" ");

            if (_property.SetterAccessibility.HasValue)
            {
                Write(_property.SetterAccessibility.Value.ToGeneratorString());
                Write(" ");
            }
            Write("set;");

            Write(" } ");
            WriteLine();

            return true;
        }

        private IEnumerable<string> GetPropertyDescription()
        {
            yield return _property.Accessibility.ToGeneratorString();

            if (_property.Static)
            {
                yield return "static";
            }

            yield return _property.Type;
            yield return _property.Name;
        }

        /// <summary>
        /// Does not write anything
        /// </summary>
        /// <returns>Always <see langword="false"/></returns>
        public override bool End() => false;
    }
}
