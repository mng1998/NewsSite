using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using News.BusinessLayer.Builders;
using News.BusinessLayer.Extension;
using News.BusinessLayer.Models;
using News.DataLayer.DAO;
using News.DataLayer.Repositories;

namespace News.BusinessLayer.Services
{
    /// <summary>
    /// Provides the role service methods.
    /// </summary>
    /// <seealso cref="IUserRoleService"/>
    /// <seealso cref="IBuilder{IEnumerable{UserRoleDAO}, IEnumerable{UserRole}}"/>
    public class UserRoleService : IUserRoleService, IBuilder<IEnumerable<UserRoleDAO>, IEnumerable<UserRole>>
    {
        /// <summary>
        /// The user service.
        /// </summary>
        private readonly IUserService userService;

        /// <summary>
        /// The role service.
        /// </summary>
        private readonly IRoleService roleService;

        /// <summary>
        /// The user role service.
        /// </summary>
        private readonly IUserRoleRepository userroleRepo;

        /// <summary>
        /// Initialize the new instance <seealso cref="UserRoleService"/> class.
        /// </summary>
        /// <param name="userService">The user rolw service.</param>
        /// <param name="roleService">The role service.</param>
        /// <param name="userroleRepo">The user role service.</param>
        public UserRoleService(IUserService userService, IRoleService roleService, IUserRoleRepository userroleRepo)
        {
            this.userroleRepo = userroleRepo;
            this.userService = userService;
            this.roleService = roleService;
        }

        /// <summary>
        /// Builds back.
        /// </summary>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        public IEnumerable<UserRoleDAO> BuildBack(IEnumerable<UserRole> destination)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds an instance.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public IEnumerable<UserRole> Build(IEnumerable<UserRoleDAO> source)
        {
            var lst = new List<UserRole>();
            foreach (var inner in source)
            {
                if (!lst.IsExist(inner))
                {
                    var userrole = new UserRole
                    {
                        Id = inner.Id,
                        User = this.userService.ReadByKey(inner.UserId),
                        Roles = new List<Role>() { this.roleService.ReadByKey(inner.RoleId) },
                        CreatedDate = DateTime.Now,
                        ModifiedDate = null
                    };

                    lst.Add(userrole);
                }
                else
                {
                    var item = lst.FirstOrDefault(n => long.Equals(n.User.Id, inner.Id));
                    item.Roles.Add(this.roleService.ReadByKey(inner.RoleId));
                }
            }

            return lst as IEnumerable<UserRole>;
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public long Create(UserRole model)
        {
            /* STEP 1: Insert user into db */
            var userId = this.userService.Create(model.User);

            /* STEP 2: Insert userrole in db */
            foreach(var inner in model.Roles)
            {
                var entity = new UserRoleDAO
                {
                    UserId = userId,
                    RoleId = inner.Id,
                    CreatedDate = DateTime.Now
                };
                this.userroleRepo.Add(entity);
            }

            /* STEP 3: Don't have error return 0 */
            return 0;
        }

        /// <summary>
        /// Deletes an instance.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Delete(long key)
        {
            this.userService.Delete(key);
        }

        /// <summary>
        /// Reads all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserRole> ReadAll()
        {
            var userroles = this.userroleRepo.GetAll();
            return this.Build(userroles);
        }

        /// <summary>
        /// Reads by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public UserRole ReadByKey(long key)
        {
            var userroleDaoItems = userroleRepo.FindByUserId(key);
            var data = userroleDaoItems.First();
            var userrole = new UserRole
            {
                User = this.userService.ReadByKey(data.Id),
            };

            foreach(var inner in userroleDaoItems)
            {
                userrole.Roles.Add(this.roleService.ReadByKey(inner.RoleId));
            }

            return userrole;
        }

        /// <summary>
        /// Updates an instance.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(UserRole model)
        {
            this.userService.Update(model.User);
            //var userroleDao = new UserRoleDAO
            //{
            //    Id = model.Id,
            //    UserId = model.User.Id,
            //    RoleId = model.Roles.Id,
            //    CreatedDate = model.CreatedDate,
            //    ModifiedDate = DateTime.Now
            //};
            //this.userroleRepo.Edit(userroleDao);
        }

        public IEnumerable<Role> ReadAllRole()
        {
            return this.roleService.ReadAll();
        }
    }
}
