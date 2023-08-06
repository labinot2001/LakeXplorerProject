using LakeXplorerProject.Models;

namespace LakeXplorerProject.Data.ViewModels
{
    public class NewLakeDropdownsVM
    {


        public NewLakeDropdownsVM()
        {
            Lakes = new List<Lake>();
        }

        public List<Lake> Lakes { get; set; }

    }
}
