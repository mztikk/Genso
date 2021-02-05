using System.IO;
using Genso.IO;

namespace Genso.Generator
{
    /// <summary>
    /// Base class for a Generator operating on a <see cref="IndentedStreamWriter"/>
    /// </summary>
    public abstract class BaseGenerator : IGenerator
    {
        /// <summary>
        /// Underlying <see cref="IndentedStreamWriter"/> used to write to
        /// </summary>
        protected readonly IndentedStreamWriter _writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseGenerator"/> class for the specified <see cref="IndentedStreamWriter"/>
        /// </summary>
        /// <param name="writer"><see cref="IndentedStreamWriter"/> used to write to</param>
        protected BaseGenerator(IndentedStreamWriter writer) => _writer = writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseGenerator"/> class for the specified <see cref="Stream"/>
        /// </summary>
        /// <param name="stream"><see cref="Stream"/> to write to</param>
        protected BaseGenerator(Stream stream) : this(new IndentedStreamWriter(stream)) { }

        /// <inheritdoc/>
        public abstract bool Begin();
        /// <inheritdoc/>
        public abstract bool End();

        /// <summary>
        /// Fully writes the data, calling <see cref="Begin"/> and <see cref="End"/>
        /// </summary>
        /// <returns>Should return <see langword="true"/> if it wrote anything</returns>
        public virtual bool Make()
        {
            bool begin = Begin();
            bool end = End();

            return begin || end;
        }

        /// <inheritdoc cref="IndentedStreamWriter.WriteLine"/>
        protected virtual void WriteLine(string s = "") => _writer.WriteLine(s);

        /// <inheritdoc cref="IndentedStreamWriter.Write"/>
        protected virtual void Write(string s) => _writer.Write(s);

        /// <inheritdoc cref="IndentedStreamWriter.OpenBrackets"/>
        protected virtual void OpenBrackets() => _writer.OpenBrackets();

        /// <inheritdoc cref="IndentedStreamWriter.CloseBrackets"/>
        protected virtual void CloseBrackets() => _writer.CloseBrackets();

        /// <inheritdoc cref="IndentedStreamWriter.IndentationLevel"/>
        public virtual int IndentationLevel
        {
            get => _writer.IndentationLevel;
            set => _writer.IndentationLevel = value;
        }

        /// <inheritdoc cref="IndentedStreamWriter.Indent"/>
        public virtual string Indent
        {
            get => _writer.Indent;
            set => _writer.Indent = value;
        }
    }
}
