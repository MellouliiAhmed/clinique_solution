using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Domain
{
    public class Patient
    {
        [Key]
        public string CIN { get; set; }
        public NomComplet NomComplet { get; set; }
        //public string Nom { get; set; }
        //public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public int NumTel { get; set; }
        [EmailAddress]
        public string AdresseEmail { get; set; }
        [Range(0, 9999)]

        public int NumDossier { get; set; }
        public virtual ICollection<Admission> Admissions { get; set; }
    }
}
