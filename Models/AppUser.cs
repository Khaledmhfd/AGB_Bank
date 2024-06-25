using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using static AGB_Bank.Models.NumericOnlyAttribute;

namespace AGB_Bank.Models;

public class AppUser : IdentityUser
{
    [Required]
    public bool IsConfirmed { get; set; }
    public string? mot_passe { get; set; }
    [Required]
    public string? typeClient { get; set; }  
    public int? codePostal { get; set; }
    [Required]
    public string? gl { get; set; }
    [Required]
    public string? Category { get; set; }
    [Required]
    public string? agence { get; set; }
    public int? Revenu { get; set; }

    [Required(ErrorMessage = "La date de naissance est requise.")]
    [DataType(DataType.Date, ErrorMessage = "Veuillez entrer une date valide.")]
    [MinimumAge(18, ErrorMessage = "L'utilisateur doit avoir au moins 18 ans.")]
    public DateTime? dateNaissance { get; set; }

    [StringLength(100)]
    [MaxLength(100)]
    [NoNumbersOrSymbols(ErrorMessage = "Le prénom ne doit pas contenir de chiffres ni de symboles.")]
    public string? FirstName { get; set; }

    [NoNumbersOrSymbols(ErrorMessage = "Le nom ne doit pas contenir de chiffres ni de symboles.")]
    public string? LastName { get; set; }


    public string? Profession { get; set; }
    public string? Objet { get; set; }
    
    public string? Gender { get; set; }
    
    public string? EtatCivil { get; set; }
    
    public string? PaysNaissance { get; set; }
    
    public string? Address { get; set; }

    // professionel
    public string? Documents { get; set; }
    public string? Registre { get; set; }
    public string? ActivitePrincipal { get; set; }

    // entreprise

    public int? Document_number { get; set; }
    public int? chiffre_affaire { get; set; }
    [GreaterThanFive]
    public int? effectif { get; set; }
    public string? nature_juridque { get; set; }
    public string? dénomination_sociale { get; set; }
    

}

// pour vérifier l'age 
public class MinimumAgeAttribute : ValidationAttribute
{
    private readonly int _minimumAge;

    public MinimumAgeAttribute(int minimumAge)
    {
        _minimumAge = minimumAge;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime dateOfBirth)
        {
            var age = DateTime.Today.Year - dateOfBirth.Year;

            if (age < _minimumAge)
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        return ValidationResult.Success;
    }
}

//vérifier firstname et lastname

public class NoNumbersOrSymbolsAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            string stringValue = value.ToString();
            if (!string.IsNullOrWhiteSpace(stringValue))
            {
                // Vérifiez s'il y a des chiffres ou des symboles dans la chaîne
                if (Regex.IsMatch(stringValue, @"[\d\W]"))
                {
                    return new ValidationResult("Le champ ne doit pas contenir de chiffres ni de symboles.");
                }
            }
        }
        return ValidationResult.Success;
    }
}


// numéro de telephone


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

    // revenu condition

    public class IntegerOnlyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (int.TryParse(value.ToString(), out _))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("La valeur doit être un entier.");
                }
            }

            return new ValidationResult("La valeur est requise.");
        }
    }


public class PositiveIntegerAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            if (int.TryParse(value.ToString(), out int result))
            {
                if (result > 0)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Le revenu doit être un entier positif.");
        }

        return new ValidationResult("Le revenu est requis.");
    }

}

    // pour l'effecitf
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