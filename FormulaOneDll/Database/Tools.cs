using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using FormulaOneDll.Database.Models;
using Newtonsoft.Json;
using SqlKata.Compilers;
using SqlKata.Execution;

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
                    reader.GetString(5),
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
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetString(6),
                    reader.GetInt32(7),
                    reader.GetInt32(8)
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



        #region API CRUD

        #region Countries

        public PaginationResult<Country> API___Countries_List(int page, int limit = 10, string query = "")
        {
            var con = new SqlConnection(CONNSTR);
            var compiler = new SqlServerCompiler();

            var db = new QueryFactory(con, compiler);

            if (query == "")
                return db.Query(Country.TABLE)
                    .Paginate<Country>(page, limit);

            return db.Query(Country.TABLE)
                .WhereLike("Code", $"%{query}%")
                .OrWhereLike("Name", $"%{query}%")
                .Paginate<Country>(page, limit);
        }

        public Country API___Countries_Get(string code)
        {
            var con = new SqlConnection(CONNSTR);
            var compiler = new SqlServerCompiler();

            var db = new QueryFactory(con, compiler);
            var ret = db.Query(Country.TABLE)
                .Where("Code", "=", code)
                .FirstOrDefault<Country>();

            return ret;
        }

        #endregion


        #region Drivers

        public PaginationResult<Driver> API___Drivers_List(int page, int limit = 10, string query = "")
        {
            var con = new SqlConnection(CONNSTR);
            var compiler = new SqlServerCompiler();

            var db = new QueryFactory(con, compiler);

            if (query == "")
                return db.Query(Driver.TABLE)
                    .Paginate<Driver>(page, limit);

            return db.Query(Driver.TABLE)
                .WhereLike("FirstName", $"%{query}%")
                .OrWhereLike("LastName", $"%{query}%")
                .OrWhereLike("Pob", $"%{query}%")
                .Paginate<Driver>(page, limit);
        }

        public Driver API___Drivers_Get(int id)
        {
            var con = new SqlConnection(CONNSTR);
            var compiler = new SqlServerCompiler();

            var db = new QueryFactory(con, compiler);
            var ret = db.Query(Driver.TABLE)
                .Where("Id", "=", id)
                .FirstOrDefault<Driver>();

            return ret;
        }

        #endregion


        #region Teams

        public PaginationResult<Team> API___Teams_List(int page, int limit = 10, string query = "")
        {
            var con = new SqlConnection(CONNSTR);
            var compiler = new SqlServerCompiler();

            var db = new QueryFactory(con, compiler);

            if (query == "")
                return db.Query(Team.TABLE)
                    .Paginate<Team>(page, limit);

            return db.Query(Team.TABLE)
                .WhereLike("Name", $"%{query}%")
                .OrWhereLike("FullName", $"%{query}%")
                .Paginate<Team>(page, limit);
        }

        public Team API___Teams_Get(int id)
        {
            var con = new SqlConnection(CONNSTR);
            var compiler = new SqlServerCompiler();

            var db = new QueryFactory(con, compiler);
            var ret = db.Query(Team.TABLE)
                .Where("Id", "=", id)
                .FirstOrDefault<Team>();

            return ret;
        }

        #endregion


        #region Circuits

        public PaginationResult<Circuit> API___Circuits_List(int page, int limit = 10, string query = "")
        {
            var con = new SqlConnection(CONNSTR);
            var compiler = new SqlServerCompiler();

            var db = new QueryFactory(con, compiler);

            if (query == "")
                return db.Query(Circuit.TABLE)
                    .Paginate<Circuit>(page, limit);

            return db.Query(Circuit.TABLE)
                .WhereLike("Name", $"%{query}%")
                .OrWhereLike("Location", $"%{query}%")
                .Paginate<Circuit>(page, limit);
        }

        public Circuit API___Circuits_Get(int id)
        {
            var con = new SqlConnection(CONNSTR);
            var compiler = new SqlServerCompiler();

            var db = new QueryFactory(con, compiler);
            var ret = db.Query(Circuit.TABLE)
                .Where("Id", "=", id)
                .FirstOrDefault<Circuit>();

            return ret;
        }

        #endregion


        #region Races

        public PaginationResult<Race> API___Races_List(int page, int limit = 10, string query = "")
        {
            var con = new SqlConnection(CONNSTR);
            var compiler = new SqlServerCompiler();

            var db = new QueryFactory(con, compiler);

            if (query == "")
                return db.Query(Race.TABLE)
                    .Paginate<Race>(page, limit);

            return db.Query(Race.TABLE)
                .WhereLike("Name", $"%{query}%")
                .OrWhereLike("Date", $"%{query}%")
                .Paginate<Race>(page, limit);
        }

        public Race API___Races_Get(int id)
        {
            var con = new SqlConnection(CONNSTR);
            var compiler = new SqlServerCompiler();

            var db = new QueryFactory(con, compiler);
            var ret = db.Query(Race.TABLE)
                .Where("Id", "=", id)
                .FirstOrDefault<Race>();

            return ret;
        }

        #endregion


        #region Results

        public PaginationResult<Result> API___Results_List(int page, int limit = 10, string query = "")
        {
            var con = new SqlConnection(CONNSTR);
            var compiler = new SqlServerCompiler();

            var db = new QueryFactory(con, compiler);

            if (query == "")
                return db.Query(Result.TABLE)
                    .Paginate<Result>(page, limit);

            return db.Query(Result.TABLE)
                .WhereLike("Position", $"%{query}%")
                .OrWhereLike("Score", $"%{query}%")
                .OrWhereLike("FastestLap", $"%{query}%")
                .Paginate<Result>(page, limit);
        }

        public Result API___Results_Get(int id)
        {
            var con = new SqlConnection(CONNSTR);
            var compiler = new SqlServerCompiler();

            var db = new QueryFactory(con, compiler);
            var ret = db.Query(Result.TABLE)
                .Where("Id", "=", id)
                .FirstOrDefault<Result>();

            return ret;
        }

        public IEnumerable<Result> API___Results_OfRace(int id)
        {
            var con = new SqlConnection(CONNSTR);
            var compiler = new SqlServerCompiler();

            var db = new QueryFactory(con, compiler);
            var ret = db.Query(Result.TABLE)
                .Where("Race_Id", "=", id)
                .Get<Result>();

            return ret;
        }

        #endregion

        #endregion

    }
}
