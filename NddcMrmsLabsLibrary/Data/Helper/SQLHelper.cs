using NddcMrmsLabsLibrary.Databases;
using NddcMrmsLabsLibrary.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLabsLibrary.Data.Helper
{
    public class SQLHelper : IHelperData
    {
        private const string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;

        public SQLHelper(ISqlDataAccess db)
        {
            this.db = db;
        }

        public List<State> GetAllStates()
        {
            return db.LoadData<State, dynamic>("select SID, StateName from State", new { }, connectionStringName, false).ToList();
        }
    }
}
