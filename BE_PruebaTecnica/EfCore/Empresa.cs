using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_PruebaTecnica.EfCore
{
    [Table("tb_empresa")]
    public class Empresa
    {
        [Key, Required]
        public int nit { get; set; } // Llave primaria
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual Producto productos { get; set; }
    }
}
