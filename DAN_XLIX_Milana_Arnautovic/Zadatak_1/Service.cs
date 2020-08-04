using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.Model;

namespace Zadatak_1
{
   public class Service
    {
        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (DAN_XLIXEntities context = new DAN_XLIXEntities())
                {
                    List<tblUser> users = new List<tblUser>();
                    users = context.tblUsers.ToList();
                    return users;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        public List<tblEmployee> GetAllEmployees()
        {
            try
            {
                using (DAN_XLIXEntities context = new DAN_XLIXEntities())
                {
                    List<tblEmployee> employee = new List<tblEmployee>();
                    employee = context.tblEmployees.ToList();
                    return employee;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        public List<tblManager> GetAllManagers()
        {
            try
            {
                using (DAN_XLIXEntities context = new DAN_XLIXEntities())
                {
                    List<tblManager> managers = new List<tblManager>();
                    managers = context.tblManagers.ToList();
                    return managers;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

       

    }
}
