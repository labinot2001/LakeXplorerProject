namespace LakeXplorerProject.Models
{
    public class LakeSighting
    {
        public int Id { get; set; } // Primary key
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string? Image { get; set; } // Store the image URL or local path

       // public int UserId { get; set; }   //Reference to the user
       // public virtual User User { get; set; }  

       // public int LakeId { get; set; } // Reference to the lake
       // public virtual Lake Lake { get; set; } 


    }
}
