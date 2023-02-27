using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Animals_API.Model;

[Table("animals")]
public partial class Animal
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("classification")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Classification { get; set; }

    [Column("locations")]
    [StringLength(260)]
    [Unicode(false)]
    public string? Locations { get; set; }

    [Column("is_endangered")]
    public bool? IsEndangered { get; set; }
}
