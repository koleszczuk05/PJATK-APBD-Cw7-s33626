using PJATK_APBD_Cw7_s33626.DTOs;

namespace PJATK_APBD_Cw7_s33626.Service;

public interface IPCService
{
    Task<IEnumerable<PCResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<PCDetailsResponse> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<PCResponse> AddAsync(CreatePCRequest request, CancellationToken cancellationToken);
    Task UpdateAsync(int id, UpdatePCRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}