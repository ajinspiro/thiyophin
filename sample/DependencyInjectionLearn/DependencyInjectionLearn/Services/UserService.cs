using System;

namespace DependencyInjectionLearn.Services;

public class UserService: IUserService
{
    public string GetUser()
    {
        return "Thiyophin is 26 years old";
    }
}

public interface IUserService
{
    public string GetUser();
}
