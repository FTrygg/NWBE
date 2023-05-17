using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screencap
{
    public partial class NWBE : Form
    {
        private List<Weapon> weapons = new List<Weapon>();
        private List<Equipment> equipmentSlots = new List<Equipment>();
        private static Point attributeCoordinates = new Point(564, 166);
        private static Point weaponMasteryCoordinates = new Point(850, 166);

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
            public Rectangle outputArea { get; set; }
            public Equipment(string name, Point point, Rectangle pictureArea, Rectangle outputArea)
            {
                this.name = name;
                this.inventoryCoordinates = point;
                this.pictureArea = pictureArea;
                this.outputArea = outputArea;
            }
        }

        private void InitializeWeapons()
        {
            weapons.Add(new Weapon("Hatchet", new Point(333, 660)));
            weapons.Add(new Weapon("Hammer", new Point(768, 660)));
            weapons.Add(new Weapon("Bow", new Point(1205, 377)));
            weapons.Add(new Weapon("Life staff", new Point(1650, 528)));
            weapons.Add(new Weapon("Void gauntlet", new Point(1650, 783)));
            weapons.Add(new Weapon("Musket", new Point(1205, 528)));
            weapons.Add(new Weapon("Great sword", new Point(768, 783)));
            weapons.Add(new Weapon("Great Axe", new Point(768, 528)));
            weapons.Add(new Weapon("Ice gauntlet", new Point(1650, 660)));
            weapons.Add(new Weapon("Spear", new Point(768, 377)));
            weapons.Add(new Weapon("Blunderbuss", new Point(1205, 660)));
            weapons.Add(new Weapon("Firestaff", new Point(1650, 377)));
            weapons.Add(new Weapon("Sword Shield", new Point(333, 377)));
            weapons.Add(new Weapon("Rapier", new Point(333, 528)));
        }
        private void InitializeEquipmentslots()
        {
            equipmentSlots.Add(new Equipment("Weapon1",
                new Point(860, 114),
                new Rectangle(1088, 113, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y),
                new Rectangle(110, 980, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y))); 
            equipmentSlots.Add(new Equipment("Weapon2",
                new Point(860, 179),
                new Rectangle(1088, 179, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y),
                new Rectangle(544, 980,Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            equipmentSlots.Add(new Equipment("Rune",
                new Point(860, 260),
                new Rectangle(1088, 260, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y+300),
                new Rectangle(2280,175,Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));

            equipmentSlots.Add(new Equipment("Helmet",
                new Point(365,114),
                new Rectangle(592,113, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y),
                new Rectangle(110, 175, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            equipmentSlots.Add(new Equipment("Chest",
                new Point(365, 180),
                new Rectangle(592, 179, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y),
                new Rectangle(544,175,Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            equipmentSlots.Add(new Equipment("Gloves",
                new Point(365, 240),
                new Rectangle(592, 239, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y),
                new Rectangle(978,175,Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            equipmentSlots.Add(new Equipment("Pants",
                new Point(365, 300),
                new Rectangle(592, 299, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y),
                new Rectangle(1412,175,Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            equipmentSlots.Add(new Equipment("Shoes",
                new Point(365, 360),
                new Rectangle(592, 359, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y),
                new Rectangle(1846,175,Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            
            equipmentSlots.Add(new Equipment("Amulet",
                new Point(365, 608),
                new Rectangle(592, 1079 - Equipment.pictureAreaDimensions.Y, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y),
                new Rectangle(978,980,Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            equipmentSlots.Add(new Equipment("Ring",
                new Point(365, 670),
                new Rectangle(592, 1079 - Equipment.pictureAreaDimensions.Y, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y),
                new Rectangle(1412,980, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
            equipmentSlots.Add(new Equipment("Earring",
                new Point(365, 731),
                new Rectangle(592, 1079 - Equipment.pictureAreaDimensions.Y, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y),
                new Rectangle(1846,980, Equipment.pictureAreaDimensions.X, Equipment.pictureAreaDimensions.Y)));
        }

    }
}
