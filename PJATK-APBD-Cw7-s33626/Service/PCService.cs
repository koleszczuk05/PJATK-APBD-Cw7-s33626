using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33626.DTOs;
using PJATK_APBD_Cw7_s33626.Exceptions;
using PJATK_APBD_Cw7_s33626.Infrastructure;
using PJATK_APBD_Cw7_s33626.Models;

namespace PJATK_APBD_Cw7_s33626.Service;

public class PCService(AppDbContext ctx) : IPCService
{
    public async Task<IEnumerable<PCResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await ctx.PCs
            .Select(p => new PCResponse(p.Id, p.Name, p.Weight, p.Warranty, p.CreatedAt, p.Stock))
            .ToListAsync(cancellationToken);
    }

    public async Task<PCDetailsResponse> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.PCs
            .Where(p => p.Id == id)
            .Select(p => new PCDetailsResponse(
                p.Id,
                p.Name,
                p.Weight,
                p.Warranty,
                p.CreatedAt,
                p.Stock,
                p.PCComponents.Select(pc => new PCComponentResponse(
                    pc.Amount,
                    new NestedComponentResponse(
                        pc.Component.Code,
                        pc.Component.Name,
                        pc.Component.Description,
                        new ManufacturerResponse(
                            pc.Component.ComponentManufacturer.Id,
                            pc.Component.ComponentManufacturer.Abbreviation,
                            pc.Component.ComponentManufacturer.FullName,
                            pc.Component.ComponentManufacturer.FoundationDate
                        ),
                        new TypeResponse(
                            pc.Component.ComponentType.Id,
                            pc.Component.ComponentType.Abbreviation,
                            pc.Component.ComponentType.Name
                        )
                    )
                ))
            )).FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException($"PC with id {id} not found");
    }

    public async Task<PCResponse> AddAsync(CreatePCRequest request, CancellationToken cancellationToken)
    {
        var pc = new PC
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };

        ctx.PCs.Add(pc);
        await ctx.SaveChangesAsync(cancellationToken);

        return new PCResponse(pc.Id, pc.Name, pc.Weight, pc.Warranty, pc.CreatedAt, pc.Stock);
    }

    public async Task UpdateAsync(int id, UpdatePCRequest request, CancellationToken cancellationToken)
    {
        int affectedRows = await ctx.PCs
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(p => p.Name, request.Name)
                .SetProperty(p => p.Weight, request.Weight)
                .SetProperty(p => p.Warranty, request.Warranty)
                .SetProperty(p => p.CreatedAt, request.CreatedAt)
                .SetProperty(p => p.Stock, request.Stock),
                cancellationToken
            );

        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        int affectedRows = await ctx.PCs
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync(cancellationToken);

        if (affectedRows == 0)
        {
            throw new NotFoundException($"PC with id {id} not found");
        }
    }
}