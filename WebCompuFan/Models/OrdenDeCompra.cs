using MVCBasico.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCompuFan.Models
{
    public class OrdenDeCompra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Relación con Articulo
        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }

        // Relación con Cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int Cantidad { get; set; }
    }
}
