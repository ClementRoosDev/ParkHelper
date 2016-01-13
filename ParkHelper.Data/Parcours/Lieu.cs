using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ParkHelper.Data
{
    [KnownType(typeof(Lieu))]
    [MetadataType(typeof(LieuMetadata))]
    public partial class Lieu : IElementDeParcours
    {
        public bool EstDejaDansLeParcours { get; set; }

        public int Ordre { get; set; }

        public Type type
        {
            get
            {
                return this.GetType();
            }
        }

        int IElementDeParcours.Duree
        {
            get
            {
                return (int)Duree;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        
        
        internal sealed class LieuMetadata
        {
            [ForeignKey("IdType")]
            public TypeDeLieu TypeDeLieu { get; set; }

            [Key]
            public int Id { get; set; }
        }

    }
}
