using System.Collections.Generic;
using AutoMapper;
using News.BusinessLayer.Models;
using News.DataLayer.DAO;
using News.DataLayer.Repositories;

namespace News.BusinessLayer.Services
{
    /// <summary>
    /// Provides the role service methods.
    /// </summary>
    /// <seealso cref="IRoleService"/>
    public class RoleService : IRoleService
    {
        /// <summary>
        /// The role repository.
        /// </summary>
        private readonly IRoleRepository roleRepo;

        /// <summary>
        /// Initialize the new instance <seealso cref="RoleService"/> class.
        /// </summary>
        /// <param name="roleRepo">The role repository.</param>
        public RoleService(IRoleRepository roleRepo)
        {
            this.roleRepo = roleRepo;
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public long Create(Role model)
        {
            var data = Mapper.Map<Role, RoleDAO>(model);
            return this.roleRepo.Add(data);
        }

        /// <summary>
        /// Deletes an instance.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Delete(long key)
        {
            this.roleRepo.Remove(key);
        }

        /// <summary>
        /// Reads all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Role> ReadAll()
        {
            var data = roleRepo.GetAll();
            var result = Mapper.Map<IEnumerable<RoleDAO>, IEnumerable<Role>>(data);
            return result;
        }

        /// <summary>
        /// Reads by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public Role ReadByKey(long key)
        {
            var data = this.roleRepo.FindById(key);
            var result = Mapper.Map<RoleDAO, Role>(data);
            return result;
        }

        /// <summary>
        /// Updates an instance.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(Role model)
        {
            var data = Mapper.Map<Role, RoleDAO>(model);
            this.roleRepo.Edit(data);
        }
    }
}
