using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screencap
{
    public partial class NWBE : Form
    {
        private Weapon[] selectedWeapons = new Weapon[2];
        private List<Weapon> weapons = new List<Weapon>();
        private List<Equipment> equipmentSlots = new List<Equipment>();

        public class Weapon
        {
            public string name { get; set; }
            public Point masteryCoordinates { get; set; }
            public Weapon(string name, Point point)
            {
                this.name = name;
                this.masteryCoordinates = point;
            }
        }
        public class Equipment
        {
            public string name { get; set; }
            public Point inventoryCoordinates { get; set; }
            public Equipment(string name, Point point)
            {
                this.name = name;
                this.inventoryCoordinates = point;
            }
        }

        private void InitializeWeapons()
        {
            weapons.Add(new Weapon("Hatchet", new Point(0, 0)));
            weapons.Add(new Weapon("Hammer", new Point(0, 0)));
            weapons.Add(new Weapon("Bow", new Point(0, 0)));
            weapons.Add(new Weapon("Life staff", new Point(0, 0)));
            weapons.Add(new Weapon("Void gauntlet", new Point(0, 0)));
            weapons.Add(new Weapon("Musket", new Point(0, 0)));
            weapons.Add(new Weapon("Great sword", new Point(0, 0)));
            weapons.Add(new Weapon("Great Axe", new Point(0, 0)));
            weapons.Add(new Weapon("Ice gauntlet", new Point(0, 0)));
            weapons.Add(new Weapon("Spear", new Point(0, 0)));
            weapons.Add(new Weapon("Blunderbuss", new Point(0, 0)));
            weapons.Add(new Weapon("Firestaff", new Point(0, 0)));
        }
        private void InitializeEquipmentslots()
        {
            equipmentSlots.Add(new Equipment("Helmet", new Point(0,0)));
        }
    }
}
