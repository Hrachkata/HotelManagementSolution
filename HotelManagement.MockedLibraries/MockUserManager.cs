using System.Runtime.CompilerServices;
using HotelManagement.Data;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace HotelManagement.MockedLibraries
{

    public interface extendedStore : IUserStore<ApplicationUser>,
        IUserEmailStore<ApplicationUser>,
        IUserPasswordStore<ApplicationUser>,
        IUserRoleStore<ApplicationUser>,
        IUserClaimStore<ApplicationUser>,
        ILookupNormalizer
    {};

    public class MockUserManager
    {
        
        /// <summary>
        /// Absolute shit of a method but took me too much time to delete it
        /// </summary>
        /// <returns></returns>
    public UserManager<ApplicationUser> CreateUserManager()
    {
        
        Mock<extendedStore> userPasswordStore = new Mock<extendedStore>();
        userPasswordStore.Setup(s => s.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(IdentityResult.Success));
        
        userPasswordStore.Setup(s => s.FindByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ApplicationUser()
            {
                FirstName = "Atanas"
            });
        
        userPasswordStore.Setup(s => s.FindByNameAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ApplicationUser()
            {
                FirstName = "Atanas"
            });

        userPasswordStore.Setup(s => s.FindByEmailAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ApplicationUser()
            {
                FirstName = "Atanas"
            });
        
        userPasswordStore.Setup(s => s.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(),It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

      
        
        var options = new Mock<IOptions<IdentityOptions>>();
        var idOptions = new IdentityOptions();

        //this should be keep in sync with settings in ConfigureIdentity in WebApi -> Startup.cs
        idOptions.Password.RequiredLength = 8;
        
        idOptions.SignIn.RequireConfirmedEmail = true;

        idOptions.Password.RequireNonAlphanumeric = false;

        idOptions.Password.RequireUppercase = false;

        idOptions.SignIn.RequireConfirmedEmail = false;

        options.Setup(o => o.Value).Returns(idOptions);
        var userValidators = new List<IUserValidator<ApplicationUser>>();
        UserValidator<ApplicationUser> validator = new UserValidator<ApplicationUser>();
        userValidators.Add(validator);

        var passValidator = new PasswordValidator<ApplicationUser>();
        var pwdValidators = new List<IPasswordValidator<ApplicationUser>>();
        pwdValidators.Add(passValidator);
        
        // var userManager = new UserManager<ApplicationUser>(userPasswordStore.Object, options.Object, new PasswordHasher<ApplicationUser>(),
        //     userValidators, pwdValidators, new UpperInvariantLookupNormalizer(),
        //     new IdentityErrorDescriber(), null,
        //     new Mock<ILogger<UserManager<ApplicationUser>>>()
        //     .Object);

        var userManager = new Mock<UserManager<ApplicationUser>>(userPasswordStore.Object, options.Object, new PasswordHasher<ApplicationUser>(),
            userValidators, pwdValidators, new UpperInvariantLookupNormalizer(),
            new IdentityErrorDescriber(), null,
            new Mock<ILogger<UserManager<ApplicationUser>>>()
                .Object);

        userManager.CallBase = true;

        var result = IdentityResult.Success;
        
        userManager.Setup(s => s.CreateAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);

        userManager.Setup(s => s.AddToRolesAsync(It.IsAny<ApplicationUser>(), It.IsAny<IEnumerable<string>>())).ReturnsAsync(IdentityResult.Success);
        
        userManager.Setup(s => s.GenerateEmailConfirmationTokenAsync(It.IsAny<ApplicationUser>())).ReturnsAsync("result");

        return userManager.Object;
    }
    
    
    
    }
    
    
}