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
public class TurmaController : BaseController
{
    private readonly ITurmaAppService _turmaAppService;
    private readonly ILogger<AlunoController> _logger;

    public TurmaController(ILogger<AlunoController> logger, ITurmaAppService turmaAppService)
    {
        _turmaAppService = turmaAppService;
        _logger = logger;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<Turma>>> GetAll()
    {
        _logger.LogWarning("Entry at GetAll - Turma");

        var result = await _turmaAppService.GetAll();

        return ResponseGetAll(result);
    }

    [HttpGet("GetById")]
    public async Task<ActionResult<Turma>> GetById(Guid id)
    {
        _logger.LogWarning("Entry at GetById - Turma");

        try
        {
            var result = await _turmaAppService.GetById(id);

            return ResponseGet(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpPost("Post")]
    public async Task<ActionResult<Turma>> Post(TurmaDto dto)
    {
        _logger.LogWarning("Entry at Post - Turma");

        try
        {
            var result = await _turmaAppService.Post(dto);

            return ResponsePost(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpPut("Update")]
    public async Task<ActionResult<Turma>> Update(Guid id, TurmaDto dto)
    {
        _logger.LogWarning("Entry at Update - Turma");

        try
        {
            if (!await _turmaAppService.Exists(id))
            {
                return ResponseIdNotFound();
            }

            var result = await _turmaAppService.Update(id, dto);

            return ResponseUpdate(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<Turma>> Delete(Guid id)
    {
        _logger.LogWarning("Entry at Delete - Turma");

        try
        {
            if (!await _turmaAppService.Exists(id))
            {
                return ResponseIdNotFound();
            }

            var result = await _turmaAppService.Delete(id);

            return ResponseDelete(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }
}
