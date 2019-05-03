using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity
{
    public class FormField
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
