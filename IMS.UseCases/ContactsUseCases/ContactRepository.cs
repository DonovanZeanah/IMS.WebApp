using IMS.CoreBusiness.Models;
using IMS.Plugins.SQL.Queries;
using IMS.UseCases._PluginInterfaces_.DataStore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace IMS.UseCases.ContactsUseCases
{
    public class ContactRepository : IContactRepository
    {
        #region ===[ Private Members ]=============================================================

        private readonly IConfiguration _configuration;

        #endregion

        #region ===[ Constructor ]=================================================================

        public ContactRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region ===[ IContactRepository Methods ]==================================================

        public async Task<IReadOnlyList<Contact>> GetAllAsync()
        {
            IDbConnection connection;
            using (connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Contact>(ContactQueries.AllContact);
                return result.ToList();
            }
        }

        public async Task<Contact> GetByIdAsync(long id)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Contact>(ContactQueries.ContactById, new { ContactId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(Contact entity)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(ContactQueries.AddContact, entity);
                return result.ToString();
            }
        }

        public async Task<string> UpdateAsync(Contact entity)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(ContactQueries.UpdateContact, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(ContactQueries.DeleteContact, new { ContactId = id });
                return result.ToString();
            }
        }

        #endregion
    }
}
