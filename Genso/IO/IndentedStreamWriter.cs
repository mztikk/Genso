using System;
using System.IO;
using Genso.Common;

namespace Genso.IO
{
    /// <summary>
    /// Using <see cref="StreamWriter"/> to write to a stream with indents
    /// </summary>
    public class IndentedStreamWriter : IDisposable
    {
        /// <summary>
        /// Underlying <see cref="Stream"/>
        /// </summary>
        protected readonly Stream _stream;
        private readonly StreamWriter _writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndentedStreamWriter"/> class for the specified stream
        /// </summary>
        /// <param name="stream"></param>
        public IndentedStreamWriter(Stream stream)
        {
            _stream = stream;
            _writer = new StreamWriter(stream);
        }

        /// <summary>
        /// Level of indentation
        /// </summary>
        public int IndentationLevel { get; set; } = 0;

        // Default 4 spaces
        /// <summary>
        /// Indenting string to use, default 4 spaces
        /// </summary>
        public string Indent { get; set; } = new string(' ', 4);

        private bool _indented = false;

        /// <summary>
        /// Writes a <see cref="string"/> to the stream with indenting, followed by a newline
        /// </summary>
        /// <param name="s"><see cref="string"/> to write</param>
        public virtual void WriteLine(string s = "")
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                Write(s);
            }

            DirectWriteLine();
        }

        /// <summary>
        /// Writes a <see cref="string"/> to the stream with indenting
        /// </summary>
        /// <param name="s"><see cref="string"/> to write</param>
        public virtual void Write(string s)
        {
            WriteIndent();

            DirectWrite(s);
        }

        /// <summary>
        /// Calls <see cref="OpenBrackets"/> and returns a <see cref="IDisposable"/> which will call <see cref="CloseBrackets"/> when disposed
        /// </summary>
        public virtual IDisposable UseBrackets()
        {
            OpenBrackets();
            return new DisposableAction(CloseBrackets);
        }

        /// <summary>
        /// Writes an opening curly bracket { and newline to the stream and increases <see cref="IndentationLevel"/>
        /// </summary>
        public virtual void OpenBrackets()
        {
            WriteLine("{");
            IndentationLevel++;
        }

        /// <summary>
        /// Decreases <see cref="IndentationLevel"/> and writes a closing curly bracket } and newline to the stream
        /// </summary>
        public virtual void CloseBrackets()
        {
            IndentationLevel--;
            WriteLine("}");
        }

        /// <summary>
        /// Writes the <see cref="Indent"/> with <see cref="IndentationLevel"/> to the stream
        /// </summary>
        /// <remarks>
        /// Will only write indent once when called multiple times
        /// </remarks>
        protected virtual void WriteIndent()
        {
            if (_indented)
            {
                return;
            }

            for (int i = 0; i < IndentationLevel; i++)
            {
                DirectWrite(Indent);
            }

            _indented = true;
        }

        /// <summary>
        /// Directly writes a <see cref="string"/> to the stream followed by a newline, without indenting
        /// </summary>
        /// <param name="s"><see cref="string"/> to write</param>
        protected virtual void DirectWriteLine(string s = "")
        {
            _writer.WriteLine(s);
            _writer.Flush();

            _indented = false;
        }

        /// <summary>
        /// Directly writes a <see cref="string"/> to the stream, without indenting
        /// </summary>
        /// <param name="s"><see cref="string"/> to write</param>
        protected virtual void DirectWrite(string s)
        {
            _writer.Write(s);
            _writer.Flush();
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Disposes the underlying stream
        /// </summary>
        /// <param name="disposing">Dispose managed objects</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _writer?.Dispose();
                    _stream?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~IndentedStreamWriter()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        /// <inheritdoc cref="Dispose(bool)"/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
