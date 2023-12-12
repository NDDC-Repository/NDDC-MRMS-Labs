using NddcMrmsLabsLibrary.Model.Helper;

namespace NddcMrmsLabsLibrary.Data.Helper
{
    public interface IHelperData
    {
        int GetAge(DateTime dateOfBirth);
        List<State> GetAllStates();
        T GetAnyRecord<T, U>(string tableName, string returnFieldName, string parameterName, U paramValue);
    }
}