using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinHorizontalList.Models;

namespace XamarinHorizontalList.Services
{
    public interface IMonkeyService
    {
        Task<IEnumerable<Monkey>> GetMonkey();
    }
}
