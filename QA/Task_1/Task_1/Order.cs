namespace Task_1
{
    public static class Order
    {
        static string orderHasBeenPlaced = "Заказ оформлен";
        static string orderIsNotIssued = "Заказ отклонен";
        /*
         * Класс ссозданный для наглядности, имитирующий логику работы с заказами
         * bool payOnSite - переменная обозначает как оформлена покупка, онлайн или оффлайн
         * decimal orderSum - сумма покупки
         * 
         */
        public static string MakingOrder(bool payOnSite, decimal orderSum)
        {
            if (orderSum < 0) 
            {
                return orderIsNotIssued;
            }
            if (payOnSite == true)
            {
                return orderHasBeenPlaced;
            }
            else if (payOnSite == false && orderSum < 1000.01m)
            {
                return orderHasBeenPlaced;
            }
            return orderIsNotIssued;
        }
    }
    
}
