﻿using System;
using System.Collections.Generic;

namespace Ws_Tower_WebApi.Domains
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Apelido { get; set; }
        public byte[] Foto { get; set; }
        public string Senha { get; set; }
    }
}
