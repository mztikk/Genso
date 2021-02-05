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
    public class FieldGeneratorTests : BaseTest
    {
        [TestMethod]
        public void EndsWithSemicolon() => EndsWithTrimmed(GetPublicField, ";");

        [TestMethod]
        public void Static() => Contains(GetStaticField, "static");

        [TestMethod]
        public void Readonly() => Contains(GetReadonlyField, "readonly");

        [TestMethod]
        public void Const() => Contains(GetConstField, "const");

        [TestMethod]
        public void NotStatic() => DoesNotMatch(GetNonStaticField, new Regex(".*static.*"));

        [TestMethod]
        public void NotReadonly() => DoesNotMatch(GetNonReadonlyField, new Regex(".*readonly.*"));

        [TestMethod]
        public void NotConst() => DoesNotMatch(GetNonConstField, new Regex(".*const.*"));

        [DataTestMethod]
        [DataRow("test")]
        [DataRow("field")]
        [DataRow("äöü?ßá`àá")]
        public void FieldName(string name) => Contains(GetNameFactory(name), name);

        [DataTestMethod]
        [DataRow("string")]
        [DataRow("int")]
        [DataRow("float")]
        public void FieldType(string type) => Contains(GetTypeFactory(type), type);

        [DataTestMethod]
        [DataRow(Accessibility.Public)]
        [DataRow(Accessibility.Private)]
        [DataRow(Accessibility.Protected)]
        [DataRow(Accessibility.Internal)]
        [DataRow(Accessibility.ProtectedAndInternal)]
        public void AccessibilityTests(Accessibility accessibility) => Contains(GetAccessibilityFactory(accessibility), accessibility.ToGeneratorString());

        private static void EndsWithTrimmed(Func<CSharpField> fieldFactory, string substring) => StringAssert.EndsWith(Field(fieldFactory).Trim(), substring);
        private static void Contains(Func<CSharpField> fieldFactory, string substring) => StringAssert.Contains(Field(fieldFactory), substring);
        private static void DoesNotMatch(Func<CSharpField> fieldFactory, Regex pattern) => StringAssert.DoesNotMatch(Field(fieldFactory), pattern);

        private static string Field(Func<CSharpField> fieldFactory) => GetString((indentedWriter) => new FieldGenerator(fieldFactory(), indentedWriter).Make());

        private static CSharpField GetPublicField() => new CSharpField(Accessibility.Public, false, false, false, "typename", "fieldname", null);
        private static CSharpField GetStaticField() => new CSharpField(Accessibility.Public, false, false, true, "typename", "fieldname", null);
        private static CSharpField GetReadonlyField() => new CSharpField(Accessibility.Public, true, false, false, "typename", "fieldname", null);
        private static CSharpField GetConstField() => new CSharpField(Accessibility.Public, false, true, false, "typename", "fieldname", null);
        private static CSharpField GetNonStaticField() => new CSharpField(Accessibility.Public, false, false, false, "typename", "fieldname", null);
        private static CSharpField GetNonReadonlyField() => new CSharpField(Accessibility.Public, false, false, false, "typename", "fieldname", null);
        private static CSharpField GetNonConstField() => new CSharpField(Accessibility.Public, false, false, false, "typename", "fieldname", null);
        private static Func<CSharpField> GetNameFactory(string name) => () => new CSharpField(Accessibility.Public, false, false, false, "typename", name, null);
        private static Func<CSharpField> GetTypeFactory(string type) => () => new CSharpField(Accessibility.Public, false, false, false, type, "fieldname", null);
        private static Func<CSharpField> GetAccessibilityFactory(Accessibility accessibility) => () => new CSharpField(accessibility, false, false, false, "typename", "fieldname", null);
    }
}
