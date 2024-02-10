using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class ServiceChambre : Service<Chambre>, IServiceChambre

    {
        public ServiceChambre(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public float PourcentChSimple(Clinique c)
        {
            return (float)GetMany(ch => ch.CliniqueFK == c.CliniqueId 
                                    && ch.TypeChambre == TypeChambre.Simple)
                          .Count()
                          /GetMany(ch => ch.CliniqueFK == c.CliniqueId)
                          .Count() 
                          * 100;
        }
    }
}
