using BE_PruebaTecnica.EfCore;
using BE_PruebaTecnica.Model;
using BE_PruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {

        private readonly DbHelper _db;
        public EmpresaController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext); 
        }

        // GET
        [HttpGet]
        [Route("api/[controller]/GetEmpresas")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<EmpresaModel> data = _db.GetEmpresas();
                
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET by Codigo
        [HttpGet]
        [Route("api/[controller]/GetEmpresaById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                EmpresaModel data = _db.GetEmpresaById(id);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost]
        [Route("api/[controller]/GuardarEmpresa")]
        public IActionResult Post([FromBody] EmpresaModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveEmpresa(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT 
        [HttpPut]
        [Route("api/[controller]/UpdateEmpresa")]
        public IActionResult Put([FromBody] EmpresaModel model)
        {

            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveEmpresa(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE 
        [HttpDelete]
        [Route("api/[controller]/DeleteEmpresa/{id}")]
        public IActionResult DeleteEmpresa(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteEmpresa(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
