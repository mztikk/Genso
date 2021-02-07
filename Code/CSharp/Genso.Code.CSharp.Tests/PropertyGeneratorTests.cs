using System;
using System.Text.RegularExpressions;
using Genso.Code.CSharp.CodeRepresentation;
using Genso.Code.CSharp.Generator;
using Genso.Tests;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Genso.Code.CSharp.Tests
{
    [TestClass]
    public class PropertyGeneratorTests : BaseTest
    {
        [TestMethod]
        public void EmptyGet() => Contains(GetAutoProperty, "get;");
        [TestMethod]
        public void EmptySet() => Contains(GetAutoProperty, "set;");
        [TestMethod]
        public void PrivateSet() => Contains(GetPrivateSetProperty, "private set");
        [TestMethod]
        public void AutoProperty()
        {
            Contains(GetAutoProperty, "get;");
            Contains(GetAutoProperty, "set;");
        }

        [TestMethod]
        public void Static() => Contains(GetStaticProperty, "static");

        [TestMethod]
        public void NotStatic() => DoesNotMatch(GetNonStaticProperty, new Regex(".*static.*"));

        [DataTestMethod]
        [DataRow("test")]
        [DataRow("Property")]
        [DataRow("äöü?ßá`àá")]
        public void PropertyName(string name) => Contains(GetNameFactory(name), name);

        [DataTestMethod]
        [DataRow("string")]
        [DataRow("int")]
        [DataRow("float")]
        public void PropertyType(string type) => Contains(GetTypeFactory(type), type);

        [DataTestMethod]
        [DataRow(Accessibility.Public)]
        [DataRow(Accessibility.Private)]
        [DataRow(Accessibility.Protected)]
        [DataRow(Accessibility.Internal)]
        [DataRow(Accessibility.ProtectedAndInternal)]
        public void AccessibilityTests(Accessibility accessibility) => Contains(GetAccessibilityFactory(accessibility), accessibility.ToGeneratorString());

        private static void EndsWithTrimmed(Func<CSharpProperty> propertyFactory, string substring) => StringAssert.EndsWith(Property(propertyFactory).Trim(), substring);
        private static void Contains(Func<CSharpProperty> propertyFactory, string substring) => StringAssert.Contains(Property(propertyFactory), substring);
        private static void DoesNotMatch(Func<CSharpProperty> propertyFactory, Regex pattern) => StringAssert.DoesNotMatch(Property(propertyFactory), pattern);

        private static string Property(Func<CSharpProperty> propertyFactory) => GetString((indentedWriter) => new PropertyGenerator(propertyFactory(), indentedWriter).Make());

        private static CSharpProperty GetPublicProperty() => new CSharpProperty(Accessibility.Public, false, "typename", "Propertyname", null, null, null, null, null);
        private static CSharpProperty GetAutoProperty() => new CSharpProperty(Accessibility.Public, false, "typename", "Propertyname", null, null, null, null, null);
        private static CSharpProperty GetPrivateSetProperty() => new CSharpProperty(Accessibility.Public, false, "typename", "Propertyname", null, null, Accessibility.Private, null, null);
        private static CSharpProperty GetStaticProperty() => new CSharpProperty(Accessibility.Public, true, "typename", "Propertyname", null, null, null, null, null);
        private static CSharpProperty GetNonStaticProperty() => new CSharpProperty(Accessibility.Public, false, "typename", "Propertyname", null, null, null, null, null);
        private static Func<CSharpProperty> GetNameFactory(string name) => () => new CSharpProperty(Accessibility.Public, false, "typename", name, null, null, null, null, null);
        private static Func<CSharpProperty> GetTypeFactory(string type) => () => new CSharpProperty(Accessibility.Public, false, type, "Propertyname", null, null, null, null, null);
        private static Func<CSharpProperty> GetAccessibilityFactory(Accessibility accessibility) => () => new CSharpProperty(accessibility, false, "typename", "Propertyname", null, null, null, null, null);
    }
}
