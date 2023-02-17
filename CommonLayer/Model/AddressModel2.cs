using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class AddressModel2
    {
        public int AddressId { get; set; }
        public string Addressline1{ get; set; }
        public string Addressline2 { get; set; }
        public string Addressline3 { get; set; }
        public string Pincode { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }

        public string Country { get; set; }

    }
}
