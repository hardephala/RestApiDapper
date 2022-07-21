using Dapper;
using Microsoft.Extensions.Configuration;
using RestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Dapper
{
    public class DeveloperRepository : IDeveloperRepository
    {
        protected readonly IConfiguration _config;
        public DeveloperRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get {
                return new SqlConnection(_config.GetConnectionString("DevelopersDbConnection"));
            }

        }
        public void AddDeveloper(Developer developer)
        {
            try
            {
                using(IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO Developers(DeveloperName,Email,GithubURL,Department,JoinedDate) VALUES (@DeveloperName, @Email, @GithubURL, @Department, @JoinedDate)";
                    dbConnection.Execute(query, developer);
                }
            } catch (Exception ex) {
                throw ex; 
            }
        }

        public void DeleteDeveloper(int Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM Developers WHERE Id = @Id";
                    dbConnection.Execute(query, new { Id = Id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Developer>> GetAllDevelopersAsync()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT Id, DeveloperName, Email, GithubURL, Department, JoinedDate FROM Developers";
                    return await dbConnection.QueryAsync<Developer>(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Developer> GetDeveloperByEmailAsync(string Email)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM Developers WHERE Email = @Email";
                    return await dbConnection.QueryFirstOrDefaultAsync<Developer>(query, new {Email = Email});
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Developer> GetDeveloperByIdAsync(int Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM Developers WHERE Id = @Id";
                    return await dbConnection.QueryFirstOrDefaultAsync<Developer>(query, new {Id = Id});
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateDeveloper(Developer developer)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE Developers SET DeveloperName = @DeveloperName, Email = @Email, GithubURL = @GithubURL, Department = @Department, JoinedDate = @JoinedDate";
                    dbConnection.Execute(query, developer);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
