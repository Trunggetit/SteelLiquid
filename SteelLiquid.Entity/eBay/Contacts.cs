using System;
using System.Collections.Generic;
using System.Text;

namespace SteelLiquid.Entity.MTG
{
    public class Contacts
    {
        public int Id { get; set; }
        public string CardID { get; set; }
        public int CardCondition { get; set; }
        public string DateAdded { get; set; }
        public string DateModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
