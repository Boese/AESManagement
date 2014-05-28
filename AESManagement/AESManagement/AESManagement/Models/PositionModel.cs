using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AESManagement.Models
{
    public class PositionModel
    {
        [DisplayName("Position #")]
        public int Id { get; set; }

        [DisplayName("Position Title")]
        public string Title { get; set; }

        [DisplayName("Requirements")]
        public string Requirements { get; set; }

        [DisplayName("Education")]
        public string Education { get; set; }

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Hourly Pay")]
        public string Pay { get; set; }
    }
}