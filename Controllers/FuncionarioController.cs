using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Data;
using ProjetoAPI.ModelView;
using System.IO.Compression;
using System.Reflection.Metadata;
using System.Xml.Linq;


namespace ProjetoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {


        private ContextoEmpresa db { get; set; }
        public FuncionarioController(ContextoEmpresa db)
        {
            this.db = db;
        }
        [HttpGet]
        [Route("ToList")]
        public IEnumerable<Funcionario> ListarFuncionario()
        {
            return db.Funcionario.ToList();
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult CadastrarFuncionario([FromBody] VFuncionario funci)
        {
            var funcionario = new Funcionario
            {
                Nome = funci.Nome,
                Rg = funci.Rg,
                DepartamentoId = funci.DepartamentoId,

            };
            db.Funcionario.Add(funcionario);
            db.SaveChanges();
            return Ok("Funcionário cadastrado com sucesso!");
        }
        [HttpPut("{id}")]
        [Route("Update")]
        public IActionResult EditarFuncionario(int id, [FromBody] VFuncionario funciatt)
        {
            var Funcionario = db.Funcionario.Find(id);
            if (Funcionario == null)
            {
                return NotFound();
            };

            Funcionario.Nome = funciatt.Nome;
            Funcionario.Rg = funciatt.Rg;
            Funcionario.DepartamentoId = funciatt.DepartamentoId;

            db.Funcionario.Update(Funcionario);
            db.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Route("Remove")]
        public IActionResult DeletarFuncionario(int id)
        {
            var Funcionario = db.Funcionario.Find(id);
            if (Funcionario == null)
            {
                return NotFound();
            }
            db.Funcionario.Remove(Funcionario);
            db.SaveChanges();
            return Ok("Funcionário deletado!");
        }


        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;

                // Criar o caminho completo do arquivo
                var physicalPath = Path.Combine(Funcionario.ContentRootPath, "Photos", filename);

                // Verificar se o diretório existe, se não, criá-lo
                string directory = Path.GetDirectoryName(physicalPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Salvar o arquivo
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }
        [HttpGet]
        [Route("ToListAsync")]
        public async Task<IActionResult> GetAllDepartments()
        {
            return Ok(await db.Departamento.ToListAsync());
        }
    }
}
