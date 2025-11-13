using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.data
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(User u);
        Task<User?> GetAsync(int id);
        Task<IReadOnlyList<User>> ListAsync();
    }
}
