using System;
using character_api.DTOs;
using character_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace character_api.Interfaces
{
    public interface ICharacterService
    {
        public Task<List<Character>> GetCharacters();

        public Task<Character> GetSingleCharacter(int id);

        public Task<Character> AddCharacter(AddCharacterDTO add_character_dto);

        public Task<Character> EditCharacter(Character edit_character);

        public Task<Character> DeleteCharacter(int id);
    }
}
