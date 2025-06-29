using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefMenu.Infrastructure.Scripts;

public class ScriptMigration : Migration
{
    private readonly string[] _scriptNames;

    public ScriptMigration(string firstScriptName, params string[] additionalScriptNames)
    {
        _scriptNames = [firstScriptName, ..additionalScriptNames];
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        foreach (var scriptName in _scriptNames)
        {
            using var sqlStream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream($"{typeof(ScriptMigration).Namespace}.{scriptName}.sql");

            using var streamReader = new StreamReader(sqlStream!);

            migrationBuilder.Sql(streamReader.ReadToEnd());
        }
    }
}