using System.ComponentModel.DataAnnotations;

namespace FADY.Services.IdentityServer.API.Models.AccountViewModels
{
    public record ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; init; }
    }
}
