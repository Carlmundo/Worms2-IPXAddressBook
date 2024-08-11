using Microsoft.Win32;
using System;
using System.IO;
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

        public static class lang
        {
            public static string PlayOnline = "Play Online";
            public static string PlayLAN = "Play via LAN or VPN";
            public static string SelectServer = "Select Server";
            public static string Restart = "Please restart the game for changes to take effect.";
            public static string Port = "Port"; //9-143
            public static string AddressBook = "Address book"; //14-208
            public static string ServerList = "Server List"; //14-209
            public static string New = "New"; //14-210
            public static string Delete = "Delete"; //14-211
            public static string Cancel = "Cancel"; //14-212
            public static string Exit = "Exit"; //14-213
            public static string Name = "Name"; //14-214
            public static string Server = "Server"; //14-216
            public static string Address = "Address"; //14-218
            public static string PortNumber = "Port number"; //14-219
            public static string Done = "Done"; //14-220
            public static string Update = "Update"; //14-221
            public static string OK = "OK"; //47-743
            public static string AreYouSure = "Are you sure?"; //134-2140
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
            //Check Language
            string langFile = "language.txt";
            string[] langArr = { "de", "en", "es", "es-419", "fr", "it", "nl", "pl", "pt", "pt-br", "ru", "sv" };
            string langVal;
            if (File.Exists(langFile)) {
                langVal = File.ReadAllText(langFile).Trim();
                if (!Array.Exists(langArr, element => element == langVal)) {
                    langVal = "en";
                }
            }
            else {
                langVal = "en";
            }
           
            switch (langVal) {
                case "de":
                    lang.PlayOnline = "Online spielen"; //Play Online
                    lang.PlayLAN = "LAN/VPN"; //Play LAN/VPN
                    lang.SelectServer = "Server auswählen";
                    lang.Restart = "Bitte starten Sie das Spiel neu, damit die Änderungen wirksam werden.";
                    lang.Port = "Anschluß"; //9-143
                    lang.AddressBook = "Adreßbuch"; //14-208
                    lang.ServerList = "Namen"; //14-209
                    lang.New = "Neu"; //14-210
                    lang.Delete = "Löschen"; //14-211
                    lang.Cancel = "Abbrechen"; //14-212
                    lang.Exit = "Beenden"; //14-213
                    lang.Name = "Name"; //14-214
                    lang.Server = "Server"; //14-216
                    lang.Address = "Adresse"; //14-218
                    lang.PortNumber = "Anschluß-Nummer"; //14-219
                    lang.Done = "Fertig"; //14-220
                    lang.Update = "Aktualisieren"; //14-221
                    lang.OK = "OK"; //47-743
                    lang.AreYouSure = "Bist Du sicher?"; //134-2140
                    break;
                case "es":
                    lang.PlayOnline = "Jugar en línea"; //Play Online
                    lang.PlayLAN = "LAN/VPN"; //Play LAN/VPN
                    lang.SelectServer = "Seleccionar servidor";
                    lang.Restart = "Reinicia el juego para que los cambios surtan efecto.";
                    lang.Port = "Puerto"; //9-143
                    lang.AddressBook = "Libreta de Direcciones"; //14-208
                    lang.ServerList = "Nombres"; //14-209
                    lang.New = "Nuevo"; //14-210
                    lang.Delete = "Eliminar"; //14-211
                    lang.Cancel = "Anular"; //14-212
                    lang.Exit = "Salir"; //14-213
                    lang.Name = "Nombre"; //14-214
                    lang.Server = "Servidor"; //14-216
                    lang.Address = "Dirección"; //14-218
                    lang.PortNumber = "N°Puerto"; //14-219
                    lang.Done = "Terminado"; //14-220
                    lang.Update = "Actualiación"; //14-221
                    lang.OK = "Aceptar"; //47-743
                    lang.AreYouSure = "¿Seguro?"; //134-2140
                    break;
                case "es-419":
                    lang.PlayOnline = "Jugar en línea"; //Play Online
                    lang.PlayLAN = "LAN/VPN"; //Play LAN/VPN
                    lang.SelectServer = "Seleccionar servidor";
                    lang.Restart = "Por favor, reinicia el juego para aplicar los cambios.";
                    lang.Port = "Puerto"; //9-143
                    lang.AddressBook = "Libreta de direcciones"; //14-208
                    lang.ServerList = "Nombres"; //14-209
                    lang.New = "Nuevo"; //14-210
                    lang.Delete = "Borrar"; //14-211
                    lang.Cancel = "Cancelar"; //14-212
                    lang.Exit = "Salir"; //14-213
                    lang.Name = "Nombre"; //14-214
                    lang.Server = "Servidor"; //14-216
                    lang.Address = "Dirección"; //14-218
                    lang.PortNumber = "Número de puerto"; //14-219
                    lang.Done = "Hecho"; //14-220
                    lang.Update = "Actualización"; //14-221
                    lang.OK = "Aceptar"; //47-743
                    lang.AreYouSure = "¿Estás seguro?"; //134-2140
                    break;
                case "fr":
                    lang.PlayOnline = "Jouer en ligne"; //Play Online
                    lang.PlayLAN = "LAN/VPN"; //Play LAN/VPN
                    lang.SelectServer = "Sélectionner le serveur"; //Confirm
                    lang.Restart = "Veuillez redémarrer le jeu pour que les modifications soient prises en compte.";
                    lang.Port = "Port"; //9-143
                    lang.AddressBook = "Carnet d'adresses"; //14-208
                    lang.ServerList = "Noms"; //14-209
                    lang.New = "Nouveau"; //14-210
                    lang.Delete = "Supprimer"; //14-211
                    lang.Cancel = "Annuler"; //14-212
                    lang.Exit = "Sortir"; //14-213
                    lang.Name = "Nom"; //14-214
                    lang.Server = "Serveur"; //14-216
                    lang.Address = "Adresse"; //14-218
                    lang.PortNumber = "Numéro du port"; //14-219
                    lang.Done = "Fini"; //14-220
                    lang.Update = "Mise à jour"; //14-221
                    lang.OK = "OK"; //47-743
                    lang.AreYouSure = "Etes-vous sûr?"; //134-2140
                    break;
                case "it":
                    lang.PlayOnline = "Gioca Online"; //Play Online
                    lang.PlayLAN = "LAN/VPN"; //Play LAN/VPN
                    lang.SelectServer = "Selezionare il server";
                    lang.Restart = "Per rendere effettive le modifiche, riavviare il gioco.";
                    lang.Port = "Porta"; //9-143
                    lang.AddressBook = "Agenda"; //14-208
                    lang.ServerList = "Nomi"; //14-209
                    lang.New = "Nuovo"; //14-210
                    lang.Delete = "Cancella"; //14-211
                    lang.Cancel = "Annulla"; //14-212
                    lang.Exit = "Esci"; //14-213
                    lang.Name = "Nome"; //14-214
                    lang.Server = "Server"; //14-216
                    lang.Address = "Indirizzo"; //14-218
                    lang.PortNumber = "Numero porta"; //14-219
                    lang.Done = "Fatto"; //14-220
                    lang.Update = "Aggiorna"; //14-221
                    lang.OK = "OK"; //47-743
                    lang.AreYouSure = "Sei sicuro?"; //134-2140
                    break;
                case "nl":
                    lang.PlayOnline = "Speel online"; //Play Online
                    lang.PlayLAN = "LAN/VPN"; //Play LAN/VPN
                    lang.SelectServer = "Selecteer server";
                    lang.Restart = "Start het spel opnieuw op om de wijzigingen door te voeren.";
                    lang.Port = "Poort"; //9-143
                    lang.AddressBook = "Adresboek"; //14-208
                    lang.ServerList = "Lista serwerów"; //14-209
                    lang.New = "Nieuw"; //14-210
                    lang.Delete = "Verwijder"; //14-211
                    lang.Cancel = "Annuleren"; //14-212
                    lang.Exit = "Terug"; //14-213
                    lang.Name = "Naam"; //14-214
                    lang.Server = "Server"; //14-216
                    lang.Address = "adres"; //14-218
                    lang.PortNumber = "Poort"; //14-219
                    lang.Done = "Klaar"; //14-220
                    lang.Update = "Bijwerken"; //14-221
                    lang.OK = "OK"; //47-743
                    lang.AreYouSure = "Weet je dit zeker?"; //134-2140
                    break;
                case "pl":
                    //Credit: Dawid8
                    lang.PlayOnline = "Graj Online"; //Play Online
                    lang.PlayLAN = "Graj przez sieć lokalną lub VPN"; //Play LAN/VPN
                    lang.SelectServer = "Wybierz serwer";
                    lang.Restart = "Aby zmiany zaczęły obowiązywać, należy ponownie uruchomić grę.";
                    lang.Port = "Port"; //9-143
                    lang.AddressBook = "Książka adresowa"; //14-208
                    lang.ServerList = "Nazwy"; //14-209
                    lang.New = "Nowy"; //14-210
                    lang.Delete = "Usuń"; //14-211
                    lang.Cancel = "Wróć"; //14-212
                    lang.Exit = "Wyjdź"; //14-213
                    lang.Name = "Nazwa"; //14-214
                    lang.Server = "Serwer"; //14-216
                    lang.Address = "adres"; //14-218
                    lang.PortNumber = "Numer portu"; //14-219
                    lang.Done = "Gotowe"; //14-220
                    lang.Update = "Uaktualnienie"; //14-221
                    lang.OK = "OK"; //47-743
                    lang.AreYouSure = "Na pewno?"; //134-2140
                    break;
                case "pt":
                    //Credit: rubinho146
                    lang.PlayOnline = "Jogar online"; //Play Online
                    lang.PlayLAN = "Jogar via LAN ou VPN"; //Play LAN/VPN
                    lang.SelectServer = "Selecionar servidor";
                    lang.Restart = "Reinicia o jogo para as alterações fazerem efeito.";
                    lang.Port = "Porta"; //9-143
                    lang.AddressBook = "Livro de endereços"; //14-208
                    lang.ServerList = "Lista de servidores"; //14-209
                    lang.New = "Novo"; //14-210
                    lang.Delete = "Apagar"; //14-211
                    lang.Cancel = "Cancelar"; //14-212
                    lang.Exit = "Sair"; //14-213
                    lang.Name = "Nome"; //14-214
                    lang.Server = "Servidor"; //14-216
                    lang.Address = "Endereço"; //14-218
                    lang.PortNumber = "Número de porta"; //14-219
                    lang.Done = "Terminado"; //14-220
                    lang.Update = "Atualização"; //14-221
                    lang.OK = "OK"; //47-743
                    lang.AreYouSure = "Tens a certeza?"; //134-2140
                    break;
                case "pt-br":
                    //Credit: rubinho146
                    lang.PlayOnline = "Jogar online"; //Play Online
                    lang.PlayLAN = "Jogar via LAN ou VPN"; //Play LAN/VPN
                    lang.SelectServer = "Selecionar servidor";
                    lang.Restart = "Reinicie o jogo para as alterações surtirem efeito.";
                    lang.Port = "Porta"; //9-143
                    lang.AddressBook = "Caderno de endereços"; //14-208
                    lang.ServerList = "Nomes"; //14-209
                    lang.New = "Novo"; //14-210
                    lang.Delete = "Remover"; //14-211
                    lang.Cancel = "Cancelar"; //14-212
                    lang.Exit = "Sair"; //14-213
                    lang.Name = "Nome"; //14-214
                    lang.Server = "Servidor"; //14-216
                    lang.Address = "Endereço"; //14-218
                    lang.PortNumber = "Número de Porta"; //14-219
                    lang.Done = "Concluído"; //14-220
                    lang.Update = "Atualização"; //14-221
                    lang.OK = "OK"; //47-743
                    lang.AreYouSure = "Tem certeza?"; //134-2140
                    break;
                case "ru":
                    lang.PlayOnline = "Играть по сети"; //Play Online
                    lang.PlayLAN = "LAN/VPN"; //Play LAN/VPN
                    lang.SelectServer = "Выберите сервер";
                    lang.Restart = "Чтобы изменения вступили в силу, перезапустите игру.";
                    lang.Port = "Порт"; //9-143
                    lang.AddressBook = "Адресная книга"; //14-208
                    lang.ServerList = "Имена"; //14-209
                    lang.New = "Новое"; //14-210
                    lang.Delete = "Удалить"; //14-211
                    lang.Cancel = "Отмена"; //14-212
                    lang.Exit = "Выйти"; //14-213
                    lang.Name = "Имя"; //14-214
                    lang.Server = "Сервер"; //14-216
                    lang.Address = "адрес"; //14-218
                    lang.PortNumber = "Номер порта"; //14-219
                    lang.Done = "Готово"; //14-220
                    lang.Update = "Обновить"; //14-221
                    lang.OK = "OK"; //47-743
                    lang.AreYouSure = "Уверены?"; //134-2140
                    break;
                case "sv":
                    lang.PlayOnline = "Spela online"; //Play Online
                    lang.PlayLAN = "LAN/VPN"; //Play LAN/VPN
                    lang.SelectServer = "Välj server";
                    lang.Restart = "Starta om spelet för att ändringarna ska träda i kraft.";
                    lang.Port = "Dörr"; //9-143
                    lang.AddressBook = "Adress bok"; //14-208
                    lang.ServerList = "Namn"; //14-209
                    lang.New = "Ny"; //14-210
                    lang.Delete = "Ta bort"; //14-211
                    lang.Cancel = "Avbryt"; //14-212
                    lang.Exit = "Exit"; //14-213
                    lang.Name = "Namn"; //14-214
                    lang.Server = "Server"; //14-216
                    lang.Address = "Adress"; //14-218
                    lang.PortNumber = "Port nummer"; //14-219
                    lang.Done = "Gjort"; //14-220
                    lang.Update = "Uppdatera"; //14-221
                    lang.OK = "OK"; //47-743
                    lang.AreYouSure = "Är du säker?"; //134-2140
                break;
            }

            //Apply language to controls
            this.Text = lang.AddressBook;
            rbOnline.Text = lang.PlayOnline;
            rbLAN.Text = lang.PlayLAN;
            gbServers.Text = lang.ServerList;
            listServers.Columns[0].Text = lang.Server;
            listServers.Columns[1].Text = lang.Address;
            listServers.Columns[2].Text = lang.Port;
            gbName.Text = lang.Name;
            gbAddress.Text = lang.Address;
            gbPort.Text = lang.PortNumber;
            btnSet.Text = lang.SelectServer;
            btnNew.Text = lang.New;
            btnExit.Text = lang.Exit;
            btnCancel.Text = lang.Exit;
            btnDelete.Text = lang.Delete;
            btnOK.Text = lang.OK;


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
            listServers.Columns[2].Width = -2;
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
            btnCancel.Text = lang.Exit;
            btnCancel.Enabled = true;
            btnNew.Enabled = true;
            btnOK.Text = lang.OK;
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
            btnCancel.Text = lang.Cancel;
            btnDelete.Enabled = false;
            btnOK.Text = lang.Done;
            btnOK.Enabled = false;
            foreach (TextBox tb in global.textBoxes) {
                tb.Text = "";
                tb.Enabled = true;
            }
            tbName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == lang.Cancel) {
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
            else if (btnCancel.Text == lang.Exit) {
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try { global.sndSelect.Play(); }
            catch { }
            if (listServers.SelectedItems.Count > 0) {
                DialogResult dialogResult = MessageBox.Show(lang.AreYouSure, lang.Delete, MessageBoxButtons.YesNo);
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
            if (btnOK.Text == lang.Update) {
                btnOK.Text = lang.OK;
                btnNew.Enabled = true;
                btnCancel.Text = lang.Exit;
                btnOK.Enabled = false;

                var selectedItem = listServers.SelectedItems[0];
                selectedItem.Text = tbName.Text;
                selectedItem.SubItems[1].Text = tbAddress.Text;
                selectedItem.SubItems[2].Text = tbPort.Text;

                saveFile();
            }
            else if (btnOK.Text == lang.Done) {
                listAdd(new string[] { tbName.Text, tbAddress.Text, tbPort.Text, "" });
                saveFile();
                foreach (TextBox tb in global.textBoxes) {
                    tb.Text = "";
                    tb.Enabled = false;
                }
                btnNew.Enabled = true;
                btnCancel.Text = lang.Exit;
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
                    btnOK.Text = lang.Update;
                }
                btnCancel.Text = lang.Cancel;
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
                    MessageBox.Show(lang.Restart);
                }
            }
        }
    }
}
