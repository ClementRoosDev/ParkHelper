using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
// ReSharper disable CheckNamespace

namespace ParkHelper.Data
{
    public interface IMoisMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }
    }

    [KnownType(typeof(Mois))]
    [MetadataType(typeof(IMoisMetadata))]
    public partial class Mois
    {
         
    }
}