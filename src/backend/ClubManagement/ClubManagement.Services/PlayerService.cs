using ClubManagement.Domain;
using ClubManagement.Domain.Models;
using ClubManagement.Domain.ViewModels;
using ClubManagement.Repositories.Interfaces;
using ClubManagement.Services.Interfaces;
using ClubManagement.Services.ViewModels;

namespace ClubManagement.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public async Task Create(PlayerCreateModel createModel)
        {
            var player = new Player
            {
                FirstName = createModel.FirstName,
                LastName = createModel.LastName,
                BirthDate = createModel.BirthDate,
                Street = createModel.Street,
                City = createModel.City,
                Zip = createModel.Zip,
                Height = createModel.Height,
                Weight = createModel.Weight,
                PlayerNumber = createModel.PlayerNumber,
                ClubId = createModel.ClubId,
                TeamId = createModel.TeamId,
            };

            playerRepository.Add(player);
            await playerRepository.SaveContextChanges();
        }


        public async Task Update(PlayerUpdateModel updateModel)
        {
            var playerToUpdate = await playerRepository.GetAsync(updateModel.PlayerId);

            if (playerToUpdate == null)
            {
                throw new ArgumentException();
            }

            playerToUpdate.FirstName = updateModel.FirstName;
            playerToUpdate.LastName = updateModel.LastName;
            playerToUpdate.BirthDate = updateModel.BirthDate;
            playerToUpdate.City = updateModel.City;
            playerToUpdate.Street = updateModel.Street;
            playerToUpdate.Zip = updateModel.Zip;
            playerToUpdate.Height = updateModel.Height;
            playerToUpdate.Weight = updateModel.Weight;
            playerToUpdate.PlayerNumber = updateModel.PlayerNumber;
            playerToUpdate.ClubId = updateModel.ClubId;
            playerToUpdate.TeamId = updateModel.TeamId;

            playerRepository.Update(playerToUpdate);
            await playerRepository.SaveContextChanges();
        }

        public async Task<PlayerViewModel?> GetById(Guid id)
        {
            var player = await playerRepository.GetAsync(id);

            return player != null ? new PlayerViewModel()
            {
                PlayerId = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                BirthDate = player.BirthDate,
                Street = player.Street,
                City = player.City,
                Zip = player.Zip,
                Height = player.Height,
                Weight = player.Weight,
                PlayerNumber = player.PlayerNumber,
                ClubId = player.Id,
                TeamId = player.Id,
            } : null;
        }

        public async Task<IEnumerable<PlayerViewModel>> GetAll()
        {
            var players = await playerRepository.GetAllAsync();

            var playerViewModels = players.Select(player => new PlayerViewModel()
            {
                PlayerId = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                BirthDate = player.BirthDate,
                Street = player.Street,
                City = player.City,
                Zip = player.Zip,
                Height = player.Height,
                Weight = player.Weight,
                PlayerNumber = player.PlayerNumber,
                ClubId = player.Id,
                TeamId = player.Id,
            });

            return playerViewModels;
        }

        public async Task Delete(Guid id)
        {
            var playerToDelete = await playerRepository.GetAsync(id);

            if (playerToDelete == null)
            {
                throw new ArgumentException();
            }

            playerRepository.Remove(playerToDelete);
            await playerRepository.SaveContextChanges();
        }


    }
}
