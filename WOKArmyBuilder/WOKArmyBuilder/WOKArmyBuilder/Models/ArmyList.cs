using System;
using System.Collections.Generic;
using System.Text;

namespace WOKArmyBuilder.Models
{
    public class ArmyList
    {
        public string Name { get; set; }
        public string Faction { get; set; }
        public int ArmyPoints { get; set; }
        public string ArmySize { get; set; }
        public List<ArmyListItem> ArmyListItems { get; set; }
    }
}
