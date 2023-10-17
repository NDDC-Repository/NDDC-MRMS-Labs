using NddcMrmsLabsLibrary.Model;

namespace NddcMrmsLabsLibrary.Data.Labs
{
    public interface ILabsData
    {
        int AddLab(MyLab lab);
        void AddLabUser(int labId, string userId);
        bool IsLabApproved(string userId);
        bool UserExistsInLab(string email);
    }
}