using System;
using Genso.Code.CSharp.CodeRepresentation;
using Genso.Generator;

namespace Genso.Code.CSharp.Generator
{
    /// <inheritdoc/>
    public class ClassGenerator : BaseGenerator
    {
        private readonly CSharpClass _class;

        /// <inheritdoc/>
        public ClassGenerator(CSharpClass @class, IO.IndentedStreamWriter writer) : base(writer)
        {
            _class = @class;
        }

        /// <inheritdoc/>
        public ClassGenerator(CSharpClass @class, System.IO.Stream stream) : base(stream)
        {
            _class = @class;
        }

        /// <inheritdoc/>
        public override bool Begin()
        {
            var usingGen = new UsingGenerator(_class.Usings, _writer);

            if (usingGen.Make())
            {
                WriteLine();
            }
        }

        /// <inheritdoc/>
        public override bool End() => throw new NotImplementedException();
    }
}
