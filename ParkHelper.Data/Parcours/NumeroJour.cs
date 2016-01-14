using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

// ReSharper disable CheckNamespace

namespace ParkHelper.Data
{
    public interface INumeroJourMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }
    }

    [KnownType(typeof(NumeroJour))]
    [MetadataType(typeof(INumeroJourMetadata))]
    public partial class NumeroJour
    {
    }
}
