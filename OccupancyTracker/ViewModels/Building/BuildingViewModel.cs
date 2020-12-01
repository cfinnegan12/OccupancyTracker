using OccupancyTracker.ViewModels.Space;

namespace OccupancyTracker.ViewModels.Building
{
    public class BuildingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Occupancy { get; set; }
        public SpacesViewModel Spaces { get; set; }
    }
}
