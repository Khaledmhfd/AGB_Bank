using AGB_Bank.Models;
using System.ComponentModel.DataAnnotations;
using static AGB_Bank.Models.NumericOnlyAttribute;

namespace AGB_Bank.ViewModels
{
    public class Register_EntrepriseVM
    {


        [Required]
        [NumericOnly(ErrorMessage = "Le numéro de téléphone ne doit contenir que des chiffres.")]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? typeClient { get; set; }
        [Required]
        [IntegerOnly(ErrorMessage = "La valeur doit être un entier.")]
        [PositiveInteger]
        public int? codePostal { get; set; }
        [Required(ErrorMessage = "Le revenu est requis.")]
        [IntegerOnly(ErrorMessage = "La valeur doit être un entier.")]
        [PositiveInteger]
        public int? Revenu { get; set; }

        [Required(ErrorMessage = "La date de naissance est obligatoire.")]
        [DataType(DataType.Date, ErrorMessage = "Veuillez entrer une date valide.")]
        public DateTime dateNaissance { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? EtatCivil { get; set; }

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

        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }


        
        public string? Documents { get; set; }
        
        
        public string? ActivitePrincipal { get; set; }
        public string? gl { get; set; }

        public int? Document_number { get; set; }
        public int? chiffre_affaire { get; set; }
        public int? effectif { get; set; }
        public string? nature_juridque { get; set; }
        public string? dénomination_sociale { get; set; }
    }
}
