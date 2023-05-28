namespace KolosPowtórka.Models
{
    public class Country
    {
        public int IdCountry { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CountryTrip> CountryTrips { get; set; }
    }
}
