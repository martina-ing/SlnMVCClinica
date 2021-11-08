using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;//AGREGAR


namespace MVCClinica.Data
{
    public class ClinicaDBContext : DbContext
    {
        public ClinicaDBContext(): base ("KeyD"){}
       public DbSet<Medico> Medicos { get; set; }
                    

    }
}