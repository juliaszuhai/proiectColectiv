using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PreAcademicInfo.Models
{
    public enum GradeType { LAB, SEMINAR, EXAMEN, PARTIAL, BONUS, FINAL}
    public class Grade
    {
        [Required, Key]
        public Int32 Id { get; set; }

        [Required]
        public Discipline Discipline { get; set; }

        [Required]
        public Student Student { get; set; }

        [Required]
        public Double GradeValue { get; set; }

        [Required]
        public GradeType Type { get; set; }

        //laboratorul are mai multe note, fiecare cu procentaje diferite.
        // examen final: 1 (adica 100%)
        // lab: 0.1 sau 0.2 etc. (adica 10%, 20%, etc.)
        // seminar: 1
        public Double ProcentInnerType { get; set; }

        //fiecare nota finala este compusa din sum(ProcentOuter * sum( ProcentInnerType * GradeType[i]))
        // examen: 0.6
        // lab: 0.3,..., sau 0 daca nu are lab
        //     nota de laborator se face sum(grade[i].GradeValue * grade[i].ProcentInnerType) unde grade[i].Type == LAB
        // seminar: 0.1 daca are not de seminar, sau 0 daca nu are
        // bonusurile sunt adaugate la nota finala, nu au procent din nota
        public Double ProcentOuter { get; set; }


        //daca e nota de lab se va pune Date.Now ca yyyy.mm.dd
        //nota finala va avea data data din aplicatie
        public String DataNotei { get; set; }

        public Int32 PrezenteLab { get; set; }
        public Int32 PrezenteSeminar { get; set; }

    }
}
