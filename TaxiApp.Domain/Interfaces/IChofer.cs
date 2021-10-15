using System;
using System.Collections.Generic;
using System.Text;
using TaxiApp.Domain.Models;

namespace TaxiApp.Domain.Interfaces
{
    public interface IChofer
    {
        void Create(Chofer entity);
        void Delete(Guid ID);
        bool Delete(Chofer entity);
        IList<Chofer> GetAll();
        Chofer GetByID(Guid ID);
        bool Update(Chofer entity);
        bool Disable(Guid ID);

        TurnoTaxi IniciaTurno( Guid ChoferID, Guid TaxiID, DateTime FechaEntrada);

        TurnoTaxi GetTurnoByID(Guid ID);
    }
}
