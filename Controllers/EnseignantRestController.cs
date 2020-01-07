using gestionEnseignantsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace gestionEnseignantsWebApp.Controllers{
    [Route("/api/enseignants")]
    public class EnseignantRestController:Controller{
        public EtablissementDbRepository etablissementRepository {get;set;}

        public EnseignantRestController(EtablissementDbRepository repository){
            this.etablissementRepository=repository;
        }

        [HttpGet]
        public IEnumerable <Enseignant> findAll(){
            return etablissementRepository.Enseignants.Include(e=>e.Departement);
        }

        [HttpGet("paginate")]
        public IEnumerable <Enseignant> page(int page=0,int size=2){
            int skipValue=(page-1)*size;
            return etablissementRepository.Enseignants.Include(e=>e.Departement)
            .Skip(skipValue)
            .Take(size);
        }

         [HttpGet("search")]
        public IEnumerable <Enseignant> search(string kw){
            return etablissementRepository.Enseignants.Include(e=>e.Departement)
            .Where(e=>e.Name.Contains(kw));
        }

        [HttpGet("{Id}")]
        public Enseignant getOne(int Id){
            return etablissementRepository.Enseignants.Include(e=>e.Departement).FirstOrDefault(e=>e.EnseignantID==Id);
        }
        [HttpPost]
        public Enseignant Save([FromBody]Enseignant enseignant){
            etablissementRepository.Enseignants.Add(enseignant);
            etablissementRepository.SaveChanges();
            return enseignant;
        }
        [HttpPut("{Id}")]
        public Enseignant UpDate([FromBody]Enseignant enseignant, int Id){
            enseignant.EnseignantID=Id;
            etablissementRepository.Enseignants.Update(enseignant);
            etablissementRepository.SaveChanges();
            return enseignant;
        }
         [HttpDelete("{Id}")]
        public void Delete(int Id){
            Enseignant enseignant=etablissementRepository.Enseignants.FirstOrDefault(e=>e.EnseignantID==Id);
            etablissementRepository.Remove(enseignant);
            etablissementRepository.SaveChanges();
        }
    }
}