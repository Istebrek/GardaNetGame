using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Controllers;
[ApiController]
[Route("api/physicalProducts")]
public class PhysicalProductController : ControllerBase
{
    private readonly IPhysicalProductService _physicalProductService;

    public PhysicalProductController(IPhysicalProductService physicalProductService)
    {
        _physicalProductService = physicalProductService
            ?? throw new ArgumentNullException(nameof(physicalProductService));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PhysicalProductDto>>> GetAllPhysicalProductAsync()
    {
        var products = await _physicalProductService.GetAllPhysicalProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PhysicalProductDto>> GetPhysicalProductAsync(int id)
    {
        var product = await _physicalProductService.GetPhysicalProducAsync(id);
        if (product == null) return NotFound($"No product was found by the Id {id}");
        return Ok(product);
    }

    [HttpDelete]
    public async Task<ActionResult> DeletePhysicalProductAsync(PhysicalProductDto physicalProductDto)
    {
        var p = await _physicalProductService.DeletePhysicalProductAsync(physicalProductDto);
        return p == null ? NotFound() : Ok(p);
    }

    [HttpPost]
    public async Task<ActionResult> NewPhysicalProductAsync(PhysicalProductDto physicalProductDto)
    {
        await _physicalProductService.NewPhysicalProductAsync(physicalProductDto);
        return Ok();
    }

    [HttpPut("{productDto}")]
    public async Task<ActionResult> UpdatePhysicalProductAsync(PhysicalProductDto physicalProductDto)
    {
        var p = await _physicalProductService.UpdatePhycialProductAsync(physicalProductDto);
        return p == null ? NotFound() : Ok();
    }
}
