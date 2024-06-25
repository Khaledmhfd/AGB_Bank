using AGB_Bank.Models;
using System.ComponentModel.DataAnnotations;
using static AGB_Bank.Models.NumericOnlyAttribute;

namespace AGB_Bank.ViewModels
{
    public class Register_EntrepriseVM
    {
        [Required]
        public string? typeClient { get; set; }


        [Required(ErrorMessage = "le numéro de téléphone est requis.")]
        [NumericOnly(ErrorMessage = "Le numéro de téléphone ne doit contenir que des chiffres.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "le code postal est requis.")]
        [IntegerOnly(ErrorMessage = "La valeur doit être un entier.")]
        [PositiveInteger]
        public int? codePostal { get; set; }

        [Required(ErrorMessage = "Le revenu est requis.")]
        //[IntegerOnly(ErrorMessage = "La valeur doit être un entier.")]
        [PositiveInteger]
        public int? Revenu { get; set; }

        [Required(ErrorMessage = "La date de naissance est obligatoire.")]
        [DataType(DataType.Date, ErrorMessage = "Veuillez entrer une date valide.")]
        public DateTime dateNaissance { get; set; }

        [Required(ErrorMessage = "le sex est requis.")]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "l'etat civil est requis.")]
        public string? EtatCivil { get; set; }

        [Required(ErrorMessage = "l'agence est requise.")]
        public string? agence { get; set; }

        [Required(ErrorMessage = "l'email est requis.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "le mot de passe est requis.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "le mot de passe ne conrespond pas ")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }


        [Required(ErrorMessage = "l'adresse est requise.")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        public string? Documents { get; set; }
        public string? ActivitePrincipal { get; set; }

        [Required(ErrorMessage = "le GL est requis. ")]
        public string? gl { get; set; }

        [Required(ErrorMessage = "La catégorie de produits souhaitée est requise.")]
        public string? Category { get; set; }

        //[Required]
        [IntegerOnly(ErrorMessage = "La valeur doit être un entier.")]
        [PositiveInteger]
        public int? Document_number { get; set; }
        public int? chiffre_affaire { get; set; }

        [Required(ErrorMessage = "l'effectif est requis. ")]
        [IntegerOnly(ErrorMessage = "La valeur doit être un entier.")]
        [PositiveInteger]
        [GreaterThanFive]
        public int? effectif { get; set; }
        public string? nature_juridque { get; set; }
        public string? dénomination_sociale { get; set; }
    }

    public class GreaterThanFiveAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is int intValue && intValue > 5)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Effectif doit être supérieur à 5.");
        }
    }
}
