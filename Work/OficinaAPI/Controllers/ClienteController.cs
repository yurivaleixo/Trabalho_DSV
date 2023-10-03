using Microsoft.AspNetCore.Mvc;
using MinhaAPI.Models;
using MinhaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MinhaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private LockheedDbContext _dbContext;
    public ClienteController(LockheedDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Cliente cliente)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Cliente is null) return NotFound();
        await _dbContext.AddAsync(cliente);
        await _dbContext.SaveChangesAsync();
        return Created("",cliente);
    }
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Cliente is null) return NotFound();
        return await _dbContext.Cliente.ToListAsync();
    }
    [HttpGet]
    [Route("buscar/{clienteid}")]
    public async Task<ActionResult<Cliente>> Buscar(int clienteid)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Cliente is null) return NotFound();
        var clienteTemp = await _dbContext.Cliente.FindAsync(clienteid);
        if(clienteTemp is null) return NotFound();
        return clienteTemp;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Cliente cliente)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Cliente is null) return NotFound();
        //var clienteTemp = await _dbContext.Cliente.FindAsync(cliente.ClienteId);
        //if(clienteTemp is null) return NotFound();       
        _dbContext.Cliente.Update(cliente);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch()]
    [Route("mudardescricao/{clienteid}")]
    public async Task<ActionResult> MudarDescricao(int clienteid, [FromForm] string nome)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Cliente is null) return NotFound();
        var clienteTemp = await _dbContext.Cliente.FindAsync(clienteid);
        if(clienteTemp is null) return NotFound();
        clienteTemp.Nome = nome;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{clienteid}")]
    public async Task<ActionResult> Excluir(int clienteid)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Cliente is null) return NotFound();
        var clienteTemp = await _dbContext.Cliente.FindAsync(clienteid);
        if(clienteTemp is null) return NotFound();
        _dbContext.Remove(clienteTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}