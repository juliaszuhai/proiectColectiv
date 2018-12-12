using PreAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Services
{
    public class DepartmentService
    {
        StudentContext context;

        public DepartmentService(StudentContext context)
        {
            this.context = context;
        }

        public List<Specializare> GetSpecializariByDepartment(string departmentName)
        {
            return context.Department.Where(d => d.Name == departmentName)
                                     .Select(d => d.Specializares).First().ToList();
        }

        public List<Specializare> GetSpecializariByDepartmentId(int id)
        {
            return context.Department.Where(d => d.Id == id)
                                     .Select(d => d.Specializares).First().ToList();
        }
        
        
    }
}
