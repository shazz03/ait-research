using AITSurvey.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AITSurvey.Core.Implementation
{
    public class SelectListItemService
    {
        public List<SelectListItems> LoadAddressType()
        {
            var list = new List<SelectListItems>
            {
                new SelectListItems { Text = "Select Address Type", Value = "0" }
            };

            try
            {
                using (var myConnection = new SqlConnection(Database.Connection.ConnectionString))
                {
                    var myCommand = new SqlCommand("SELECT * FROM AddressType", myConnection);

                    myConnection.Open();
                    using (var myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            list.Add(new SelectListItems { Text = myReader["TypeName"].ToString(), Value = myReader["AddressTypeId"].ToString() });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                throw new Exception("An error occurred while loading the address type list.", ex);
            }

            return list;
        }

        

        public List<SelectListItems> LoadState()
        {
            var list = new List<SelectListItems>
            {
                new SelectListItems { Text = "Select State", Value = "0" }
            };

            try
            {
                using (var myConnection = new SqlConnection(Database.Connection.ConnectionString))
                {
                    var myCommand = new SqlCommand("SELECT * FROM State", myConnection);

                    myConnection.Open();
                    using (var myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            list.Add(new SelectListItems { Text = myReader["State"].ToString(), Value = myReader["Id"].ToString() });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while loading the state list.", ex);
            }

            return list;
        }
    }
}
