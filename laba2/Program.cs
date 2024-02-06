using company;
using bank;
using atm;

namespace laba2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CompanyTest1();
            //CompanyTest2();
            //BankTest1();
            //BankTest2();
            //AtmTest1();
            //AtmTest2();
        }

        static void CompanyTest1()
        {
            try
            {
                Company bmw = new Company("Bmw");

                Department workingDepartmen = new Department(bmw, 50, "Первый отдел");

                RegularEmployee employee = new RegularEmployee("Эмиль", workingDepartmen, -80, "some Position", 40);

                Console.WriteLine(employee.getSalary());
            }
            catch(BonusException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CompanyTest2()
        {
            try
            {
                Company toyota = new Company("Toyota");

                Department workingDepartment = new Department(toyota, 60, "Какой-то отдел");

                ContractEmployee employee = new ContractEmployee("Данил", workingDepartment, "рабочий", -10);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void BankTest1()
        {
            try
            {
                Bank bank = new Bank("Сбер");
                BankBranch branch = new BankBranch(bank, 5670, "Филиал-1");

                LongInvestment investment = new LongInvestment("Петя", 567, branch);
                Console.WriteLine(investment.getTotalSum(-10));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void BankTest2()
        {
            try
            {
                Bank bank = new Bank("Банк");
                BankBranch branch = new BankBranch(bank, 45445, "Филиал-2");

                InitialInvestment investment = new InitialInvestment("Кирилл", -234, branch);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void AtmTest1()
        {
            try
            {
                BasicCheck check = new BasicCheck("43434", "2345", 100);
                check.withdraw(200);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static  void AtmTest2()
        {
            try
            {
                PreferedCheck check = new PreferedCheck("344", "2345", -900);
                check.withdraw(200);
            }
            catch(Exception ext)
            {
                Console.WriteLine(ext.Message);
            }
        }

    }
}
