using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IAddressBL
    {
        public AddressModel2 AddAddress(AddressModel emp);

        public List<AddressModel2> GetAllAddress();

        public AddressModel2 RetriveAddress(long EmployeeId);

        public AddressModel2 AddAddress2(AddressModel2 emp);
    }
}
