﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserForRegisterDto:IDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirsName { get; set; }

        public string LastName { get; set; }

    }
}
