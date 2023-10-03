using Microsoft.AspNetCore.Mvc;
using MinhaAPI.Models;
using MinhaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MinhaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class NotaFiscalPecaController : ControllerBase
{
    private LockheedDbContext _dbContext;
    public NotaFiscalPecaController(LockheedDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(NotaFiscalPeca notafiscalpeca)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.NotaFiscalPeca is null) return NotFound();
        await _dbContext.AddAsync(notafiscalpeca);
        await _dbContext.SaveChangesAsync();
        return Created("",notafiscalpeca);
    }
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<NotaFiscalPeca>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.NotaFiscalPeca is null) return NotFound();
        return await _dbContext.NotaFiscalPeca.ToListAsync();
    }
    [HttpGet]
    [Route("buscar/{notafiscalpecaid}")]
    public async Task<ActionResult<NotaFiscalPeca>> Buscar(int notafiscalpecaid)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.NotaFiscalPeca is null) return NotFound();
        var notafiscalpecaTemp = await _dbContext.NotaFiscalPeca.FindAsync(notafiscalpecaid);
        if(notafiscalpecaTemp is null) return NotFound();
        return notafiscalpecaTemp;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(NotaFiscalPeca notafiscalpeca)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.NotaFiscalPeca is null) return NotFound();
        //var notafiscalpecaTemp = await _dbContext.NotaFiscalPeca.FindAsync(notafiscalpeca.NotaFiscaPecalId);
        //if(notafiscalpecaTemp is null) return NotFound();       
        _dbContext.NotaFiscalPeca.Update(notafiscalpeca);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch()]
    [Route("mudardescricao/{notafiscalpecaid}")]
    public async Task<ActionResult> MudarDescricao(int notafiscalpecaid, [FromForm] string descricao)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.NotaFiscalPeca is null) return NotFound();
        var notafiscalpecaTemp = await _dbContext.NotaFiscalPeca.FindAsync(notafiscalpecaid);
        if(notafiscalpecaTemp is null) return NotFound();
        notafiscalpecaTemp.Descricao = descricao;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{notafiscalpecaid}")]
    public async Task<ActionResult> Excluir(int notafiscalpecaid)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.NotaFiscalPeca is null) return NotFound();
        var notafiscalpecaTemp = await _dbContext.NotaFiscalPeca.FindAsync(notafiscalpecaid);
        if(notafiscalpecaTemp is null) return NotFound();
        _dbContext.Remove(notafiscalpecaTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}