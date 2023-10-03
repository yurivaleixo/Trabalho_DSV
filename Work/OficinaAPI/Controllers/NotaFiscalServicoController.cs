using MinhaAPI.Data;
using MinhaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MinhaAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class NotaFiscalServicoController : ControllerBase
{
    private LockheedDbContext _dbContext;
    public NotaFiscalServicoController(LockheedDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(NotaFiscalServico notafiscalservico)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.NotaFiscalServico is null) return NotFound();
        await _dbContext.AddAsync(notafiscalservico
);
        await _dbContext.SaveChangesAsync();
        return Created("",notafiscalservico
);
    }
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<NotaFiscalServico>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.NotaFiscalServico is null) return NotFound();
        return await _dbContext.NotaFiscalServico.ToListAsync();
    }
    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<NotaFiscalServico>> Buscar(int id)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.NotaFiscalServico is null) return NotFound();
        var notafiscalservicolTemp = await _dbContext.NotaFiscalServico.FindAsync(id);
        if(notafiscalservicolTemp is null) return NotFound();
        return notafiscalservicolTemp;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(NotaFiscalServico notafiscalservico)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.NotaFiscalServico is null) return NotFound();
        //var notafiscalservicolTemp = await _dbContext.NotaFiscalServico.FindAsync(notafiscalservico.NotaFiscalServicoId);
        //if(notafiscalservicolTemp is null) return NotFound();       
        _dbContext.NotaFiscalServico.Update(notafiscalservico
);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch()]
    [Route("mudardescricao/{id}")]
    public async Task<ActionResult> MudarDescricao(int id, [FromForm] string descricao)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.NotaFiscalServico is null) return NotFound();
        var notafiscalservicolTemp = await _dbContext.NotaFiscalServico.FindAsync(descricao);
        if(notafiscalservicolTemp is null) return NotFound();
        notafiscalservicolTemp.Descricao = descricao;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.NotaFiscalServico is null) return NotFound();
        var notafiscalservicolTemp = await _dbContext.NotaFiscalServico.FindAsync(id);
        if(notafiscalservicolTemp is null) return NotFound();
        _dbContext.Remove(notafiscalservicolTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}