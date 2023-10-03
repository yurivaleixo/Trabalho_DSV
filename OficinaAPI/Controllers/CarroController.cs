using Microsoft.AspNetCore.Mvc;
using MinhaAPI.Models;
using MinhaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MinhaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CarroController : ControllerBase
{
    private LockheedDbContext _dbContext;
    public CarroController(LockheedDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Carro carro)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Carro is null) return NotFound();
        await _dbContext.AddAsync(carro);
        await _dbContext.SaveChangesAsync();
        return Created("",carro);
    }
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Carro>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Carro is null) return NotFound();
        return await _dbContext.Carro.ToListAsync();
    }
    [HttpGet]
    [Route("buscar/{carroid}")]
    public async Task<ActionResult<Carro>> Buscar(int carroid)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Carro is null) return NotFound();
        var carroTemp = await _dbContext.Carro.FindAsync(carroid);
        if(carroTemp is null) return NotFound();
        return carroTemp;
    }
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Carro carro)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Carro is null) return NotFound();
        //var carroTemp = await _dbContext.Carro.FindAsync(carro.CarroId);
        //if(carroTemp is null) return NotFound();       
        _dbContext.Carro.Update(carro);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch()]
    [Route("mudardescricao/{carroid}")]
    public async Task<ActionResult> MudarDescricao(int carroid, [FromForm] string modelo)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Carro is null) return NotFound();
        var carroTemp = await _dbContext.Carro.FindAsync(carroid);
        if(carroTemp is null) return NotFound();
        carroTemp.Modelo = modelo;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{carroid}")]
    public async Task<ActionResult> Excluir(int carroid)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.Carro is null) return NotFound();
        var carroTemp = await _dbContext.Carro.FindAsync(carroid);
        if(carroTemp is null) return NotFound();
        _dbContext.Remove(carroTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}