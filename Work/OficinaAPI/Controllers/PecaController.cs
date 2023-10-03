using MinhaAPI.Data;
using MinhaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MinhaAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class PecaController : ControllerBase
{
    private LockheedDbContext _dbContext;
    public PecaController(LockheedDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Peca peca)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Peca is null) return NotFound();
        await _dbContext.AddAsync(peca);
        await _dbContext.SaveChangesAsync();
        return Created("",peca);
    }
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Peca>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Peca is null) return NotFound();
        return await _dbContext.Peca.ToListAsync();
    }
    [HttpGet]
    [Route("buscar/{pecaid}")]
    public async Task<ActionResult<Peca>> Buscar(int pecaid)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Peca is null) return NotFound();
        var pecaTemp = await _dbContext.Peca.FindAsync(pecaid);
        if(pecaTemp is null) return NotFound();
        return pecaTemp;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Peca peca)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Peca is null) return NotFound();
        //var pecaTemp = await _dbContext.Peca.FindAsync(peca.PecaId);
        //if(pecaTemp is null) return NotFound();       
        _dbContext.Peca.Update(peca);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch()]
    [Route("mudardescricao/{pecaid}")]
    public async Task<ActionResult> MudarDescricao(int pecaid, [FromForm] string fornecedor)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Peca is null) return NotFound();
        var pecaTemp = await _dbContext.Peca.FindAsync(pecaid);
        if(pecaTemp is null) return NotFound();
        pecaTemp.Fornecedor = fornecedor;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
        [HttpDelete]
        [Route("excluir/{pecaid}")]
        public async Task<ActionResult> Excluir(int pecaid)
        {
            var peca = await _dbContext.Peca.FindAsync(pecaid);
            if (peca == null)
            {
                return NotFound(); 
            }

            var registrosRelacionados = _dbContext.CheckListPeca.Where(e => e.PecaId == pecaid).ToList();

            if (registrosRelacionados.Any())
            {
                return BadRequest("Esta peça possui registros relacionados e não pode ser excluída.");
            }

            _dbContext.Peca.Remove(peca);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
}