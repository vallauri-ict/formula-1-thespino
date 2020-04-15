using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using FormulaOneDll.Database.Models;
using Newtonsoft.Json;

namespace FormulaOneDll.Database
{
    public class Tools
    {

        #region ATTRIBUTES

        public const string WORKINGPATH = @"C:\Dati\";
        public const string CONNSTR = @"Data Source=(LocalDB)\MSSQLLocalDB; Database=FormulaOne; Integrated Security=True";

        private Dictionary<string, Country> countries;
        private Dictionary<int, Driver> drivers;
        private Dictionary<int, Team> teams;

        #endregion



        #region UTILS

        public void ExecuteSqlScript(string sqlScriptName)
        {
            var fileContent = File.ReadAllText(WORKINGPATH + sqlScriptName);
            fileContent = fileContent
                .Replace("\r\n", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace("\t", "");
            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection(CONNSTR);
            var cmd = new SqlCommand("query", con);
            con.Open();
            var i = 0;
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query;
                i++;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Console.WriteLine("Errore in esecuzione della query numero: " + i);
                    Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                }
            }
            con.Close();
        }

        public void DropTable(string tableName)
        {
            var con = new SqlConnection(CONNSTR);
            var cmd = new SqlCommand("Drop Table " + tableName + ";", con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException err)
            {
                Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
            }
            con.Close();
        }

        #endregion



        #region MODELS CRUD

        public Dictionary<string, Country> Countries__GetAll(bool force = false)
        {
            if (!force && this.countries != null)
            {
                return this.countries;
            }

            this.countries = new Dictionary<string, Country>();

            var con = new SqlConnection(CONNSTR);
            var command = new SqlCommand("SELECT * FROM Countries;", con);
            con.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var country = new Country(reader.GetString(0), reader.GetString(1));
                this.countries.Add(country.Code, country);
            }
            reader.Close();
            con.Close();

            return countries;
        }

        public Country Countries__Get(string code)
        {
            try
            {
                return Countries__GetAll()[code];
            }
            catch
            {
                return null;
            }
        }


        public Dictionary<int, Driver> Drivers__GetAll(bool force = false)
        {
            if (!force && this.drivers != null)
            {
                return this.drivers;
            }

            this.drivers = new Dictionary<int, Driver>();

            var con = new SqlConnection(CONNSTR);
            var command = new SqlCommand("SELECT * FROM Drivers;", con);
            con.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var driver = new Driver(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetDateTime(3),
                    reader.GetString(4),
                    Countries__GetAll()[reader.GetString(5)]
                );
                this.drivers.Add(driver.Id, driver);
            }
            reader.Close();
            con.Close();

            return this.drivers;
        }

        public Driver Drivers__Get(int id)
        {
            try
            {
                return Drivers__GetAll()[id];
            } catch
            {
                return null;
            }
        }


        public Dictionary<int, Team> Teams__GetAll(bool force = false)
        {
            if (!force && this.teams != null)
            {
                return this.teams;
            }

            this.teams = new Dictionary<int, Team>();

            var con = new SqlConnection(CONNSTR);
            var command = new SqlCommand("SELECT * FROM Teams;", con);
            con.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var team = new Team(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    Countries__GetAll()[reader.GetString(3)],
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6),
                    Drivers__GetAll()[reader.GetInt32(7)],
                    Drivers__GetAll()[reader.GetInt32(8)]
                );
                this.teams.Add(team.Id, team);
            }
            reader.Close();
            con.Close();

            return this.teams;
        }

        public Team Teams__Get(int id)
        {
            try
            {
                return Teams__GetAll()[id];
            }
            catch
            {
                return null;
            }
        }

        #endregion



        #region SERIALIZE

        public bool SerializeToJSON<T>(IEnumerable<T> list, string path)
        {
            try
            {
                var jsonstring = JsonConvert.SerializeObject(list, Formatting.Indented);
                new StreamWriter(path, false).Write(jsonstring);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

    }
}
