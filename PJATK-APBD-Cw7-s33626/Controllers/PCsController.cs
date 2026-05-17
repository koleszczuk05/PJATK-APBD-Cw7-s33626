using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_s33626.DTOs;
using PJATK_APBD_Cw7_s33626.Exceptions;
using PJATK_APBD_Cw7_s33626.Service;

namespace PJATK_APBD_Cw7_s33626.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PCsController(IPCService pcService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await pcService.GetAllAsync(cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var result = await pcService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePCRequest request, CancellationToken cancellationToken)
    {
        var result = await pcService.AddAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdatePCRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await pcService.UpdateAsync(id, request, cancellationToken);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        try
        {
            await pcService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}