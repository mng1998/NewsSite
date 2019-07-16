using AutoMapper;
using News.BusinessLayer.Models;
using News.DataLayer.DAO;
using News.DataLayer.Repositories;
using System.Collections.Generic;

namespace News.BusinessLayer.Services
{
    /// <summary>
    /// Provides the user service methods.
    /// </summary>
    /// <seealso cref="IUserService"/>
    public class UserService : IUserService
    {
        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IUserRepository userRepo;

        /// <summary>
        /// Initialize the new instance <seealso cref="RoleService"/> class.
        /// </summary>
        /// <param name="userRepo">The user repository.</param>
        public UserService(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public long Create(User model)
        {
            var data = Mapper.Map<User, UserDAO>(model);
            data.UserStatus = UserStatus.Created;
            return this.userRepo.Add(data);
        }

        /// <summary>
        /// Deletes an instance.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Delete(long key)
        {
            this.userRepo.Remove(key);
        }

        /// <summary>
        /// Reads all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> ReadAll()
        {
            var data = this.userRepo.GetAll();
            var result = Mapper.Map<IEnumerable<UserDAO>, IEnumerable<User>>(data);
            return result;
        }

        /// <summary>
        /// Reads by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public User ReadByKey(long key)
        {
            var data = this.userRepo.FindById(key);
            var result = Mapper.Map<UserDAO, User>(data);
            return result;
        }

        /// <summary>
        /// Updates an instance.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(User model)
        {
            var data = Mapper.Map<User, UserDAO>(model);
            this.userRepo.Edit(data);
        }
    }
}
