namespace PJATK_APBD_Cw7_s33626.DTOs;

public record NestedComponentResponse(
    string Code,
    string Name,
    string Description,
    ManufacturerResponse Manufacturer,
    TypeResponse Type
);