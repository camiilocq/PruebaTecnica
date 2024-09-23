using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_PruebaTecnica.Model;

    public class ProductoModel
    {
  
        public int Codigo { get; set; } 
        public string Nombre { get; set; }
        public string Caracteristicas { get; set; }
        public decimal Precio { get; set; }


    }

