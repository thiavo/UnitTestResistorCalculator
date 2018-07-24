using ColorResistorCalculator.Controllers;
using ColorResistorCalculator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;

/********************************************************************************************
 * Unit Test for the Electronic Color Code Calculator
 * that calculates the min, max and resistor values
 * 
 * Pattern:  
 *      Arrange:  Setup the testing objects and prepare the prerequisites for your test.
 *      Act:  Perform the actual work of the test.
 *      Assert:  Verify results.
 * 5 Test Scenarios:
 *      TestIndex_IsNotNull() - Test the View()
 *      TestMinResistor_IsTrue() - Test that the correct minimum value is returned
 *      TestMaxResistor_IsTrue() - Test that the correct maximum value is returned
 *      TestResistor_IsTrue() - Test that the correct resistor value is returned
 *      TestNullCalculateOhmValue_IsNotNull() - Test that the Computation is not null
 * ******************************************************************************************/

namespace UnitTestResistorCalculator
{
    [TestClass]
    public class TestController
    {
        [TestMethod]
        public void TestIndex_IsNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult r = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(r);
        }

        [TestMethod]
        public void TestMinResistor_IsTrue()
        {
            //Arrange
            IOhmValueCalculator ohmCalc = new ResistanceCalculator();

            //Act
            ResistorCaculatedValue r = ohmCalc.CalculateOhmValue("orange", "yellow", "red", "green");

            //Assert
            Assert.AreEqual("3383  Ohms", r.ResistMin);
        }

        [TestMethod]
        public void TestMaxResistor_IsTrue()
        {
            //Arrange
            IOhmValueCalculator ohmCalc = new ResistanceCalculator();

            //Act
            ResistorCaculatedValue r = ohmCalc.CalculateOhmValue("orange", "yellow", "red", "green");

            //Assert
            Assert.AreEqual("3417  Ohms", r.ResistMax);
        }

        [TestMethod]
        public void TestResistor_IsTrue()
        {
            //Arrange
            IOhmValueCalculator ohmCalc = new ResistanceCalculator();

            //Act
            ResistorCaculatedValue r = ohmCalc.CalculateOhmValue("orange", "yellow", "red", "green");

            //Assert
            Assert.AreEqual("3400  Ohms", r.GetSetResistor);
        }

        [TestMethod]
        public void TestNullCalculateOhmValue_IsNotNull()
        {
            Exception eResult = null;

            try
            {    // Arrange 
                IOhmValueCalculator ohmCalc = new ResistanceCalculator();

                // Act
                ohmCalc.CalculateOhmValue(null, null, null, null);
            }
            catch (Exception exception)
            {
                eResult = exception;
            }

            // Assert
            Assert.IsNotNull(eResult);
            Assert.IsInstanceOfType(eResult, typeof(ArgumentException));
        }

    }
}
