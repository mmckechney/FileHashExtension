using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using SharpShell.SharpContextMenu;
using System.Windows.Forms;
using System.Drawing;
using SharpShell.Attributes;
namespace FileHashExtension
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.AllFiles)]
    public class FileHashContextMenu : SharpContextMenu
    {
        protected override bool CanShowMenu()
        {
            return true;
        }

        protected override System.Windows.Forms.ContextMenuStrip CreateMenu()
        {
            //  Create the menu strip.
            var menu = new ContextMenuStrip();

            //  Create a 'count lines' item.
            var itemCalculateHash = new ToolStripMenuItem
            {
                Text = "Calculate File Hash",
                Image = Properties.Resources.Puzzle
            };


            var itemSHA1 = new ToolStripMenuItem
            {
                Text = "SHA-1",
            };
            itemSHA1.Click += (sender, args) => OpenShellForm(HashHelper.HashType.SHA1);
            var itemMD5 = new ToolStripMenuItem
            {
                Text = "MD5"
            };
            itemMD5.Click += (sender, args) => OpenShellForm(HashHelper.HashType.MD5);

            var itemSHA256 = new ToolStripMenuItem
            {
                Text = "SHA-256"
            };
            itemSHA256.Click += (sender, args) => OpenShellForm(HashHelper.HashType.SHA256);

            var itemSHA384 = new ToolStripMenuItem
            {
                Text = "SHA-384"
            };
            itemSHA384.Click += (sender, args) => OpenShellForm(HashHelper.HashType.SHA384);

            var itemSHA512 = new ToolStripMenuItem
            {
                Text = "SHA-512"
            };
            itemSHA512.Click += (sender, args) => OpenShellForm(HashHelper.HashType.SHA512);

            var itemRIPEMD160 = new ToolStripMenuItem
            {
                Text = "RIPEMD-160"
            };
            itemRIPEMD160.Click += (sender, args) => OpenShellForm(HashHelper.HashType.RIPEMD160);

            
            itemCalculateHash.DropDownItems.Add(itemMD5);
            itemCalculateHash.DropDownItems.Add(itemSHA1);
            itemCalculateHash.DropDownItems.Add(itemSHA256);
            itemCalculateHash.DropDownItems.Add(itemSHA384);
            itemCalculateHash.DropDownItems.Add(itemSHA512);
            itemCalculateHash.DropDownItems.Add(itemRIPEMD160);

            //  Add the item to the context menu.
            menu.Items.Add(itemCalculateHash);

            //  Return the menu.
            return menu;
        }

        public void OpenShellForm(HashHelper.HashType hashType)
        {
            var frm = new ShellForm(SelectedItemPaths.ToList(), hashType);
            frm.Show();
        }
    }
}
