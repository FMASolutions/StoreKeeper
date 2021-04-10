using AutoMapper;

namespace StoreKeeper.Services
{
    public abstract class BaseService
    {
        protected IMapper _mapper;
        public BaseService()
        {
            if(_mapper == null)
                _mapper = Helper.GetInstance().GetMapper();
        }
    }
}
