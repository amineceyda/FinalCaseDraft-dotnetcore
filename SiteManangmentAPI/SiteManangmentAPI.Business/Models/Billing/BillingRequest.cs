using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManangmentAPI.Application.Models;

public class BillingRequest
{
    public int ApartmentID { get; set; }
    public DateTime BillingDate { get; set; }
    public decimal BillAmount { get; set; }
    public decimal RentAmount { get; set; }
}
