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
        public T GetAnyRecord<T, U>(string tableName, string returnFieldName, string parameterName, U paramValue)
        {
            string SQL = $"select {returnFieldName} from {tableName} where {parameterName} = @{parameterName}";

            return db.LoadData<T, dynamic>(SQL, new { Id = paramValue }, connectionStringName, false).FirstOrDefault();

            //return (T)Convert.ChangeType(myValue, typeof(T));
        }
        public int GetAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            DateTime DoB = dateOfBirth;
            int age = today.Year - DoB.Year;

            return age;
        }
    }
}
