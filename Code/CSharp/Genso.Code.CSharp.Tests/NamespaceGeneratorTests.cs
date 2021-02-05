using System;
using System.Text.RegularExpressions;
using Genso.Code.CSharp.Generator;
using Genso.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Genso.Code.CSharp.Tests
{
    [TestClass]
    public class NamespaceGeneratorTests : BaseTest
    {
        [TestMethod]
        public void StartsWithNamespace() => StartsWith(() => string.Empty, "namespace");

        [DataTestMethod]
        [DataRow("test")]
        [DataRow("System")]
        [DataRow("System.Text.RegularExpressions")]
        [DataRow("Genso.Code.CSharp.Generator")]
        [DataRow("Genso.Tests")]
        [DataRow("Microsoft.VisualStudio.TestTools.UnitTesting")]
        [DataRow("äöüßá´à`")]
        public void NamespaceNameTest(string name)
        {
            Contains(() => name, name);
            StartsWith(() => name, $"namespace {name}");
        }

        [TestMethod]
        public void NamespaceStructureTest() => Matches(() => string.Empty, new Regex("namespace .*\\{.*\\}", RegexOptions.Singleline));

        [DataTestMethod]
        [DataRow("test")]
        public void NamespaceStructureWithNameTest(string name) => Matches(() => name, new Regex($"namespace {name}.*\\{{.*\\}}", RegexOptions.Singleline));

        private static void StartsWith(Func<string> namespaceFactory, string substring) => StringAssert.StartsWith(Namespace(namespaceFactory), substring);
        private static void Contains(Func<string> namespaceFactory, string substring) => StringAssert.Contains(Namespace(namespaceFactory), substring);
        private static void Matches(Func<string> namespaceFactory, Regex pattern) => StringAssert.Matches(Namespace(namespaceFactory), pattern);

        private static string Namespace(Func<string> namespaceFactory) => GetString((indentedWriter) => new NamespaceGenerator(namespaceFactory(), indentedWriter).Make());
    }
}
