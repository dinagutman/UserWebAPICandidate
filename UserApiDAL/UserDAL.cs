using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace UserApiDAL
{
    public class UserDAL : IUserDAL
    {
        public async Task<bool>? insertCandidates(Candidates value)
        {
            try
            {
                using (var db = new CandidatesContext())
                {

                    var language = value.languagesCodes.ToList();
                    value.languagesCodes = new List<Language>();
                    db.candidates.Add(value);
                    db.SaveChanges();
                    var candidate = db.candidates.OrderBy(b => b.candidateId).Last();
                    candidate.languagesCodes = new List<Language>();
                    language.ForEach(element =>
                    {
                        candidate.languagesCodes.Add(element);

                    });
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool>? insertLanguage(Language lang)
        {
            try
            {
                using (var db = new CandidatesContext())
                {
                    db.language.Add(lang);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;


            }
        }
        public async Task<List<Candidates>>? getAllCandidates()
        {
            try
            {
                using (var db = new CandidatesContext())
                {
                    var candidateList = db.candidates.Select(x =>
                              new Candidates()
                              {
                                  candidateId = x.candidateId,
                                  name = x.name,
                                  lastUpdateDate = x.lastUpdateDate,
                                  beginYear = x.beginYear,
                                  languagesCodes = x.languagesCodes.ToList()
                              }

                    ).ToList();

                    return candidateList;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<List<Language>>? GetAllLanguages()
        {
            try
            {
                using (var db = new CandidatesContext())
                {

                    var check = db.language.ToList();
                    return check;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


    }
}
