﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManangmentAPI.Application.Models;


public class ContactResponse
{
    public int Id { get; set; }
    public int UserID { get; set; }
    public string ContactName { get; set; }
    public string ContactPhone { get; set; }
    public string ContactEmail { get; set; }
}
