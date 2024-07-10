using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;/* --Importamos esta libreria*/
using System.Data; /* --Importamos esta libreria*/
using WebApplication5.Models; /* --Importamos esta libreria*/

namespace WebApplication5.Datos
{
    public class DT_REPORTE
    {
        public List<Reporteventa> RetornarVentas(){

            List<Reporteventa> objLista = new List<Reporteventa>();

            using (SqlConnection oconexion = new SqlConnection("Data Source=(local); Initial Catalog=GASOLINERA_UCENM; Integrated Security=True"))
            {

                string query = "SP_retornarventas";
                SqlCommand cmd = new SqlCommand(query, oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                oconexion.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objLista.Add(new Reporteventa()
                        {
                            mes = dr["DESCRIPCIONMES"].ToString(),
                            cantidad = float.Parse(dr["TOTALVENTAS"].ToString()),
                        });
                    }
                }
            }

            return objLista;
        }
        public List<Reporte_dispensador> Retornardispensador()
        {
            List<Reporte_dispensador> objLista = new List<Reporte_dispensador>();

            using (SqlConnection oconexion = new SqlConnection("Data Source=(local); Initial Catalog=GASOLINERA_UCENM; Integrated Security=True"))
            {

                string query = "SP_ventasxdispensador";
                 SqlCommand cmd = new SqlCommand(query, oconexion);
                cmd.CommandType = CommandType.StoredProcedure;

                oconexion.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objLista.Add(new Reporte_dispensador()
                        {
                             nombre = dr["NOMBRE_DISPENSADOR"].ToString(),
                            venta = float.Parse(dr["VENTAS"].ToString()),
                        });
                    }
                }
            }

            return objLista;
        }
    }
}
