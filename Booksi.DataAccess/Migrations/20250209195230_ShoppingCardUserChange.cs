using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booksi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCardUserChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCards_AspNetUsers_ApplicationUserId",
                table: "ShoppingCards");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "ShoppingCards",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCards_ApplicationUserId",
                table: "ShoppingCards",
                newName: "IX_ShoppingCards_AppUserId");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Hitler boasted that The Third Reich would last a thousand years. It lasted only 12.\r\n                        But those 12 years contained some of the most catastrophic events Western civilization has ever known.\r\n                        No other powerful empire ever bequeathed such mountains of evidence about its birth and destruction as the Third Reich.\r\n                        When the bitter war was over, and before the Nazis could destroy their files, the Allied demand for unconditional surrender produced an\r\n                        almost hour-by-hour record of the nightmare empire built by Adolph Hitler. This record included the testimony of Nazi\r\n                        leaders and of concentration camp inmates, the diaries of officials, transcripts of secret conferences, army orders,\r\n                        private letters—all the vast paperwork behind Hitler's drive to conquer the world. \r\n                        The famed foreign correspondent and historian William L. Shirer, who had watched and reported on the Nazis since 1925, \r\n                        spent five and a half years sifting through this massive documentation. The result is a monumental study that has been widely \r\n                        acclaimed as the definitive record of one of the most frightening chapters in the history of mankind.\r\n                        This worldwide bestseller has been acclaimed as the definitive book on Nazi Germany; it is a classic work.\r\n                        The accounts of how the United States got involved and how Hitler used Mussolini and Japan are astonishing, and the \r\n                        coverage of the war-from Germany's early successes to her eventual defeat-is must reading.");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCards_AspNetUsers_AppUserId",
                table: "ShoppingCards",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCards_AspNetUsers_AppUserId",
                table: "ShoppingCards");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "ShoppingCards",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCards_AppUserId",
                table: "ShoppingCards",
                newName: "IX_ShoppingCards_ApplicationUserId");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Hitler boasted that The Third Reich would last a thousand years. It lasted only 12.\n                        But those 12 years contained some of the most catastrophic events Western civilization has ever known.\n                        No other powerful empire ever bequeathed such mountains of evidence about its birth and destruction as the Third Reich.\n                        When the bitter war was over, and before the Nazis could destroy their files, the Allied demand for unconditional surrender produced an\n                        almost hour-by-hour record of the nightmare empire built by Adolph Hitler. This record included the testimony of Nazi\n                        leaders and of concentration camp inmates, the diaries of officials, transcripts of secret conferences, army orders,\n                        private letters—all the vast paperwork behind Hitler's drive to conquer the world. \n                        The famed foreign correspondent and historian William L. Shirer, who had watched and reported on the Nazis since 1925, \n                        spent five and a half years sifting through this massive documentation. The result is a monumental study that has been widely \n                        acclaimed as the definitive record of one of the most frightening chapters in the history of mankind.\n                        This worldwide bestseller has been acclaimed as the definitive book on Nazi Germany; it is a classic work.\n                        The accounts of how the United States got involved and how Hitler used Mussolini and Japan are astonishing, and the \n                        coverage of the war-from Germany's early successes to her eventual defeat-is must reading.");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCards_AspNetUsers_ApplicationUserId",
                table: "ShoppingCards",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
