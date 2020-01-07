using Microsoft.AspNetCore.Mvc;
using gestionEnseignantsWebApp.Models;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace gestionEnseignantsWebApp.Controllers{
    [Route("/api/departements")]
    public class DepartementRestController:Controller{
        public EtablissementDbRepository etablissementRepository{get;set;}

        public DepartementRestController(EtablissementDbRepository repository){
            this.etablissementRepository=repository;
        }
        [HttpGet]
        public IEnumerable <Departement> listDeparts(){
            return etablissementRepository.Departements;
        }
        [HttpGet("{Id}")]
        public Departement getDep(int Id){
            return etablissementRepository.Departements.FirstOrDefault(d=>d.DepartementID==Id);
        }
        [HttpGet("{Id}/enseignants")]
        public IEnumerable <Enseignant> enseignants(int Id){
            Departement departement=etablissementRepository.Departements.Include(d=>d.Enseignants).FirstOrDefault(d=>d.DepartementID==Id);
            return departement.Enseignants;
        }
        [HttpPost]
        public Departement Save([FromBody]Departement departement){
            etablissementRepository.Departements.Add(departement);
            etablissementRepository.SaveChanges();
            return departement;
        }
        [HttpPut("{Id}")]
        public Departement UpDate([FromBody]Departement departement, int Id){
            departement.DepartementID=Id;
            etablissementRepository.Departements.Update(departement);
            etablissementRepository.SaveChanges();
            return departement;
        }
         [HttpDelete("{Id}")]
        public void Delete(int Id){
            Departement departement=etablissementRepository.Departements.FirstOrDefault(d=>d.DepartementID==Id);
            etablissementRepository.Remove(departement);
            etablissementRepository.SaveChanges();
        }
    }
}
