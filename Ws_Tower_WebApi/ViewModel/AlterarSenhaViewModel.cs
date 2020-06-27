using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ws_Tower_WebApi.ViewModel
{
    public class AlterarSenhaViewModel
    {
        [Required(ErrorMessage = "Informe o ID é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Informe o ID é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a senha é obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
