using AutoMapper;
using FilmAPI.Data;
using FilmAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Services.Character
{
    public class CharacterService: ICharacterService
    {
        private readonly FilmDbContext _context;
        //private readonly ICrudService<Data.Models.Character, int> _crudService;
        
        public CharacterService(FilmDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Data.Models.Character>> GetAllAsync()
        {
            // not sure if there should be an excpetion here since the db is already
            // seeded with sample data.
            return await _context.Characters.ToListAsync();
        }
        public async Task<Data.Models.Character> GetByIdAsync(int id)
        {
            // can prob add some excpetion here (null check, as the ide cries about it)
            return await _context.Characters.FindAsync(id);
        }
        public async Task<Data.Models.Character> AddAsync(Data.Models.Character character)
        {
            // cana add/throw exception here for not being able to add an already-existing
            // character.
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }
        public async Task<Data.Models.Character> UpdateAsync(Data.Models.Character character)
        {
            // will need try/catch here
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return character;

        }
        public async Task<Data.Models.Character> DeleteAsync(int id)
        {
            // Likely have to add try/catch here for triying to delete non existant character
            Data.Models.Character character = await _context.Characters.FindAsync(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
            }
            return character;
        }

    }
}
