using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s33626.Models;

[Table("Components")]
public class Component
{
    [Key]
    [MaxLength(10)]
    [Column(TypeName = "char(10)")]
    public string Code { get; set; } = string.Empty;

    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int ComponentManufacturersId { get; set; }
    
    [ForeignKey(nameof(ComponentManufacturersId))]
    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;

    public int ComponentTypesId { get; set; }
    
    [ForeignKey(nameof(ComponentTypesId))]
    public ComponentType ComponentType { get; set; } = null!;

    public IEnumerable<PCComponent> PCComponents { get; set; } = [];
}