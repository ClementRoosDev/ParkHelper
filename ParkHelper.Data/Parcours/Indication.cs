using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

// ReSharper disable CheckNamespace

namespace ParkHelper.Data
{
    public interface IIndicationMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }
    }

    [KnownType(typeof(Indication))]
    [MetadataType(typeof(IIndicationMetadata))]
    public partial class Indication
    {
    }
}
