using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace HoTelManger_MVCFM.Models
{
    public class UserServer
    {
        public static bool UserConform(string user,string password)

        {

            string serverip = ConfigurationManager.AppSettings["ServerIp"];

            string dataBase = ConfigurationManager.AppSettings["DataBase"];

            string dbuser = ConfigurationManager.AppSettings["User"];

            string passWord = ConfigurationManager.AppSettings["PassWord"];


            try
            {
                //string connstr = "data source=192.168.3.8;database=Hotel_User;user id=wuxj;password=wuxj;pooling=false;charset=utf8";
                string connstr = "data source={0};database={1};user id={2};password={3};pooling=false;charset=utf8";
                connstr = string.Format(connstr, new string[] { serverip, dataBase, dbuser, passWord });


                MySqlConnection conn = new MySqlConnection(connstr);
                string sql = "select * from usersinfo where username = @user and password = @pass";
                MySqlCommand mySqlCommand = new MySqlCommand(sql, conn);
                mySqlCommand.Parameters.Add(new MySqlParameter("@user", user));
                mySqlCommand.Parameters.Add(new MySqlParameter("@pass", password));

                conn.Open();

                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                if (mySqlDataReader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }

     
        }

    }
}