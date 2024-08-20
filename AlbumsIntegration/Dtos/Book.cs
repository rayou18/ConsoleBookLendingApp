using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumsIntegration.Dtos;
public class Book
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string? Title { get; set; }
}
