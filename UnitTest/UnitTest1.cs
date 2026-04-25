using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    public class ValidationModule
    {
        [TestMethod]
        public void VaidatePositive()
        {
            string text = "Текст, подходящий для шифровки";
            string diam = "4";

            bool isValid = ScitalaCipher.Validate(text, diam);

            Assert.IsTrue(isValid);
        }
    }


}
