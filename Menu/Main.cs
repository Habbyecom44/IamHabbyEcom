using AirApp.Models.Enums;
using AirApp.Services.Implementation;
using AirApp.Services.Interface;

namespace AirApp.Menu
{
    public class Main
    {
        Admin admin = new Admin();
        ICustomerService customerService = new CustomerService();
        IUserService userService = new UserService();
        public void MainMenu()
        {
            Console.WriteLine("1. Register\n2. Login\n3. Exit");
            string opt = Console.ReadLine();

            if(opt == "1")
            {
                RegisterMenu();
                MainMenu();
            }
            else if(opt == "2")
            {
                LoginMenu();
                MainMenu();
            }
            else if(opt == "3")
            {
               Console.WriteLine("Thanks");
               MainMenu();
            }
            else
            {
                Console.WriteLine("Invalid option");
            }
        }

        public void RegisterMenu()
        {
            Console.Write("Enter First Name: ");
            string fn = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string ln = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            Console.Write("Select Your Gender: ");
            Gender gender = (Gender)int.Parse(Console.ReadLine());  

            var response =  customerService.Create(password,fn,ln,email,phone,address,gender);
            if(response == null)
            {
                Console.WriteLine("Email Already Exists");
            }
            else
            {
                Console.WriteLine("Successfully Registered");
            }            
        }

        private void LoginMenu()
        {
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();

            var user = userService.Login(email,password);
            if(user == null)
            {
                Console.WriteLine("Invalid Credentials");
            }
            else if(user._role == "app_admin")
            {
                admin.AdminMenu();
            }
            else if(user._role == "app_customer")
            {
                //CustomerMenu();
            }	
        }

    }
}