using BusinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class AddressBL : IAddressBL
    {
        IAddressRL iAddressRL;
        public AddressBL(IAddressRL iAddressRL)
        {
            this.iAddressRL = iAddressRL;
        }
        public AddressModel2 AddAddress(AddressModel emp)
        {
            try
            {
                return iAddressRL.AddAddress(emp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Address method 2

        public AddressModel2 AddAddress2(AddressModel2 emp)
        {
            try
            {
                return iAddressRL.AddAddress2(emp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AddressModel2> GetAllAddress()
        {
            try
            {
                return iAddressRL.GetAllAddress();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public AddressModel2 RetriveAddress(long AddressId)
        {
            try
            {
                return iAddressRL.RetriveAddress(AddressId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
