namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldAddAllTheElementsOfTheArray(int[] input)
        {
            Database database = new Database(input);
            CollectionAssert.AreEqual(input, database.Fetch());
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CountShouldReturnTheActualCountOfTheArray(int[] input)
        {
            Database database = new Database(input);
            Assert.That(database.Count, Is.EqualTo(input.Length));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddShouldThrowExceptionWhenAddingMoreThan17Elements(int[] input)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(input);
                database.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { 1 })]
        public void AddingElementsToDatabase(int[] input)
        {
            Database database = new Database();
            database.Add(1);
            CollectionAssert.AreEqual(input, database.Fetch(), "Add doesnt add properly.");
            Assert.That(database.Count, Is.EqualTo(1), "Add doesnt change _count properly.");
        }

        [TestCase(new int[] { })]
        public void RemovingElementsFromDatabaseWithZeroElements(int[] input)
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] { })]
        public void RemovingElementsFromDatabaseWithPositiveAmountOfElements(int[] input)
        {
            Database database = new Database(1);
            database.Remove();
            CollectionAssert.AreEqual(input, database.Fetch(), "Remove doesnt remove properly.");
            Assert.That(database.Count, Is.EqualTo(input.Length), "Remove doesnt change _count properly.");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCopyArray(int[] input)
        {
            Database database = new Database(input);
            CollectionAssert.AreEqual(input, database.Fetch());
        }
    }
}
