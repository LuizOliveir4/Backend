﻿using System.ComponentModel.DataAnnotations;

namespace Autentication.Models;

public class SignUpForm
{
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;

    [Required]
    [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[\\W_]).{8,}$", ErrorMessage = "Invalid password")]
    public string Password { get; set; } = null!;
}
