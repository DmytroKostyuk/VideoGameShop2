using DAL.Entities;
using DAL.Interfaces.EFInterfaces.IEFRepositories;
using Microsoft.AspNetCore.Identity;

namespace DAL.Interfaces
{
    public interface IEFUnitOfWork
    {
        IEFDeveloperRepository EFDeveloperRepository { get; }
        IEFGameRepository EFGameRepository { get; }
        IEFGenreRepository EFGenreRepository { get; }
        IEFPublisherRepository EFPublisherRepository { get; }
        IEFUserBoughtRepository EFUserBoughtRepository { get; }
        UserManager<User> UserManager { get; }
        SignInManager<User> SignInManager { get; }
        RoleManager<MyRole> RoleManager { get; }

        void Complete();
    }
}
