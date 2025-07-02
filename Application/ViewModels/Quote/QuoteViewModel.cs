using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Quote;

public class QuoteViewModel
{
    public Guid Id { get; set; }
    public required string QuoteText { get; set; }
    public string? AuthorName { get; set; }
}