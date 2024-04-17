﻿using TaskImpiegati.Models;

namespace TaskImpiegati.Repositories
{
    public class ImpiegatoRepo : IRepository<Impiegato>
    {

        private readonly TaskImpiegatiContext _context;

        public ImpiegatoRepo(TaskImpiegatiContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                Impiegato temp = _context.Impiegatos.Single(p => p.ImpiegatoId == id);
                _context.Impiegatos.Remove(temp);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public List<Impiegato> GetAll()
        {
            return _context.Impiegatos.ToList();
        }

        public Impiegato? GetById(int id)
        {
           Impiegato? tmp = null;
            try
            {
                tmp = _context.Impiegatos.FirstOrDefault(p => p.ImpiegatoId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tmp;
        }

        public bool Insert(Impiegato t)
        {
            try
            {
                _context.Impiegatos.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public bool Update(Impiegato t)
        {
            try
            {
                _context.Update(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }


        public Impiegato? GetByMatricola(string varMatricola)
        {
            Impiegato? tmp = null;
            try
            {
                tmp = _context.Impiegatos.FirstOrDefault(p => p.Matricola == varMatricola);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tmp;
        }
    }
}
