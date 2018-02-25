using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ZoologicoWeb.Models;

namespace ZoologicoWeb.Repository
{
    public class EspecieRepository
    {
        public List<Especie> getEspeciesAll()
        {
            List<Especie> especies = new List<Especie>();

            string connectionString = ConfigurationManager.ConnectionStrings["ZoologicoStringConnection"].ToString();

            string sqlString = "select IdEspecie, Nombre from Especie";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand(sqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Especie e1 = new Especie();
                        e1.IdEspecie = Convert.ToInt32(reader["IdEspecie"].ToString());
                        e1.Nombre = reader["Nombre"].ToString();
                        especies.Add(e1);
                    }
                    reader.Close();
                }
            }

            return especies;
        }

       
    }
}