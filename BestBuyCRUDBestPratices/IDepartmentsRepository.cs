using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPratices
{
    interface IDepartmentsRepository
    {
        // Method for calling the departments which returns a collection that is Ienumerable<T> which is replaced with departments as well sets implementation standards for classes that inherit
        IEnumerable<Departments> GetAllDepartments();

        // Method for inserting a new Department
        void InsertDepartment(string newDepartmentName);
    }
}
