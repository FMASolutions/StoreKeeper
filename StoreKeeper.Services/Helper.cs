using AutoMapper;
using StoreKeeper.Services.Mapping;

namespace StoreKeeper.Services
{
    internal class Helper
    {
        private Helper() {}
        private static Helper _instance;
        private static readonly object _lock = new object();
        private static IMapper _mapper;
        internal static Helper GetInstance()
        {
            if(_instance == null)
            {
                lock(_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new Helper();
                    }
                }
            }
            return _instance;
        }
        internal IMapper GetMapper() 
          {
               if (_mapper == null)
               {
                    var config = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });
                    _mapper = config.CreateMapper();
               } 
               return _mapper;
          }
    }
}
