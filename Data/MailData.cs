using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mail_marketing.Data
{
    [Table("MailData")]
    public class MailData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get ; set; }

        // Receiver
        [Required, MaxLength(100)]
        public string To { get; set; }

        [MaxLength(100)]
        public string? Bcc { get; set; }

        [MaxLength(100)]
        public string? Cc { get; set; }

        // Sender
        [Required, MaxLength(100)]
        public string From { get; set; }

        // Content
        [Required, MaxLength(100)]
        public string Subject { get; set; }

        [Required, MaxLength(10000)]
        public string Body { get; set; }

        // Status
        [Required, DefaultValue(false)]
        public bool Sent { get; set; }
    }
}