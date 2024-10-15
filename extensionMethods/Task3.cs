using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extensionMethods
{
    public class CreditCard
    {
        public string? CardNumber { get; private set; }
        public string? OwnerName { get; private set; }
        public DateTime ValidityPeriod { get; private set; }
        private string? Pin;
        public decimal CreditLimit { get; private set; }
        public decimal Balance { get; private set; }




        public event Action<decimal>? AccountReplenishment;
        public event Action<decimal>? CashOut;
        public event Action<decimal>? CreditUsed;
        public event Action<decimal>? LimitReached;
        public event Action<string>? PinChanged;

        public CreditCard(string cardNumber, string ownerName, DateTime validityPeriod, string pin, decimal creditLimit)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            ValidityPeriod = validityPeriod;
            Pin = pin;
            CreditLimit = creditLimit;
            Balance = 0;
        }

        public void accountReplenishment(decimal amount)
        {
            Balance += amount;
            AccountReplenishment?.Invoke(amount);
        }

        public void SpendFunds(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Недостатньо коштів");
                return;
            }

            Balance -= amount;
            CashOut?.Invoke(amount);
        }

        public void CreditMoney(decimal amount)
        {
            if (Balance + amount > CreditLimit)
            {
                Console.WriteLine("Досягнуто кредитного ліміту");
                LimitReached?.Invoke(CreditLimit);
                return;
            }

            Balance += amount;
            CreditUsed?.Invoke(amount);
        }

        public void ChangePin(string newPin)
        {
            Pin = newPin;
            PinChanged?.Invoke(newPin);
        }
    }
}
