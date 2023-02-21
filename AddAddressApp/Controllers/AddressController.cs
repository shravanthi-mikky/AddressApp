using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;

namespace AddAddressApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        IAddressBL iAddressBL;
        public AddressController(IAddressBL iAddressBL)
        {
            this.iAddressBL = iAddressBL;
        }
        [HttpPost]
        public IActionResult AddAddress(AddressModel model)
        {
            try
            {
                var address = iAddressBL.AddAddress(model);
                if (address != null)
                {
                    return this.Ok(new { Success = true, message = "Added successfully", Data = address });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to add" });
                }
            }
            catch (System.Exception e)
            {

                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }

        // public AddressModel2 AddAddress2(AddressModel2 emp)
        [HttpPost("Add2")]
        public IActionResult AddAddress2(AddressModel2 model)
        {
            try
            {
                var address = iAddressBL.AddAddress2(model);
                if (address != null)
                {
                    return this.Ok(new { Success = true, message = "Added successfully", Data = address });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to add" });
                }
            }
            catch (System.Exception e)
            {

                return this.BadRequest(new { Success = false, message = e.Message });
            }
        }


        [HttpGet("GetAll")]
        public IActionResult GetAllAddress()
        {
            try
            {
                var reg = this.iAddressBL.GetAllAddress();
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "All Address Details", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to get details" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [HttpGet("GetAddressById")]
        public IActionResult RetriveAddress(int addressId)
        {
            try
            {
                var reg = this.iAddressBL.RetriveAddress(addressId);
                if (reg != null)

                {
                    return this.Ok(new { Success = true, message = "Address Details", Response = reg });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unable to get Address details" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
