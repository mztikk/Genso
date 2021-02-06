using Genso.IO;

namespace Genso.Code.CSharp.Generator
{
    /// <summary>
    /// Provides methods to help generate code inside if bodies of methods, ctor, etc, using a <see cref="IndentedStreamWriter"/>
    /// </summary>
    public class BodyGenerator
    {
        private readonly IndentedStreamWriter _writer;

        /// <summary>
        /// Creates a new instance of a <see cref="BodyGenerator"/> operating on a <see cref="IndentedStreamWriter"/>
        /// </summary>
        /// <param name="writer"><see cref="IndentedStreamWriter"/> used to write</param>
        public BodyGenerator(IndentedStreamWriter writer) => _writer = writer;

        /// <inheritdoc cref="IndentedStreamWriter.WriteLine(string)"/>
        public virtual BodyGenerator WriteLine(string s = "")
        {
            _writer.WriteLine(s);
            return this;
        }

        /// <inheritdoc cref="IndentedStreamWriter.Write(string)"/>
        public virtual BodyGenerator Write(string s)
        {
            _writer.Write(s);
            return this;
        }

        /// <inheritdoc cref="IndentedStreamWriter.OpenBrackets"/>
        public virtual BodyGenerator OpenBrackets()
        {
            _writer.OpenBrackets();
            return this;
        }

        /// <inheritdoc cref="IndentedStreamWriter.CloseBrackets"/>
        public virtual BodyGenerator CloseBrackets()
        {
            _writer.CloseBrackets();
            return this;
        }

        /// <summary>
        /// Writes a return statement
        /// </summary>
        public BodyGenerator WriteReturn()
        {
            Write("return ");
            return this;
        }

        /// <summary>
        /// Writes a return statement for a given <paramref name="returnValue"/>
        /// </summary>
        /// <param name="returnValue">Value to write as return</param>
        public BodyGenerator WriteReturn(string returnValue)
        {
            WriteReturn().Write($"{returnValue};");
            return this;
        }
    }
}
