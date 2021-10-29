using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infra.Data.Migrations
{
    public partial class UpdateCategory : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categories(ID,Name,DATA_CADASTRO) VALUES('fdc220d5-80fb-4f58-99cf-5b9bf5b37aac','Material Escolar',GETDATE())");
            mb.Sql("INSERT INTO Categories(ID,Name,DATA_CADASTRO) VALUES('7625f6eb-78b3-4e61-9479-8e203c672aa8','Eletrônicos',GETDATE())");
            mb.Sql("INSERT INTO Categories(ID,Name,DATA_CADASTRO) VALUES('cbbeb8e3-7a47-459a-950a-67ba434188a0','Acessórios',GETDATE())");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Categories ");
        }
    }
}
