using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteManangmentAPI.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username", "PasswordHash", "PasswordSalt", "UserType", "FirstName", "LastName", "Email", "TCNo", "VehiclePlateNumber", "IsActive", "InsertTime" },
                values: new object[,]
                {
                    { 1, "john458", "0x6FEBFFC22EE19BEA060554E4D15F33B669BB55BE29B21BBA73A03CD16A8C62D19D8BFB4900ECA74298659A2103CCEF8DE9E22D4AE45F44E3C446084193250ECF", "0x3A879749918A46D383931B03405E91CAADF445AE6327881D14744C290FBDF11F6AD515CDF6AD4B9F5BC70934629298E6D62BC44F43BE2647679F6056356CEBDF1A98B0D9208F94041BE054DDBDCA777F280F141BE3955831AB972386B63F785B6AACA6ABB22D2064671245AF7D43E398413A302376A8B8C76DED6DBBCAF98B5F", 1, "John", "Wick", "doglover@gmail.com", "52487963258", "87965", true, "2023-08-10 07:42:14.3247462" },
                    { 2, "Rdj", "0x67AF3DFF65DD0DC2503CBF257D945B5A9DC2DAEBEE4969DA96286BBABE8DFCDC879DEB7CC1B6202430B93CABC1341B440F23C73A72711D9341BC295EB176C2B4", "0xA92EB8572CD750D5BD11E84438737931E8E05E5EC873E2D989D1BF094422736200869168D3149273C5B6B371EFDF15DF6B704700091D8268A0C1B06D345BFC1BE629193480C6F8A1A94B679765A84081AF1504759F6AD044A8F0A0789723C08FB2F39857B630A7B25D10810BD7E8F05939F59D307D89C90E579A873CE58A3A9D", 2, "tony", "stark", "ıronman@gmail.com", "5215879635", "35we89", true, "2023-08-10 07:45:12.4707670" }
                });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "OwnerUserID", "TenantUserID", "Block", "Status", "Type", "Floor", "ApartmentNumber", "InsertTime" },
                values: new object[,]
                {
                    { 1, 1, 2, "block2", 1, 2, 3, "123", "2023-08-10 07:46:22.0373033" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
        }
    }
}
