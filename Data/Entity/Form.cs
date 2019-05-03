using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity
{
    public class Form
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public int CreatedBy { get; set; }
    }
}
