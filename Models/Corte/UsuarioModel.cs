using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ApiSystemsATSM.Data;

namespace ApiSystemsATSM.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 10)]
        public string Nombre { get; set; }

        [EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
        
    }
}