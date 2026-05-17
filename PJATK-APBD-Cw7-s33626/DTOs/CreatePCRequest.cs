using System.ComponentModel.DataAnnotations;

namespace PJATK_APBD_Cw7_s33626.DTOs;

public record CreatePCRequest(
    [MaxLength(50)] string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);