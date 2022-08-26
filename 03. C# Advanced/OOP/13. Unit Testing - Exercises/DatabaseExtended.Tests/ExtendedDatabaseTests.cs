namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void CountShouldReturnTheActualCountOfTheDatabase()
        {

            Database database = new Database(new Person(1, "Pesho"), new Person(2, "Gosho"), new Person(3, "Ivan"));
            Assert.That(database.Count == 3, "Add() doesn't change the count properly.");
            database.Remove();
            Assert.That(database.Count == 2, "Remove() doesn't change the count properly.");
        }
        [Test]
        public void AddRangeShouldThrowExceptionWhenAddingMoreThan16Elements()
        {
            Person[] people = new Person[17];
            for (int i = 0; i < 17; i++)
            {
                StringBuilder name = new StringBuilder();
                name.Append("Name");
                name.Append(i);
                people[i] = new Person(i, name.ToString());
            }
            Database database = new Database();
            ArgumentException ex = Assert.Throws<ArgumentException>(() => { Database database = new Database(people); });
            Assert.That(ex.Message, Is.EqualTo("Provided data length should be in range [0..16]!"));
        }
        [Test]
        public void AddRangeShouldAddAllElementsFromTheInput()
        {
            Person person = new Person(1, "Name1");

            Person[] people = new Person[] { person };
            Database actual = new Database(people);

            Database expected = new Database();
            expected.Add(person);

            Assert.That(actual.FindByUsername("Name1").UserName, Is.EqualTo(expected.FindByUsername("Name1").UserName));
        }
        [Test]
        public void AddShouldThrowExceptionWhenAddingMoreThan16Elements()
        {
            Database database = new Database();
            for (int i = 1; i < 17; i++)
            {
                StringBuilder name = new StringBuilder();
                name.Append("Name");
                name.Append(i);
                database.Add(new Person(i, name.ToString()));
            }
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17, "Name17")));
            Assert.That(ex.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        public void AddShouldThrowExceptionWhenAddingPersonWithTheSameUsernameOfAlreadyAddedPerson()
        {
            Database database = new Database();
            database.Add(new Person(1, "Name"));
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(2, "Name")));
            Assert.That(ex.Message, Is.EqualTo("There is already user with this username!"));
        }
        [Test]
        public void AddShouldThrowExceptionWhenAddingPersonWithTheSameIdOfAlreadyAddedPerson()
        {
            Database database = new Database();
            database.Add(new Person(1, "Name"));
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "Name2")));
            Assert.That(ex.Message, Is.EqualTo("There is already user with this Id!"));
        }
        [Test]
        public void RemoveShouldThrowExceptionWhenRemovingFromDatabaseWithNoPeople()
        {
            Database database = new Database();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void RemoveShouldRemoveTheLastPersonInTheDatabase()
        {
            Database database = new Database(new Person(1, "Pesho"), new Person(2, "Gosho"), new Person(3, "Ivan"));
            database.Remove();
            Assert.That(database.Count == 2);
            Assert.That(database.FindById(1) != null && database.FindById(2) != null);
        }
        [Test]
        public void FindByUsernameShouldThrowExceptionIfTheGivenNameIsNullOrEmpty()
        {
            Database database = new Database(new Person(1, "Pesho"));
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
            Assert.That(ex.ParamName, Is.EqualTo("Username parameter is null!"));
        }
        [Test]
        public void FindByUsernameShouldThrowExceptionIfTheGivenNameDoesNotExistInTheDatabase()
        {
            Database database = new Database(new Person(1, "Pesho"));
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Ivan"));
            Assert.That(ex.Message, Is.EqualTo("No user is present by this username!"));
        }
        [Test]
        public void FindByUsernameShouldReturnThePersonnWithTheGivenNameIfFound()
        {
            Database database = new Database(new Person(1, "Pesho"));
            Assert.That(() => database.FindByUsername("Pesho") is Person);
        }
        [Test]
        public void FindByIdShouldThrowExceptionIfTheGivenIdIsLowerThanZero()
        {
            Database database = new Database(new Person(1, "Pesho"));
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
            Assert.That(ex.ParamName, Is.EqualTo("Id should be a positive number!"));
        }
        [Test]
        public void FindByIdShouldThrowExceptionIfTheGivenIdDoesNotExistInTheDatabase()
        {
            Database database = new Database(new Person(1, "Pesho"));
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.FindById(2));
            Assert.That(ex.Message, Is.EqualTo("No user is present by this ID!"));
        }
        [Test]
        public void FindByIdShouldReturnThePersonWithTheGivenIdIfFound()
        {
            Database database = new Database(new Person(1, "Pesho"));
            Assert.That(() => database.FindById(1) is Person);
        }
    }
}