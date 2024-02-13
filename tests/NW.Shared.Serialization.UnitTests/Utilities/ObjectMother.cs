using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NW.Shared.Serialization.UnitTests.Utilities
{
    public static class ObjectMother
    {

        #region Properties

        public static string ShortLabeledExamplesAsJson_Content = Properties.Resources.ShortLabeledExamplesAsJson;

        public static LabeledExample ShortLabeledExample01
            = new LabeledExample(label: "en", text: "We are looking for several skilled and driven developers to join our team.");
        public static LabeledExample ShortLabeledExample02
            = new LabeledExample(label: "sv", text: "Vår kund erbjuder trivsel, arbetsglädje och en trygg arbetsmiljö.");
        public static List<LabeledExample> ShortLabeledExamples = new List<LabeledExample>()
        {

            ShortLabeledExample01,
            ShortLabeledExample02

        };

        public static string TextSnippetAsJson_Content = Properties.Resources.TextSnippetAsJson;
        public static string TextSnippetsAsJson_Content = Properties.Resources.TextSnippetsAsJson;

        public static TextSnippet TextSnippet
            = new TextSnippet(text: "We are looking for several skilled and driven developers to join our team.");
        public static List<TextSnippet> TextSnippets = new List<TextSnippet>()
        {

            new TextSnippet(text: "We are looking for several skilled and driven developers to join our team."),
            new TextSnippet(text: "Vår kund erbjuder trivsel, arbetsglädje och en trygg arbetsmiljö.")

        };

        public static string TextClassifierrSessionCLE00AsJson_Content = Properties.Resources.TextClassifierrSessionCLE00AsJson;
        public static TextClassifierSession TextClassifierSession_CompleteLabeledExamples00
            = new TextClassifierSession(
                    settingBag: new SettingBag(),
                    results: TextClassifierResults_CompleteLabeledExamples00,
                    version: "3.6.0.0"
                );

        public static string TokenizerRuleSetAsJson_Content = Properties.Resources.TokenizerRuleSetAsJson;
        public static NGramTokenizerRuleSet TokenizerRuleSet
            = new NGramTokenizerRuleSet(
                    doForMonogram: true,
                    doForBigram: true,
                    doForTrigram: true,
                    doForFourgram: true,
                    doForFivegram: true
                    );

        #endregion

        #region Methods

        public static void Method_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
        {

            // Arrange
            // Act
            // Assert
            Exception actual = Assert.Throws(expectedType, del);
            Assert.That(expectedMessage, Is.EqualTo(actual.Message));

        }

        public static bool AreEqual<T>(List<T> list1, List<T> list2, Func<T, T, bool> comparer)
        {

            if (list1 == null && list2 == null)
                return true;

            if (list1 == null || list2 == null)
                return false;

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
                if (comparer(list1[i], list2[i]) == false)
                    return false;

            return true;

        }

        public static bool AreEqual(TextSnippet obj1, TextSnippet obj2)
        {

            if (obj1 == null && obj2 == null)
                return true;

            if (obj1 == null || obj2 == null)
                return false;

            return string.Equals(obj1.Text, obj2.Text, StringComparison.InvariantCulture);

        }
        public static bool AreEqual(List<TextSnippet> list1, List<TextSnippet> list2)
            => AreEqual(list1, list2, AreEqual);

        public static bool AreEqual(LabeledExample obj1, LabeledExample obj2)
        {

            return string.Equals(obj1.Text, obj2.Text, StringComparison.InvariantCulture)
                    && string.Equals(obj1.Label, obj2.Label, StringComparison.InvariantCulture);

        }
        public static bool AreEqual(List<LabeledExample> list1, List<LabeledExample> list2)
            => Utilities.ObjectMother.AreEqual(list1, list2, AreEqual);

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.02.2024
*/