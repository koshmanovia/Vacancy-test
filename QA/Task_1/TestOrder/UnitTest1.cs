using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1;

namespace TestOrder
{
    [TestClass]
    public class UnitTest1
    {
        string orderHasBeenPlaced = "����� ��������";
        string orderIsNotIssued = "����� ��������";
        /// <summary>
        /// ���� �������� ������ MakingOrder ������ Order ������� ��������� ���������� ������ �������, ��� ������� ��� �������������� �������, ���� ������� ��������� ������
        ///��� ������������� ��������� �����������
        /// </summary>
        [TestMethod]
        public void OnlineOrder()
        {
            string result = Order.MakingOrder(true, 100.1m);
            Assert.AreEqual(orderHasBeenPlaced, result);
        }        
        /// <summary>
        /// ���� �������� ������ MakingOrder ������ Order � ������� ����� ������� ������� ����� ������� ������ � ����������� ��������
        /// </summary>
        [TestMethod]
        public void OfflineOrderCorrectSum()
        {
            string result = Order.MakingOrder(false, 99.99m);
            Assert.AreEqual(orderHasBeenPlaced, result);
        }

        /// <summary>
        /// ���� �������� ������ MakingOrder ������ Order �������� ������������ �� ��������� ����������� ����� ��� ������� ������ �� �������
        ///  �� ������� "...����� ������ �� ��������� 1000..."       
        /// </summary>
        [TestMethod]
        public void OfflineOrderMaxLimitSum()
        {
            string expected = "����� ��������";
            string result = Order.MakingOrder(false, 1000.00m);
            Assert.AreEqual(orderHasBeenPlaced, result);
        }
        /// <summary>
        /// ���� �������� ������ MakingOrder ������ Order ��������� ����� ������ ������������ ���������� ��� ������� ������
        /// </summary>
        [TestMethod]
        public void OfflineOrderIncorrectSum()
        {            
            string result = Order.MakingOrder(false, 1000.01m);
            Assert.AreEqual(orderIsNotIssued, result);
        }
        /// <summary>
        /// ���� �������� ������ MakingOrder ������ Order �� ������������� ����� ������
        /// </summary>
          [TestMethod]
        public void NegativeSum()
        {            
            string result = Order.MakingOrder(false, -1000.01m);
        Assert.AreEqual(orderIsNotIssued, result);
        }
}
}
