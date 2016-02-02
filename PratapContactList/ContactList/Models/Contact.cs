
using System;

namespace ContactList.Models
{
    public class Contact
    {
        /// <summary>
        /// The ID of the contact.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Contact's full name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Contact's Phone number. 
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// The Contact's Alternative Phone number. 
        /// </summary>
        public string Phone2 { get; set; }

        /// <summary>
        /// The Contact's Company Name. 
        /// </summary>
        public string Company { get; set; }


        /// <summary>
        /// The Contact's email address. 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The Contact's Title. 
        /// </summary>
        public string Title { get; set; }


        private DateTime _dateCreated;
        /// <summary>
        /// The DateTime on which the contact was created in the system
        /// </summary>
        public DateTime DateCreated {
            get
            {
                return _dateCreated;
            }
            set
            {
                _dateCreated = DateTime.UtcNow; 
            }
        }

        /// <summary>
        /// The Contact's Image URL. 
        /// </summary>
        public string ImageURL { get; set; }

        /// <summary>
        /// The Contact's address. 
        /// </summary>
        public string Address { get; set; }
    }
}