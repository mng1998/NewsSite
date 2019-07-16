using News.DataLayer.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace News.DataLayer.DAO
{
    /// <summary>
    /// Defines the role table model.
    /// </summary>
    /// <seealso cref="AppDaoBase{long}"/>
    [Table("USERS")]
    public class UserDAO : AppDaoBase<long>
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        /// <value>
        /// The user name.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        public DateTime DOB { get; set; }

        /// <summary>
        /// Gets or sets the home address.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string HomeAddress { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string Tel { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public UserStatus UserStatus { get; set; }
    }

    public enum UserStatus
    {
        /// <summary>
        /// 
        /// </summary>
        Created = 0,

        /// <summary>
        /// 
        /// </summary>
        Active,

        /// <summary>
        /// 
        /// </summary>
        Suspended,

        /// <summary>
        /// 
        /// </summary>
        Deleted
    }
}
