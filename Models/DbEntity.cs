using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApplication.Models
{
    internal class DbEntity:StorageDBContext
    {
        private static DbEntity _dbEntity;

        private DbEntity() {}

        public static DbEntity Instance() {
            if (_dbEntity == null) { 
                _dbEntity= new DbEntity();
            }

            return _dbEntity;
        }

        public static void ClearConnection() { 
            _dbEntity.Dispose();
        }
    }
}
