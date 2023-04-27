using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApiDAL;

namespace UserApiBL
{
    public interface IUserBL
    {
        Task<List<Candidates>>? GetAll();
        Task<bool> insertCandidates(Candidates value);
        Task<bool>? insertLanguage(Language lang);
        Task<List<Language>> GetAllLanguages();

    }
}
