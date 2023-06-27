using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJ.Service.CommonServices
{
    public interface IGetService<T, X, Y>
    {
        public Task<OutputDTO<Y>> Get(T id , X roleId);
        public Task<OutputDTO<List<Y>>> GetAll(T id, X roleId);
    }
}
