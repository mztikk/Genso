using System;
using System.Collections.Immutable;
using Genso.Code.CSharp.Generator;
using Genso.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Genso.Code.CSharp.Tests
{
    [TestClass]
    public class UsingGeneratorTests : BaseTest
    {
        [TestMethod]
        public void StartsWithUsing() => StartsWith(() => new[] { "System" }.ToImmutableArray(), "using");

        [TestMethod]
        public void NoUsingsIsEmpty() => string.IsNullOrWhiteSpace(Usings(() => Array.Empty<string>().ToImmutableArray()));

        [DataTestMethod]
        [DataRow("test")]
        [DataRow("System")]
        [DataRow("System.Collections.Immutable")]
        [DataRow("System.Text.RegularExpressions")]
        [DataRow("Genso.Code.CSharp.Generator")]
        [DataRow("Genso.Tests")]
        [DataRow("Microsoft.VisualStudio.TestTools.UnitTesting")]
        public void UsingStructureWithName(params string[] usings)
        {
            var usingsArray = usings.ToImmutableArray();
            foreach (string @using in usings)
            {
                Contains(() => usingsArray, $"using {@using};");
            }
        }

        private static void StartsWith(Func<ImmutableArray<string>> usingsFactory, string substring) => StringAssert.StartsWith(Usings(usingsFactory), substring);
        private static void Contains(Func<ImmutableArray<string>> usingsFactory, string substring) => StringAssert.Contains(Usings(usingsFactory), substring);

        private static string Usings(Func<ImmutableArray<string>> usingsFactory) => GetString((indentedWriter) => new UsingGenerator(usingsFactory(), indentedWriter).Make());
    }
}
