using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioBusCrud.Models
{
    class Repository
    {
        private GestioBusEntities db;
        public Repository()
        {
            db = dbConnect();
        }
        public GestioBusEntities dbConnect()
        {
            return new GestioBusEntities();
        }
        public List<Linia> GetLinias()
        {
            List<Linia> ls = new List<Linia>();
            try
            {
                ls = db.Linias
                    .OrderBy(a => a.nom)
                    .ThenBy(a => a.id)
                    .ToList();    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return ls;
        }
        public List<LiniaParadaHora> GetParades(int idLinia)
        {
            List<LiniaParadaHora> lp = new List<LiniaParadaHora>();
            try 
            {
                lp = db.LiniaParadaHoras
                    .Where(o => o.idLinia == idLinia)
                    .OrderBy(o => o.numeroParada)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lp;
        }
        public Linia AddLinia(Linia novaLinia)
        {
            try
            {
                db.Linias.Add(novaLinia);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return novaLinia;
        }
        public Parada AddParada(Parada parada)
        {
            try
            {
                db.Paradas.Add(parada);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return parada;
        }
        public LiniaParadaHora AddLiniaParadaHora(LiniaParadaHora lParHor)
        {
            try
            {
                db.LiniaParadaHoras.Add(lParHor);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return lParHor;
        }

        public Parada GetParada(int idParada)
        {
            Parada parada = null;
            try
            {
                parada = db.Paradas.Find(idParada);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return parada;
        }
        public bool ExisteixPosParada(int idLinia, int pos)
        {            
            try
            {
                var parades = GetParades(idLinia);
                if (parades != null)
                {
                    foreach (var parada in parades)
                    {
                        if (parada.numeroParada == pos)
                            return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        // Esborra una linia en cascada
        public bool DelLinia(int idLinia)
        {
            var lin = db.Linias.Find(idLinia);

            if (lin != null)                
            {
                try
                {   if (lin.Horaris != null)
                        db.Horaris.RemoveRange(lin.Horaris);
                    if (lin.LiniaParadaHoras != null)
                        db.LiniaParadaHoras.RemoveRange(lin.LiniaParadaHoras);
                    if (lin.Transports != null)
                        db.Transports.RemoveRange(lin.Transports);
                    if (lin.Conductors != null)
                        db.Conductors.RemoveRange(lin.Conductors);
                    db.Linias.Remove(lin);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return false;
        }
        //Esborra una parada en cascada
        public bool DelParada(int idParada)
        {
            Parada p = db.Paradas.Find(idParada);
            if (p != null)
            {
                try
                {
                    if (p.Horaris != null)
                        db.Horaris.RemoveRange(p.Horaris);
                    if (p.InteresTuristics != null)
                        db.InteresTuristics.RemoveRange(p.InteresTuristics);
                    if (p.LiniaParadaHoras != null)
                        db.LiniaParadaHoras.RemoveRange(p.LiniaParadaHoras);
                    db.Paradas.Remove(p);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return false;
        }
        //Actualitza el nom i la descripcio d'una Linia.
        public Linia UpdateLiniaNomDesc(int id, string nom, string descripcio)
        {
            // troba l'objecte original a la db:
            Linia lin0 = db.Linias.Find(id); //db.Linias.Where(l => l.id == id).FirstOrDefault();
            try
            {
                if (lin0 != null)
                {
                    //db.Entry(lin0).CurrentValues.SetValues(liniaModificada);                    
                    lin0.nom = nom;
                    lin0.descripcio = descripcio;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
            return lin0;
        }

    }
}
