﻿using Sample.Domain.Entities;
using Sample.Domain.Exceptions;
using Sample.Domain.Interfaces;
using Sample.Domain.Interfaces.Repositories;
using Sample.Domain.Interfaces.Services;

namespace Sample.Service
{
    public class UserService : ServiceBase<User>, IUserService
    {
        #region [ Properties ]

        private readonly IUserRepository _userRepository;

        #endregion

        #region [ Constructor ]

        public UserService(IUserRepository repository, IUserHelper userHelper) : base(repository, userHelper)
        {
            _userRepository = repository;
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Add a new user to the database
        /// </summary>
        /// <param name="entity">User</param>
        /// <returns>Entity</returns>
        public override User Add(User entity)
        {
            if (GetByLogin(entity.Login) != null)
            {
                throw new DomainException(nameof(UserService), nameof(Add), "Login already exists");
            }

            return base.Add(entity);
        }

        /// <summary>
        /// Returns a user based on its login
        /// </summary>
        /// <param name="login">User login</param>
        /// <returns>User</returns>
        public User GetByLogin(string login)
        {
            return _userRepository.GetByLogin(login);
        }

        #endregion
    }
}