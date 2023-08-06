using LakeXplorerProject.Models;

namespace LakeXplorerProject.Data.ViewModels
{
    public class LakeVM
    {
        public Lake? Lake { get; set; }
        public List<LakeSighting>? LakeSightings { get; set; }

    }
}
