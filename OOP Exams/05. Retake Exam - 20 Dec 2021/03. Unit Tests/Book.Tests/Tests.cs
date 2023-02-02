namespace Book.Tests
{
    using System;    
    using NUnit.Framework;    

    [TestFixture]
    public class Tests
    {
        private const string DEF_BOOKNAME = "Test book name";
        private const string DEF_AUTHOR = "Test author";

        private const int DEF_FOOTNOTE_NUMBER = 1;
        private const string DEF_FOOTNOTE_TEXT = "Test footnote text";

        private Book book;

        [SetUp]
        public void Setup()
        {
            book = new Book(DEF_BOOKNAME, DEF_AUTHOR);
            book.AddFootnote(DEF_FOOTNOTE_NUMBER, DEF_FOOTNOTE_TEXT);
        }

        [Test]
        public void Constructor_CreatesObjectProperly()
        {
            Assert.True(book.BookName == DEF_BOOKNAME &&
                        book.Author == DEF_AUTHOR &&
                        book.FootnoteCount == 1);
        }

        [TestCase(null)]
        [TestCase("")]
        public void PropBookName_ThrowsForNullOrEmptyValue(string name)
        {
            Assert.Throws<ArgumentException>(() => book = new Book(name, DEF_AUTHOR));
        }

        [TestCase(null)]
        [TestCase("")]
        public void PropAuthor_ThrowsForNullOrEmptyValue(string author)
        {
            Assert.Throws<ArgumentException>(() => book = new Book(DEF_BOOKNAME, author));
        }

        [Test]
        public void AddFootnote_ThrowsForExistingFootnoteNumber()
        {            
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(DEF_FOOTNOTE_NUMBER, "Token text"));
        }

        [Test]
        public void AddFootnote_IncreasesFootnoteCount()
        {            
            Assert.AreEqual(book.FootnoteCount, 1);
        }

        [Test]
        public void FindFootnote_ThrowsForNonExistingFootnote()
        {            
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(123));
        }

        [Test]
        public void FindFootnote_ReturnsCorrectFootnote()
        {
            string expectedString = $"Footnote #{DEF_FOOTNOTE_NUMBER}: {DEF_FOOTNOTE_TEXT}";
            string footnoteTextFound = book.FindFootnote(DEF_FOOTNOTE_NUMBER);
            Assert.AreEqual(expectedString, footnoteTextFound);
        }

        [Test]
        public void AlterFootnote_ThrowsForNonExistentFootnoteNumber()
        {
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(15, "Some text"));
        }

        [Test]
        public void AlterFootnote_ChangesTheFootnoteText()
        {
            string testText = "Test text";
            string expectedText = $"Footnote #{DEF_FOOTNOTE_NUMBER}: {testText}";
            book.AlterFootnote(DEF_FOOTNOTE_NUMBER, testText);
            string resultText = book.FindFootnote(DEF_FOOTNOTE_NUMBER);
            Assert.AreEqual(expectedText, resultText);
        }

    }
}