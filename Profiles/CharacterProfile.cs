using System;
using AutoMapper;
using character_api.DTOs;
using character_api.Models;

namespace character_api.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<AddCharacterDTO, Character>();
            CreateMap<Character, AddCharacterDTO>();
        }
    }
}
