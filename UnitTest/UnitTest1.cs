using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scitala;
using System;

namespace UnitTest
{
    public class ValidationModule
    {
        [TestMethod]
        public void VaidatePositive()
        {
            string text = "Тестовый текст для шифровальной шифровки";
            string diam = "3";

            bool isValid = ScitalaCipher.Validate(text, diam);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void VaidateBoundary()
        {
            string text;
            string diam;

            text = "Текстовый текст";
            diam = "15";

            bool isValid = ScitalaCipher.Validate(text, diam);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void ValidateNegative()
        {
            string text;
            string diam;


            text = "";
            diam = "";

            bool isValid = ScitalaCipher.Validate(text, diam);

            Assert.IsFalse(isValid);


            text = "Текстовый текст";
            diam = "24";

            isValid = ScitalaCipher.Validate(text, diam);

            Assert.IsFalse(isValid);


            text = "Текстовый текст";
            diam = "3,8";

            isValid = ScitalaCipher.Validate(text, diam);

            Assert.IsFalse(isValid);


            text = "Текстовый текст";
            diam = "-9";

            isValid = ScitalaCipher.Validate(text, diam);

            Assert.IsFalse(isValid);
        }
    }

    [TestClass]
    public class EncryptModule
    {
        [TestMethod]
        public void EncryptDecrypt()
        {
            string orig = "Тестовый текст для шифровальной шифровки";
            int diam = 3;

            string encrypted = ScitalaCipher.Encrypt(orig, diam);
            string decrypted = ScitalaCipher.Decrypt(encrypted, diam);

            Assert.AreEqual(orig, decrypted.TrimEnd());
            Assert.AreNotEqual(encrypted, decrypted);
        }

        [TestMethod]
        public void EncryptPositive()
        {
            string orig = "Тестовый текст для шифровальной шифровки.";
            int diam = 3;
            string expect = "Т недослйтя о швшиыифйфр ротовевккаисл.ть";

            string encrypted = ScitalaCipher.Encrypt(orig, diam);

            Assert.AreEqual(expect, encrypted.TrimEnd());
        }

        [TestMethod]
        public void EncryptBoundary()
        {
            string orig;
            int diam;
            string expect;


            orig = "A";
            diam = 1;
            expect = "A";

            string encrypted = ScitalaCipher.Encrypt(orig, diam);

            Assert.AreEqual(expect, encrypted);


            orig = "Мой дом остался далеко позади, и я весь был во власти чар восточного моря. " +
                "Уже стемнело, когда я услышал шум прибоя и понял, что море находится вон за тем " +
                "холмом с прихотливыми силуэтами ив на фоне прояснившегося ясного неба. Я должен был исполнить завет.";
            diam = 8;
            expect = "М н  м .ояоум ф й гсосоЯ волр н де ыепедосмш р омьоанипл  рлахржобя хооесы." +
                "шотянтл удлс а Умиинблвж твиысоепсывля  рямш  вси иеидлтбв гсааеоосоплсмянисоетн  " +
                "лялкиеизу но л аэяи чоп тстпа,отаньор немо з кямигзавол  оадог,хи висд овне,тачл ет о тмнб.ичяооаа";

            encrypted = ScitalaCipher.Encrypt(orig, diam);

            Assert.AreEqual(expect, encrypted.TrimEnd());
        }

        [TestMethod]
        public void EncryptSpecialSymbols()
        {
            string orig = "ПРИВЕТ/@{}|[]";
            int diam = 2;
            string expect = "П@Р{И}В|Е[Т]/";

            string encrypted = ScitalaCipher.Encrypt(orig, diam);

            Assert.AreEqual(expect, encrypted.TrimEnd());
        }
    }


    [TestClass]
    public class DecryptModule
    {
        [TestMethod]
        public void DecryptPositive()
        {
            string orig = "Т недослйтя о швшиыифйфр ротовевккаисл.ть";
            int diam = 3;
            string expect = "Тестовый текст для шифровальной шифровки.";

            string encrypted = ScitalaCipher.Decrypt(orig, diam);

            Assert.AreEqual(expect, encrypted.TrimEnd());
        }

        [TestMethod]
        public void DecryptBoundary()
        {
            string orig;
            int diam;
            string expect;


            orig = "A";
            diam = 1;
            expect = "A";

            string encrypted = ScitalaCipher.Decrypt(orig, diam);

            Assert.AreEqual(expect, encrypted.TrimEnd());

            orig = "М н  м .ояоум ф й гсосоЯ волр н де ыепедосмш р омьоанипл  рлахржобя хооесы." +
                "шотянтл удлс а Умиинблвж твиысоепсывля  рямш  вси иеидлтбв гсааеоосоплсмянисоетн  " +
                "лялкиеизу но л аэяи чоп тстпа,отаньор немо з кямигзавол  оадог,хи висд овне,тачл ет о тмнб.ичяооаа";
            diam = 8;
            expect = "Мой дом остался далеко позади, и я весь был во власти чар восточного моря. " +
                "Уже стемнело, когда я услышал шум прибоя и понял, что море находится вон за тем " +
                "холмом с прихотливыми силуэтами ив на фоне прояснившегося ясного неба. Я должен был исполнить завет.";


            encrypted = ScitalaCipher.Decrypt(orig, diam);

            Assert.AreEqual(expect, encrypted.TrimEnd());
        }

        [TestMethod]
        public void DecryptSpecialSymbols()
        {
            string orig = "П@Р{И}В|Е[Т]/";
            int diam = 2;
            string expect = "ПРИВЕТ/@{}|[]";

            string encrypted = ScitalaCipher.Decrypt(orig, diam);

            Assert.AreEqual(expect, encrypted.TrimEnd());
        }
    }


}
