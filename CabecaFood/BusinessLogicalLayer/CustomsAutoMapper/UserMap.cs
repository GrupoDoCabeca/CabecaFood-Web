﻿using BusinessLogicalLayer.Models.UserModel;
using Domain;
using Shared;

namespace BusinessLogicalLayer.CustomsAutoMapper
{
    public static class UserMap
    {
        public static User UserRequestToUser(UserRequestModel userRequestModel)
        {
            return Map.ChangeValues<UserRequestModel, User>(userRequestModel);
        }

        public static UserResponseModel UserToUserResponse(User user)
        {
            var userResponse = Map.ChangeValues<User, UserResponseModel>(user);
            return userResponse;
        }

        public static User UserUpdateToUser(UserUpdateRequestModel user)
        {
            var userResponse = Map.ChangeValues<UserUpdateRequestModel, User>(user);
            return userResponse;
        }
    }
}
