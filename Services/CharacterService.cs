using System;
using AutoMapper;
using character_api.Data;
using character_api.DTOs;
using character_api.Interfaces;
using character_api.Models;
using Microsoft.EntityFrameworkCore;

namespace character_api.Services
{
    public class CharacterService : ICharacterService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _dbContext;

        public CharacterService(IMapper mapper, DataContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<List<Character>> GetCharacters()
        {
            var query = await _dbContext.Characters.OrderBy(x => x.Id).ToListAsync();
            return query;
        }

        public async Task<Character> GetSingleCharacter(int id)
        {
            var query = await _dbContext.Characters.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (query is null)
            {
                return null;
            }
            return query;
        }
        public async Task<Character> AddCharacter(AddCharacterDTO add_character_dto)
        {
            Character add_character = _mapper.Map<AddCharacterDTO, Character>(add_character_dto);

            Character new_character = new Character();
            new_character = add_character;
            _dbContext.Characters.Add(new_character);
            await _dbContext.SaveChangesAsync();
            return new_character;
        }
        public async Task<Character> EditCharacter(Character edit_character)
        {

            var query = await _dbContext.Characters.Where(x => x.Id == edit_character.Id).FirstOrDefaultAsync();
            if (query is null)
            {
                return null;
            }
            query.Name = edit_character.Name;
            query.Strength = edit_character.Strength;
            query.Agility = edit_character.Agility;
            query.Intelligence = edit_character.Intelligence;
            await _dbContext.SaveChangesAsync();
            return query;
        }

        public async Task<Character> DeleteCharacter(int id)
        {
            var query = await _dbContext.Characters.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (query is null)
            {
                return null;
            }
            _dbContext.Characters.Remove(query);
            await _dbContext.SaveChangesAsync();
            return query;
        }


    }
}
