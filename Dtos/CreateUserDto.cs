﻿using System.Reflection.Metadata.Ecma335;

namespace SonmezERP.Dtos
{
    public class CreateUserDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
