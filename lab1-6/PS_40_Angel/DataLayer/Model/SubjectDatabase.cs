using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Welcome.Model;

namespace DataLayer.Model;

public class SubjectDatabase : Subject
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }
}