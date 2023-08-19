using System.ComponentModel.DataAnnotations;

namespace Aurora_Project.Enums
{
    public enum BikeTypes
    {
        [Display(Name = "Mountain Bike")]
        MountainBike,

        [Display(Name = "Road Bike")]
        RoadBike,

        [Display(Name = "Hybrid Bike")]
        HybridBike,

        [Display(Name = "E-Bike")]
        Ebike,
    }
}
