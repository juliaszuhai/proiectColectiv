using PreAcademicInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Services
{
    public class DisciplineService
    {
        DisciplineContext context;

        public DisciplineService(DisciplineContext context)
        {
            this.context = context;
        }

        public List<Discipline> GetDisciplineBySpecializare(string specializare)
        {
            return context.Discipline.Where(d => d.Specializare.Nume == specializare).ToList();
        }
    }
}
