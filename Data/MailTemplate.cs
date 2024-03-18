using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mail_marketing.Data
{
    [Table("MailTemplates")]
    public class MailTemplate
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string name { get; set; }

        [Required, MaxLength(10000)] // html content
        public string template { get; set; }
    }
}