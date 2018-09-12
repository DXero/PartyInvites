using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace PartyInvites.Models
{
    public class DatoContexto : DbContext
    {
        public DatoContexto(DbContextOptions<DatoContexto> options) : base(options)
        {

        }

        public DbSet<InvitadoRespuesta> Respuestas { get; set; }
    }
}
