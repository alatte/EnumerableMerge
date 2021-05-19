using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tasks.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMergeWithInt()
        {
            EnumerableMerge enumerableMerge = new EnumerableMerge();
            List<int> list1 = new List<int>() { 1, 5, 9, 11 };
            List<int> list2 = new List<int>() { -2, 3, 6, 10, 44 };
            List<int> list3 = new List<int>() { -6, -4, 6 };
            List<int> list4 = new List<int>() { };

            List<int> actual = (List<int>)enumerableMerge.Merge(list1, list2, list3, list4);
            List<int> expected = new List<int> { -6, -4, -2, 1, 3, 5, 6, 6, 9, 10, 11, 44 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMergeWithString()
        {
            EnumerableMerge enumerableMerge = new EnumerableMerge();
            List<string> list1 = new List<string>() { "ab", "ag", "dv", "mh" };
            List<string> list2 = new List<string>() { "" };
            List<string> list3 = new List<string>() { "ac", "ad", "bn" };
            List<string> list4 = new List<string>() { null };

            List<string> actual = (List<string>)enumerableMerge.Merge(list1, list2, list3, list4);
            List<string> expected = new List<string> {null, "", "ab", "ac", "ad", "ag", "bn", "dv", "mh" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMergeWithOwnClass()
        {
            EnumerableMerge enumerableMerge = new EnumerableMerge();
            Book book1 = new Book("Harry Potter", 478);
            Book book2 = new Book("The Witcher", 457);
            Book book3 = new Book("Roadside Picnic", 232);
            Book book4 = new Book("Aivengo", 198);
            Book book5 = new Book("The Little Prince", 456);
            Book book6 = new Book("Second Harry Potter", 545);


            List<Book> list1 = new List<Book>() { book1, book3 };
            List<Book> list2 = new List<Book>() { book6, book5, book2 };
            List<Book> list3 = new List<Book>() { null, book4 };

            List<Book> actual = (List<Book>)enumerableMerge.Merge(list1, list2, list3);
            List<Book> expected = new List<Book> { null, book4, book1, book3, book6, book5, book2 };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
