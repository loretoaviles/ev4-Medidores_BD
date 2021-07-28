using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresDatos.DAL
{
    

    public class EstacionesServiciosDAL
    {
        public MedidoresBDEntities dbEntities = new MedidoresBDEntities();

        public List<estacionServicio> GetAll()
        {
            return dbEntities.estacionServicio.ToList();
        }

        public void Add(estacionServicio e)
        {
            dbEntities.estacionServicio.Add(e);
            dbEntities.SaveChanges(); //Commit
        }
        
        public void Remove(int id)
        {
           estacionServicio e = dbEntities.estacionServicio.Find(id);
            dbEntities.estacionServicio.Remove(e);
            dbEntities.SaveChanges();
        }
        
        public estacionServicio Buscar(int id)
        {
            return dbEntities.estacionServicio.Find(id);
        }

    }
}
