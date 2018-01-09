using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UnitRoomFloor { get; set; }

        public string BuildingName { get; set; }

        public int LotBlockHouseNumber { get; set; }

        public string Street { get; set; }

        public string SubdivisionVillage { get; set; }

        public string Baranggay { get; set; }

        public string CityMunicipality { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        public int ZipCode { get; set; }

        public DateTime DateStarted { get; set; }

        public int Mobile { get; set; }

        public int Telephone { get; set; }

        public string Email { get; set; }
    }
}