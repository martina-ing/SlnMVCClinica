using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MVCClinica.Data
{
    public static class AdminMedico
    {
        private static ClinicaDBContext context = new ClinicaDBContext();

        public static List<Medico> Listar()  //Modelo conectado
        {
            return context.Medicos.ToList();
        }

        public static List<string> ListarSoloEspecialidades()
        {
            var esps = context.Medicos.Select(m => m.Especialidad).Distinct();
            return esps.ToList();
        }
       
        public static List<Medico> ListarPorEspecialidad(string especialidad)
        {
            List<Medico> medicosEspecialidad = (from o in context.Medicos
                                                where o.Especialidad == especialidad
                                                select o).ToList();
            return medicosEspecialidad;
        }

        internal static void Insertar(Medico medico)
        {
            context.Medicos.Add(medico);
            context.SaveChanges();
        }

        internal static Medico GetPorId(int id)
        {
            Medico medico = context.Medicos.Find(id);
            context.Entry(medico).State = EntityState.Detached;
            return medico;
        }

        internal static void Modificar(Medico medico)
        {
            context.Medicos.Attach(medico);
            context.SaveChanges();
        }

        internal static void Eliminar(int id)
        {
            Medico medico = context.Medicos.Find(id);
            context.Medicos.Remove(medico);
            context.SaveChanges();
        }
    }
}
