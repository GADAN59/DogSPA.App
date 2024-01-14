using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSPA
{
    public class LocalDbService
    {
        private const string DB_NAME = "dogspa_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Pet>();
        }

        public async Task<List<Pet>> GetPets()
        {
            return await _connection.Table<Pet>().ToListAsync();
        }

        public async Task<Pet> GetPetById(int id)
        {
            return await _connection.Table<Pet>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreatePet(Pet pet)
        {
            await _connection.InsertAsync(pet);
        }

        public async Task UpdatePet(Pet pet)
        {
            await _connection.UpdateAsync(pet);
        }

        public async Task DeletePet(Pet pet)
        {
            await _connection.DeleteAsync(pet);
        }
    }
}
