using System;

namespace EmployeeLib
{
    //base class employee
    public abstract class Employee
    {
        //fields 
        public static string company;
        private string sin;
        private string first;
        private string last;
        private DateTime hire;
        private string phone;
        private string email;
        private string address;
        private bool isActive;

        //properties
        public string Firstname
        {
            get
            {
                return first;
            }
            set { first = value; }

        }
        public string Sin
        {
            get { return sin; }
            set
            {
                if (sin.Length <= 9)
                {
                    Console.WriteLine("Sin no should contain 9 digit");
                }
                else { sin = value; }//Length should contain 9 digits
            }
        }
        public string FirstName
        {
            get { return first; }
            set { first = value; }
        }
        public string LastName
        {
            get { return last; }
            set { last = value; }
        }
        public DateTime HireDate
        {
            get { return hire; }
            set { hire = value; }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                if (Utils.Methods.IsValidPhoneNumber(phone))//functiion to validate phone Number from class2 utils.Methods
                {
                    phone = value;
                }
            }
        }
        public string Email // method to check email validation
        {
            get { return email; }
            set
            {
                if (Utils.Methods.RegexEmailCheck(email) == true)
                {
                    email = value;
                }
            }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public bool IsActive
        {
            get; set;
        }


        //Constructors
        public Employee(string sin1)
        {
            this.sin = sin1;
        }

        public Employee(string sin1, string Efirst, string Elast)
        {
            this.sin = sin1;
            this.first = Efirst;
            this.last = Elast;
        }

        //abstract method
        public string Tostring() //Employees full name and phone number return method
        {
            return first + last + " " + phone;
        }
        public virtual decimal Bonus()//this method is optional for derived class 
                                      //return zero
        {
            return 0;
        }
        public decimal CalculatePay()//return zero
        {
            return 0;
        }
        public abstract decimal IncomeTax();
        public abstract decimal Pension();
        public abstract decimal UnionDues();
        public abstract  decimal Insurance();
    }

    //struct address
    public struct Address
    {
        //fields
        private string street;
        private string city;
        private string province;
        private string postalCode;

        //properties
        public string Street
        {
            get; set;
        }
        public string City
        {
            get; set;
        }
        public string Province
        {
            get; set;
        }
        public string PostalCode
        {
            get; set;
        }

        //Method to return formatted address
        public override string ToString()
        {
            return street + "," + city + "," + Province + "," + PostalCode;
        }
    }

    //Hourly class
    public sealed class Hourly : Employee
    {
        //fields
        private double hours;
        private double payrate;

        //properties
        public double Hours
        {
            get
            {
                return hours;
            }
            set
            {
                hours = value;
            }
        }

        public double Payrate
        {
            get
            {
                return payrate;
            }
            set
            {
                payrate = value;
            }
        }

        //constructors
        public Hourly(string sin1) : base(sin1)
        {

        }
        public Hourly(string sin1, string Hfirst, string Hlast) : base(sin1, Hfirst, Hlast)
        {

        }
        public Hourly(double hrate, double Hhours, string sin1, string Hfirst, string Hlast) : base(sin1, Hfirst, Hlast)
        {
            this.hours = Hhours;
            this.payrate = hrate;
        }


        //methods
        public override string ToString()
        {
            return base.ToString() + "Hourly payrate is : " + Payrate + ",hours worked : " + Hours;
        }

        //bonus
        public decimal Bonus(double THours, double Tpayrate)
        {
            decimal Ebonus;
            Ebonus = (decimal)(.20 * THours * Tpayrate);
            return Ebonus;
        }

        //Calculatepay
        public  decimal CalculatePay(double THours, double Tpayrate)
        {
            double Empay;
            Empay = THours * Tpayrate;
            return (decimal)Empay;
        }
        public override decimal IncomeTax()
        {
            return 0;
        }
        public override decimal Pension()
        {
            return 0;
        }
        public override decimal UnionDues()
        {
            return 0;
        }
        public override decimal Insurance()
        {
            return 0;
        } 

    }

    //Salaried class
    public class Salaried : Employee
    {
        //fields
        private decimal amount;
        public decimal Amount
        {
            get; set;
        }

        //contructors
        public Salaried(string sin1) : base(sin1)
        {
        }

        public Salaried(string sin1, string Efirst, string Elast) : base(sin1, Efirst, Elast)
        {
        }
        public Salaried(decimal amt, string sin1, string Efirst, string Elast) : base(sin1, Efirst, Elast)
        {
            this.amount = amt;
        }

        //methods to override the string
        public override string ToString()
        {
            return base.ToString() + "the salary amount is : " + amount;
        }

        public decimal Bonus(double salary)
        {
            decimal Ebonus;
            Ebonus = (decimal)(.20 * salary);
            return Ebonus;
        }

        //Calculatepay
        public decimal CalculatePay(double salary)
        {
            double Empay;
            Empay = salary - (.13* salary);
            return (decimal)Empay;
        }

        public override decimal IncomeTax()
        {
            return 0;
        }
        public override decimal Pension()
        {
            return 0;
        }
        public override decimal UnionDues()
        {
            return 0;
        }
        public override decimal Insurance()
        {
            return 0;
        }

    }
    //Contractpay class
    public class Contract : Employee
    {
        //fields
        private double contract_pay;
        public double Contract_pay
        {
            get; set;
        }

        //contructors
        public Contract(string sin1) : base(sin1)
        {
        }

        public Contract(string sin1, string Efirst, string Elast) : base(sin1, Efirst, Elast)
        {
        }
        public Contract(double Ccontract_pay, string sin1, string Efirst, string Elast) : base(sin1, Efirst, Elast)
        {
            this.contract_pay = Ccontract_pay;
        }

        //methods to override the string
        public override string ToString()
        {
            return base.ToString() + "the pay of contract is ;" + Contract_pay;
        }

        //Calculatepay
        public decimal CalculatePay(double ccontract_pay)
        {
            double Empay;
            Empay = ccontract_pay;
            return (decimal)Empay;
        }

        public override decimal IncomeTax()
        {
            return 0;
        }
        public override decimal Pension()
        {
            return 0;
        }
        public override decimal UnionDues()
        {
            return 0;
        }
        public override decimal Insurance()
        {
            return 0;
        }
    }

    //overtime class derived from salaried
    public sealed class Overtime : Salaried
    {
        //fields
        private decimal extrawage;
        private decimal extrahours;
        public decimal Extraage
        {
            get; set;
        }

        public decimal Extrahours
        {
            get; set;
        }

        //contructors
        public Overtime(string sin1) : base(sin1)
        {
        }

        public Overtime(string sin1, string Efirst, string Elast) : base(sin1, Efirst, Elast)
        {
        }
        public Overtime(decimal Oextrawage, decimal Oextrahours, string sin1, string Efirst, string Elast) : base(sin1, Efirst, Elast)
        {
            this.extrawage = Oextrawage;
            this.extrahours = Oextrahours;
        }

        //methods to override the string
        public override string ToString()
        {
            return base.ToString() + "the Overtime hours are : " + extrahours;
        }

        //Calculatepay
        public decimal CalculatePay(double Oextrahours, double Oextrawage, double salary)
        {
            double Empay;
            Empay = salary + (Oextrahours * Oextrawage);
            return (decimal)Empay;
        }
    }//sealed class
}