using News.DataLayer.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace News.DataLayer.DAO
{
    [Table("USERROLES")]
    public class UserRoleDAO: AppDaoBase<long>
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
