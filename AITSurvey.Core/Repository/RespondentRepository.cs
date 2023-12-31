﻿using AITSurvey.Core.Models;
using System;
using System.Data.SqlClient;

namespace AITSurvey.Core.Repository
{
    public class RespondentRepository
    {
        // Inserts a new respondent record in the database and returns the generated respondent ID
        public int InsertRespondent(int surveyId, Respondent respondent)
        {
            int respondentId = 0;
            var query = @"Insert Into Respondent (MacAddress,DateCreated,SurveyId)
                values(@MacAddress,@DateCreated,@SurveyId);SELECT SCOPE_IDENTITY();";
            try
            {
                using (var con = new SqlConnection(Database.Connection.ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        // Add parameters to the command object
                        cmd.Parameters.Add(new SqlParameter("@MacAddress", respondent.MacAddress));
                        cmd.Parameters.Add(new SqlParameter("@DateCreated", respondent.DateCreated));
                        cmd.Parameters.Add(new SqlParameter("@SurveyId", surveyId));
                        // Execute the query and retrieve the generated respondent ID
                        respondentId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting respondent record.", ex);
            }
            // Return the generated respondent ID
            return respondentId;
        }

        // Inserts a new respondent profile record in the database and returns the generated profile ID
        public int InsertRespondentProfile(int respondentId, RespondentProfile profile)
        {
            int profileId = 0;
            var query = @"Insert Into RespondentProfile (FirstName,LastName,Email,DateOfBirth,ContactNumber,RespondentId,DateCreated) 
                values(@FirstName,@LastName,@Email,@DateOfBirth,@ContactNumber,@RespondentId,@DateCreated);SELECT SCOPE_IDENTITY();";
            try
            {
                using (var con = new SqlConnection(Database.Connection.ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        // Add parameters to the command object
                        cmd.Parameters.Add(new SqlParameter("@FirstName", profile.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@LastName", profile.LastName));
                        cmd.Parameters.Add(new SqlParameter("@Email", profile.Email));
                        cmd.Parameters.Add(new SqlParameter("@DateOfBirth", profile.DateOfBirth));
                        cmd.Parameters.Add(new SqlParameter("@ContactNumber", profile.ContactNumber));
                        cmd.Parameters.Add(new SqlParameter("@RespondentId", respondentId));
                        cmd.Parameters.Add(new SqlParameter("@DateCreated", profile.DateCreated));
                        // Execute the query and retrieve the generated profile ID
                        profileId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting respondent profile record.", ex);
            }
            // Return the generated profile ID
            return profileId;
        }

        // Inserts an address record for a respondent
        // Parameters:
        // respondentId: the id of the respondent to insert the address record for
        // address: the address object containing the address information to insert
        public void InsertAddressRecord(int respondentId, Address address)
        {
            try
            {
                using (var con = new SqlConnection(Database.Connection.ConnectionString))
                {
                    using (var cmd = new SqlCommand($"Insert into Address (StateId,Suburb,Postcode,AddressTypeId,RespondentId,DateCreated) Values(@StateId,@Suburb,@Postcode,@AddressTypeId,@RespondentId,@DateCreated)", con))
                    {
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@StateId", address.State.Id));
                        cmd.Parameters.Add(new SqlParameter("@Suburb", address.Suburb));
                        cmd.Parameters.Add(new SqlParameter("@Postcode", address.Postcode));
                        cmd.Parameters.Add(new SqlParameter("@RespondentId", respondentId));
                        cmd.Parameters.Add(new SqlParameter("@DateCreated", address.DateCreated));
                        cmd.Parameters.Add(new SqlParameter("@AddressTypeId", address.AddressType.AddressTypeId));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while inserting Address record.", ex);
            }
        }

    }
}

