using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1;

namespace TestOrder
{
    [TestClass]
    public class UnitTest1
    {
        string orderHasBeenPlaced = "Заказ оформлен";
        string orderIsNotIssued = "Заказ отклонен";
        /// <summary>
        /// Тест проверки метода MakingOrder класса Order который имитирует оформление онлайн покупки, для которой нет дополнительных условий, если покупка совершена онлайн
        ///она автоматически считается оформленной
        /// </summary>
        [TestMethod]
        public void OnlineOrder()
        {
            string result = Order.MakingOrder(true, 100.1m);
            Assert.AreEqual(orderHasBeenPlaced, result);
        }        
        /// <summary>
        /// Тест проверки метода MakingOrder класса Order в котором сумма оффлайн покупки сумма которой входит в разрешенный диапазон
        /// </summary>
        [TestMethod]
        public void OfflineOrderCorrectSum()
        {
            string result = Order.MakingOrder(false, 99.99m);
            Assert.AreEqual(orderHasBeenPlaced, result);
        }

        /// <summary>
        /// Тест проверки метода MakingOrder класса Order проверям обрабатывает ли программа масимальную сумму при оффлайн заказе по условию
        ///  из задания "...сумма заказа не превышает 1000..."       
        /// </summary>
        [TestMethod]
        public void OfflineOrderMaxLimitSum()
        {
            string expected = "Заказ оформлен";
            string result = Order.MakingOrder(false, 1000.00m);
            Assert.AreEqual(orderHasBeenPlaced, result);
        }
        /// <summary>
        /// Тест проверки метода MakingOrder класса Order проверяем сумму больше максимальной допустимой для оффлайн заказа
        /// </summary>
        [TestMethod]
        public void OfflineOrderIncorrectSum()
        {            
            string result = Order.MakingOrder(false, 1000.01m);
            Assert.AreEqual(orderIsNotIssued, result);
        }
        /// <summary>
        /// Тест проверки метода MakingOrder класса Order на отрицательную сумму заказа
        /// </summary>
          [TestMethod]
        public void NegativeSum()
        {            
            string result = Order.MakingOrder(false, -1000.01m);
        Assert.AreEqual(orderIsNotIssued, result);
        }
}
}
