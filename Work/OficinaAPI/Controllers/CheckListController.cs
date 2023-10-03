using MinhaAPI.Data;
using MinhaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MinhaAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class CheckListController : ControllerBase
{
    private LockheedDbContext _dbContext;
    public CheckListController(LockheedDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(CheckList checklist)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.CheckList is null) return NotFound();
        await _dbContext.AddAsync(checklist);
        await _dbContext.SaveChangesAsync();
        return Created("",checklist);
    }
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<List<CheckList>>> Listar()
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.CheckList is null) return NotFound();
        var resultCheckList = await _dbContext.CheckList
            .Include(sc => sc.Carro)
            .Include(sc => sc.Carro.Cliente)
            .ToListAsync();
        return resultCheckList;
    }
    [HttpGet]
    [Route("buscar/{checklistid}")]
    public async Task<ActionResult<ResponseBuscaCheckListDTO>> Buscar(int checklistid)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.CheckList is null) return NotFound();
        var resultCheckList = await _dbContext.CheckList
            .Include(sc => sc.Carro)
            .Include(sc => sc.Carro.Cliente)
            .Include(sc => sc.NotaFiscalServico)
            .Where(sc => sc.CheckListId == checklistid)
            .ToListAsync();
        var query = "SELECT * FROM Peca p WHERE PecaId IN (SELECT PecaId FROM CheckListPeca cl WHERE CheckListId = "+resultCheckList[0].CheckListId+")";
        List<Peca> resultpeca2 = _dbContext.Peca.FromSqlRaw<Peca>(query).ToList();
        if(resultCheckList is null) return NotFound();
        return new ResponseBuscaCheckListDTO {
            checkList = resultCheckList,
            peca = resultpeca2
        };
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(CheckList checklist)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.CheckList is null) return NotFound();
        //var checklistTemp = await _dbContext.CheckList.FindAsync(checklist.CheckListId);
        //if(checklistTemp is null) return NotFound();       
        _dbContext.CheckList.Update(checklist);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch()]
    [Route("mudardescricao/{checklistid}")]
    public async Task<ActionResult> MudarDescricao(int checklistid, [FromForm] string descricao)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.CheckList is null) return NotFound();
        var checklistTemp = await _dbContext.CheckList.FindAsync(checklistid);
        if(checklistTemp is null) return NotFound();
        checklistTemp.Descricao = descricao;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{checklistid}")]
    public async Task<ActionResult> Excluir(int checklistid)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.CheckList is null) return NotFound();
        var checklistTemp = await _dbContext.CheckList.FindAsync(checklistid);
        if(checklistTemp is null) return NotFound();
        _dbContext.Remove(checklistTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpPost]
    [Route("addPecaChecklist")]
    public async Task<ActionResult> addPecaChecklist(int checkListId, int pecaId, int notaFiscalId)
    {
        if(_dbContext is null) return NotFound();
        if(_dbContext.CheckList is null) return NotFound();
        if(_dbContext.Peca is null) return NotFound();
        if(_dbContext.CheckListPeca is null) return NotFound();
        CheckList check = await _dbContext.CheckList.FindAsync(checkListId);
        if(check is null)return NotFound();
        var cp = new CheckListPeca
            {
                CheckListId = checkListId,
                PecaId = pecaId,
                NotaFiscalPecaId = notaFiscalId
            };
        await _dbContext.AddAsync(cp);
        await _dbContext.SaveChangesAsync();
        return Created("",cp);
    }
}

public class ResponseBuscaCheckListDTO {
    public List<CheckList> checkList { get; set; }
    public List<Peca> peca { get; set; }
}