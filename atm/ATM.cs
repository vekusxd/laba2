using bank;
namespace atm
{
    /// <summary>
    /// Класс для исключения  остатка на счете
    /// </summary>
    public class AccountBalanceException : ArgumentException
    {
        public int Value { get; set; }
        public AccountBalanceException(string message, int value) : base(message)
        {
            Value = value;
        }
    }
    
    /// <summary>
    /// Класса для исключения cнятия со счета
    /// </summary>
    public class WithDrawException : ArgumentException
    {
        public int Value { get; set; }
        public WithDrawException(string message, int value) : base(message)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Класс банкомата
    /// </summary>
    public class ATM
    {
        /// <summary>
        /// Свойство id
        /// </summary>
        public string Id {  get; set; }
        /// <summary>
        /// Свойство address 
        /// </summary>
        public string Address {  get; set; }
        /// <summary>
        /// Свойство bank 
        /// </summary>
        public Bank Bank { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ATM()
        {
            Id = "unknown";
            Address = "unknown";
            Bank = new Bank();
        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="id">id банкомата</param>
        /// <param name="address">address банкомата</param>
        /// <param name="bank">банк банкомата</param>
        public ATM(string id, string address, Bank bank)
        {
            Id = id;
            Address = address;
            Bank = bank;
        }
    }

    /// <summary>
    /// Класс счета
    /// </summary>
    public abstract class Check
    {
        /// <summary>
        /// Поле остатка на балансе
        /// </summary>
        private int _restBalance;
        /// <summary>
        /// Свойство номера счета
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Свойство пин-кода
        /// </summary>
        public string PinCode { get; set; }
        /// <summary>
        /// Свойство остатка на счете, выбрасывается исключение, если задать остаток меньше 0
        /// </summary>
        public int RestBalance
        {
            get { return _restBalance;}
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new AccountBalanceException("Невозможно создать счет – указано некорректное значение остатка на счете: ", value);
                    }
                }
                catch (AccountBalanceException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception("AccountBalanceException обработан");
                }
            }
        }
        /// <summary>
        /// Метод для снятия со счета
        /// </summary>
        /// <param name="sum">сумма для снятия</param>
        public abstract void withdraw(int sum);
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Check()
        {
            Number = "unknown";
            PinCode = "unknown";
            RestBalance = 0;
        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="number">Номер счета</param>
        /// <param name="pinCode">Пин код</param>
        /// <param name="balance">Остаток на балансе</param>
        public Check(string number, string pinCode, int balance)
        {
            Number = number; 
            PinCode = pinCode;
            RestBalance = balance;
        }
    }

    /// <summary>
    ///  Класс простого счета
    /// </summary>
    public class BasicCheck : Check
    {
        /// <summary>
        /// Метод для снятия денег со счета
        /// </summary>
        /// <param name="sum">сумма для снятия</param>
        /// <exception cref="Exception">выбрасывает исключение, если денег на счетек меньше или сумма для снятия меньше 0</exception>
        public override void withdraw(int sum)
        {
            try
            {
                if (this.RestBalance < sum || sum < 0)
                {
                    throw new WithDrawException("Ошибка снятия со счета", sum);
                }
                RestBalance -= sum;
            }
            catch(WithDrawException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("WithdrawException обработана");
            }
        }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public BasicCheck() : base() { }
        
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="number">номер счета</param>
        /// <param name="pinCode">пин-код</param>
        /// <param name="balance">остаток на балансе</param>
        public BasicCheck(string number, string pinCode, int balance) : base(number, pinCode, balance) { }
    }

    public class PreferedCheck : Check
    {
        /// <summary>
        /// Метод для снятия со счета
        /// </summary>
        /// <param name="sum">суммая для снятия</param>
        /// <exception cref="Exception">Выбрасывается если денег на балансе недостаточно или сумма для снятия меньше 0</exception>
        public override void withdraw(int sum)
        {
            try
            {
                if (this.RestBalance < sum || sum < 0)
                {
                    throw new WithDrawException("Ошибка снятия со счета", sum);
                }
                RestBalance -= sum ;
                RestBalance += 200;
            }
            catch (WithDrawException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("WithdrawException обработана");
            }
        }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public PreferedCheck() : base() { }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="number">номер счета</param>
        /// <param name="pinCode">пин-код</param>
        /// <param name="balance">остаток на балансе</param>
        public PreferedCheck(string number, string pinCode, int balance) : base(number, pinCode, balance) { }

    }
}
