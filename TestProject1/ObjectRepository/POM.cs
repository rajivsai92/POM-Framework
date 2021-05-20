using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.ObjectRepository.People;

namespace TestProject1.ObjectRepository
{
    public sealed class POM<T> where T: class, new()
    {
        int count = 0;
        private static readonly T instance = new T();

        public static T GetInstance
        {
            get
            {
                return instance;
            }

        }
        private POM()
        {
            count++;
            Console.WriteLine("times :" + count);
        }


        //#region Fields
        //private LoginPage loginPage;
        //private MyDashBoardPage myDashBoardPage;
        //private UsersPage usersPage;
        //#endregion


        //#region Properties
        //public LoginPage LoginPage
        //{
        //    get
        //    {
        //        if ((this.loginPage == null))
        //        {
        //            this.loginPage = new LoginPage();
        //        }
        //        return this.loginPage;
        //    }
        //}
        //public MyDashBoardPage MyDashBoardPage
        //{
        //    get
        //    {
        //        if ((this.myDashBoardPage == null))
        //        {
        //            this.myDashBoardPage = new MyDashBoardPage();
        //        }
        //        return this.myDashBoardPage;
        //    }
        //}
        //public UsersPage UsersPage
        //{
        //    get
        //    {
        //        if ((this.usersPage == null))
        //        {
        //            this.usersPage = new UsersPage();
        //        }
        //        return this.usersPage;
        //    }
        //}
        //#endregion


    }
}
