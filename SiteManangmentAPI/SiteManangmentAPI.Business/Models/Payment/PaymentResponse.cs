﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManangmentAPI.Application.Models;

public class PaymentResponse
{
    public int Id { get; set; }
    public int UserID { get; set; }
    public int BillingID { get; set; }
    public decimal PaidAmount { get; set; }
    public string PaymentMethod { get; set; }
}
