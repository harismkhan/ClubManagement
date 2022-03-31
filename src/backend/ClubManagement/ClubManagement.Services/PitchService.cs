using ClubManagement.Domain;
using ClubManagement.Domain.Models;
using ClubManagement.Domain.ViewModels;
using ClubManagement.Repositories.Interfaces;
using ClubManagement.Services.Interfaces;

namespace ClubManagement.Services
{
    public class PitchService : IPitchService
    {
        private readonly IPitchRepository pitchRepository;

        public PitchService(IPitchRepository pitchRepository)
        {
            this.pitchRepository = pitchRepository;
        }

        public async Task Create(PitchCreateModel createModel)
        {
            var pitch = new Pitch
            {
                Street = createModel.Street,
                City = createModel.City,
                Zip = createModel.Zip,
                ClubId = createModel.ClubId,
            };

            pitchRepository.Add(pitch);
            await pitchRepository.SaveContextChanges();
        }

        public async Task Update(PitchUpdateModel updateModel)
        {
            var pitchToUpdate = await pitchRepository.GetAsync(updateModel.Id);

            if (pitchToUpdate == null)
            {
                throw new ArgumentException();
            }
            pitchToUpdate.Street = updateModel.Street;
            pitchToUpdate.City = updateModel.City;
            pitchToUpdate.Zip = updateModel.Zip;
            pitchToUpdate.ClubId = updateModel.ClubId;

            pitchRepository.Update(pitchToUpdate);
            await pitchRepository.SaveContextChanges();
        }

        public async Task<PitchViewModel?> GetById(Guid id)
        {
            var pitch = await pitchRepository.GetAsync(id);

            return pitch != null ? new PitchViewModel()
            {
                Id = pitch.Id,
                Street = pitch.Street,
                City = pitch.City,
                Zip = pitch.Zip,
                ClubId = pitch.ClubId,
            } : null;
        }

        public async Task<IEnumerable<PitchViewModel>> GetAll()
        {
            var pitches = await pitchRepository.GetAllAsync();

            var pitchViewModels = pitches.Select(pitch => new PitchViewModel()
            {
                Id = pitch.Id,
                Street = pitch.Street,
                City = pitch.City,
                Zip = pitch.Zip,
                ClubId = pitch.ClubId,
            });

            return pitchViewModels;
        }

        public async Task Delete(Guid id)
        {
            var pitchToDelete = await pitchRepository.GetAsync(id);

            if (pitchToDelete == null)
            {
                throw new ArgumentException();
            }

            pitchRepository.Remove(pitchToDelete);
            await pitchRepository.SaveContextChanges();
        }

    }
}
