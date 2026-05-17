using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PJATK_APBD_Cw7_s33626.Models;

[Table("PCComponents"), PrimaryKey(nameof(PCid), nameof(ComponentCode))]
public class PCComponent
{
    public int PCid { get; set; }
    
    [ForeignKey(nameof(PCid))]
    public PC PC { get; set; } = null!;

    [MaxLength(10)]
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } = string.Empty;
    
    [ForeignKey(nameof(ComponentCode))]
    public Component Component { get; set; } = null!;

    public int Amount { get; set; }
}