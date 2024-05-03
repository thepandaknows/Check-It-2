using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToDoListApp;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateListLoads()
        {
            var app = new ToDoList();
            Assert.IsNotNull(app); // make sure the list launches correctly. 
        }

        [TestMethod]

        public void checkTextboxesEmpty()
        {
            var app = new ToDoList();

            var expected = "";
            
           
        }
    }
}
