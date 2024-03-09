
using StreamSafari.ViewModel;
using StreamSafari.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamSafari.ViewModel.ViewModels;
using StreamSafari.Model;

namespace StreamSafari.Service
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();


        public User UserViewModelToEntity(UserViewModel p_UserViewModel)
        {
            User user = new User();
            user.UserId = (p_UserViewModel.UserId == 0) ? 0 : p_UserViewModel.UserId;
            user.UserName = p_UserViewModel.UserName;
            user.Password = p_UserViewModel.Password;
            user.UserRole = p_UserViewModel.UserRole;
            return user;

        }

        public UserViewModel UserEntityToViewModel(User p_UserCreated)
        {

            UserViewModel userViewModelCreated = new UserViewModel();
            userViewModelCreated.UserId = p_UserCreated.UserId;
            userViewModelCreated.UserName = p_UserCreated.UserName;
            userViewModelCreated.UserRole = p_UserCreated.UserRole ?? false;
            return userViewModelCreated;

        }

        public UserViewModel GetUser(UserViewModel p_userViewModel)
        {
            User user = UserViewModelToEntity(p_userViewModel);
            User userAvailable = userRepository.GetUser(user);
            UserViewModel userViewModelAvailable = new UserViewModel();
            if (userAvailable != null)
            {
                userViewModelAvailable = UserEntityToViewModel(userAvailable);
            }
            else
            {
                userViewModelAvailable = UserEntityToViewModel(user);
            }

            return userViewModelAvailable;
        }

        public UserViewModel CreateUser(UserViewModel p_userViewModel)
        {
            User user = UserViewModelToEntity(p_userViewModel);
            User userCreated = userRepository.CreateUser(user);
            UserViewModel userViewModelCreated = UserEntityToViewModel(userCreated);
            return userViewModelCreated;
        }

        public UserViewModel EditUser(UserViewModel p_userViewModel)
        {
            User user = UserViewModelToEntity(p_userViewModel);
            User userEdited = userRepository.EditUser(user);
            UserViewModel userViewModelEdited = UserEntityToViewModel(userEdited);
            return userViewModelEdited;
        }

        public UserViewModel FindUser(int? p_User)
        {

            User findUser = userRepository.FindUser(p_User);
            UserViewModel userViewModelFind = UserEntityToViewModel(findUser);
            return userViewModelFind;
        }

        public List<UserViewModel> ListUsers()
        {
            List<User> users = userRepository.ListUsers();
            List<UserViewModel> userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                UserViewModel userViewModel = new UserViewModel
                {

                    UserId = user.UserId,
                    UserName = user.UserName,
                    UserRole = user.UserRole ?? false

                };
                userViewModels.Add(userViewModel);
            }

            return userViewModels;
        }

        public UserViewModel DeleteUser(UserViewModel p_userViewModel)
        {
            UserViewModel userViewModel = new UserViewModel();
            User user = UserViewModelToEntity(p_userViewModel);
            User findUser = userRepository.FindUser(user.UserId);
            if (findUser != null)
            {
                User userDelete = userRepository.DeleteUser(findUser);
                userViewModel = UserEntityToViewModel(userDelete);
            }

            return userViewModel;
        }

        public UserViewModel LoginUserValid(UserViewModel p_userViewModel)
        {
            
            User user = UserViewModelToEntity(p_userViewModel);
            User loginUser = userRepository.GetUser(user);
            UserViewModel userViewModel = UserEntityToViewModel(loginUser);
            return userViewModel;


        }
       
    }
}
