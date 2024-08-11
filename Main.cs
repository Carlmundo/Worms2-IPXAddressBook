using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Worms2_IPXAddressBook
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public class DBTableLayoutPanel : TableLayoutPanel
        {
            public DBTableLayoutPanel()
            {
                this.DoubleBuffered = true;
            }
        }

        public static class global
        {
            public static string fileServerlist = "Teams\\IPX.dat";
            public static string charEnabled = "✅";
            public static string selectedPcap = "";
            public static string selectedAddress = "";
            public static string selectedPort = "";
            public static Boolean newEntry = false;
            public static TextBox[] textBoxes = {};
            public static RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\IPXWrapper", true);
            public static string initPcap = key.GetValue("use_pcap").ToString();
            public static string initAddress = key.GetValue("dosbox_server_addr").ToString();
            public static string initPort = key.GetValue("dosbox_server_port").ToString();
            public static Boolean soundReady = false;
            public static System.Media.SoundPlayer sndOption = new System.Media.SoundPlayer(@"Data\Wav\Effects\CrossImpact.wav");
            public static System.Media.SoundPlayer sndNew = new System.Media.SoundPlayer(@"Data\Wav\Effects\SheepBaa.wav");
            public static System.Media.SoundPlayer sndSelect = new System.Media.SoundPlayer(@"Data\Wav\Effects\CrateImpact.wav");
            public static System.Media.SoundPlayer sndSave = new System.Media.SoundPlayer(@"Data\Wav\Speech\yessir.wav");

        }

        private void listAdd(string[] entry)
        {
            try {
                ListViewItem listItem = new ListViewItem();
                listItem.ImageKey = "icon-server";
                listItem.Text = entry[0];
                string enabled = "";
                if (entry.Length > 3 && entry[3] == "1") {
                    enabled = global.charEnabled;
                    global.selectedAddress = entry[1];
                    global.selectedPort = entry[2];
                }
                string[] serverInfo = { entry[1], entry[2], enabled };
                listItem.SubItems.AddRange(serverInfo);
                listServers.Items.Add(listItem);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void resetFields()
        {
            tbName.Text = listServers.SelectedItems[0].Text;
            tbAddress.Text = listServers.SelectedItems[0].SubItems[1].Text;
            tbPort.Text = listServers.SelectedItems[0].SubItems[2].Text;
        }

        private void saveRegChanges()
        {
            global.key.SetValue("use_pcap", 2, RegistryValueKind.DWord);
            global.key.SetValue("dosbox_server_addr", global.selectedAddress);
            global.key.SetValue("dosbox_server_port", global.selectedPort, RegistryValueKind.DWord);
        }
        private void saveFile()
        {
            using (StreamWriter outputFile = new StreamWriter(global.fileServerlist)) {
                foreach (ListViewItem serverItem in listServers.Items) {
                    string serverLine = "";
                    int countSubitem = 0;
                    foreach (ListViewItem.ListViewSubItem subitem in serverItem.SubItems) {
                        if (subitem.Text == global.charEnabled) {
                            serverLine += "1";
                            global.selectedAddress = serverItem.SubItems[1].Text;
                            global.selectedPort = serverItem.SubItems[2].Text;
                        }
                        else {
                            serverLine += subitem.Text;
                        }
                        if (countSubitem < 3) {
                            serverLine += ",";
                        }
                        countSubitem++;
                    }
                    outputFile.WriteLine(serverLine);
                }
                if (global.soundReady) {
                    try { global.sndSave.Play(); }
                    catch { }
                }
            }  
        }
        private void Main_Load(object sender, EventArgs e)
        {
            try {
                var fileLines = File.ReadAllLines(global.fileServerlist);
                Boolean serverSet = false;
                for (var i = 0; i < fileLines.Length; i += 1) {
                    var line = fileLines[i];
                    string[] server = line.Split(',');
                    if (server.Length > 3 && server[3] == "1") {
                        if (serverSet) { //Prevent multiple enabled servers
                            server[3] = "";
                        }
                        else {
                            serverSet = true;
                        }
                    }
                    listAdd(server);
                }
            }
            catch {}
            /*catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            */
            int ipxMode = (int)global.key.GetValue("use_pcap");
            if ( ipxMode == 0) {
                rbLAN.Checked = true;
            }
            else {
                rbOnline.Checked = true;
            }

            if (listServers.Items.Count == 0) {
                listAdd(new string[] { "333networks (Backup)", "dark1.333networks.com", "3000", "1" });
                listAdd(new string[] { "HigHog", "games.highog.com", "10000", "" });
                if (rbOnline.Checked) {
                    saveFile();
                    saveRegChanges();
                }
            }
            else {
                string checkAddress = global.key.GetValue("dosbox_server_addr").ToString();
                string checkPort = global.key.GetValue("dosbox_server_port").ToString();
                //If an enabled server is found in file
                if (global.selectedAddress.Length > 0 && global.selectedPort.Length > 0) {
                    //Set the enabled server in registry if it is not set there
                    if (checkAddress != global.selectedAddress || checkPort != global.selectedPort) {
                        saveRegChanges();
                    }
                }
                else {
                    setTopServer();
                }
            }
            listServers.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            listServers.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent);

            global.textBoxes = new TextBox[] { tbName, tbAddress, tbPort };
            global.soundReady = true;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (listServers.SelectedItems.Count > 0) {
                foreach (ListViewItem serverItem in listServers.Items) {
                    serverItem.SubItems[3].Text = "";
                }
                ListView.SelectedListViewItemCollection serverSelected = listServers.SelectedItems;
                serverSelected[0].SubItems[3].Text = global.charEnabled;
                saveFile();
                saveRegChanges();
            }
        }

        private void listServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listServers.SelectedItems.Count > 0) {
                resetFields();
                if (global.newEntry) {
                    global.newEntry = false;    
                }
                listSelect();
                if (listServers.SelectedItems[0].SubItems[3].Text == global.charEnabled) {
                    btnSet.Enabled = false;
                }
                else {
                    btnSet.Enabled = true;
                }
                
                btnDelete.Enabled = true;
                try { global.sndSelect.Play(); }
                catch { }
                foreach (TextBox tb in global.textBoxes) {
                    tb.Enabled = true;
                }
            }
            else {
                btnSet.Enabled = false;
                foreach (TextBox tb in global.textBoxes) {
                    tb.Text = "";
                    tb.Enabled = false;
                }
                listSelect();
                btnDelete.Enabled = false;
            }
        }
        private void listSelect()
        {
            btnCancel.Text = "Exit";
            btnCancel.Enabled = true;
            btnNew.Enabled = true;
            btnOK.Text = "OK";
            btnOK.Enabled = false;
            global.newEntry = false;
        }
        private void rbLAN_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLAN.Checked) {
                global.selectedPcap = "0";
                btnSet.Visible = false;
                btnExit.Visible = true;
                gbServers.Visible = false;
                tblEdit.Visible = false;
                if (global.soundReady) {
                    try { global.sndOption.Play(); }
                    catch { }
                }
                global.key.SetValue("use_pcap", 0, RegistryValueKind.DWord);
            }
        }

        private void rbOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOnline.Checked) {
                global.selectedPcap = "2";
                btnSet.Visible = true;
                btnExit.Visible = false;
                gbServers.Visible = true;
                tblEdit.Visible = true;
                if (global.soundReady) {
                    try { global.sndOption.Play(); }
                    catch { }
                }
                global.key.SetValue("use_pcap", 2, RegistryValueKind.DWord);
            } 
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try {global.sndNew.Play();}
            catch { }
            listServers.SelectedIndices.Clear();
            global.newEntry = true;
            btnNew.Enabled = false;
            btnCancel.Text = "Cancel";
            btnDelete.Enabled = false;
            btnOK.Text = "Done";
            btnOK.Enabled = false;
            foreach (TextBox tb in global.textBoxes) {
                tb.Text = "";
                tb.Enabled = true;
            }
            tbName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "Cancel") {
                try { global.sndSelect.Play(); }
                catch { }
                if (global.newEntry) {
                    foreach (TextBox tb in global.textBoxes) {
                        tb.Text = "";
                        tb.Enabled = false;
                    }
                }
                else {
                    resetFields();
                }
                listSelect();
            }
            else if (btnCancel.Text == "Exit") {
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try { global.sndSelect.Play(); }
            catch { }
            if (listServers.SelectedItems.Count > 0) {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) {
                    var selected = listServers.SelectedItems[0];
                    Boolean setNew = false;
                    if (selected.SubItems[3].Text == global.charEnabled) {
                        setNew = true;                        
                    }
                    selected.Remove();
                    if (setNew) {
                        setTopServer();
                    }
                    saveFile(); 
                }                
            }
        }
        private void setTopServer()
        {
            if (listServers.Items.Count > 0) {
                var serverTop = listServers.Items[0];
                serverTop.SubItems[3].Text = global.charEnabled;
                global.selectedAddress = serverTop.SubItems[1].Text;
                global.selectedPort = serverTop.SubItems[2].Text;
            }
            else {
                global.selectedAddress = "";
                global.selectedPort = "0";
            }
            saveFile();
            saveRegChanges();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (btnOK.Text == "Update") {
                btnOK.Text = "OK";
                btnNew.Enabled = true;
                btnCancel.Text = "Exit";
                btnOK.Enabled = false;

                var selectedItem = listServers.SelectedItems[0];
                selectedItem.Text = tbName.Text;
                selectedItem.SubItems[1].Text = tbAddress.Text;
                selectedItem.SubItems[2].Text = tbPort.Text;

                saveFile();
            }
            else if (btnOK.Text == "Done") {
                listAdd(new string[] { tbName.Text, tbAddress.Text, tbPort.Text, "" });
                saveFile();
                foreach (TextBox tb in global.textBoxes) {
                    tb.Text = "";
                    tb.Enabled = false;
                }
                btnNew.Enabled = true;
                btnCancel.Text = "Exit";
                btnCancel.Enabled = true;
                btnOK.Enabled = false; 
            }
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Enabled){
                //Remove commas
                if (Regex.IsMatch(tb.Text, "[,]")) {
                    tb.Text = tb.Text.Replace(",","");
                }
                switch (tb.Name) {
                    case "tbAddress":
                        string regAddress = "[^.a-zA-Z0-9]";
                        if (Regex.IsMatch(tbAddress.Text, regAddress)) {
                            tbAddress.Text = Regex.Replace(tbAddress.Text, regAddress, "");
                        }
                        break;
                    case "tbPort":
                        string regPort = "[^0-9]";
                        if (Regex.IsMatch(tbPort.Text, regPort)) {
                            tbPort.Text = Regex.Replace(tbPort.Text, regPort, "");
                        }
                    break;
                }

                btnNew.Enabled = false;
                if (tbName.Text.Length > 0 && tbAddress.Text.Length > 0 && tbPort.Text.Length > 0) {
                    btnOK.Enabled = true;
                }
                else {
                    btnOK.Enabled = false;
                }
                if (!global.newEntry) {
                    btnOK.Text = "Update";
                }
                btnCancel.Text = "Cancel";
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                global.sndSelect.Play();
                System.Threading.Thread.Sleep(250);
            }
            catch { }
            if (global.initPcap != global.selectedPcap || global.initAddress != global.selectedAddress || global.initPort != global.selectedPort) {
                if (global.selectedAddress.Length > 0 && global.selectedPort.Length > 0) {
                    MessageBox.Show("Please restart the game for changes to take affect.");
                }
            }
        }
    }
}
