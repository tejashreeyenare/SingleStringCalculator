using SingleStringCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SingleStringCalculator.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        /// <summary>
        /// Case 1 : Add method to add up given numbers seperated by commas
        /// </summary>
        [TestMethod()]
        public void AddTest_EmptyString()
        {
            var addValue = Program.Add("");
            Assert.AreEqual(0, addValue);
        }

        [TestMethod()]
        public void AddTest_SingleNumber()
        {
            var addValue = Program.Add("1");
            Assert.AreEqual(1, addValue);
        }

        [TestMethod()]
        public void AddTest_TwoNumbers()
        {
            var addValue = Program.Add("1,2");
            Assert.AreEqual(3,addValue);
        }


        /// <summary>
        /// Case 2 : Add method to handle unknown amount of numbers 
        /// </summary>
        [TestMethod()]
        public void AddTest_ExtraDilimiter()
        {
            var addValue = Program.Add("1,2,");
            Assert.AreEqual(3, addValue);
        }

        [TestMethod()]
        public void AddTest_UnknownAmount()
        {
            var addValue = Program.Add("1,2,23,54,67,,789,456,,,23,223,,,23");
            Assert.AreEqual(1661, addValue);
        }

        /// <summary>
        /// Case 3 : Add method with new line character
        /// </summary>
        [TestMethod()]
        public void AddTest_MultipleDelimeters()
        {
            var addValue = Program.Add("1\n2,3");
            Assert.AreEqual(6, addValue);
        }

        [TestMethod()]
        public void AddTest_IncorrectMultipleDelimeters()
        {
            var addValue = Program.Add("1\n,");
            Assert.AreEqual(1, addValue);
        }

        /// <summary>
        /// Case 4 : Add method to support different delimiter
        /// </summary>
        [TestMethod()]
        public void AddTest_NewDelimeters()
        {
           var addValue = Program.Add("//;\n1;2");
            Assert.AreEqual(3, addValue);
        }

        [TestMethod()]
        public void AddTest_NewDelimetersWithOld()
        {
            var addValue = Program.Add("//;\n1;2,2");
            Assert.AreEqual(5, addValue);
        }


        /// <summary>
        /// Case 5 : Add method to throw error when negative numbers are passed.
        /// </summary>
        [TestMethod()]
        public void AddTest_NegativeNumber()
        {
            var ex = Assert.ThrowsException<Exception>(() => Program.Add("//;\n1;2,-2"));
            Assert.AreEqual("Negatives not allowed -2", ex.Message);
        }

        [TestMethod()]
        public void AddTest_NegativeNumbers()
        {
            var ex = Assert.ThrowsException<Exception>(() => Program.Add("//;\n1;2,-2;-4;-9"));
            Assert.AreEqual("Negatives not allowed -2,-4,-9", ex.Message);
        }

        /// <summary>
        /// Case 6 : Add method to ignor numbers greater than 1000
        /// </summary>
        [TestMethod()]
        public void AddTest_GreaterThan1000()
        {
            var addValue = Program.Add("1,2,1000,999");
            Assert.AreEqual(1002, addValue);
        }


        /// <summary>
        /// Case 7 : Add method to handle any length delimiter
        /// </summary>
        [TestMethod()]
        public void AddTest_NewDelimetersAnyLength()
        {
            var addValue = Program.Add("//***\n1***2");
            Assert.AreEqual(3, addValue);
        }
    }
}
