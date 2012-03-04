using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Linq;

namespace ConsoleApplicationMongo
{
    static class DBHelper
    {
        /// <summary>
        /// Ссылка на открытое подключение
        /// к MongoDB
        /// </summary>
        private static Mongo db;        
        /// <summary>
        /// Подключаемся к БД
        /// </summary>
        /// <returns>Результат попытки подключения</returns>
        private static bool ConnectToMongo()
        {            
            db = new Mongo();             
            try
            {
                ///Делаем попытку подключения
                db.Connect();
                ///если все ок,возвращаем true               
                return true;
            }
            catch(Exception)
            {
                ///иначе -false
                ///для промтоты сделана 
                ///такая "тупая" обработка
                ///ошибки
                return false;
            }
        }
        /// <summary>
        /// Отключаемся от БД
        /// </summary>
        /// <returns></returns>
        private static bool DisconnectWithMongo()
        {
            try
            {                
                db.Disconnect();
                return true;
            }
            catch (Exception) { return false; }
        }
        /// <summary>
        /// Добавить нового пользователя
        /// </summary>
        /// <param name="user">
        /// Ссылка на объект класса User
        /// </param>
        public static void InsertUser(ref User user)
        {
            ///подключаемся к БД
            ConnectToMongo();
            ///сздаем новый документ
            var docuser = new Document();
            ///генерируем заранее его _id
            user.Id = Oid.NewOid().ToString();
            ///заполняем все  поля
            docuser["_id"] = user.Id;
            docuser["FIO"] = user.FIO;
            docuser["BirthDay"] = user.BirthDay;
            docuser["RegisterDate"] = DateTime.Now;
            ///вставляем новый документ в БД
            db["test"]["users"].Insert(docuser);            
            ///отключаемся от БД
            DisconnectWithMongo();            
        }
        /// <summary>
        /// Обновить информацию о пользователе
        /// </summary>
        /// <param name="user">
        /// Ссылка на объект класса User
        /// </param>
        public static void UpdateUser(ref User user)
        {
            ConnectToMongo();
            var docuser = new Document();
            docuser["_id"] = user.Id;
            docuser["FIO"] = user.FIO;
            docuser["BirthDay"] = user.BirthDay;
            ///обновляем запись, которая
            ///соответствует указанному _id
            db["test"]["users"].Update(docuser);
            DisconnectWithMongo();
        }
        /// <summary>
        /// Удаляем информацию о пользователе
        /// </summary>
        /// <param name="Id">
        /// в качестве параметра передаем Id юзера
        /// </param>
        public static void DeleteUser(string Id)
        {
            ConnectToMongo();
            var docuser = new Document();
            ///заполняем _id и удаляем запись
            docuser["_id"] = Id;
            db["test"]["users"].Delete(docuser);
            DisconnectWithMongo();
        }
        /// <summary>
        /// Добавляем новый статус 
        /// пользователя
        /// </summary>
        /// <param name="status">
        /// Ссылка на объект Status
        /// </param>
        public static void InsertStatus(ref Status status)
        {
            ConnectToMongo();
            var docstatus = new Document();
            docstatus["idUser"] = status.IdUser;
            docstatus["Name"] = status.Name;
            db["test"]["statuses"].Update(docstatus);
            DisconnectWithMongo();
        }
        /// <summary>
        /// Удаляем статус с заданным Id
        /// </summary>
        /// <param name="Id">Id статуса</param>
        public static void DeleteStatus(string Id)
        {
            ConnectToMongo();
            var docstatus = new Document();
            docstatus["_id"] = Id;
            db["test"]["statuses"].Delete(docstatus);
            DisconnectWithMongo();
        }
        /// <summary>
        /// Считываем информацию о пользователе
        /// по его ID
        /// </summary>
        /// <param name="Id">Id пользователя</param>
        /// <param name="user">В этот объект будет записана
        /// полученная информация
        /// </param>
        /// <returns></returns>
        public static bool FindUserById(string Id, ref User user)
        {
            ConnectToMongo();
            user.Id = Id;
            var resultuser = db["test"]["users"].FindOne(new Document().Append("_id", user.Id.ToString()));
            if (resultuser==null)
            {
                DisconnectWithMongo();
                return false;
            }
            user.FIO=resultuser["FIO"].ToString();
            user.BirthDay = Convert.ToDateTime(resultuser["BirthDay"].ToString());
            user.RegisterDate = Convert.ToDateTime(resultuser["RegisterDate"].ToString());
            DisconnectWithMongo();
            return true;
        }
        /// <summary>
        /// считываем из БД все статусы пользователя
        /// </summary>
        /// <param name="Id">
        /// Id пользователя
        /// </param>
        /// <returns></returns>
        public static List<Status> FindAllStatusUser(string Id)
        {
            List<Status> res=new List<Status>();
            ConnectToMongo();
            ICursor status = db["test"]["statuses"].Find(
                new Document().Append("idUser",Id));
            foreach (var s in status.Documents)
            {
                res.Add(new Status(){IdUser=s["idUser"].ToString(),Name=s["Name"].ToString()});
            }
            return res;
        }
    }
}
