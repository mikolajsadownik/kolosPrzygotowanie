﻿namespace KolosPowtórka.Models
{
    public class CountryTrip
    {
        public int IdCountry { get; set; }

        public int IdTrip { get; set; }

        public virtual Country Country { get; set; }

        public virtual Trip Trip { get; set; }

    }
}
