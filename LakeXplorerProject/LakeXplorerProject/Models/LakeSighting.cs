using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LakeXplorerProject.Models
{
    public class LakeSighting
    {
        [Key]
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string? Image { get; set; } // Store the image URL or local path
        
        // public int UserId { get; set; }   //Reference to the user
        // public virtual User User { get; set; }  
        public int LakeId { get; set; }
        [ForeignKey("LakeId")]
        public Lake Lake { get; set; }



    }
}
