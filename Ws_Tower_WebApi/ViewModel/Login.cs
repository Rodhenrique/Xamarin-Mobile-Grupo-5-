using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ws_Tower_WebApi.ViewModel
{
    public class Login
    {
        [Required(ErrorMessage = "Informe o e-mail é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha é obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
