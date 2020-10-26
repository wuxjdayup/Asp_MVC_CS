using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoTelManger_MVCFM.Models;

namespace HoTelManger_MVCFM.Models
{
    public class Listinfo
    {
       static  public List<RoomsInfo> GetList()
        {
            List<RoomsInfo> roomList = new List<RoomsInfo>();
            string connstr = "data source=192.168.3.8;database=Hotel_User;user id=wuxj;password=wuxj;pooling=false;charset=utf8";
            MySqlConnection conn = new MySqlConnection(connstr);
            string sql = "select * from roomsinfo ";
            MySqlCommand mySqlCommand = new MySqlCommand(sql, conn);

            conn.Open();

            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            while (mySqlDataReader.Read())
            {
                RoomsInfo roomsInfo = new RoomsInfo();
                roomsInfo.No = mySqlDataReader["NO"].ToString();
                roomsInfo.RommName = mySqlDataReader["Name"].ToString();
                roomsInfo.RoomSts = mySqlDataReader["sts"].ToString();
                roomList.Add(roomsInfo);
            }

            return roomList;
        }

    }
}