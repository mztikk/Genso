using Genso.Code.CSharp.CodeRepresentation;
using Genso.Generator;
using Genso.IO;

namespace Genso.Code.CSharp.Generator.Class
{
    /// <summary>
    /// Class to generate a C# Class
    /// </summary>
    public class ClassGenerator : BaseGenerator
    {
        private readonly CSharpClass _class;
        private readonly UsingGenerator _usingGenerator;
        private readonly NamespaceGenerator _namespaceGenerator;
        private readonly ClassDefinitionGenerator _classDefinitionGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassGenerator"/> class for the specified <see cref="IndentedStreamWriter"/>
        /// </summary>
        /// <param name="class"><see cref="CSharpClass"/> to generate</param>
        /// <param name="writer"><see cref="IndentedStreamWriter"/> used to write to</param>
        public ClassGenerator(CSharpClass @class, IndentedStreamWriter writer) : base(writer)
        {
            _class = @class;
            _usingGenerator = new UsingGenerator(_class.Usings, writer);
            _namespaceGenerator = new NamespaceGenerator(_class.Namespace, writer);
            _classDefinitionGenerator = new ClassDefinitionGenerator(_class, writer);
        }

        /// <summary>
        /// Begins writing the class. Usings, opening namespace, class definition
        /// </summary>
        /// <returns>Always <see langword="true"/></returns>
        public override bool Begin()
        {
            if (_usingGenerator.Make())
            {
                WriteLine();
            }

            _namespaceGenerator.Begin();

            _classDefinitionGenerator.Make();

            OpenBrackets();

            return true;
        }

        /// <summary>
        /// Finishes writing the class and namespace
        /// </summary>
        /// <returns>Always <see langword="true"/></returns>
        public override bool End()
        {
            // Close brackets for class
            CloseBrackets();

            _namespaceGenerator.End();

            return true;
        }
    }
}
