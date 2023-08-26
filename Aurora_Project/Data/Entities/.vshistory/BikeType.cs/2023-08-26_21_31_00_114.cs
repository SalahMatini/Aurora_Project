namespace Aurora_Project.Data.Entities
{
    public interface BikeType
    {

        public int Id { get; set; }


        public string Type { get; set; }


        public List<Bike> Bikes { get; set; }
    }
}
