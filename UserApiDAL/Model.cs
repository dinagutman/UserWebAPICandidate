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
    public string currentPath { get; }

    public CandidatesContext()
    {
        currentPath = @"..\UserApiDAL\CandidatesDB\Candidate.db";
    }


    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={currentPath}");
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
