using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationMongo
{
    class Program
    {
        static void Main(string[] args)
        {            
            ///Заносим нового пользователя в БД
            User userA = new User() { FIO="Сидоров И.И.",BirthDay=new DateTime(1985,1,5)};
            DBHelper.InsertUser(ref userA);
            ///заносим 6 статусов данного пользователя в БД
            Status st = new Status() { IdUser = userA.Id, Name = "Off" };
            DBHelper.InsertStatus(ref st);
            st.Name = "online";
            DBHelper.InsertStatus(ref st);
            st.Name = "away";
            DBHelper.InsertStatus(ref st);
            st.Name = "hone";
            DBHelper.InsertStatus(ref st);
            st.Name = "work";
            DBHelper.InsertStatus(ref st);
            st.Name = "do it";
            DBHelper.InsertStatus(ref st);
            ///получаем список всех статусов пользователя
            List<Status> list=DBHelper.FindAllStatusUser(userA.Id);
            Console.WriteLine("Count status={0}",list.Count);
            Console.Read();
        }
    }
}
