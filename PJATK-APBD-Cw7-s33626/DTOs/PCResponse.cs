namespace PJATK_APBD_Cw7_s33626.DTOs;

public record PCResponse(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);