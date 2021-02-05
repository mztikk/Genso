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
        /// <param name="class"><see cref="CSharpClass"/> to generate</param>
        /// <param name="writer"><see cref="IndentedStreamWriter"/> used to write to</param>
        public ClassDefinitionGenerator(CSharpClass @class, IndentedStreamWriter writer) : base(writer) => _class = @class;

        /// <summary>
        /// Begins writing the class. Usings, opening namespace, class definition
        /// </summary>
        /// <returns>Always <see langword="true"/></returns>
        public override bool Begin()
        {
            var classDescription = new List<string>();
            if (_class.Accessibility.HasValue)
            {
                classDescription.Add(_class.Accessibility.Value.ToGeneratorString());
            }
            if (_class.Static)
            {
                classDescription.Add("static");
            }
            if (_class.Partial)
            {
                classDescription.Add("partial");
            }

            classDescription.Add("class");
            classDescription.Add(_class.Name);

            Write(string.Join(" ", classDescription));

            return true;
        }

        /// <summary>
        /// Does not write anything
        /// </summary>
        /// <returns>Always <see langword="false"/></returns>
        public override bool End() => false;
    }
}
