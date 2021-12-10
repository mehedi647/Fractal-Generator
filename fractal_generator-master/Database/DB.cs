using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using fractal_generator.Model;

namespace fractal_generator.Database
{
    class DB
    {
        private static DBConnection dbCon;
        public static List<List<String>> ExecuteFractalListSql()
        {
            string sql = "select * from fractal";
            dbCon = new DBConnection();
            MySqlDataReader reader = null;
            List<List<String>> listString = new List<List<string>>();
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = sql;
                var cmd = new MySqlCommand(query, dbCon.Connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    List<String> item = new List<string>();
                    item.Add(reader.GetString(0));
                    item.Add(reader.GetString(1));
                    item.Add(reader.GetString(2));
                    item.Add(reader.GetString(3));
                    item.Add(reader.GetString(4));

                    listString.Add(item);
                }
            }
            dbCon.Close();
            return listString;


        }

        public static List<String> ExecuteImageUrlSql(Fractal f)
        {
            dbCon = new DBConnection();
            MySqlDataReader reader = null;
            List<String> listString = new List<string>();
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string sql = string.Format("select url from image where fractal_id={0}", f.Id);
                var query = sql;
                var cmd = new MySqlCommand(query, dbCon.Connection);
                Console.WriteLine(dbCon.Connection.ToString());
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string item = reader.GetString(0);
                    listString.Add(item);
                }
            }
            dbCon.Close();
            return listString;

        }
    }
}
