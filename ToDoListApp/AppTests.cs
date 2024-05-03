using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace ToDoListApp
{
    [TestFixture]
    internal class AppTests
    {
        [Test]
        public void ValidateListLoads()
        {
            ToDoList app = new ToDoList();
            Assert.That(app, Is.Not.Null);
        }


        [Test]
        public void clearTitle_Valid()
        {
            ToDoList app = new ToDoList();
            string expected = "";
            var actual = app.clearTitle();
            Assert.That(actual, Is.EqualTo(expected));
        } // make sure Title is empty
        [Test]
        public void clearDescription_Valid()
        {
            ToDoList app = new ToDoList();
            string expected = "";
            var actual = app.clearDescription();
            Assert.That(actual, Is.EqualTo(expected));
        } // make sure Description is empty
        [Test]
        public void resetPriority_Valid()
        {
            ToDoList app = new ToDoList();
            int expected = -1;
            var actual = app.resetPriority();
            Assert.That(actual, Is.EqualTo(expected));
        } // make sure Priority selection box is empty
        [Test]
        public void clearFields_Valid()
        {
            ToDoList app = new ToDoList();
            int expected = 0;
            var actual = app.clearFields();
            Assert.That(actual, Is.EqualTo(expected));
        }  // make sure clearFields clears all the fields.

        [Test]
        public void noTitleCheck_Empty()
        {
            ToDoList app = new ToDoList();
            string expected = "";
            string test = app.noTitleCheck(expected);
            Assert.That(test, Is.EqualTo(expected));
        }

        [Test]
        public void noTitleCheck_NotEmpty()
        {
            ToDoList app = new ToDoList();
            string expected = "Test";
            string test = app.noTitleCheck(expected);
            Assert.That(test, Is.EqualTo(expected));
        }



    }


}
