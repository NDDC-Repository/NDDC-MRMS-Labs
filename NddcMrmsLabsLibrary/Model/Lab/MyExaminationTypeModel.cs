using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLabsLibrary.Model.Lab
{
    public class MyExaminationTypeModel
    {
        public int Id { get; set; }
        public int ExaminationCategoryId { get; set; }
        public string ExaminationType { get; set; }
    }
}
