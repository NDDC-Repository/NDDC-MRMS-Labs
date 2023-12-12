using NddcMrmsLabsLibrary.Model;

namespace NddcMrmsLabsLibrary.Data.Labs
{
    public interface ILabsData
    {
        int AddLab(MyLab lab);
        void AddLabUser(int labId, string userId, string email, string givenName, string surname, DateTime dateCreated);
        int GetLabId(string userId);
        string GetLabName(int Id);
        string GetLabUserFullName(string userId);
        bool IsLabApproved(string userId);
        bool UserExistsInLab(string email);
    }
}