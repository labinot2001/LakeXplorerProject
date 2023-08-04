using LakeXplorerProject.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace LakeXplorerProject.Models
{
    public class Lake : IEntityBase
    {
        [Key]
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Image { get; set; } // Store the image URL or local path
        public string? Description { get; set; }


        //Relationships
        public List<LakeSighting> LakeSightings { get; set; }


    }
}
