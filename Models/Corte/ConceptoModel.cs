using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSystemsATSM.Models
{
    public class ConceptoModel
    {
        public int Id { get; set; }
        public string Proveedor { get; set; }
        public int Usuario { get; set; }
        public string Concepto { get; set; }
        public string Folio { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public string Factura { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Subtotal { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal IVA { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Total { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal TipoCambio { get; set; }
        public string Moneda { get; set; }
    }
}