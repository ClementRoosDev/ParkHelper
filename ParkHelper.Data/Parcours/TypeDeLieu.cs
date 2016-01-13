using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

// ReSharper disable once CheckNamespace
namespace ParkHelper.Data
{
    [KnownType(typeof(TypeDeLieu))]
    [MetadataType(typeof(TypeDeLieuMetadata))]
    public partial class TypeDeLieu
    {
        private sealed class TypeDeLieuMetadata
        {
            [Key]
            public int Id { get; set; }
        }
    }
}
