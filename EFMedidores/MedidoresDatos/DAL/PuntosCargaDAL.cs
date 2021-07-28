using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresDatos.DAL
{
    public class PuntosCargaDAL
    {
        public MedidoresBDEntities dbEntities = new MedidoresBDEntities();

        public void Add(PuntoCarga p)
        {
            dbEntities.PuntoCarga.Add(p);
            dbEntities.SaveChanges();
        }

        public List<PuntoCarga> GetAll()
        {
            return dbEntities.PuntoCarga.ToList();
        }

        public List<PuntoCarga> GetAll(int tipo)
        {
            //LINQ
            var query = from p in dbEntities.PuntoCarga
                        where p.Tipo == tipo
                        select p;
            return query.ToList();
        }

        public void Update(PuntoCarga p)
        {

            var punto = dbEntities.PuntoCarga.Find(p.IdPuntoCarga);
            punto.Tipo = p.Tipo;
            punto.Capacidad = p.Capacidad;
            punto.Vida = p.Vida;
            punto.estacionServicio = p.estacionServicio;
            dbEntities.SaveChanges();
         

        }

        public PuntoCarga Buscar(int id)
        {
            return dbEntities.PuntoCarga.Find(id);
        }

        public void Remove(int id)
        {
            PuntoCarga p = dbEntities.PuntoCarga.Find(id);
            dbEntities.PuntoCarga.Remove(p);
            dbEntities.SaveChanges();

        }

    }
}
