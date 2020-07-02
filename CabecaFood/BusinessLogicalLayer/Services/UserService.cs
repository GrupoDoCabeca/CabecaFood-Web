﻿using BusinessLogicalLayer.CustomsAutoMapper;
using BusinessLogicalLayer.IServices;
using BusinessLogicalLayer.Models.UserModel;
using Domain;
using Domain.DTO;
using Infra.IRepositories;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Services
{
    public class UserService : BaseService<User>, IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponseModel> Create(UserRequestModel userModel)
        {
            var user = UserMap.UserRequestToUser(userModel);

            Validate(user);

            await _userRepository.Create(user);
            await _userRepository.Save();

            return UserMap.UserToUserResponse(user);
        }

        public async Task<UserResponseModel> Delete(int id)
        {
            ValidateId(id);

            HandleError();

            var user = await _userRepository.GetById(id);

            if (user == null)
                AddError("Usuario", "Não encontrado");

            HandleError();

            await _userRepository.Delete(id);
            await _userRepository.Save();

            return UserMap.UserToUserResponse(user);
        }

        public async Task<List<UserResponseModel>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return users.Select(user => UserMap.UserToUserResponse(user)).ToList();
        }

        public async Task<UserResponseModel> GetById(int id)
        {
            ValidateId(id);

            HandleError();

            var user = await _userRepository.GetById(id);

            if (user == null)
                AddError("Usuario", "Não encontrado");

            HandleError();

            return UserMap.UserToUserResponse(user);
        }

        public async Task<UserResponseModel> Login(UserLoginRequestModel userLoginRequestModel)
        {
            var user = await _userRepository.Login(userLoginRequestModel.Email, userLoginRequestModel.Password);

            if (user == null)
                AddError("Email ou senha", "Invalido");

            HandleError();

            return UserMap.UserToUserResponse(user);
        }

        public async Task<UserResponseModel> Update(int id, UserRequestModel userModel)
        {
            var user = UserMap.UserRequestToUser(userModel);

            Validate(user);
            ValidateId(id);

            HandleError();

            var userToUpdate = await _userRepository.GetById(id);

            if (user == null)
                AddError("Usuario", "Não encontrado");

            HandleError();

            var userDTO = Map.ChangeValues<User, UserDTO>(user);
            userToUpdate.Update(userDTO);

            await _userRepository.Update(userToUpdate);
            await _userRepository.Save();

            return UserMap.UserToUserResponse(userToUpdate);
        }

        public override void Validate(User entity)
        {
            if (entity.IsInvalid())
                AddErrors(entity.GetErrors());

            var exist = _userRepository.EmailExist(entity).Result;

            if (exist)
                AddError("Email", "Ja existe");

            HandleError();
        }
    }
}
