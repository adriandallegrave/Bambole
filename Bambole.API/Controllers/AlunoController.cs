using Bambole.API.Controllers.Base;
using Bambole.Application.Dtos;
using Bambole.Application.Interfaces;
using Bambole.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Bambole.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AlunoController : BaseController
{
    private readonly IAlunoAppService _alunoAppService;
    private readonly ILogger<AlunoController> _logger;

    public AlunoController(ILogger<AlunoController> logger, IAlunoAppService alunoAppService)
    {
        _alunoAppService = alunoAppService;
        _logger = logger;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<Aluno>>> GetAll()
    {
        _logger.LogWarning("Entry at GetAll - Aluno");

        var result = await _alunoAppService.GetAll();

        return ResponseGetAll(result);
    }

    [HttpGet("GetById")]
    public async Task<ActionResult<Aluno>> GetById(Guid id)
    {
        _logger.LogWarning("Entry at GetById - Aluno");

        try
        {
            var result = await _alunoAppService.GetById(id);

            return ResponseGet(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpPost("Post")]
    public async Task<ActionResult<Aluno>> Post(AlunoDto dto)
    {
        _logger.LogWarning("Entry at Post - Aluno");

        try
        {
            var result = await _alunoAppService.Post(dto);

            return ResponsePost(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpPut("Update")]
    public async Task<ActionResult<Aluno>> Update(Guid id, AlunoDto dto)
    {
        _logger.LogWarning("Entry at Update - Aluno");

        try
        {
            if (!await _alunoAppService.Exists(id))
            {
                return ResponseIdNotFound();
            }

            var result = await _alunoAppService.Update(id, dto);

            return ResponseUpdate(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<Aluno>> Delete(Guid id)
    {
        _logger.LogWarning("Entry at Delete - Aluno");

        try
        {
            if (!await _alunoAppService.Exists(id))
            {
                return ResponseIdNotFound();
            }

            var result = await _alunoAppService.Delete(id);

            return ResponseDelete(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }
}
