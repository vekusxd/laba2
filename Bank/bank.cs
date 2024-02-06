namespace bank
{
    /// <summary>
    /// Exception класс для месяца
    /// </summary>
    public class MonthException : ArgumentException
    {
        public int Counter { get; set; }
        public MonthException(string message, int counter) : base(message) 
        {
            Counter = counter;
        }
    }

    /// <summary>
    /// Exception класс для вклада
    /// </summary>
    public class InvestmentException : ArgumentException
    {
        public int Investment { get; set; }
        public InvestmentException(string messsage, int investment) : base(messsage) 
        {
            Investment = investment;
        }
    }

    /// <summary>
    /// Класс банка
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// Свойство названия банка
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// Констуктор по умолчанию
        /// </summary>
        public Bank()
        {
            Title = "unknown";
        }
        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="title">Название банка</param>
        public Bank(string title)
        {
            Title = title;
        }
    }

    /// <summary>
    /// Класс филиала банков
    /// </summary>
    public class BankBranch
    {
        /// <summary>
        /// Свойство названия филиала
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Свойство общей суммы вкладов
        /// </summary>
        public int TotalInvestmentSum { get; set; }
        /// <summary>
        /// Свйоство банка, к которому относится филиал
        /// </summary>
        public Bank Bank { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public BankBranch()
        {
            Title = "unknown";
            TotalInvestmentSum = 0;
            Bank = new Bank();
        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="bank">Банк</param>
        /// <param name="totalSum">Общая сумма вкладов</param>
        /// <param name="title">Название филиала</param>
        public BankBranch(Bank bank, int totalSum = 0, string title = "unknown")
        {
            Bank = bank;
            TotalInvestmentSum = totalSum;
            Title = title;
        }
    }


    /// <summary>
    /// Абстрактный класс вклада
    /// </summary>
    public abstract class Investment
    {
        /// <summary>
        /// Поле для суммы вклада
        /// </summary>
        private int _investmentSum;
        /// <summary>
        /// Свойство для имени вкладчика
        /// </summary>
        public string InvesterName { get; set; }
        /// <summary>
        /// Свойство для суммы вклада, выбрасывает InvestmentException, если задать отрицательный вклад
        /// </summary>
       
        public BankBranch BankBranch { get; set; }

        public int IntvestmentSum
        {
            get { return _investmentSum; }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new InvestmentException("Вклад не может быть отрицательным", value);
                    }
                    _investmentSum = value;
                }
                catch(InvestmentException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception("после  InvestmentException");
                }
            }
        }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Investment()
        {
            IntvestmentSum = 0;
            InvesterName = "unknown";
            BankBranch = new BankBranch();
        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Имя вкладчика</param>
        /// <param name="sum">Сумма вклада</param>
        public Investment(string name, int sum, BankBranch bankBranch )
        {
            InvesterName = name;
            IntvestmentSum = sum;
            BankBranch = bankBranch;
        }
        /// <summary>
        /// Абстрактный метод для получения суммы вклада
        /// </summary>
        /// <param name="monthCount">Количество месяцев</param>
        /// <returns>сумма вклада</returns>
        public abstract double getTotalSum(int monthCount);
    }

    /// <summary>
    /// Класс долгосрочного вклада
    /// </summary>
    public class LongInvestment : Investment
    {
        /// <summary>
        /// Метод для получения суммы долгосрочного вклада, выбрасывает исключение, если ввести количество месяцев меньше 1
        /// </summary>
        /// <param name="monthCount">Количество месяцев</param>
        /// <returns>Сумма вклада</returns>
        public override double getTotalSum(int monthCount)
        {
            try
            {
                if (monthCount <= 0)
                {
                    throw new MonthException("Количество месяцев должно быть больше 0!", monthCount);
                }
            }
            catch(MonthException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Month Exceptinon получено");
            }
            return Convert.ToDouble(IntvestmentSum) * Convert.ToDouble(monthCount) * 0.16;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public LongInvestment() : base() { }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Имя вкладчика</param>
        /// <param name="investment">Сумма вклада</param>
        public LongInvestment(string name, int investment, BankBranch bankBranch) : base(name, investment, bankBranch) { }
    }

    /// <summary>
    /// Класс вклада до востребования
    /// </summary>
    public class InitialInvestment : Investment
    {
        /// <summary>
        /// Метод для получения суммы долгосрочного вклада, выбрасывает исключение, если ввести количество месяцев меньше 1
        /// </summary>
        /// <param name="monthCount">Количество месяцев</param>
        /// <returns>Сумма вклада</returns>
        public override double getTotalSum(int monthCount)
        {
            try
            {
                if (monthCount <= 0)
                {
                    throw new MonthException("Количество месяцев должно быть больше 0!", monthCount);
                }
            }
            catch(MonthException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Convert.ToDouble(IntvestmentSum) * Convert.ToDouble(monthCount) * 0.05;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public InitialInvestment() : base() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Имя вкладчика</param>
        /// <param name="investment">Сумма вклада</param>
        public InitialInvestment(string name, int investment, BankBranch bankBranch) : base(name, investment, bankBranch) { }
    }
}
