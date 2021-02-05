using System.Collections.Generic;
using Genso.Code.CSharp.CodeRepresentation;
using Genso.Generator;
using Genso.IO;

namespace Genso.Code.CSharp.Generator
{
    /// <summary>
    /// Class to generate a C# Field
    /// </summary>
    public class FieldGenerator : BaseGenerator
    {
        private readonly CSharpField _field;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldGenerator"/> class for the specified <see cref="IndentedStreamWriter"/>
        /// </summary>
        /// <param name="field">Field to generate</param>
        /// <param name="writer"><see cref="IndentedStreamWriter"/> used to write to</param>
        public FieldGenerator(CSharpField field, IndentedStreamWriter writer) : base(writer) => _field = field;

        /// <summary>
        /// Begins writing the namespace
        /// </summary>
        /// <returns><see langword="true"/> if it wrote anything</returns>
        public override bool Begin()
        {
            Write(string.Join(" ", GetFieldDescription()));

            if (_field.DefaultValue is { })
            {
                Write($" = {_field.DefaultValue}");
            }

            WriteLine(";");

            return true;
        }

        private IEnumerable<string> GetFieldDescription()
        {
            yield return _field.Accessibility.ToGeneratorString();

            if (_field.Static)
            {
                yield return "static";
            }
            if (_field.Readonly)
            {
                yield return "readonly";
            }
            if (_field.Const)
            {
                yield return "const";
            }

            yield return _field.Type;
            yield return _field.Name;
        }

        /// <summary>
        /// Does not write anything
        /// </summary>
        /// <returns>Always <see langword="false"/></returns>
        public override bool End() => false;
    }
}
