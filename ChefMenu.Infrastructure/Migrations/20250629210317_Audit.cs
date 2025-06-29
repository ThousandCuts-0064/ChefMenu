using ChefMenu.Infrastructure.Scripts;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChefMenu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Audit : ScriptMigration
    {
        public Audit() : base("Audit") { }
    }
}
