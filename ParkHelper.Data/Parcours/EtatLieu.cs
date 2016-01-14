using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
// ReSharper disable CheckNamespace

namespace ParkHelper.Data
{
    public interface IEtatLieuMetadata
    {
        [Key]
        int IdEtat { get; set; }
    }

    [KnownType(typeof(EtatLieu))]
    [MetadataType(typeof(IEtatLieuMetadata))]
    public partial class EtatLieu
    {

    }
}
