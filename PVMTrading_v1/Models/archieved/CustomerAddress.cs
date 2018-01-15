using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models.archieved
{
    public class CustomerAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public string UnitRoomFloor { get; set; }

        public string BuildingName { get; set; }

        public int LotBlockHouseNumber { get; set; }

        public string Street { get; set; }

        public string SubdivisionVillage { get; set; }

        public string Barangay { get; set; }

        public string CityMunicipality { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        public int ZipCode { get; set; }
        public bool IsPermanent { get; set; }
        public int AddressTypeId { get; set; }


    }
}