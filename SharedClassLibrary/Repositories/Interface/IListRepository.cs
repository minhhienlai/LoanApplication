using SharedClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary.Repositories.Interface
{
    public interface IListRepository
    {
        public IEnumerable<ListModel> GetList();
        public IEnumerable<ListModel> Search(string? app, string? bcode, string? bname,
            int? MinScore, int? MaxScore, int? MinAmount, int? MaxAmount);
    }
}
