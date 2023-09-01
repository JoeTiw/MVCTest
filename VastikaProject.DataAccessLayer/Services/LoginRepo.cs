using VastikaProject.DataAccessLayer.DataContext;
using VastikaProject.DataAccessLayer.Interfaces;

namespace VastikaProject.DataAccessLayer.Services;

public class LoginRepo : ILoginRepo
{
    private DbDataContext _dbDataContext;

    public LoginRepo(DbDataContext dbDataContext)
    {
        _dbDataContext = dbDataContext;
    }

    public bool CheckValidUser(string username, string password)
    {
        try
        {
            var result = _dbDataContext.Login.FirstOrDefault(x => x.Username == username && x.Password == password);
            if (result == null)
            {
                return false;
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}