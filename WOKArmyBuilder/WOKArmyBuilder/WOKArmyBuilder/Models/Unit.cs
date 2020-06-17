using System;
using System.Collections.Generic;
using System.Text;

namespace WOKArmyBuilder.Models
{
    public class Unit
    {
        // Basic info
        public string Name { get; set; }
        public string Faction { get; set; }
        public string Trait { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public bool Character { get; set; }
        public char DeploymentZone { get; set; }

        // Size info
        public int Base { get; set; }
        public int Size { get; set; }
    }
}
