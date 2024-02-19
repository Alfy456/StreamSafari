using StreamSafari.Model;
using StreamSafari.ViewModel;
using StreamSafari.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamSafari.ViewModel.ViewModels;

namespace StreamSafari.Service
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
        public UserViewModel CreateUser(UserViewModel p_userViewModel)
        {
            User user = new User();
            user.UserName = p_userViewModel.UserName;
            user.Password = p_userViewModel.Password;
            user.UserRole = p_userViewModel.UserRole;
            User userCreated = userRepository.CreateUser(user);
            UserViewModel userViewModelCreated = new UserViewModel();
            userViewModelCreated.UserId = userCreated.UserId;
            userViewModelCreated.UserName = userCreated.UserName;
            userViewModelCreated.UserRole = userCreated.UserRole ?? false;

            return userViewModelCreated;
        }
    }
}
