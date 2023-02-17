using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class AddressModel
    {
        public string SingleLineAddress { get; set; }
        public string Pincode { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }

        public string Country { get; set; }

    }
}
