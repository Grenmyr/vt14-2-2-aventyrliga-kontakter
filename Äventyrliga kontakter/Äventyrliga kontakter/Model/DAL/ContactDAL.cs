using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Äventyrliga_kontakter.Model.DAL
{
    // contactDAL är av baLBase
    public class ContactDAL : DALBase
    {
        public Contact GetContactById(int contactId)
        {  // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {   // Se metod GetContacs för kommentarer.
                    var cmd = new SqlCommand("Person.uspGetContacts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var contactIdIndex = reader.GetOrdinal("ContactId");
                        var firstNameIndex = reader.GetOrdinal("FirstName");
                        var lastNameIndex = reader.GetOrdinal("LastName");
                        var emailIndex = reader.GetOrdinal("EmailAddress");

                        if (reader.Read())
                        {
                            return new Contact
                            {
                                ContactId = reader.GetInt32(contactIdIndex),
                                FirstName = reader.GetString(firstNameIndex),
                                LastName = reader.GetString(lastNameIndex),
                                EmailAddress = reader.GetString(emailIndex)
                            };
                        }
                        return null;
                    }
                }
                catch
                {
                    throw new ApplicationException("Ett fel har skett i DAL");
                }
            }
        }

        //public IEnumerable<Contact> GetContacts()
        //{  // Skapar och initierar ett anslutningsobjekt.
        //    using (var conn = CreateConnection())
        //    {
        //        try
        //        {
        //            // Skapar det List-objekt som initialt har plats för 100 referenser till Customer-objekt.
        //            var contacts = new List<Contact>(100);

        //            // Skapar och initierar ett SqlCommand-objekt som används till att
        //            // exekveras specifierad lagrad procedur.
        //            var cmd = new SqlCommand("Person.uspGetContacts", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            conn.Open();

        //            // Den lagrade proceduren innehåller en SELECT-sats som kan returnera flera poster varför
        //            // ett SqlDataReader-objekt måste ta hand om alla poster. Metoden ExecuteReader skapar ett
        //            // SqlDataReader-objekt och returnerar en referens till objektet.
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                var contactIdIndex = reader.GetOrdinal("ContactId");
        //                var firstNameIndex = reader.GetOrdinal("FirstName");
        //                var lastNameIndex = reader.GetOrdinal("LastName");
        //                var emailIndex = reader.GetOrdinal("EmailAddress");

        //                while (reader.Read())
        //                {
        //                    // Hämtar ut datat för en post. Använder GetXxx-metoder - vilken beror av typen av data.
        //                    // Du måste känna till SQL-satsen för att kunna välja rätt GetXxx-metod.
        //                    contacts.Add(new Contact
        //                    {
        //                        ContactId = reader.GetInt32(contactIdIndex),
        //                        FirstName = reader.GetString(firstNameIndex),
        //                        LastName = reader.GetString(lastNameIndex),
        //                        EmailAddress = reader.GetString(emailIndex)
        //                    });
        //                }
        //            }
        //            contacts.TrimExcess();
        //            return contacts.OrderBy(c => c.FirstName);
        //        }
        //        catch
        //        {
        //            throw new ApplicationException("Ett fel har skett i DAL");
        //        }
        //    }
        //}

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            //Totalrowcount is first declared null, but after done reading it has the value of totalrows from the out int partameter.
            var contacts = new List<Contact>(maximumRows);

            try
            {
                using (var conn = CreateConnection())
                {
                    SqlCommand cmd = new SqlCommand("Person.uspGetContactsPageWise", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // By substracting startrowindex with maximumrows i get correct pageview with rows on correct sides.
                    cmd.Parameters.Add("@PageIndex", SqlDbType.Int, 4).Value = startRowIndex / maximumRows + 1;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int, 4).Value = maximumRows;
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();
                    // While reader reads, i add the values from table into my list. below i first declare the variables to make it faster. for the compilator.
                    using (var reader = cmd.ExecuteReader())
                    {
                        var contactIdIndex = reader.GetOrdinal("ContactId");
                        var firstNameIndex = reader.GetOrdinal("FirstName");
                        var lastNameIndex = reader.GetOrdinal("LastName");
                        var emailIndex = reader.GetOrdinal("EmailAddress");

                        while (reader.Read())
                        {
                            contacts.Add(new Contact
                            {
                                ContactId = reader.GetInt32(contactIdIndex),
                                FirstName = reader.GetString(firstNameIndex),
                                LastName = reader.GetString(lastNameIndex),
                                EmailAddress = reader.GetString(emailIndex),
                            });
                        }
                    }
                    // I return the totalrowcount so my pager knows how many sides to create, and where it is relative.
                    totalRowCount = (int)cmd.Parameters["@RecordCount"].Value;
                    return contacts;
                }
            }
            catch
            {
                throw new ApplicationException("Ett fel har skett i DAL");
            }
        }

        public void InsertContact(Contact contact)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspAddContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;

                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    // Setting the ID of my newly created contact to my contacID parameter.
                    contact.ContactId = (int)cmd.Parameters["@ContactID"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fel har skett i DAL");
                }
            }
        }
        public void DeleteContact(int contactId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspRemoveContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contactId;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Ett fel har skett i DAL");
                }
            }
        }
        public void UpdateContact(Contact contact)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    SqlCommand cmd = new SqlCommand("Person.uspUpdateContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contact.ContactId;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch
            {
                throw new ApplicationException("Ett fel har skett i DAL");
            }
        }
    }
}
