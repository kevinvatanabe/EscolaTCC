using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EscolaTCC.Models
{
    public class EscolaTCCContext : DbContext
    {
        public EscolaTCCContext (DbContextOptions<EscolaTCCContext> options)
            : base(options)
        {
        }

        public DbSet<EscolaTCC.Models.Aluno> Aluno { get; set; }
    }
}
