using Examen.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IServiceAdmission:IService<Admission>
    {
        IEnumerable<NomComplet> Occupants(Chambre c, DateTime debut);
        float Recette(Clinique c, int annee);
    }
}
