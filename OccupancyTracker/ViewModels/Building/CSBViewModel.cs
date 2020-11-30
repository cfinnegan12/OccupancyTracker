using OccupancyTracker.ViewModels.Space;

namespace OccupancyTracker.ViewModels.Building
{
    public class CSBViewModel
    {
        public string Name = "Computer Science Building";
        public int Occupancy { get; set; }
        public SpacesViewModel Spaces { get; set;}
    }
}
