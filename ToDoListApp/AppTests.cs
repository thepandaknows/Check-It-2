using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Moq.Protected;
using ToDoListApp;



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
        [Test]
        public void saveTask_Valid() // fails because I need mock data for this test
        {
            ToDoList app = new ToDoList();
            int expected = 0;
            int test = app.saveTask();
            Assert.That(test, Is.EqualTo(expected));
        }
        [Test]
        public void saveTitle_Valid() // fails because I need mock data for this test
        {
            ToDoList app = new ToDoList();
            string expected = "";
            string test = app.saveTitle();
            Assert.That(test, Is.Not.EqualTo(expected));
        }

         [Test]
         public void deleteTask_Test()  // Need to make fake cells in the datagrid array. I tried using Moq and I can't get anything to compile that lets me create a fake cell.
         {
             var mockToDoList = new Mock<ToDoList>();
             mockToDoList.SetupGet(x => x.todoList).Returns(new DataTable());

             mockToDoList.Object.todoList.Rows.Add("Task1", "Description1", "High", DateTime.Now);

             // Act
             int initialRowCount = mockToDoList.Object.todoList.Rows.Count;
             int result = mockToDoList.Object.deleteTask(1, 0);

             // Assert
             Assert.That(initialRowCount, Is.EqualTo(1));
             Assert.That(result,Is.EqualTo(0));
             Assert.That(mockToDoList.Object.todoList.Rows.Count, Is.EqualTo(0));

         }
        
        /*[Test]
        public void DeleteTask_Valid()
        {
            // Arrange
            var mockDataAccess = new Mock<ToDoList>();
            var todoList = new ToDoList();
            
            todoList.Rows.Add("Task1", "Description1", "High", DateTime.Now);
            mockDataAccess.Setup(x => x.GetToDoList()).Returns(todoList);

            var app = new ToDoList();

            // Act
            int initialRowCount = app.GetToDoList().Rows.Count;
            int result = app.DeleteTask(0, 0);

            // Assert
            Assert.That(initialRowCount, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo(0));
            Assert.That(app.GetToDoList().Rows.Count,Is.EqualTo(0));
        }*/

    }
}
