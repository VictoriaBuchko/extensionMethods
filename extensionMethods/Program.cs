using System.Threading.Tasks;


namespace extensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Task1");
            string[] testStrings = { "{}[]", "(())", "[{}]", "[}", "[[{]}]" };
            foreach (string test in testStrings)
            {
                Console.WriteLine($"\"{test}\": валідність дужок: {test.AreBracketsValid()}");
            }




            Console.WriteLine("\n\nTask2");
            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            Predicate<int> isEven = x => x % 2 == 0;
            int[] evenNumbers = numbers.Filter(isEven);
            Console.WriteLine("Парні числа: " + string.Join(", ", evenNumbers));




            Console.WriteLine("\n\nTask3");
            var card = new CreditCard("1234567890", "Бучко Вікторія", new DateTime(2025, 10, 15), "1111", 1000);

            card.AccountReplenishment += (amount) => Console.WriteLine($"Рахунок поповнено на {amount} грн. Новий баланс: {card.Balance}");
            card.CashOut += (amount) => Console.WriteLine($"Знято {amount} грн. Залишок: {card.Balance}");
            card.CreditUsed += (amount) => Console.WriteLine($"Використано кредитні кошти: {amount} грн. Баланс: {card.Balance}");
            card.LimitReached += (limit) => Console.WriteLine($"Досягнуто кредитного ліміту {limit} грн.");
            card.PinChanged += (newPin) => Console.WriteLine($"PIN-код змінено. Новий PIN: {newPin}");

            Console.WriteLine("Поповнення рахунку на 500 грн");
            card.accountReplenishment(500);

            Console.WriteLine("\nЗняття 300 грн");
            card.SpendFunds(300);

            Console.WriteLine("\nВикористання 800 грн з кредитного ліміту");
            card.CreditMoney(800);

            Console.WriteLine("\nВикористання 300 грн з кредитного ліміту");
            card.CreditMoney(300);

            Console.WriteLine("\nЗміна PIN-коду на 1234");
            card.ChangePin("1234");






            Console.WriteLine("\n\nTask4");
            DailyTemperature[] temperature = new DailyTemperature[]
            {
                new DailyTemperature(12, 10),
                new DailyTemperature(15, 9),
                new DailyTemperature(14, 11),
                new DailyTemperature(18, 8),
                new DailyTemperature(20, 12),
            };

            Console.WriteLine($"День з максимальною різницею температур: День {DailyTemperature.GetMaxDifference(temperature) + 1}");
        }
    }
}
