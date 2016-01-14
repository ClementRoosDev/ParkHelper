using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

// ReSharper disable once CheckNamespace
namespace ParkHelper.Data
{
    public interface ITypeDeLieuMetadata
    {
        [Key]
        int Id { get; set; }
    }

    [KnownType(typeof(TypeDeLieu))]
    [MetadataType(typeof(ITypeDeLieuMetadata))]
    public partial class TypeDeLieu
    {

    }
}
