using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsurancePremiumInquiry.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Benefits_BenefitRequests_BenefitRequestId1",
                table: "Benefits");

            migrationBuilder.DropIndex(
                name: "IX_Benefits_BenefitRequestId1",
                table: "Benefits");

            migrationBuilder.DropColumn(
                name: "BenefitRequestId1",
                table: "Benefits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BenefitRequestId1",
                table: "Benefits",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_BenefitRequestId1",
                table: "Benefits",
                column: "BenefitRequestId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Benefits_BenefitRequests_BenefitRequestId1",
                table: "Benefits",
                column: "BenefitRequestId1",
                principalTable: "BenefitRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
