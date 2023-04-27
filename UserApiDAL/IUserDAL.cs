using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApiDAL
{
    public interface IUserDAL
    {
        Task<List<Candidates>>? getAllCandidates();
        Task<bool>? insertCandidates(Candidates value);
        Task<bool>? insertLanguage(Language lang);
        Task<List<Language>>? GetAllLanguages();

    }
}