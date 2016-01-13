using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Data
{
    [KnownType(typeof(TypeDeLieu))]
    [MetadataType(typeof(TypeDeLieuMetadata))]
    public partial class TypeDeLieu
    {
        internal sealed class TypeDeLieuMetadata
        {
            [Key]
            public int Id { get; set; }
        }
    }
}
