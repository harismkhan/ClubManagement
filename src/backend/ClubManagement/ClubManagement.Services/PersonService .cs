using ClubManagement.Domain.DomainModels;
using ClubManagement.Domain.RequestModels.CreateModels;
using ClubManagement.Domain.RequestModels.UpdateModels;
using ClubManagement.Domain.ViewModels;
using ClubManagement.Repositories.Interfaces;
using ClubManagement.Services.Interfaces;

namespace ClubManagement.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task Create(PersonCreateModel createModel)
        {
            var person = new Person
            {
                Type = createModel.Type,
                FirstName = createModel.FirstName,
                LastName = createModel.LastName,
                BirthDate = createModel.BirthDate,
                Street = createModel.Street,
                City = createModel.City,
                Zip = createModel.Zip,
            };

            personRepository.Add(person);
            await personRepository.SaveContextChanges();
        }


        public async Task Update(PersonUpdateModel updateModel)
        {
            var personToUpdate = await personRepository.GetAsync(updateModel.Id);

            if (personToUpdate == null)
            {
                throw new ArgumentException();
            }

            personToUpdate.Type = updateModel.Type;
            personToUpdate.FirstName = updateModel.FirstName;
            personToUpdate.LastName = updateModel.LastName;
            personToUpdate.BirthDate = updateModel.BirthDate;
            personToUpdate.City = updateModel.City;
            personToUpdate.Street = updateModel.Street;
            personToUpdate.Zip = updateModel.Zip;

            personRepository.Update(personToUpdate);
            await personRepository.SaveContextChanges();
        }

        public async Task<PersonViewModel?> GetById(Guid id)
        {
            var person = await personRepository.GetAsync(id);

            return person != null ? new PersonViewModel()
            {
                Id = person.Id,
                Type = person.Type,
                FirstName = person.FirstName,
                LastName = person.LastName,
                BirthDate = person.BirthDate,
                Street = person.Street,
                City = person.City,
                Zip = person.Zip,
            } : null;
        }

        public async Task<IEnumerable<PersonViewModel>> GetAll()
        {
            var persons = await personRepository.GetAllAsync();

            var personViewModels = persons.Select(person => new PersonViewModel()
            {
                Id = person.Id,
                Type = person.Type,
                FirstName = person.FirstName,
                LastName = person.LastName,
                BirthDate = person.BirthDate,
                Street = person.Street,
                City = person.City,
                Zip = person.Zip,
            });

            return personViewModels;
        }

        public async Task Delete(Guid id)
        {
            var personToDelete = await personRepository.GetAsync(id);

            if (personToDelete == null)
            {
                throw new ArgumentException();
            }

            personRepository.Remove(personToDelete);
            await personRepository.SaveContextChanges();
        }
    }
}
