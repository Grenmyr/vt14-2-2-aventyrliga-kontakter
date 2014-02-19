using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Äventyrliga_kontakter.Model.DAL
{
    abstract class DALBase
    {
        private static string _connectionString;

        protected SqlConnection CreateConnection() { throw new NotImplementedException("här ska jag retunera en referens till mitt anslutningsobj"); }

        public static DALBase() 
        {
            _connectionString = "här ska jag skicka in min anslutninssträng";
        }

    }
}