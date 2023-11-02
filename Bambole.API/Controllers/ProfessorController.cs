using Bambole.API.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bambole.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class ProfessorController : BaseController
{
    private readonly IProfessorAppService _professorAppService;
    private readonly ILogger<AlunoController> _logger;

    public ProfessorController(ILogger<AlunoController> logger, IProfessorAppService professorAppService)
    {
        _professorAppService = professorAppService;
        _logger = logger;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<Professor>>> GetAll()
    {
        _logger.LogWarning("Entry at GetAll - Professor");

        var result = await _professorAppService.GetAll();

        return ResponseGetAll(result);
    }

    [HttpGet("GetById")]
    public async Task<ActionResult<Professor>> GetById(Guid guid)
    {
        _logger.LogWarning("Entry at GetById - Professor");

        try
        {
            var result = await _professorAppService.GetById(guid);

            return ResponseGet(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpPost("Post")]
    public async Task<ActionResult<Professor>> Post(ProfessorDto dto)
    {
        _logger.LogWarning("Entry at Post - Professor");

        try
        {
            var result = await _professorAppService.Post(dto);

            return ResponsePost(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpPut("Update")]
    public async Task<ActionResult<Professor>> Update(Guid id, ProfessorDto dto)
    {
        _logger.LogWarning("Entry at Update - Professor");

        try
        {
            if (!await _professorAppService.Exists(id))
            {
                return ResponseIdNotFound();
            }

            var result = await _professorAppService.Update(id, dto);

            return ResponseUpdate(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<Professor>> Delete(Guid id)
    {
        _logger.LogWarning("Entry at Delete - Professor");

        try
        {
            if (!await _professorAppService.Exists(id))
            {
                return ResponseIdNotFound();
            }

            var result = await _professorAppService.Delete(id);

            return ResponseDelete(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }
}
