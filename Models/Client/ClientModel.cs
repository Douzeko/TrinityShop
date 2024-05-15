using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrinityShop.Models.Client;

public class ClientModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid id_client { get; set; }
    public string document_type { get; set; }
    public string document_number { get; set; }
    public string full_name { get; set; }
    public string born_date { get; set; }
    public bool is_active { get; set; } 
    public DateTime created_at { get; set; }
    public DateTime? update_at { get; set; }
}

