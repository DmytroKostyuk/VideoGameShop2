using BLL.DTO;
using BLL.Interfaces.IEFServices;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Services.EF_Services
{
    public class EFUserBoughtService : IEFUserBoughtService
    {
        IEFUnitOfWork _efUnitOfWork;
        private readonly IMapper _mapper;

        public EFUserBoughtService(IEFUnitOfWork efunitOfWork, IMapper mapper)
        {
            _efUnitOfWork = efunitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserBoughtDTO>> GetAllUserBoughts()
        {
            var x = await _efUnitOfWork.EFUserBoughtRepository.GetAll();
            List<UserBoughtDTO> res = new List<UserBoughtDTO>();
            foreach (var i in x)
                res.Add(_mapper.Map<UserBought, UserBoughtDTO>(i));

            return res;
        }

        public async Task<UserBoughtDTO> GetUserBoughtById(int Id)
        {
            var x = await _efUnitOfWork.EFUserBoughtRepository.Get(Id);
            UserBoughtDTO res = _mapper.Map<UserBought, UserBoughtDTO>(x);

            return res;
        }

        public async Task AddUserBought(UserBoughtDTO userBought)
        {
            var x = _mapper.Map<UserBoughtDTO, UserBought>(userBought);
            await _efUnitOfWork.EFUserBoughtRepository.Add(x);
        }

        public async Task DeleteUserBought(int Id)
        { await _efUnitOfWork.EFUserBoughtRepository.Delete(Id); }

        public async Task UpdateUserBought(UserBoughtDTO userBought)
        {
            var x = _mapper.Map<UserBoughtDTO, UserBought>(userBought);
            await _efUnitOfWork.EFUserBoughtRepository.Update(x);
        }
    }
}