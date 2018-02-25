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
    public class AnimalRepository
    {
        public List<Animal> getAnimalesAll()
        {
            List<Animal> animales = new List<Animal>();

            string connectionString = ConfigurationManager.ConnectionStrings["ZoologicoStringConnection"].ToString();

            string sqlString = "SELECT " +

                               " ani.IdAnimal, " +
                               " ani.Nombre as NombreAnimal, " +
                               " esp.IdEspecie, " +
                               " esp.Nombre as NombreEspecie" +

                           " FROM      Animal  AS ani, " +
                                      "Especie AS esp" +

                           " WHERE " +
                               " ani.IdEspecie = esp.IdEspecie";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand(sqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Animal a1 = new Animal();
                        a1.IdAnimal      = Convert.ToInt32(reader["IdAnimal"].ToString());
                        a1.Nombre        = reader["NombreAnimal"].ToString();
                        a1.IdEspecie     = Convert.ToInt32(reader["IdEspecie"].ToString());
                        a1.NombreEspecie = reader["NombreEspecie"].ToString();

                        animales.Add(a1);
                    }
                    reader.Close();
                }
            }

            return animales;
        }


        public int insertAnimal(Animal x) //Sql_inyeccion!
        {
            //out of the box = (librerias) por defecto = ya viene incluido
            string connectionString = ConfigurationManager.ConnectionStrings["ZoologicoStringConnection"].ToString();

            string sqlString = "Insert into Animal (Nombre, IdEspecie) values (@Nombre, @IdEspecie) ";  //PENDIENTE CORREGIR CON SQL INJECCION
            int retorno = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Nombre", x.Nombre);
                    cmd.Parameters.AddWithValue("@IdEspecie", x.IdEspecie);

                    conn.Open();

                    retorno = cmd.ExecuteNonQuery(); //esta funcion es para INSERT,UPDATE,DELETE y me devuelve el total de filas afectadas
                }
            }


            return retorno;
        }

    }
}