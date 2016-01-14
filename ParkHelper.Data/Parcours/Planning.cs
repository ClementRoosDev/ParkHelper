using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
// ReSharper disable CheckNamespace

namespace ParkHelper.Data
{
    public interface IPlanningMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int id { get; set; }

        [ForeignKey("idLieu")]
        Lieu Lieu { get; set; }

        [ForeignKey("idJour")]
        Jour Jour { get; set; }

        [ForeignKey("idNumeroJour")]
        NumeroJour NumeroJour { get; set; }

        [ForeignKey("idMois")]
        Mois Mois { get; set; }

        [ForeignKey("idHoraire")]
        Horaire Horaire { get; set; }

        [ForeignKey("idEtat")]
        EtatLieu EtatLieu { get; set; }
    }

    [KnownType(typeof(Planning))]
    [MetadataType(typeof(IPlanningMetadata))]
    public partial class Planning
    {
    }
}