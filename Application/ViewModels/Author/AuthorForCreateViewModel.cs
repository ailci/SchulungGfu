using Application.ViewModels.Quote;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Validations;
using Microsoft.AspNetCore.Components.Forms;

namespace Application.ViewModels.Author;

public class AuthorForCreateViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Bitte geben Sie einen Namen ein")]
    [Length(2, 150, ErrorMessage = "Name ist zu lang/kurz")]
    [DeniedValues(["root","admin","god"], ErrorMessage = "Der Name ist nicht erlaubt")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Bitte geben Sie eine Beschreibung ein")]
    [MinLength(2, ErrorMessage = "Bitte geben Sie mehr als 2 Zeichen ein")]
    public required string Description { get; set; }

    [NoFutureDate(ErrorMessage = "Das Geburtsdatum liegt in der Zukunft")]
    [DataType(DataType.Date)]
    public DateOnly? BirthDate { get; set; }
    public IBrowserFile? Photo { get; set; }
}