using System;
using System.Collections.Generic;

namespace NetGameProjectBlazor.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Phonenumber { get; set; }

    public string? Address { get; set; }

    public DateTime? RegistrationDate { get; set; }
}
