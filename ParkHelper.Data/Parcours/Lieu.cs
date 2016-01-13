using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

// ReSharper disable once CheckNamespace
namespace ParkHelper.Data
{
    public interface ILieuMetadata
    {
        [ForeignKey("IdType")]
        TypeDeLieu TypeDeLieu { get; set; }

        [Key]
        int Id { get; set; }
    }

    [KnownType(typeof(Lieu))]
    [MetadataType(typeof(ILieuMetadata))]
    public partial class Lieu : IElementDeParcours
    {
        public bool EstDejaDansLeParcours { get; set; }

        public int Ordre { get; set; }

        public Type type => GetType();

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

    }
}
