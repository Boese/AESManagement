using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AESManagement.Models
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Question")]
        [DataType(DataType.MultilineText)]
        public string Question { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Correct Answer")]
        public string Answer { get; set; }
    }
}