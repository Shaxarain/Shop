using DBs.DB;
using DBs.Infrastructure;
using Funcs;
using Microsoft.AspNet.Identity;
using Shop.Funcs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFContracts;
using WCFContracts.DataContracts;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "UserService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы UserService.svc или UserService.svc.cs в обозревателе решений и начните отладку.
    public class UserService : IUserService
    {
        UOWCatalog Database = new UOWCatalog();

        public OperationDetails Create(UserData userDto)
        {
            ApplicationUser user;
            if (Database.UserManager.FindByEmail(userDto.Email) == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = Database.UserManager.Create(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // добавляем роль
                Database.UserManager.AddToRole(user.Id, userDto.Role);
                // создаем профиль клиента
                var CustomerId = Database.ClientManager.GetAll().OrderByDescending(x => x.CustomerID).First().CustomerID + 1;
                ClientProfile clientProfile = new ClientProfile() { Id=user.Id, Address = userDto.Address, Name = userDto.Name, CustomerID = CustomerId };
             
                Database.ClientManager.Create(clientProfile);
                Database.Save();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public ClaimsIdentityData Authenticate(UserData userDto)
        {
            ClaimsIdentityData claim = null;
            // находим пользователя
            ApplicationUser user = Database.UserManager.Find(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = new ClaimsIdentityData(Database.UserManager.CreateIdentity(user,
                                            DefaultAuthenticationTypes.ApplicationCookie));
            return claim;
        }

        // начальная инициализация бд
        public void SetInitialData(UserData adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = Database.RoleManager.FindByName(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    Database.RoleManager.Create(role);
                }
            }
            Create(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
