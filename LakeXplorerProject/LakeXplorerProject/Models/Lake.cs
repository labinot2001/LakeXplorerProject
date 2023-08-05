using LakeXplorerProject.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LakeXplorerProject.Models
{
    public class Lake : IEntityBase
    {
        [Key]
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Image { get; set; } // Store the image URL or local path
        public string? Description { get; set; }
        
        [NotMapped]
        public IFormFile? ImageFile { get; set; } // Property for the uploaded image
        public byte[]? ImageData { get; set; }

        //Relationships
        public List<LakeSighting>? LakeSightings { get; set; }


    }
}
