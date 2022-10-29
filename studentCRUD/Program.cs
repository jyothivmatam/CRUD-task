using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace studentCRUD
{
     class Program
    {
        static void Main(string[] args)
        {
            StudentCrud sCrud = new StudentCrud();
            sCrud.Create("sahana", "female", "sahana@gmail.com");
            sCrud.DisplayAll();
            sCrud.Display();
            sCrud.DisplayAll();
            sCrud.Update(3, "vinu", "female", "vinu@gmail.com");
            sCrud.Delete(1);

            //Console.WriteLine("Employee Management Application");
            //Console.WriteLine("Select Operation:");
            //Console.WriteLine("1 create Employee Details");
            //Console.WriteLine("2 Display All Employee");
            //Console.WriteLine("3 Display Employee you want to see");
            //Console.WriteLine("4 update Employees");
            //Console.WriteLine("5 Delete Employee Detail");
            //Console.WriteLine("Press any key to exit");
            //var operation = Console.ReadLine();
            //while (true)
            //{
            //    switch (operation)
            //    {
            //        case "1":
            //            sCrud.Create();
            //            break;
            //        case "2":
            //            sCrud.DisplayAll();
            //            break;
            //        case "3":
            //            sCrud.Display();
            //            break;
            //        case "4":
            //            sCrud.Update();
            //            break;
            //        case "5":
            //            sCrud.Delete();
            //            break;
            //        case "x":
            //            return;
            //        default:
            //            Console.WriteLine("Select valid Operation");
            //            break;
            //    }
            //    Console.Write("\nSelect Operation:");
            //    operation = Console.ReadLine();
            //}
        }
    }
}

