using AGB_Bank.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using static AGB_Bank.Models.NumericOnlyAttribute;

namespace AGB_Bank.ViewModels
{
    public class Register_ParticulierVM
    {
        
        [Required]
        public string? typeClient { get; set; }
        [Required]
        [StringLength(100)]
        [MaxLength(100)]
        [NoNumbersOrSymbols(ErrorMessage = "Le prénom ne doit pas contenir de chiffres ni de symboles.")]
        public string? FirstName { get; set; }
        [Required]
        [NoNumbersOrSymbols(ErrorMessage = "Le nom ne doit pas contenir de chiffres ni de symboles.")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "La date de naissance est requise.")]
        [DataType(DataType.Date, ErrorMessage = "Veuillez entrer une date valide.")]
        [MinimumAge(18, ErrorMessage = "L'utilisateur doit avoir au moins 18 ans.")]
        public DateTime? dateNaissance { get; set; }
        [Required]
        [NumericOnly(ErrorMessage = "Le numéro de téléphone ne doit contenir que des chiffres.")]
        public string? PhoneNumber { get; set; }
        public string? gl { get; set; }
        [Required]
        public string? agence { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords don't match.")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [Required]
        [IntegerOnly(ErrorMessage = "La valeur doit être un entier.")]
        [PositiveInteger]
        public int? codePostal { get; set; }
        [Required(ErrorMessage = "Le revenu est requis.")]
        [IntegerOnly(ErrorMessage = "La valeur doit être un entier.")]
        [PositiveInteger]
        public int? Revenu { get; set; }

        public string? Profession { get; set; }
        
        public string? Objet { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? EtatCivil { get; set; }
        [Required]
        public string? PaysNaissance { get; set; }

    }

}
