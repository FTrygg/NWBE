using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screencap
{
    public partial class NWBE : Form
    {
        public void SetupUI()
        {
            ouputFolderBrowser.SelectedPath = AppContext.BaseDirectory;
            this.linkLabel1.Text = this.ouputFolderBrowser.SelectedPath;


            this.weapon1Combobox.Items.Clear();
            this.weapon2Combobox.Items.Clear();

            foreach (var item in weapons)
            {
                this.weapon1Combobox.Items.Add(item.name);
                this.weapon2Combobox.Items.Add(item.name);
            }

        }
        public void UpdateComboboxes(ComboBox sender)
        {
            ComboBox boxToUpdate = sender == this.weapon2Combobox ? this.weapon1Combobox : this.weapon2Combobox;
            boxToUpdate.Items.Remove(sender.GetItemText(sender.SelectedItem));
            foreach (var item in weapons)
            {
                if (item.name != sender.GetItemText(sender.SelectedItem) && !boxToUpdate.Items.Contains(item.name))
                {
                    boxToUpdate.Items.Add(item.name);
                }
            }
        }
    }
}