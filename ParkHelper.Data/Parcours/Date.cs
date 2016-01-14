using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
// ReSharper disable CheckNamespace

namespace ParkHelper.Data
{
    public interface IDateMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }
    }
    [KnownType(typeof(Date))]
    [MetadataType(typeof(IDateMetadata))]
    public partial class Date
    {
         
    }
}