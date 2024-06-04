using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTOs;

public class UserLoginDTO
{
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;


}
