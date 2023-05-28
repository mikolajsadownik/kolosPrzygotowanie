﻿namespace KolosPowtórka.Models
{
    public class ClientTrip

    {
        public int IdClient { get; set; }

        public int IdTrip { get; set; }

        public DateTime RegisteredAt { get; set; }

        public DateTime? PaymentDate { get; set; }

        public virtual Client Client { get; set; }

        public virtual Trip Trip { get; set; }
    }
}
