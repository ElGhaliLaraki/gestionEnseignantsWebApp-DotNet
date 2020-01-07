using System.Collections.Generic;
using System.Linq;
using gestionEnseignantsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace gestionEnseignantsWebApp.Controllers{

    public class EnseignantsController:Controller{
        public EtablissementDbRepository etablissementRepository {get;set;}
        public EnseignantsController(EtablissementDbRepository repository){
            this.etablissementRepository=repository;
        }
        public IActionResult Enseignants(){
            IEnumerable <Enseignant> ens=etablissementRepository.Enseignants.Include(e=>e.Departement);
            return View(ens);   
        }

        public IActionResult FormEnseignant(){
            Enseignant enseignant = new Enseignant();
            return View(enseignant);

        }

        public IActionResult Save(Enseignant enseignant){    
            if(ModelState.IsValid){
                etablissementRepository.Enseignants.Add(enseignant);
                etablissementRepository.SaveChanges();
                return RedirectToAction("Enseignants",enseignant);
            }
            return View("FormEnseignant",enseignant);
        }

        public IActionResult search(string kw){
            if(kw==null){
                ModelState.AddModelError("kw","ne doit pas etre nul");
            }
            if(ModelState.IsValid){
            IEnumerable <Enseignant> enseignant=etablissementRepository.Enseignants.Include(e=>e.Departement)
            .Where(e=>e.Name.Contains(kw));
            return View("Enseignants",enseignant);
            }
            IEnumerable <Enseignant> allEns=etablissementRepository.Enseignants.Include(e=>e.Departement);
            return View("Enseignants",allEns);
        }

        public IActionResult Edit(int Id){
            Enseignant enseignant=etablissementRepository.Enseignants.Include(e=>e.Departement).FirstOrDefault(e=>e.EnseignantID==Id);
            return View(enseignant);

        }
        public IActionResult UpDate(Enseignant enseignant, int Id){
            if(ModelState.IsValid){
            etablissementRepository.Enseignants.Update(enseignant);
            etablissementRepository.SaveChanges();
            return RedirectToAction("Enseignants");
            }
            return View("Edit",enseignant);
        }
        
        public IActionResult Delete(int Id){
            Enseignant enseignant=etablissementRepository.Enseignants.FirstOrDefault(e=>e.EnseignantID==Id);
            etablissementRepository.Remove(enseignant);
            etablissementRepository.SaveChanges();
            return RedirectToAction("Enseignants");
        }
        

    }
}