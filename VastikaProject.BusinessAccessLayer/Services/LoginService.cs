
using VastikaProject.DataAccessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastikaProject.BusinessAccessLayer.Interfaces;
using VastikaProject.DataAccessLayer.Interfaces;

namespace VastikaProject.BusinessAccessLayer.Services;

public class LoginService : ILoginService
{
    private ILoginRepo _loginRepo;
    public LoginService(ILoginRepo loginRepo)
    {
        _loginRepo = loginRepo;
    }
         
    public bool Login(string username, string password)
    {
        var isValidUser = _loginRepo.CheckValidUser(username, password);
        return isValidUser;
    }
}