using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualAssignment.Models;
using IndividualAssignment.Users;
using System.Collections;

namespace IndividualAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Popullate.AddRandomData();
            Popullate.AddRandomData2();
            Console.WriteLine("###passwords for evaluator:");
            Console.WriteLine("###Head-Master account - surname:Pasparakis    password:giopas");
            Console.WriteLine("###Student account - surname:Georgilas    password:vasgeo");
            Console.WriteLine("###Trainer account - surname:Nikolaidis    password:micnik");
            Console.WriteLine("###Trainer account - surname:Vasileiadis    password:vyrvas");
            Console.WriteLine("###You can also see the class POPULLATE to see all the initial data and passwords");
            Console.WriteLine("\n");

            Passwords P= new Passwords();

            P.PasswordTry();

            if (P.type_user == "Student")
            {

                UserStudent.MenouStudent(P.user_id);
            }

            if (P.type_user == "Trainer")
            {

                UserTrainer.MenouTrainer(P.user_id);
            }
            if (P.type_user == "Head_Master")
            {

                UserHeadMaster.MenouHeadMaster(P.user_id);

            }






        }
    }
}
