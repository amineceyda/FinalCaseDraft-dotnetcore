namespace SiteManangmentAPI.Application.Models;

public class BillingResponse
{
    public int Id { get; set; }
    public string ApartmentNumber { get; set; } // Use "ApartmentNumber" instead of "ApartmentID"
    public DateTime BillingDate { get; set; }
    public decimal BillAmount { get; set; }
    public decimal RentAmount { get; set; }
}
