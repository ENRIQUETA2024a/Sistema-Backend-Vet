﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Clients
{
    public class ClientListRequestDto
    {
        public int index { get; set; }
        public int limit { get; set; } = 5;
    }
}
