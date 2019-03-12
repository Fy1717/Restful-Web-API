using RestApi3.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi3.Connector
{
    public class Conn
    {
        private string connstr = "Server=DESKTOP-HQ2891Q;Database=CafeMenu;Trusted_Connection=True";

        public List<Kategoriler> kategoriListele()
        {
            List<Kategoriler> kategoriler = new List<Kategoriler>();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string komut = "select * from dbo.Kategoriler ";
                SqlCommand com = new SqlCommand(komut, conn);
                conn.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    kategoriler.Add(new Kategoriler { ID = dr.GetInt32(dr.GetOrdinal("ID")), ADI = dr.GetString(dr.GetOrdinal("ADI")) });
                }
                conn.Close();
            }
            return kategoriler;

        }

    }
}
