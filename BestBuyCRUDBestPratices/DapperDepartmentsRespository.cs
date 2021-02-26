using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace BestBuyCRUDBestPratices
{
    class DapperDepartmentsRespository : IDepartmentsRepository
    {

        private readonly IDbConnection _connection;  // read only can be given value inline or in the constructor AND LOCAL VARIABLE Field used for making queries to the Database
        public DapperDepartmentsRespository(IDbConnection connection)
        {// constructor
            _connection = connection;
        }
        public IEnumerable<Departments> GetAllDepartments()
        {
            var retrieveDepartments = _connection.Query<Departments>("SELECT * FROM DEPARTMENTS");

            return retrieveDepartments;
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (NAME) VALUES (@departmentName);",
                new { departmentName = newDepartmentName });
        }
    }
}
