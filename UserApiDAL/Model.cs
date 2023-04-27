using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CandidatesContext : DbContext
{
    public DbSet<Candidates> candidates { get; set; }
    public DbSet<Language> language { get; set; }

    public string DbPath { get; }

    public CandidatesContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = "D:\\OzTest\\UserWebAPICandidate\\UserApiDAL\\CandidatesDB\\Candidate.db";
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Candidates
{ 
    private int _candidateId;
    [Key]
    public int candidateId
    {
        get { return _candidateId; }
        set { _candidateId = value; }
    }
    public string? name { get; set; }
    public DateTime? beginYear { get; set; }
    public DateTime? lastUpdateDate { get; set; }
   
    public List<Language>? languagesCodes { get; set; } 
}

public class Language
{

    public int languageId { get; set; }
    public string name { get; set; }
    public List<Candidates>? candidates { get; set; }

}