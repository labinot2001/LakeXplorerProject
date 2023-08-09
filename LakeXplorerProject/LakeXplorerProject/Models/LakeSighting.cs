using LakeXplorerProject.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LakeXplorerProject.Models
{
    public class LakeSighting : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string? Image { get; set; } 
        [NotMapped]
        public IFormFile? ImageFile { get; set; } 
        public byte[]? ImageData { get; set; }
        public int LakeId { get; set; }
        [ForeignKey("LakeId")]
        public Lake? Lake { get; set; }
        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }

        public int LikeCount { get; set; }
    }
}
