using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCompuFan.Models
{
    public class Articulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [EnumDataType(typeof(Categoria))]
        public Categoria Categoria { get; set; }
        [EnumDataType(typeof(Marca))]
        public Marca Marca { get; set; }

        [EnumDataType(typeof(Modelo))]
        public Modelo Modelo { get; set; }
        public string Precio { get; set; }


    }
}
