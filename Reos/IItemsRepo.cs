using CQRS_Lib.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Lib.Reos
{
    public interface IItemsRepo
    {
        public List<Items> GetItems();

        public Items GetItem(int id);

        public int InsertItems(Items items);

        public int DeleteItems(int id);

        public int UpdateItems(Items items);

    }
}
