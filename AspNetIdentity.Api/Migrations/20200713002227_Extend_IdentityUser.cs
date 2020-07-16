using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetIdentity.Api.Migrations
{
    public partial class Extend_IdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "NombreEmpresa",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreEmpresa",
                table: "AspNetUsers");

           
        }
    }
}
