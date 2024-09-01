using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bangazon.Migrations
{
    /// <inheritdoc />
    public partial class FixSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Check if column exists before renaming it
            migrationBuilder.Sql(@"
        DO $$
        BEGIN
            IF EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'ProductItems' AND column_name = 'SellerId') THEN
                ALTER TABLE ""ProductItems"" RENAME COLUMN ""SellerId"" TO ""UserId"";
            END IF;
        END
        $$;");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_UserId",
                table: "ProductItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Users_UserId",
                table: "ProductItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop foreign key if it exists
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Users_UserId",
                table: "ProductItems");

            // Drop index if it exists
            migrationBuilder.DropIndex(
                name: "IX_ProductItems_UserId",
                table: "ProductItems");

            // Rename column if it exists
            migrationBuilder.Sql(@"
        DO $$
        BEGIN
            IF EXISTS (SELECT 1 FROM information_schema.columns WHERE table_name = 'ProductItems' AND column_name = 'UserId') THEN
                ALTER TABLE ""ProductItems"" RENAME COLUMN ""UserId"" TO ""SellerId"";
            END IF;
        END
        $$;");
        }
    }
}
