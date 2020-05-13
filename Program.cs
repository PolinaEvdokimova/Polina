using System;
using System.Linq;

namespace Lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта User
                tester user1 = new tester { Id_tester = 100 };
                tester user2 = new tester { FIO_tester = "Петров Василий" };
                Console.WriteLine(UpdateTesterById(db, user1));
                InsertTester(db, user2);
                DeleteTester(db, user2);
                

            }

            Console.Read();
        }
        public static string InsertTester(ApplicationContext db, tester user)
        {
            //Insert
            db.tester.Add(user);
            db.SaveChanges();

            var users = db.tester.ToList();
            foreach (tester us in users)
            {
                if(us.FIO_tester == user.FIO_tester)
                {
                    return us.FIO_tester;
                 
                }

            }
            return "err";      

        }

        public static string UpdateTesterById(ApplicationContext db, tester user)
        {
            //Update
            
            var users = db.tester.Find(user.Id_tester);
            if (users != null)
             {
                users.FIO_tester = "Якубович Леонид";
                db.tester.Update(users);
                db.SaveChanges();
                return "Complete";
            }
            else
            {
                return "Err";
            }
             
            
         }
            
            /*foreach (tester us in finduser)
            {
                if (us.FIO_tester == users.FIO_tester)
                {
                    return users.FIO_tester;
                }
            }
            return "Err";*/
        

        public static string DeleteTester(ApplicationContext db, tester user)
        {
            //Delete
            var users = db.tester.ToList();
            foreach (tester us in users)
            {
                if (us.FIO_tester == user.FIO_tester)
                {
                    db.tester.Remove(us);
                    db.SaveChanges();
                    return "Complete";   

                }

            }
            return "err";
          
        }
    }
}