using System;
using System.Collections.Immutable;
using Genso.Code.CSharp.CodeRepresentation;
using Genso.Code.CSharp.Generator.Class;
using Genso.Tests;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Genso.Code.CSharp.Tests
{
    [TestClass]
    public class ClassDefinitionGeneratorTests : BaseTest
    {
        [TestMethod]
        public void Class()
        {
            Contains(GetStaticClass, "class");
            Contains(GetPublicStaticClass, "class");
            Contains(GetPublicClass, "class");
        }

        [DataTestMethod]
        [DataRow("Genso")]
        [DataRow("TestClass")]
        public void ClassWithName(string name) => Contains(GetNameFactory(name), name);

        [TestMethod]
        public void StaticClass()
        {
            Contains(GetStaticClass, "static");
            Contains(GetPublicStaticClass, "static");
        }

        [TestMethod]
        public void PartialClass() => Contains(GetPartialClass, "partial");

        [TestMethod]
        public void PublicClass() => Contains(GetPublicClass, "public");

        [DataTestMethod]
        [DataRow(Accessibility.Public)]
        [DataRow(Accessibility.Private)]
        [DataRow(Accessibility.Protected)]
        [DataRow(Accessibility.Internal)]
        [DataRow(Accessibility.ProtectedAndInternal)]
        public void AccessibilityTests(Accessibility accessibility) => Contains(GetAccessibilityFactory(accessibility), accessibility.ToGeneratorString());

        private static void Contains(Func<CSharpClass> classFactory, string substring) => StringAssert.Contains(ClassDefinition(classFactory), substring);

        private static string ClassDefinition(Func<CSharpClass> classFactory) => GetString((indentedWriter) => new ClassDefinitionGenerator(classFactory(), indentedWriter).Make());

        private static CSharpClass GetStaticClass() => new CSharpClass("StaticClass", "Genso", Accessibility.Public, Array.Empty<string>().ToImmutableArray(), true, false);
        private static CSharpClass GetPartialClass() => new CSharpClass("StaticClass", "Genso", Accessibility.Public, Array.Empty<string>().ToImmutableArray(), true, true);
        private static CSharpClass GetPublicClass() => new CSharpClass("StaticClass", "Genso", Accessibility.Public, Array.Empty<string>().ToImmutableArray(), true, true);
        private static CSharpClass GetPublicStaticClass() => new CSharpClass("StaticClass", "Genso", Accessibility.Public, Array.Empty<string>().ToImmutableArray(), true, true);
        private static Func<CSharpClass> GetAccessibilityFactory(Accessibility accessibility) => () => new CSharpClass("StaticClass", "Genso", accessibility, Array.Empty<string>().ToImmutableArray(), true, true);
        private static Func<CSharpClass> GetNameFactory(string name) => () => new CSharpClass(name, "Genso", Accessibility.Public, Array.Empty<string>().ToImmutableArray(), true, true);
    }
}
