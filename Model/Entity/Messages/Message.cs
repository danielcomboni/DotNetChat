using DotNetChatApp.Model.Entity.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetChatApp.Model.Entity.Messages
{
    public class Message
    {
        public long Id { get; set; }
        
        public long SenderId { get; set; }
        public virtual User Sender { get; set; }
        
        public long RecipientId { get; set; }
        public virtual User Recipient { get; set; }
        public string TheMessage { get; set; }
        public DateTime TheDateAndTime { get; set; }
    }
}
