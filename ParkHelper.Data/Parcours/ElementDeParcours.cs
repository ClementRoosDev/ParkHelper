using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

// ReSharper disable once CheckNamespace
namespace ParkHelper.Data
{
    public interface IElementDeParcours
    {
        [Required]
        int Duree { get; set; }

        [Required]
        int Ordre { get; set; }

        [Required]
        bool EstDejaDansLeParcours { get; set; }

        [Required]
        Type type { get; }
    }
}
