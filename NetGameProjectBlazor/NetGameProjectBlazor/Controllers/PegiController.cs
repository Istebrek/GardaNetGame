using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Controllers;

[ApiController]
[Route("api/pegi")]
public class PegiController : ControllerBase
{
    private readonly IPegiService _pegiService;

    public PegiController(IPegiRepository pegiRepository, IPegiService pegiService)
    {
        _pegiService = pegiService ?? throw new ArgumentNullException(nameof(pegiService));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PegiNameDto>>> GetAllAgeRestrictions()
    {
        var ageRestrictions = await _pegiService.GetAllAgeRestrictionsAsync();
        if (ageRestrictions == null || !ageRestrictions.Any())
        {
            return NotFound();
        }

        return Ok(ageRestrictions);
    }
}
