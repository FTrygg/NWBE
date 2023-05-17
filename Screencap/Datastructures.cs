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
            //static 
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
            public static Point pictureAreaDimensions = new Point(359, 647);
            public string name { get; set; }
            public Point inventoryCoordinates { get; set; }
            public Rectangle pictureArea { get; set; }
            public Equipment(string name, Point point, Rectangle pictureArea)
            {
                this.name = name;
                this.inventoryCoordinates = point;
                this.pictureArea = pictureArea;
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
            equipmentSlots.Add(new Equipment("Weapon1", new Point(860, 114), new Rectangle(1088, 113, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            equipmentSlots.Add(new Equipment("Weapon2", new Point(860, 179), new Rectangle(1088, 179, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            equipmentSlots.Add(new Equipment("Rune", new Point(860, 260), new Rectangle(1088, 260, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));

            equipmentSlots.Add(new Equipment("Helmet", new Point(365,114), new Rectangle(592,113, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            equipmentSlots.Add(new Equipment("Chest", new Point(365, 180), new Rectangle(592, 179, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            equipmentSlots.Add(new Equipment("Gloves", new Point(365, 240), new Rectangle(592, 239, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            equipmentSlots.Add(new Equipment("Pants", new Point(365, 300), new Rectangle(592, 299, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            equipmentSlots.Add(new Equipment("Shoes", new Point(365, 360), new Rectangle(592, 359, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            
            equipmentSlots.Add(new Equipment("Amulet", new Point(365, 608), new Rectangle(592, 1079 - Equipment.pictureAreaDimensions.Y, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            equipmentSlots.Add(new Equipment("Ring", new Point(365, 670), new Rectangle(592, 1079 - Equipment.pictureAreaDimensions.Y, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            equipmentSlots.Add(new Equipment("Earring", new Point(365, 731), new Rectangle(592, 1079 - Equipment.pictureAreaDimensions.Y, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
        }
    }
}
