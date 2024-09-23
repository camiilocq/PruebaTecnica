using BE_PruebaTecnica.EfCore;

namespace BE_PruebaTecnica.Models
{
    public class EmpresaModel
    {
        public int nit { get; set; } // Llave primaria
        public string Nombre { get; set; }
        public string Direccion { get; set; } = string.Empty; 
        public string Telefono { get; set; } = string.Empty;

       
    }
}
