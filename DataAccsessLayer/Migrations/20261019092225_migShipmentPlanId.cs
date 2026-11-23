
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    public partial class migShipmentPlanId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Eski Foreign Key varsa kaldır.
            migrationBuilder.Sql(@"
                IF EXISTS (
                    SELECT 1
                    FROM sys.foreign_keys
                    WHERE name = 'FK_Db_ShipmentOrderPlan_Db_DailyShipmentPlan_DailyShipmentPlansRecId'
                      AND parent_object_id = OBJECT_ID('dbo.Db_ShipmentOrderPlan')
                )
                BEGIN
                    ALTER TABLE dbo.Db_ShipmentOrderPlan
                    DROP CONSTRAINT FK_Db_ShipmentOrderPlan_Db_DailyShipmentPlan_DailyShipmentPlansRecId;
                END
            ");

            // Eski indeks varsa kaldır.
            migrationBuilder.Sql(@"
                IF EXISTS (
                    SELECT 1
                    FROM sys.indexes
                    WHERE name = 'IX_Db_ShipmentOrderPlan_DailyShipmentPlansRecId'
                      AND object_id = OBJECT_ID('dbo.Db_ShipmentOrderPlan')
                )
                BEGIN
                    DROP INDEX IX_Db_ShipmentOrderPlan_DailyShipmentPlansRecId
                    ON dbo.Db_ShipmentOrderPlan;
                END
            ");

            // Eski kolon varsa kaldır.
            migrationBuilder.Sql(@"
                IF COL_LENGTH('dbo.Db_ShipmentOrderPlan', 'DailyShipmentPlansRecId') IS NOT NULL
                BEGIN
                    ALTER TABLE dbo.Db_ShipmentOrderPlan
                    DROP COLUMN DailyShipmentPlansRecId;
                END
            ");

            // Eski ShipmentPlanId varsa yeni isme dönüştür.
            migrationBuilder.Sql(@"
                IF COL_LENGTH('dbo.Db_ShipmentOrderPlan', 'ShipmentPlanId') IS NOT NULL
                   AND COL_LENGTH('dbo.Db_ShipmentOrderPlan', 'DailyShipmentPlanId') IS NULL
                BEGIN
                    EXEC sp_rename
                        'dbo.Db_ShipmentOrderPlan.ShipmentPlanId',
                        'DailyShipmentPlanId',
                        'COLUMN';
                END
            ");

            // Yeni kolon yoksa oluştur.
            migrationBuilder.Sql(@"
                IF COL_LENGTH('dbo.Db_ShipmentOrderPlan', 'DailyShipmentPlanId') IS NULL
                BEGIN
                    ALTER TABLE dbo.Db_ShipmentOrderPlan
                    ADD DailyShipmentPlanId int NOT NULL
                        CONSTRAINT DF_Db_ShipmentOrderPlan_DailyShipmentPlanId
                        DEFAULT (0);
                END
            ");

            migrationBuilder.Sql(@"
                IF NOT EXISTS (
                    SELECT 1
                    FROM sys.indexes
                    WHERE name = 'IX_Db_ShipmentOrderPlan_DailyShipmentPlanId'
                      AND object_id = OBJECT_ID('dbo.Db_ShipmentOrderPlan')
                )
                BEGIN
                    CREATE INDEX IX_Db_ShipmentOrderPlan_DailyShipmentPlanId
                    ON dbo.Db_ShipmentOrderPlan(DailyShipmentPlanId);
                END
            ");

            migrationBuilder.Sql(@"
                IF NOT EXISTS (
                    SELECT 1
                    FROM sys.foreign_keys
                    WHERE name = 'FK_Db_ShipmentOrderPlan_Db_DailyShipmentPlan_DailyShipmentPlanId'
                      AND parent_object_id = OBJECT_ID('dbo.Db_ShipmentOrderPlan')
                )
                BEGIN
                    ALTER TABLE dbo.Db_ShipmentOrderPlan
                    ADD CONSTRAINT FK_Db_ShipmentOrderPlan_Db_DailyShipmentPlan_DailyShipmentPlanId
                    FOREIGN KEY (DailyShipmentPlanId)
                    REFERENCES dbo.Db_DailyShipmentPlan(RecId);
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Db_ShipmentOrderPlan_Db_DailyShipmentPlan_DailyShipmentPlanId",
                table: "Db_ShipmentOrderPlan");

            migrationBuilder.DropIndex(
                name: "IX_Db_ShipmentOrderPlan_DailyShipmentPlanId",
                table: "Db_ShipmentOrderPlan");

            migrationBuilder.RenameColumn(
                name: "DailyShipmentPlanId",
                table: "Db_ShipmentOrderPlan",
                newName: "ShipmentPlanId");

            migrationBuilder.AddColumn<int>(
                name: "DailyShipmentPlansRecId",
                table: "Db_ShipmentOrderPlan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Db_ShipmentOrderPlan_DailyShipmentPlansRecId",
                table: "Db_ShipmentOrderPlan",
                column: "DailyShipmentPlansRecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_ShipmentOrderPlan_Db_DailyShipmentPlan_DailyShipmentPlansRecId",
                table: "Db_ShipmentOrderPlan",
                column: "DailyShipmentPlansRecId",
                principalTable: "Db_DailyShipmentPlan",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
