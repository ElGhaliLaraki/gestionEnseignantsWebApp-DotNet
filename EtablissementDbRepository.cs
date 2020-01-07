using System;
using System.Collections.Generic;
using gestionEnseignantsWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace gestionEnseignantsWebApp
{
    public class EtablissementDbRepository : DbContext
    {
        public DbSet <Departement> Departements { get; set; }
        public DbSet <Enseignant> Enseignants { get; set; }
        public EtablissementDbRepository(DbContextOptions options):base(options){ }
    }  }