using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyTrack.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteOperationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperationType",
                table: "Operation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperationType",
                table: "Operation",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
