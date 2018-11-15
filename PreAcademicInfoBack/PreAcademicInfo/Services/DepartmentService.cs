using PreAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Services
{
    public class DepartmentService
    {
        DepartmentsContext context;

        public DepartmentService(DepartmentsContext context)
        {
            this.context = context;
        }

        public List<Specializare> GetSpecializariByDepartment(string departmentName)
        {
            return context.Departments.Where(d => d.Name == departmentName)
                                     .Select(d => d.Specializares).First().ToList();
        }
        
        
    }
}
