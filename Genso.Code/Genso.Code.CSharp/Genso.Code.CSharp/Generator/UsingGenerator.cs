using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Genso.Generator;
using Genso.IO;

namespace Genso.Code.CSharp.Generator
{
    /// <summary>
    /// Class to generate C# using statements
    /// </summary>
    public class UsingGenerator : BaseGenerator
    {
        private readonly ImmutableArray<string> _usings;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsingGenerator"/> class for the specified <see cref="IndentedStreamWriter"/>
        /// </summary>
        /// <param name="usings">usings to generate</param>
        /// <param name="writer"><see cref="IndentedStreamWriter"/> used to write to</param>
        public UsingGenerator(ImmutableArray<string> usings, IndentedStreamWriter writer) : base(writer) => _usings = usings;

        private IEnumerable<string> GetUsingStatements()
        {
            foreach (string item in _usings)
            {
                yield return "using " + item + ";";
            }
        }

        private string GetUsingsString() => string.Join(Environment.NewLine, GetUsingStatements());

        /// <summary>
        /// Writes all using statements
        /// </summary>
        /// <returns><see langword="true"/> if it wrote anything</returns>
        public override bool Begin()
        {
            if (_usings.Length > 0)
            {
                WriteLine(GetUsingsString());
            }

            return _usings.Length > 0;
        }

        /// <summary>
        /// Does not write anything
        /// </summary>
        /// <returns>Always <see langword="false"/></returns>
        public override bool End() => false;
    }
}
