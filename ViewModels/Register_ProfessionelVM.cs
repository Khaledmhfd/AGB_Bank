using AGB_Bank.Models;
using System.ComponentModel.DataAnnotations;
using static AGB_Bank.Models.NumericOnlyAttribute;

namespace AGB_Bank.ViewModels
{
    public class Register_ProfessionelVM
    {
        string errorMessage = "ce champ est requis.";

        [Required(ErrorMessage = "le nom est requis.")]
        [StringLength(100)]
        [MaxLength(100)]
        [NoNumbersOrSymbols(ErrorMessage = "Le prénom ne doit pas contenir de chiffres ni de symboles.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "le prénom est requis.")]
        [NoNumbersOrSymbols(ErrorMessage = "Le nom ne doit pas contenir de chiffres ni de symboles.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "La date de naissance est requise.")]
        [DataType(DataType.Date, ErrorMessage = "Veuillez entrer une date valide.")]
        [MinimumAge(18, ErrorMessage = "L'utilisateur doit avoir au moins 18 ans.")]
        public DateTime? dateNaissance { get; set; }

        [Required(ErrorMessage = "le numéro de téléphone est requis.")]
        [NumericOnly(ErrorMessage = "Le numéro de téléphone ne doit contenir que des chiffres.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "ce champ est requis.")]
        public string? typeClient { get; set; }

        [Required(ErrorMessage = "le GL est requis.")]
        public string? gl { get; set; }

        [Required(ErrorMessage = "La catégorie de produits souhaitée est requise.")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "l'agence est requise.")]
        public string? agence { get; set; }

        [Required(ErrorMessage = "l'email est requis.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "le mot de passe est requis.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "le mot de passe ne conrespond pas. ")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "l'adresse est requise.")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [Required(ErrorMessage = "le code postal est requis.")]
        [IntegerOnly(ErrorMessage = "La valeur doit être un entier.")]
        [PositiveInteger]
        public int? codePostal { get; set; }

        [Required(ErrorMessage = "Le revenu est requis.")]
        //[IntegerOnly(ErrorMessage = "La valeur doit être un entier.")]
        [PositiveInteger]
        public int? Revenu { get; set; }
        public string? Profession { get; set; }

        [Required(ErrorMessage = "le sex est requis.")]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "l'etat civil est requis.")]
        public string? EtatCivil { get; set; }

        [Required(ErrorMessage = "le pays de naissance est requis.")]
        [NoNumbersOrSymbols(ErrorMessage = "Le nom ne doit pas contenir de chiffres ni de symboles.")]
        public string? PaysNaissance { get; set; }      
        public string? Documents { get; set; }
        
        public string? Registre { get; set; }
        
        public string? ActivitePrincipal { get; set; }
    }
// phone number verification

public class NumericOnlyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string stringValue = value.ToString();
                if (!string.IsNullOrWhiteSpace(stringValue))
                {
                    // Vérifiez s'il y a des caractères autres que des chiffres
                    if (!int.TryParse(stringValue, out _))
                    {
                        return new ValidationResult("Le numéro de téléphone ne doit contenir que des chiffres.");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }

}
