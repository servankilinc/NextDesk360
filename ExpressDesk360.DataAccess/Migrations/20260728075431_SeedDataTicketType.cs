using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpressDesk360.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataTicketType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TicketStatus",
                columns: new[] { "Id", "CreateDateUtc", "CreatedBy", "DeletedBy", "DeletedDateUtc", "Description", "IsDeleted", "Name", "UpdateDateUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Yeni açılan ve atanma bekleyen talepler", false, "Yeni Kayıt", null, null },
                    { 2, null, null, null, null, "Personel atanmış ve işlem süreci devam eden talepler", false, "İşlemde", null, null },
                    { 3, null, null, null, null, "Kargo veya parça bekleyen talepler", false, "Beklemede", null, null },
                    { 4, null, null, null, null, "Yönetici veya müşteri onayı bekleyen talepler", false, "Onay Bekleniyor", null, null },
                    { 5, null, null, null, null, "İptal edilen ve işlem yapılmayan talepler", false, "İptal Edildi", null, null },
                    { 6, null, null, null, null, "Çözümlenmiş ve kapatılmış talepler", false, "Tamamlandı", null, null }
                });

            migrationBuilder.InsertData(
                table: "TicketMovementType",
                columns: new[] { "Id", "Accessible", "Color", "CreateDateUtc", "CreatedBy", "DeletedBy", "DeletedDateUtc", "Description", "InformationText", "IsDeleted", "Name", "TicketStatusId", "UpdateDateUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, "#3699FF", null, null, null, null, null, "Talep ilk kez açıldı.", false, "Yeni Kayıt", 1, null, null },
                    { 2, true, "#8950FC", null, null, null, null, null, "Talebe temsilci atandı.", false, "Temsilci Atandı", 2, null, null },
                    { 3, true, "#FFA800", null, null, null, null, null, "Teknik servise yönlendirme yapıldı.", false, "Teknik Hizmetlere Yönlendirildi", 2, null, null },
                    { 4, true, "#1BC5BD", null, null, null, null, null, "Arıza tespiti tamamlandı.", false, "Arıza Tespiti Yapıldı", 2, null, null },
                    { 5, true, "#F64E60", null, null, null, null, null, "Kargo teslimatı bekleniyor.", false, "Kargo Bekleniyor", 3, null, null },
                    { 6, true, "#E4E6EF", null, null, null, null, null, "Yedek parça bekleniyor.", false, "Parça Bekleniyor", 3, null, null },
                    { 7, true, "#3699FF", null, null, null, null, null, "Kargo gönderimi yapıldı.", false, "Kargo Gönderildi", 3, null, null },
                    { 8, true, "#FFA800", null, null, null, null, null, "Yönetici onayı bekleniyor.", false, "Müdür Onayı Bekleniyor", 4, null, null },
                    { 9, true, "#F64E60", null, null, null, null, null, "Müşteri ücret onayı bekleniyor.", false, "Ücret Onayı Bekleniyor", 4, null, null },
                    { 10, true, "#1BC5BD", null, null, null, null, null, "Onay alındı, işleme devam ediliyor.", false, "Onay Alındı", 2, null, null },
                    { 11, true, "#3F4254", null, null, null, null, null, "Talep iptal edildi.", false, "İptal Edildi", 5, null, null },
                    { 12, true, "#1BC5BD", null, null, null, null, null, "Talep tamamlandı ve kapatıldı.", false, "Tamamlandı", 6, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TicketMovementType",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TicketStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TicketStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TicketStatus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TicketStatus",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
