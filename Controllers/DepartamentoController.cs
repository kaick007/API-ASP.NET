using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Data;
using ProjetoAPI.ModelView;

namespace ProjetoAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class DepartamentoController : ControllerBase
{
    private ContextoEmpresa db { get; set; }

    public DepartamentoController(ContextoEmpresa db)
    {
        this.db = db;
    }
    [HttpGet]
    [Route("ToList")]
    public IEnumerable<Departamento> Listar()
    {
        return db.Departamento.ToList();
    }

    [HttpPost]
    [Route("Add")]
    public IActionResult CadastrarDepartamento([FromBody] VDepartamento dpt)
    {
        var departamento = new Departamento
        {

            Nome = dpt.Nome,
            Sigla = dpt.Sigla,

        };
        db.Departamento.Add(departamento);
        db.SaveChanges();
        return Ok("Departamento cadastrado com sucesso!");
    }
    [HttpPut("{id}")]
    [Route("Update")]
    public IActionResult Editar(int id, [FromBody] VDepartamento departamentoatualizado)
    {
        var Departamento = db.Departamento.Find(id);
        if (Departamento == null)
        {
            return NotFound();
        };

        Departamento.Nome = departamentoatualizado.Nome;
        Departamento.Sigla = departamentoatualizado.Sigla;

        db.Departamento.Update(Departamento);
        db.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    [Route("Remove")]
    public IActionResult Deletar(int id)
    {
        var Departamento = db.Departamento.Find(id);
        if (Departamento == null)
        {
            return NotFound();
        }
        db.Departamento.Remove(Departamento);
        db.SaveChanges();
        return Ok("departamento deletado");
    }
    
}