using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

// ReSharper disable CheckNamespace

namespace ParkHelper.Data
{
    public interface IJourMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }
    }

    [KnownType(typeof(Jour))]
    [MetadataType(typeof(IJourMetadata))]
    public partial class Jour
    {
    }
}
