using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using Task_5;
using Xunit.Sdk;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        //public AbstactTable at = new AbstactTable();
        //DataTable dtIncorrect = new DataTable("safsgwergt></.//.,><><", new System.DateTime(1999, 11,11,11,11,11));
        //DataTable dt2 = new DataTable("1213 123411  1234<", new System.DateTime(2023, 1, 1, 1, 1, 1));
        DataTable dtIncorrectInput = new DataTable("safsgwergt>sdfgsdfgsdfgsdfgsdfgs" +
            "dfgsdfgsdfgsdfgsdfgsdfgwergtwreg3t5g4tgvrfcefrvtgbyhunjbyvtcrf" +
            "tvgybhunjhygtfrderftgybhnujmnhbgvftgvybhunjminuhbygtvfrtgyhujnimy" +
            "fghyetdy65redfghjyutrgfvbhjyu675t4redfghtyrfdvghtyr</.//.,><><", new System.DateTime(2022, 11, 11, 11, 11, 11));
        //DataTable dt4 = new DataTable("s></.//.,><><", new System.DateTime(1009, 11, 11, 11, 11, 11));

        [TestMethod]
        public void CorrectCodeInDate()
        {
            bool result = Regex.IsMatch(dtIncorrectInput.Code, @"^[A-Z0-9]+$");
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void CorrectNameInDate()
        {
            bool result = default;
            if (dtIncorrectInput.Name.Length <= 200)
            {
                 result = true;
            }
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void CorrectNameInDate()
        {
            bool result = default;
            if (dtIncorrectInput.Name.Length <= 200)
            {
                result = true;
            }
            Assert.AreEqual(true, result);
        }
    }
}
