using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Npgsql;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RepositoryLayer.Services
{
    public class AddressRL : IAddressRL
    {
        private IConfiguration config;
        NpgsqlConnection sqlConnection;
        string ConnString = "Server=localhost;Port=5432;Database=AddressAppAR;Username=postgres; Password=Mickey@27;Integrated Security=True;";
        public AddressRL(IConfiguration config)
        {
            this.config = config;
        }


        // Add Address new method with validations

        public AddressModel2 AddAddressAndSplit(AddressModel emp)
        {
            try
            {
                AddressModel2 addressModel2 = new AddressModel2();
                    int value1 =0;
                    int value2=0;
                    int value3=0;
                    int value = 0;
                    int value4 = emp.SingleLineAddress.Length;
                    string[] addressParts = emp.SingleLineAddress.Split(' ');
                    string[] address1 = new string[5];

                    int Count = addressParts.Length;

                    if (Count < 3 )
                    {
                        addressModel2.Addressline1 = emp.SingleLineAddress;
                        addressModel2.Addressline2 = emp.City + ", " + emp.District;
                        addressModel2.Addressline3 = emp.Country;
                        
                    }
                    else if(Count >= 5)
                    {
                        foreach(string addressPart in addressParts)
                        {
                            value1 += addressPart.Length;
                            value2 += addressPart.Length;
                            value3 += addressPart.Length;
                            if ( value1 < 55 && value < 5)
                            {
                                addressModel2.Addressline1 += addressPart + " ";
                                value++;
                                value2 = 0;
                                value3 = 0;
                            }
                            else if (value2 <= 55)
                            {
                                addressModel2.Addressline2 += addressPart + " ";
                                addressModel2.Addressline3 += "";
                            }
                            else if (value3 <= 55)
                            {
                                addressModel2.Addressline3 += addressPart + " ";
                            }
                        }
                    }
                    if(Count >= 3 && Count < 5)
                    {
                        addressModel2.Addressline1 = emp.SingleLineAddress + ", " + emp.City + ", " + emp.District;
                        addressModel2.Addressline2 = emp.State;
                        addressModel2.Addressline3 = "";
                    }
                addressModel2.Pincode = emp.Pincode;
                addressModel2.City = emp.City;
                addressModel2.District = emp.District;
                addressModel2.State = emp.State;
                addressModel2.Country = emp.Country;

                   return addressModel2;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        //Add Address
        public AddressModel2 AddAddress(AddressModel emp)
        {
            try
            {
                AddressModel2 addressModel3 = new AddressModel2();
                addressModel3 = AddAddressAndSplit(emp);
                using (sqlConnection = new NpgsqlConnection(ConnString))
                {
                    NpgsqlCommand com = new NpgsqlCommand("call Sp_AddAddress(:Addressline1,:Addressline2,:Addressline3,:Pincode,:City,:District,:State,:Country)", sqlConnection);
                    com.CommandType = System.Data.CommandType.Text;
                    sqlConnection.Open();

                    // Apply Validations
                    com.Parameters.AddWithValue("Addressline1", DbType.String).Value = addressModel3.Addressline1;
                    com.Parameters.AddWithValue("Addressline2", DbType.String).Value = addressModel3.Addressline2;
                    com.Parameters.AddWithValue("Addressline3", DbType.String).Value = addressModel3.Addressline3;
                    com.Parameters.AddWithValue("Pincode", DbType.String).Value = addressModel3.Pincode;
                    com.Parameters.AddWithValue("City", DbType.String).Value = addressModel3.City;
                    com.Parameters.AddWithValue("District", DbType.String).Value = addressModel3.District;
                    com.Parameters.AddWithValue("State", DbType.String).Value = addressModel3.State;
                    com.Parameters.AddWithValue("Country", DbType.String).Value = addressModel3.Country;

                    com.ExecuteNonQuery();
                    return addressModel3;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<AddressModel2> GetAllAddress()
        {
            List<AddressModel2> employ = new List<AddressModel2>();
            NpgsqlConnection conn = new NpgsqlConnection(ConnString);
            using (conn)
            {
                try
                {
                    string query = "select * from AddressTable;";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    conn.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employ.Add(new AddressModel2
                            {
                                AddressId = Convert.ToInt32(reader["AddressId"]),
                                Addressline1 = reader["Addressline1"].ToString(),
                                Addressline2 = reader["Addressline2"].ToString(),
                                Addressline3 = reader["Addressline3"].ToString(),
                                Pincode = reader["Pincode"].ToString(),
                                City = reader["City"].ToString(),
                                District = reader["District"].ToString(),
                                State = reader["State"].ToString(),
                                Country = reader["Country"].ToString()
                            });
                        }
                        return employ;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public AddressModel2 RetriveAddress(long addressId)
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConnString);
            string query = "select * from AddressTable where AddressId= '" + addressId + "';";
            NpgsqlCommand com = new NpgsqlCommand(query, conn);
            com.CommandType = CommandType.Text;
            conn.Open();
            AddressModel2 employ = new AddressModel2();
            NpgsqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    employ.AddressId = Convert.ToInt32(reader["AddressId"]);
                    employ.Addressline1 = reader["Addressline1"].ToString();
                    employ.Addressline2 = reader["Addressline2"].ToString();
                    employ.Addressline3 = reader["Addressline3"].ToString();
                    employ.Pincode = reader["Pincode"].ToString();
                    employ.City = reader["City"].ToString();
                    employ.District = reader["District"].ToString();
                    employ.State = reader["State"].ToString();
                    employ.Country = reader["Country"].ToString();

                    if(employ.Addressline2 == null)
                    {
                        employ.Addressline2 = employ.City;
                    }
                }
                return employ;
            }
            return null;
        }

    }
}
