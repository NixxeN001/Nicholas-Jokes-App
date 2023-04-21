using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nicholas_Jokes_App.Data.Migrations
{
    public partial class jokeSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JokesContain",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JokeAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JokeQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JokesContain", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JokesContain");
        }
    }
}
