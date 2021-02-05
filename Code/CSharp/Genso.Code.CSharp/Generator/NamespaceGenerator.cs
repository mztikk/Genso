using Genso.Generator;
using Genso.IO;

namespace Genso.Code.CSharp.Generator
{
    /// <summary>
    /// Class to generate a C# namespace
    /// </summary>
    public class NamespaceGenerator : BaseGenerator
    {
        private readonly string? _namespace;

        /// <summary>
        /// Initializes a new instance of the <see cref="NamespaceGenerator"/> class for the specified <see cref="IndentedStreamWriter"/>
        /// </summary>
        /// <param name="namespace">namespace to generate</param>
        /// <param name="writer"><see cref="IndentedStreamWriter"/> used to write to</param>
        public NamespaceGenerator(string? @namespace, IndentedStreamWriter writer) : base(writer) => _namespace = @namespace;

        /// <summary>
        /// Begins writing the namespace
        /// </summary>
        /// <returns><see langword="true"/> if it wrote anything</returns>
        public override bool Begin()
        {
            if (_namespace is { })
            {
                WriteLine($"namespace {_namespace}");
                OpenBrackets();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Finishes writing the namespace
        /// </summary>
        /// <returns><see langword="true"/> if it wrote anything</returns>
        public override bool End()
        {
            if (_namespace is { })
            {
                CloseBrackets();

                return true;
            }

            return false;
        }
    }
}
