using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Article.Ef.Migrations
{
    public partial class seedingRoleAndCatagory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "User", "User".ToUpper(), Guid.NewGuid().ToString() }

                );
            migrationBuilder.InsertData(table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] {Guid.NewGuid().ToString(),"Admin","Admin".ToUpper(),Guid.NewGuid().ToString() }   

                );


            migrationBuilder.InsertData(table: "Catagories",
                columns: new[] { "CatigoryId", "CatigoryName" },
                values: new object[] { Guid.NewGuid().ToString(),"Art" }

                );


            migrationBuilder.InsertData(table: "Catagories",
            columns: new[] { "CatigoryId", "CatigoryName" },
            values: new object[] { Guid.NewGuid().ToString(), "Sport" }
            );

            migrationBuilder.InsertData(table: "Catagories",
            columns: new[] { "CatigoryId", "CatigoryName" },
            values: new object[] { Guid.NewGuid().ToString(), "Cars" }
             );

                
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
