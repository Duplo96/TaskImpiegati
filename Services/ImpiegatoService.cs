using TaskImpiegati.Models;
using TaskImpiegati.Repositories;

namespace TaskImpiegati.Services
{
    public class ImpiegatoService
    {

        private readonly ImpiegatoRepo _repository;

        public ImpiegatoService(ImpiegatoRepo repo)
        {
            _repository = repo;
        }

        public List<Impiegato> ElencoTuttiImpiegati()
        {
            return _repository.GetAll();
        }


        public bool InserisciImpiegato(Impiegato imp)
        {
            return _repository.Insert(imp);
        }

        public Impiegato? RicercaImpiegatoPerMatricola(string varMatricola)
        {
            return _repository.GetByMatricola(varMatricola);
        }
        public bool EliminaImpiegatoPerMatricola(string varMatricola)
        {
            Impiegato? temp = _repository.GetByMatricola(varMatricola);
            if (temp == null)
                return false;

            return _repository.Delete(temp.ImpiegatoId);
        }
    }
}
