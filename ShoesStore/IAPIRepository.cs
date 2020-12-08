using ShoesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesStore
{
    public interface IAPIRepository
    {
        public IEnumerable<Shoes> GetShoes();
    }
}
