using LakeXplorerProject.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LakeXplorerProject.Models
{
    public class Like : IEntityBase
    {
        [Key]
        public int Id { get; set; }
       
        //Like
        public int LakeSightingId { get; set; }
        [ForeignKey("LakeSightingId")]
        public LakeSighting? LakeSightings { get; set; }

        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public  ApplicationUser? User { get; set; }



    }
}
