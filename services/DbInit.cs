using gestionEnseignantsWebApp.Models;
using System;
namespace gestionEnseignantsWebApp.Services{
    public static class DbInit{
        public static void initData(EtablissementDbRepository etablissementDb){
            Console.WriteLine("Data Initialization...");
            etablissementDb.Departements.Add(new Departement{Name="Math-Info"});
            etablissementDb.Departements.Add(new Departement{Name="Electrique"});
            etablissementDb.Enseignants.Add(new Enseignant{Name="Med ElYoussfi", DepartementID=1});
            etablissementDb.Enseignants.Add(new Enseignant{Name="Med Qbado", DepartementID=1});
            etablissementDb.Enseignants.Add(new Enseignant{Name="Abdelwahab Naji", DepartementID=1});
            etablissementDb.Enseignants.Add(new Enseignant{Name="Rafik", DepartementID=2});
            
            etablissementDb.SaveChanges();
        }
    }
}