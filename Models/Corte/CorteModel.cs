using System;
using System.ComponentModel.DataAnnotations;

namespace ApiSystemsATSM.Models
{
    public class CorteModel
    {
        public int Id { get; set; }
        public string Folio { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public int Usuario { get; set; }
        public bool IsTerminated { get; set; }
    }
}