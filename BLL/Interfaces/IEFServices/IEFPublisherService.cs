using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces.IEFServices
{
    public interface IEFPublisherService
    {
        Task<string> AddPublisher(PublisherDTO publisher);

        Task UpdatePublisher(PublisherDTO publisher);

        Task DeletePublisher(int Id);

        Task<PublisherDTO> GetPublisherById(int Id);

        Task<IEnumerable<PublisherDTO>> GetAllPublishers();

        Task<PublisherDTO> GetPublisherByName(string name);
    }
}

