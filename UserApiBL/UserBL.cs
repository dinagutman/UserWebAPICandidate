
using UserApiDAL;

namespace UserApiBL
{
    public class UserBL : IUserBL
    {
        IUserDAL userDAL;
        public UserBL(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }

        public async Task<List<Candidates>>? GetAll()
        {
            return await userDAL.getAllCandidates();
        }
        public Task<bool> insertCandidates(Candidates value)
        {
            return userDAL.insertCandidates(value);
        }

        public Task<bool>? insertLanguage(Language lang)
        {
            return userDAL.insertLanguage(lang);
        }
        public Task<List<Language>> GetAllLanguages()
        {
            return userDAL.GetAllLanguages();
        }


    }
}