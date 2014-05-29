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
        public string Question { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Correct Answer")]
        [MaxLength(1)]
        [RegularExpression(@"[yn]{1,1}$", ErrorMessage = "Answer must be y or n")]
        public string Answer { get; set; }
    }
}