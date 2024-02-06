namespace company
{
    /// <summary>
    /// Класс компании
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Свойство название компании
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Конструктор по умолчанию, задает название компании "unknown"
        /// </summary>
        public Company()
        {
            Title = "unknown";
        }
        /// <summary>
        /// Конструктор с парамметрами
        /// </summary>
        /// <param name="title">Название компании</param>
        public Company(string title)
        {
            Title = title;
        }
    }

    /// <summary>
    /// Класс отдела
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Свойство название отдела
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Свойство количества сотрудников в отделе
        /// </summary>
        public uint EmployeesCounter { get; set; }
        /// <summary>
        /// Свойство компании, которой принадлежит отдел
        /// </summary>
        public Company Company { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Department()
        {
            Company = new Company();
            EmployeesCounter = 0;
            Title = "unknown";
        }
        /// <summary>
        /// Конструктор с парамметрами
        /// </summary>
        /// <param name="company">Компания</param>
        /// <param name="numberOfEmployess">Количество сотрудников в отделе</param>
        /// <param name="title">Название отдела</param>
        public Department(Company company, uint numberOfEmployess = 0, string title = "")
        {
            Company = company;
            EmployeesCounter = numberOfEmployess;
            Title = title;
        }
    }

    /// <summary>
    /// Абстрактный класс работника
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Базовая зарплата сотрудника
        /// </summary>
        private double _baseSalary;
        /// <summary>
        /// Свойство имени сотрудника
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Свойство должности сотрудника
        /// </summary>
        public string Postition { get; set; }
        /// <summary>
        /// Свойство базовой зарплаты сотрудника, выбрасывает исключение, если задать число меньше 0
        /// </summary>
        public double BaseSalary
        {
            get { return _baseSalary; }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new SalaryException("Невозможно создать сотрудника, оклад не может быть меньше 0", value);
                    }
                    _baseSalary = value;
                }
                catch(SalaryException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception("После обработки SalaryException");
                }
            }
        }
        /// <summary>
        /// Свойство отдела сотрудника
        /// </summary>
        public Department Department { get; set; }
        /// <summary>
        /// Асбрактный метод для получения зарплаты
        /// </summary>
        /// <returns>Зарплата сотрудника</returns>
        public abstract double getSalary();
        /// <summary>
        /// Консруктор по умолчанию
        /// </summary>
        public Employee()
        {
            Name = "unknown";
            Postition = "unknown";
            BaseSalary = 0;
            Department = new Department();
        }
        /// <summary>
        /// Конструктор с парамметрами
        /// </summary>
        /// <param name="name">Имя сотрудника</param>
        /// <param name="department">Отдел сотудника</param>
        /// <param name="position">Должность сотрудника</param>
        /// <param name="baseSalary">Базовая зарплата сотрудника</param>
        public Employee(string name,Department department, string position = "unknown", double baseSalary = 0)
        {
            Name = name;
            Department = department;
            Postition = position;
            BaseSalary = baseSalary;
        }
    }

    /// <summary>
    /// Обычный работник
    /// </summary>
    public class RegularEmployee : Employee
    {
        /// <summary>
        /// Свойство премии сотрудника
        /// </summary>
        public double Bonus { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public RegularEmployee() : base()
        {
            Bonus = 0;
        }
        /// <summary>
        /// Конструктор с одним параметром
        /// </summary>
        /// <param name="bonus">Премия</param>
        public RegularEmployee(double bonus) : base()
        {
            Bonus = bonus;
        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Имя сотрудника</param>
        /// <param name="department">Отдел сотрудника</param>
        /// <param name="bonus">Премия сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        /// <param name="baseSalary">Базовая зарплата сотрудника</param>
        public RegularEmployee(string name, Department department, double bonus, string position = "unknown", double baseSalary = 0) : base(name, department, position, baseSalary)
        {
            Bonus = bonus;
        }

        /// <summary>
        /// Метод для получения зарплаты сотрудника
        /// </summary>
        /// <returns>Зарплата сотрудника</returns>
        /// <exception cref="BonusException">Выбрасывает BonusException, если премия меньще 0</exception>
        public override double getSalary()
        {
            try
            {
                if (Bonus < 0)
                {
                    throw new BonusException("Премия не может быть отрицательной!", Bonus);
                }
            }
            catch(SalaryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BaseSalary + Bonus;
        }
    }

    /// <summary>
    /// Класс работника по контракту
    /// </summary>
    public class ContractEmployee : Employee
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ContractEmployee() : base() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Имя сотрудника</param>
        /// <param name="department">Отдел сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        /// <param name="baseSalary">Базовая зарплата сотрудника</param>
        public ContractEmployee(string name, Department department, string position = "unknown", double baseSalary = 0) : base(name, department, position, baseSalary) { }
        /// <summary>
        /// Получение зарплаты 
        /// </summary>
        /// <returns></returns>
        public override double getSalary()
        {
            return BaseSalary;
        }
    }

    /// <summary>
    /// Класс SalaryException, для обработки зарплаты
    /// </summary>
    public class SalaryException : ArgumentException
    {
        /// <summary>
        /// Свойство зарплаты
        /// </summary>
        public double Salary { get; }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="message">Сообщени ошибки</param>
        /// <param name="value">Зарплата</param>
        public SalaryException(string message, double value) : base(message) 
        {
            Salary = value;
        }
    }

    /// <summary>
    /// Класс BonusException, для обработки премии
    /// </summary>
    public class BonusException : ArgumentException
    {
        /// <summary>
        /// Свойство премии
        /// </summary>
        public double Bonus { get; }
        /// <summary>
        /// Конструкторс параметрами
        /// </summary>
        /// <param name="message">Сообщение ошибки</param>
        /// <param name="value">Премия</param>
        public BonusException(string message, double value) : base(message)
        {
            Bonus = value;
        }
    }
}
