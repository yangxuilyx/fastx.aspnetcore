using FastX.Data.Repository;
using FastX.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace FastX.App.Core.Identity.Users;

/// <summary>
/// 用户管理
/// </summary>
public class UserManager : ITransientDependency
{
    private readonly IRepository<User> _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="passwordHasher"></param>
    public UserManager(IRepository<User> userRepository, IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    /// <summary>
    /// 创建用户
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<User> CreateUserAsync(User user)
    {
        user.Password = _passwordHasher.HashPassword(user, user.Password);
        return await _userRepository.InsertAsync(user);
    }

    /// <summary>
    /// 校验密码
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public virtual Task<bool> CheckPasswordAsync(User user, string password)
    {
        if (_passwordHasher.VerifyHashedPassword(user, user.Password, password) == PasswordVerificationResult.Success)
        {
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }

    /// <summary>
    /// FindByNameAsync
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public virtual async Task<User?> FindByNameAsync(string userName)
    {
        return await _userRepository.GetAsync(p => p.UserName == userName);
    }

    /// <summary>
    /// 根据用户Id获取用户
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public virtual async Task<User?> GetUserByIdAsync(string userId)
    {
        return await _userRepository.GetAsync(userId);
    }
}