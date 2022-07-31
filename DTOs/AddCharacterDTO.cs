using System;

namespace character_api.DTOs
{
    public class AddCharacterDTO
    {
        public string Name { get; set; } = "Amir";
        public int Strength { get; set; } = 10;
        public int Agility { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
    }
}
