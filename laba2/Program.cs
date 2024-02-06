using company;

namespace laba2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CompanyTest1();
            CompanyTest2();
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
    }
}
