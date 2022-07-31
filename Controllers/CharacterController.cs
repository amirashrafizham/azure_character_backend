using character_api.Data;
using character_api.DTOs;
using character_api.Interfaces;
using character_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace character_api.Controllers;

[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet("characters")]
    public async Task<ActionResult> GetCharacters()
    {
        var query = await _characterService.GetCharacters();
        return Ok(query);
    }

    [HttpGet("character/{id}")]
    public async Task<ActionResult<Character>> GetSingleCharacter(int id)
    {
        var query = await _characterService.GetSingleCharacter(id);
        if (query is null)
        {
            return NotFound("not found");
        }
        return Ok(query);
    }

    [HttpPost("addcharacter")]
    public async Task<ActionResult<Character>> AddCharacter(AddCharacterDTO add_character)
    {
        var new_character = await _characterService.AddCharacter(add_character);
        return CreatedAtAction("GetSingleCharacter", new { Id = new_character.Id }, new_character);
    }

    [HttpPut("editcharacter")]
    public async Task<ActionResult<Character>> EditCharacter(Character edit_character)
    {
        var query = await _characterService.EditCharacter(edit_character);
        if (query is null)
        {
            return NotFound("not found");
        }
        return Ok(query);
    }

    [HttpDelete("deletecharacter/{id}")]
    public async Task<ActionResult<Character>> DeleteCharacter(int id)
    {
        var query = await _characterService.DeleteCharacter(id);
        if (query is null)
        {
            return NotFound("not found");
        }

        return Ok(query);
    }

}
