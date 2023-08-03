namespace LakeXplorerProject.Models
{
    public class Lake
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Image { get; set; } // Store the image URL or local path
        public string? Description { get; set; }

    }
}
