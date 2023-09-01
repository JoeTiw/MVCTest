namespace VastikaProject.DataAccessLayer.Interfaces;

public interface ILoginRepo
{
    bool CheckValidUser(string username, string password);
}