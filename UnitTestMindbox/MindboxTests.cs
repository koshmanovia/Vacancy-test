using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Mindbox;

namespace UnitTestMindbox
{
    [TestClass]
    public class MindboxTests
    {
        [TestMethod]
        public void Triangle_is_not_Really()
        {
            String s = default;
            double a = 1;
            double b = 2;
            double c = 99;
            try
            {
                Triangle tr = new Triangle(a, b, c);
            }
            catch(Exception ex)
            {
                s = ex.Message;
            }

            Assert.AreEqual(s, "Triangle is not really");
            //
        }
        [TestMethod]
        public void Triangle_is_not_Rectangular()
        {
            double a = 3;
            double b = 4;
            double c = 5;
            Triangle tr = new Triangle(a, b, c);
            Assert.AreEqual(tr.Rectangular, true);
        }
    }
}
