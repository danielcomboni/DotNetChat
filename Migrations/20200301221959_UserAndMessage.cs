using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetChatApp.Migrations
{
    public partial class UserAndMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(128)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", nullable: false),
                    MessageId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<long>(nullable: false),
                    RecipientId = table.Column<long>(nullable: false),
                    the_message = table.Column<string>(type: "text", nullable: false),
                    date_time = table.Column<DateTime>(type: "datetime DEFAULT GETDATE()", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_messages_users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_messages_users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_messages_RecipientId",
                table: "messages",
                column: "RecipientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_messages_SenderId",
                table: "messages",
                column: "SenderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_MessageId",
                table: "users",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_messages_MessageId",
                table: "users",
                column: "MessageId",
                principalTable: "messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messages_users_RecipientId",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_users_SenderId",
                table: "messages");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "messages");
        }
    }
}
