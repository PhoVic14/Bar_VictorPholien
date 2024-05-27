using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using Google.Protobuf.WellKnownTypes;
using System.Collections;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using MySqlX.XDevAPI.Relational;

namespace GESTION_BAR
{
    internal class Program
    {
        static string DefinirCheminBD()
        {
            string server = "localhost";
            string database = "barcocktail";
            string uid = "root";
            string password = "root";
            string connectionString;

            return "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        }

        static bool ChercherInfos(string table, out DataSet infos)
        {
            MySqlConnection maConnection = new MySqlConnection(DefinirCheminBD());
            bool ok = true;
            string query = "";
            try
            {
                maConnection.Open();

                query = "select * from " + table + ";";

                MySqlDataAdapter da = new MySqlDataAdapter(query, maConnection);
                infos = new DataSet();
                da.Fill(infos, "table");
                maConnection.Close();
                return ok;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public bool ChercheRecetteCocktail(int numCocktail, out DataSet recettes)
        {
            bool ok = false;
            MySqlConnection maConnection = new MySqlConnection(DefinirCheminBD());
            string query = "";
            try
            {
                maConnection.Open();

                query = "SELECT * FROM Recettes WHERE cocktailId=" + numCocktail + ";";

                MySqlDataAdapter da = new MySqlDataAdapter(query, maConnection);
                recettes = new DataSet();
                da.Fill(recettes, "infos");

                if (recettes.Tables[0].Rows.Count >= 1)
                {
                    ok = true;
                }
                maConnection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

            return ok;
        }

    }
}