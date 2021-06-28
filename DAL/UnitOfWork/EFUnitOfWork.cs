using DAL.Interfaces;
using DAL.Interfaces.EFInterfaces.IEFRepositories;
using System;
using Microsoft.AspNetCore.Identity;
using DAL.Entities;

namespace DAL.UnitOfWork
{
    public class EFUnitOfWork : IEFUnitOfWork
    {
        private readonly IEFDeveloperRepository _efDeveloperRepository;
        private readonly IEFGameRepository _efGameRepository;
        private readonly IEFGenreRepository _efGenreRepository;
        private readonly IEFPublisherRepository _efPublisherRepository;
        private readonly IEFUserBoughtRepository _efUserBoughtRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<MyRole> _roleManager;

        public EFUnitOfWork(IEFDeveloperRepository eFDeveloperRepository,
            IEFGameRepository eFGameRepository,
            IEFGenreRepository eFGenreRepository,
            IEFPublisherRepository eFPublisherRepository,
            IEFUserBoughtRepository eFUserBoughtRepository,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<MyRole> roleManager)
        {
            _efDeveloperRepository = eFDeveloperRepository;
            _efGameRepository = eFGameRepository;
            _efGenreRepository = eFGenreRepository;
            _efPublisherRepository = eFPublisherRepository;
            _efUserBoughtRepository = eFUserBoughtRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IEFDeveloperRepository EFDeveloperRepository
        {
            get { return _efDeveloperRepository; }
        }

        public IEFGameRepository EFGameRepository
        {
            get { return _efGameRepository; }
        }

        public IEFGenreRepository EFGenreRepository
        {
            get { return _efGenreRepository; }
        }

        public IEFPublisherRepository EFPublisherRepository
        {
            get { return _efPublisherRepository; }
        }

        public IEFUserBoughtRepository EFUserBoughtRepository
        {
            get { return _efUserBoughtRepository; }
        }

        public UserManager<User> UserManager
        {
            get { return _userManager; }
        }

        public SignInManager<User> SignInManager
        {
            get { return _signInManager; }
        }

        public RoleManager<MyRole> RoleManager
        {
            get { return _roleManager; }
        }

        public void Complete()
        { throw new NotImplementedException(); }
    }
}
