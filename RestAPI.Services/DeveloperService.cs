using RestAPI.Dapper;
using RestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Services
{
    public class DeveloperService : IDeveloperService
    {
        protected readonly IDeveloperRepository _developoerRepository;
        public DeveloperService(IDeveloperRepository developoerRepository)
        {
            _developoerRepository = developoerRepository;
        }

        public void AddDeveloper(Developer developer)
        {
            _developoerRepository.AddDeveloper(developer);
        }

        public void DeleteDeveloper(int Id)
        {
            _developoerRepository.DeleteDeveloper(Id);
        }

        public Task<IEnumerable<Developer>> GetAllDevelopers()
        {
            return _developoerRepository.GetAllDevelopersAsync();
        }

        public Task<Developer> GetDeveloperByEmail(string Email)
        {
            return _developoerRepository.GetDeveloperByEmailAsync(Email);
        }

        public Task<Developer> GetDeveloperById(int Id)
        {
            return _developoerRepository.GetDeveloperByIdAsync(Id);
        }

        public void UpdateDeveloper(Developer developer)
        {
            _developoerRepository.UpdateDeveloper(developer);
        }
    }
}
