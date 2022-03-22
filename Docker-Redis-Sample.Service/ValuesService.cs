using Docker_Redis_Sample.Cache;
using Docker_Redis_Sample.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docker_Redis_Sample.Service
{
    public class ValuesService : IValuesService
    {
        private IEnumerable<ValuesModel> _values = new List<ValuesModel>()
        {
            new ValuesModel()
            {
                Id = 1,
                title = "title one",
                description = "description one",
                date = DateTime.Now,
            },
            new ValuesModel()
            {
                Id = 2,
                title = "title two",
                description = "description two",
                date = DateTime.Now,
            },
            new ValuesModel()
            {
                Id = 3,
                title = "title three",
                description = "description three",
                date = DateTime.Now,
            },
        };

        private readonly ICacheManager _cacheManager;
        public ValuesService(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public ValuesModel getValuesById(int valuesId)
        {
            var result = _cacheManager.Get<ValuesModel>($"{RedisConstants.RedisAppKey}.{valuesId}");
            if (result == null)
            {
                result = _values.Where(x=>x.Id == valuesId).FirstOrDefault();
                if(result != null)
                {
                    Console.WriteLine($"{RedisConstants.RedisAppKey}.{valuesId} value cached");
                    _cacheManager.Set<ValuesModel>($"{RedisConstants.RedisAppKey}.{valuesId}", result, TimeSpan.FromSeconds(60));
                }
                return result;
            }
            else
            {
                Console.WriteLine($"{RedisConstants.RedisAppKey}.{valuesId} get from cache");
                return result;
            }
               
        }
    }
}
