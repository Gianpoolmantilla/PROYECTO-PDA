using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAdministracion.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {

        }
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Carrera> Carrera { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<AsignacionDeCursos> AsignacionDeCursos { get; set; }
        public DbSet<ItemsAsignacionDeCursos> ItemsAsignacionDeCursos { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Turno> Turno { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Alumno>().HasData(
                new Alumno
                {
                    Id = 1,
                    Nombre = "Jose",
                    Apellido = "Hernandez",
                    FechaDeNacimiento = DateTime.Parse("1995-04-05"),
                    Sexo = "Masculino",
                    FechaDeIngreso = DateTime.Parse("2019-03-04"),
                    CarreraId = 1,
                    Dni = "12345679",
                    Domicilio = ""
                },
                new Alumno
                {
                    Id = 2,
                    Nombre = "carlos",
                    Apellido = "sanchez",
                    FechaDeNacimiento = DateTime.Parse("1974-11-01"),
                    Sexo = "Masculino",
                    FechaDeIngreso = DateTime.Parse("2020-11-27"),
                    CarreraId = 1,
                    Dni = "12345679",
                    Domicilio = "av.flores 2458"
                },
                new Alumno
                {
                    Id = 3,
                    Nombre = "eduardo",
                    Apellido = "montes",
                    FechaDeNacimiento = DateTime.Parse("1984-04-25"),
                    Sexo = "Masculino",
                    FechaDeIngreso = DateTime.Parse("2021-03-15"),
                    CarreraId = 3,
                    Dni = "12345679",
                    Domicilio = "calle false 123"
                }
                );

            modelBuilder.Entity<Profesor>().HasData(
              new Profesor { Id = 1, Nombre = "juan", Apellido = "perez", FechaDeNacimiento = DateTime.Parse("1999-06-01"), Dni = "98765432", Sexo = "Masculino" },
              new Profesor { Id = 2, Nombre = "martin", Apellido = "castro", FechaDeNacimiento = DateTime.Parse("1986-06-01"), Dni = "5452155", Sexo = "Masculino"},
              new Profesor { Id = 3, Nombre = "juanmanuel", Apellido = "romero", FechaDeNacimiento = DateTime.Parse("1972-06-01"), Dni = "6584255", Sexo = "Masculino" },
              new Profesor { Id = 4, Nombre = "manuel", Apellido = "benitez", FechaDeNacimiento = DateTime.Parse("1990-06-01"), Dni = "58766512", Sexo = "Masculino" }


              );

            modelBuilder.Entity<Carrera>().HasData(
               new Carrera { Id = 1, Nombre = "Ingenieria en sistemas" },
               new Carrera { Id = 2, Nombre = "arquitectura" },
               new Carrera { Id = 3, Nombre = "analista de sistemas" },
               new Carrera { Id = 4, Nombre = "contador" },
               new Carrera { Id = 5, Nombre = "abogado" }
               );

            modelBuilder.Entity<Turno>().HasData(
               new Turno { Id = 1, Descripcion = "mañana" },
               new Turno { Id = 2, Descripcion = "tarde" },
               new Turno { Id = 3, Descripcion = "noche" }
               );


            modelBuilder.Entity<Curso>().HasData(
            new Curso { Id = 1, Nombre = "Matematica" },
            new Curso { Id = 2, Nombre = "ingles" },
            new Curso { Id = 3, Nombre = "fisica" },
            new Curso { Id = 4, Nombre = "Programacion" },
             new Curso { Id = 5, Nombre = "comunicacion y redes" }
            );

            modelBuilder.Entity<AsignacionDeCursos>().HasData(
             new AsignacionDeCursos { Id = 1, CursoId = 1, Anio = "2021", Semestre = 1, TurnoId = 1, ProfesorId = 1 },
             new AsignacionDeCursos { Id = 2, CursoId = 2, Anio = "2021", Semestre = 2, TurnoId = 2, ProfesorId = 2 },
             new AsignacionDeCursos { Id = 3, CursoId = 4, Anio = "2021", Semestre = 1, TurnoId = 3, ProfesorId = 3 }
             );
            modelBuilder.Entity<ItemsAsignacionDeCursos>().HasData(
            new ItemsAsignacionDeCursos { Id = 1, AsignacionDeCursosId = 1, AlumnoId = 1 },
            new ItemsAsignacionDeCursos { Id = 2, AsignacionDeCursosId = 1, AlumnoId = 2 },
            new ItemsAsignacionDeCursos { Id = 3, AsignacionDeCursosId = 1, AlumnoId = 3 },

            new ItemsAsignacionDeCursos { Id = 4, AsignacionDeCursosId = 2, AlumnoId = 1 },
            new ItemsAsignacionDeCursos { Id = 5, AsignacionDeCursosId = 2, AlumnoId = 2 },

            new ItemsAsignacionDeCursos { Id = 6, AsignacionDeCursosId = 3, AlumnoId = 1 }

            );

        }



    }
}
