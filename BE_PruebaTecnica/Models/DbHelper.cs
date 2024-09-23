using BE_PruebaTecnica.EfCore;
using BE_PruebaTecnica.Model;

namespace BE_PruebaTecnica.Models
{
    public class DbHelper
    {
        private EF_DataContext _context;

        public DbHelper(EF_DataContext context) { _context = context; }

        public List<ProductoModel> GetProductos()
        {
            List<ProductoModel> response = new List<ProductoModel>();
            var dataList = _context.Productos.ToList();
            dataList.ForEach(row => response.Add(new ProductoModel()
            {
                Codigo = row.Codigo,
                Nombre = row.Nombre,
                Caracteristicas = row.Caracteristicas,
                Precio = row.Precio
            }));
            return response;
        }

        public List<EmpresaModel> GetEmpresas()
        {
            List<EmpresaModel> response = new List<EmpresaModel>();
            var dataList = _context.Empresas.ToList();
            dataList.ForEach(row => response.Add(new EmpresaModel()
            {
                nit = row.nit,
                Nombre = row.Nombre,
                Direccion = row.Direccion,
                Telefono = row.Telefono
            }));
            return response;
        }

        public void SaveEmpresa(EmpresaModel empresaModel)
        {
            Empresa dbTable = new Empresa();
            if(empresaModel.nit > 0)
            {
                dbTable = _context.Empresas.Where(d => d.nit == empresaModel.nit).FirstOrDefault();
                if(dbTable != null)
                {
                    dbTable.Nombre = empresaModel.Nombre;
                    dbTable.Direccion = empresaModel.Direccion;
                    dbTable.Telefono = empresaModel.Telefono;
                }
                else
                {
                    Empresa dbTable2 = new Empresa();
                    dbTable2.Nombre = empresaModel.Nombre;
                    dbTable2.Direccion = empresaModel.Direccion;
                    dbTable2.Telefono = empresaModel.Telefono;
                    _context.Empresas.Add(dbTable2);
                }
                _context.SaveChanges();
            }
        }

        public void SaveProducto(ProductoModel productoModel)
        {
            Producto dbTable = new Producto();
            if (productoModel.Codigo > 0)
            {
                dbTable = _context.Productos.Where(d => d.Codigo == productoModel.Codigo).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.Nombre = productoModel.Nombre;
                    dbTable.Caracteristicas = productoModel.Caracteristicas;
                    dbTable.Precio = productoModel.Precio;
                }
                else
                {
                    dbTable.Nombre = productoModel.Nombre;
                    dbTable.Caracteristicas = productoModel.Caracteristicas;
                    dbTable.Precio = productoModel.Precio;
                    _context.Productos.Add(dbTable);
                }
                _context.SaveChanges();
            }
        }

        public void DeleteEmpresa(int nit)
        {
            var empresa = _context.Empresas.Where(d => d.nit == nit).FirstOrDefault();
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
                _context.SaveChanges();
            }
        }

        public void DeleteProductos(int codigo)
        {
            var producto = _context.Productos.Where(d => d.Codigo == codigo).FirstOrDefault();
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
        }

        public ProductoModel GetProductById(int codigo)
        {
            ProductoModel response = new ProductoModel();
            var row = _context.Productos.Where(d => d.Codigo.Equals(codigo)).FirstOrDefault();
            return new ProductoModel()
            {
                Codigo = row.Codigo,
                Nombre = row.Nombre,
                Caracteristicas = row.Caracteristicas,
                Precio = row.Precio

            };
        }

        public EmpresaModel GetEmpresaById(int nit)
        {
            EmpresaModel response = new EmpresaModel();
            var row = _context.Empresas.Where(d => d.nit.Equals(nit)).FirstOrDefault();
            return new EmpresaModel()
            {
                nit = row.nit,
                Nombre = row.Nombre,
                Direccion = row.Direccion,
                Telefono = row.Telefono

            };
        }
    }
}
