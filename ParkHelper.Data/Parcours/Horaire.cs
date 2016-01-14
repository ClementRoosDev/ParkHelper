using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

// ReSharper disable CheckNamespace

namespace ParkHelper.Data
{
    public interface IHoraireMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }
    }

    [KnownType(typeof(Horaire))]
    [MetadataType(typeof(IHoraireMetadata))]
    public partial class Horaire
    {
    }
}
