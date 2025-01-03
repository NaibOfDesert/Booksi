using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booksi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Books : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ExtraPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ExtraPrice", "ISBN", "Price", "Title" },
                values: new object[] { 1, "William L. Shirer", "Hitler boasted that The Third Reich would last a thousand years. It lasted only 12.\n                        But those 12 years contained some of the most catastrophic events Western civilization has ever known.\n                        No other powerful empire ever bequeathed such mountains of evidence about its birth and destruction as the Third Reich.\n                        When the bitter war was over, and before the Nazis could destroy their files, the Allied demand for unconditional surrender produced an\n                        almost hour-by-hour record of the nightmare empire built by Adolph Hitler. This record included the testimony of Nazi\n                        leaders and of concentration camp inmates, the diaries of officials, transcripts of secret conferences, army orders,\n                        private letters—all the vast paperwork behind Hitler's drive to conquer the world. \n                        The famed foreign correspondent and historian William L. Shirer, who had watched and reported on the Nazis since 1925, \n                        spent five and a half years sifting through this massive documentation. The result is a monumental study that has been widely \n                        acclaimed as the definitive record of one of the most frightening chapters in the history of mankind.\n                        This worldwide bestseller has been acclaimed as the definitive book on Nazi Germany; it is a classic work.\n                        The accounts of how the United States got involved and how Hitler used Mussolini and Japan are astonishing, and the \n                        coverage of the war-from Germany's early successes to her eventual defeat-is must reading.", 80.0, 9780330700016.0, 100.0, "The Rise and Fall of the Third Reich: A History of Nazi Germany" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
