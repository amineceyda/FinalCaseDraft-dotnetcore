using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManangmentAPI.Application.Models;

public class MessageResponse
{
    public int Id { get; set; }
    public int SenderUserID { get; set; }
    public int ReceiverUserID { get; set; }
    public string MessageContent { get; set; }
    public bool IsRead { get; set; }
}
