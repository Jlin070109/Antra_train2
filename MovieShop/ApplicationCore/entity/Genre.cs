namespace ApplicationCore.entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table(name:"Genre")]
public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }=string.Empty;
    // Navigation Property
    public ICollection<Movie> Movies { get; set; }
}
