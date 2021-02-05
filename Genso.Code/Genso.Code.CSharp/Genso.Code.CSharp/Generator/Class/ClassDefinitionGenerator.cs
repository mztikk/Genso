using System.Collections.Generic;
using Genso.Code.CSharp.CodeRepresentation;
using Genso.Generator;
using Genso.IO;

namespace Genso.Code.CSharp.Generator.Class
{
    /// <summary>
    /// Class to generate a C# Class definition
    /// </summary>
    public class ClassDefinitionGenerator : BaseGenerator
    {
        private readonly CSharpClass _class;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassDefinitionGenerator"/> class for the specified <see cref="IndentedStreamWriter"/>
        /// </summary>
        /// <param name="class"><see cref="CSharpClass"/> to generate definition for</param>
        /// <param name="writer"><see cref="IndentedStreamWriter"/> used to write to</param>
        public ClassDefinitionGenerator(CSharpClass @class, IndentedStreamWriter writer) : base(writer) => _class = @class;

        /// <summary>
        /// Writes the class definition
        /// </summary>
        /// <returns>Always <see langword="true"/></returns>
        public override bool Begin()
        {
            Write(string.Join(" ", GetClassDefinition()));

            return true;
        }

        private IEnumerable<string> GetClassDefinition()
        {
            if (_class.Accessibility.HasValue)
            {
                yield return _class.Accessibility.Value.ToGeneratorString();
            }
            if (_class.Static)
            {
                yield return "static";
            }
            if (_class.Partial)
            {
                yield return "partial";
            }

            yield return "class";
            yield return _class.Name;
        }

        /// <summary>
        /// Does not write anything
        /// </summary>
        /// <returns>Always <see langword="false"/></returns>
        public override bool End() => false;
    }
}
