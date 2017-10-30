using System.Data.Entity;

namespace Web.Models.Contexto
{
    public class MeuContexto : DbContext
    {
        public MeuContexto() : base("strConnT")
        {

        }
        public System.Data.Entity.DbSet<Web.Models.Item> Items { get; set; }
    }
}