using CQRS_Lib.Data;
using CQRS_Lib.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Lib.Reos
{
    public class ItemRepo : IItemsRepo
    {
        private AppDbContext _db;
        public ItemRepo(AppDbContext appDb)
        {
            _db = appDb;
        }


        public Items GetItem(int id)
        {
           var item=_db.items.Where( x=>x.Id==id).FirstOrDefault();
            return item ?? new();
        }

        public List<Items> GetItems()
        {
            return _db.items.ToList();  
        }

        public int InsertItems(Items items)
        {
           _db.items.Add(items);
            return _db.SaveChanges();
        }

        public int UpdateItems(Items items)
        {
            try {
                _db.items.Attach(items);
                _db.Entry(items).State=EntityState.Modified;
                return _db.SaveChanges();
            }
            catch { return 0; }
        }
        
        public int DeleteItems(int id)
        {
            var item=_db.items.Where(x=>x.Id==id).FirstOrDefault();
            if (item != null) { _db.items.Remove(item); }   
            return _db.SaveChanges() ;
        }
    }
}
