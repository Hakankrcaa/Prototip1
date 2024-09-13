using PowershellShowcase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Management.Automation.Language;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Security;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Threading;
using System.Diagnostics.Eventing.Reader;
using System.Data.OleDb;
using System.Collections;
using Prototip1.Properties;
using System.Runtime.Remoting.Contexts;
namespace Prototip1
{
    public partial class Form1 : Form
    {
        List<string> klasorler = new List<string>();
        List<string> users = new List<string>();
        List<string> users2 = new List<string>();
        List<string> klasorYol = new List<string>();
        List<string> klasorYol2 = new List<string>();
        List<object> domaindekiKullanicilar = new List<object>();
        List<PrincipalContext> principalContexts = new List<PrincipalContext>();
        Dictionary<string, string> excelDataManager = new Dictionary<string, string>();
        StringBuilder yollar = new StringBuilder();
        StringBuilder yollar2 = new StringBuilder();
        StringBuilder yollar3 = new StringBuilder();
        StringBuilder kullaniciResult = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        StringBuilder nihaiResult = new StringBuilder();
        Dictionary<string , List<string>> userFolder = new Dictionary<string , List<string>>();
        public Dictionary<string , string> pasifler = new Dictionary<string , string>();

        public string SelectedFolderPath { get; private set; }
        public string selectedUser;
        private float initialFormWidth;
        private float initialFormHeight;
        public string selectedUser2;
        public bool isEnabled;








        public Form1()
        {
            InitializeComponent();
            initialFormWidth = this.Width;
            initialFormHeight = this.Height;
            this.Resize += Form1_Resize;
            fullcontrolCHCK.CheckedChanged += new EventHandler(cbFullControl_CheckedChanged);
            

        }
        
       
        private void Form1_Load(object sender, EventArgs e)
        {
            //Özelleştir
            Paths ornekYol = new Paths("Dosya Yolu", "Dosya Adı");
            LoadDirectory(ornekYol.uzunYol, treeView1.Nodes);
            //düzenlenebilir

            // Ağ ve bilgisayar klasörlerini ayrı ayrı ekleyeceğiz
            this.ımageList1.Images.Add("folder", Properties.Resources.folder);
            this.ımageList1.Images.Add("file1", Properties.Resources.file1);
            this.treeView1.ImageList = this.ımageList1;
            this.Controls.Add(this.treeView1);
            treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
            //yetkiKisiSec.Text = Domain.GetCurrentDomain().Name;
            //excellOkuma();
            //LoadDataFromExcelToComboBox(); /////////////////////!!!!!!!!!!!!!!!!!!!///////////////////
            //comboBox1.Items.AddRange(domaindekiKullanicilar.ToArray());
            // Excel dosyasının yolu
            string excelFilePath = @"";

            // Verileri okuma ve Dictionary'e aktarma
            excelDataManager = ReadExcelToDictionary(excelFilePath);
        }
        
        //----------Dosya Bazlı Sorgulama Paneli-----------//
        private void klasorSec_Click(object sender, EventArgs e)
        {
            string selectedFilePath = " ";
            
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "Klasör Seç",
                ShowNewFolderButton = false
            };
            

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen klasörün yolunu al
                selectedFilePath = folderBrowserDialog.SelectedPath;
                klasorler.Add(selectedFilePath);

               yollar.AppendLine(selectedFilePath);
                richTextBox1.Text = yollar.ToString();

            }
           
              
        }
        private void sorgula_Click(object sender, EventArgs e)
        {
            
            try
            {
                foreach (var klasor in klasorler)
                {
                    //sb.AppendLine(YetkiSorgula(klasor));
                    sb.AppendLine(GetDirectoryPermissions(klasor , excelDataManager, pasifler));
                }
            }
            catch
            {
                MessageBox.Show("Klasör seçiniz..");
            }
     
            

            nihaiResult.AppendLine(sb.ToString());
            nihaiResult.AppendLine(kullaniciResult.ToString());

            richTextBox1.Text = nihaiResult.ToString();
            //userFolder.Clear();
            //klasorYol.Clear();
            yollar.Clear();
            //users.Clear();
            klasorler.Clear();
            nihaiResult.Clear();
            sb.Clear();
            kullaniciResult.Clear();
            //pasifler.Clear();
        }
        private void temizle_Click(object sender, EventArgs e)
        {
            klasorler.Clear();
            //users.Clear();
            yollar.Clear();
            //klasorYol.Clear();
            richTextBox1.Text = string.Empty;
            pasifler.Clear();
        }
        private void yazdir_Click(object sender, EventArgs e)
        {
            string data = richTextBox1.Text;
    

            string filePath = GetSaveFileName();

            if (!string.IsNullOrEmpty(filePath))
            {
                WriteToExcel(filePath, data);
                MessageBox.Show("Veriler başarıyla Excel dosyasına yazdırıldı.");
            }
            else
            {
                MessageBox.Show("Dosya kaydetme iptal edildi.");
            }
        }

        //--------- Kullanıcı Filtreli Sorgulama Paneli---------//
        private void kullaniciGuncelle_Click(object sender, EventArgs e)
        {
            // ComboBox'ı temizle
            comboBox1.Items.Clear();

            // Yerel bilgisayardaki kullanıcıları al
            using (var context = new PrincipalContext(ContextType.Domain))
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    foreach (var result in searcher.FindAll())
                    {
                        // Kullanıcı adını ComboBox'a ekle
                        comboBox1.Items.Add(result.SamAccountName);
                        comboBox2.Items.Add(result.SamAccountName);
                    }
                }
            }
           
        } // Bu kısım kullanıcıları excellden çektiğimizde silinecek.
        private void kullaniciSec_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                selectedUser = comboBox1.SelectedItem.ToString();
                users.Add(selectedUser);
                MessageBox.Show($"Seçilen Kullanıcı: {selectedUser}");
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
            }


        }
        private void kullaniciSorgula_Click(object sender, EventArgs e)
        {
            if (users != null && klasorYol != null) 
            {
                foreach (var user in users)
                {
                    foreach (string eleman in klasorYol)
                    {
                        kullaniciResult.AppendLine(GetDirectoryUserPermissions(eleman, user , excelDataManager));
                    }
                }
                richTextBox2.Text = kullaniciResult.ToString();
                users.Clear();
                klasorYol.Clear();
                kullaniciResult.Clear();
            }
            else
            {
                MessageBox.Show("Kullanıcı veya klasör seçimini kontrol edin.");
            }
        }
        private void kullaniciKlasor_Click(object sender, EventArgs e)
        {
            string secilenKlasor = string.Empty;
            if (users.Count != 0)
            {
                if (SelectedFolderPath != null)
                {
                secilenKlasor = SelectedFolderPath;

                
                    if (secilenKlasor != null)
                    {
                        klasorYol.Add(secilenKlasor);

                        foreach (string user in users)
                        {
                            foreach (string eleman in klasorYol)
                            {
                                yollar2.AppendLine("Kullanıcı : " + user + " (^_^) " + " Klasör : " + eleman);
                            }
                        }

                    }
                   richTextBox2.Text = yollar2.ToString();
                }
                else
                {
                    MessageBox.Show("Klasör hiyerarşisinden klasör seçin.");
                }
                
            }
            else
            {
                MessageBox.Show("Lütfen önce kullanıcı seçin.");
            }
            
        }
        private void excelCiktiKullanici_Click(object sender, EventArgs e)
        {
            string data = richTextBox2.Text;


            string filePath = GetSaveFileName();

            if (!string.IsNullOrEmpty(filePath))
            {
                WriteToExcel(filePath, data);
                MessageBox.Show("Veriler başarıyla Excel dosyasına yazdırıldı.");
            }
            else
            {
                MessageBox.Show("Dosya kaydetme iptal edildi.");
            }
        }
        private void temizlee_Click(object sender, EventArgs e)
        {
            users.Clear();
            yollar2.Clear();
            klasorYol.Clear();  
            richTextBox2.Text = string.Empty;
            kullaniciResult.Clear();

        }

        //--------- Yetki ekleme / kaldırma Paneli ------------//
        private void yetkiKaldirr_Click(object sender, EventArgs e)
        {

            if (users2.Count != 0)
            {
                if (klasorYol2 != null)
                {
                    try
                    {
                        if (okumaCHCK != null || okumayurutmeCHCK != null || yazmaCHCK != null || listelemeCHCK != null || degistirmeCHCK != null || fullcontrolCHCK != null)
                        {
                            foreach (string user in users2)
                            {
                                foreach (string klasor in klasorYol2)
                                {
                                    KaldirPermissions(klasor, user, okumaCHCK, yazmaCHCK, listelemeCHCK, degistirmeCHCK, okumayurutmeCHCK, fullcontrolCHCK);
                                }
                                MessageBox.Show($"Kullanıcı {user} için yetkiler başarıyla kaldırıldı.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Yetki Seviyesi Seçin");
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show("Yetkisiz erişim hatası: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Klasör hiyerarşisinden klasör seçin.");
                }

            }
            else
            {
                MessageBox.Show("Önce kullanıcı seçin");
            }  
        }
        private void yetkiVerr_Click(object sender, EventArgs e)
        {
            if (users2.Count != 0)
            {
                if (klasorYol2 != null)
                {
                    try
                    {
                        if (okumaCHCK != null || okumayurutmeCHCK != null || yazmaCHCK != null || listelemeCHCK != null || degistirmeCHCK != null || fullcontrolCHCK != null)
                        {
                            foreach (string user in users2)
                            {
                                foreach (string klasor in klasorYol2)
                                {
                                    SetPermissions(klasor, user, okumaCHCK, yazmaCHCK, listelemeCHCK, degistirmeCHCK, okumayurutmeCHCK, fullcontrolCHCK);
                                }
                                MessageBox.Show($"Kullanıcı {user} için yetkiler başarıyla verildi.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Yetki Seviyesi Seçin");
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show("Yetkisiz erişim hatası: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Klasör hiyerarşisinden klasör seçin.");
                }
                
            }
            else
            {
                MessageBox.Show("Önce kullanıcı seçin");
            }
        }
        private void kullaniciSecc_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                selectedUser2 = comboBox2.SelectedItem.ToString();
                users2.Add(selectedUser2);
                MessageBox.Show($"Seçilen Kullanıcı: {selectedUser2}");
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
            }
        }

        private void klasorSecc_Click(object sender, EventArgs e)
        {
            if (users2.Count != 0)
            {
                if (SelectedFolderPath != null)
                {
                    // Seçilen klasörün yolunu al
                    klasorYol2.Add(SelectedFolderPath);

                    foreach (string user in users2)
                    {
                        foreach (string eleman in klasorYol2)
                        {
                            yollar3.AppendLine("Kullanıcı : " + user + " (^_^) " + " Klasör : " + eleman);
                        }
                    }

                }
                richTextBox3.Text = yollar3.ToString();
            }
            else
            {
                MessageBox.Show("Lütfen önce kullanıcı seçin.");
            }
        }

        //--------Metodlar----------//
        private void LoadDirectory(string dir, TreeNodeCollection nodeCollection)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            TreeNode tds = nodeCollection.Add(di.Name);
            tds.Tag = di.FullName;
            tds.ImageKey = "folder";
            tds.SelectedImageKey = "folder";

            foreach (DirectoryInfo subdir in di.GetDirectories())
            {
                LoadDirectory(subdir.FullName, tds.Nodes);
            }

            foreach (FileInfo file in di.GetFiles())
            {
                TreeNode tn = tds.Nodes.Add(file.Name);
                tn.Tag = file.FullName;
                tn.ImageKey = "file1";
                tn.SelectedImageKey = "file1";
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Seçilen düğüm
            TreeNode selectedNode = e.Node;

            // Düğümün tam yolunu alma
            SelectedFolderPath = GetFullPath(selectedNode);
            yetkiKisiSec.Text = SelectedFolderPath;

        }
        
        private string GetFullPath(TreeNode node)
        {
            
            string path = node.Tag.ToString();
            string rootFolderPath = @"";
            string fullPath = Path.Combine(rootFolderPath, path.Replace("\\", Path.DirectorySeparatorChar.ToString()));
            
            return fullPath;
        }
        private void hiyerarsiSec_Click(object sender, EventArgs e)
        {
            string selectedFilePath = string.Empty;
            if (SelectedFolderPath != null) 
            {

                // Seçilen klasörün yolunu al
                selectedFilePath = SelectedFolderPath;
                klasorler.Add(selectedFilePath);

                yollar.AppendLine(selectedFilePath);

                richTextBox1.Text = yollar.ToString();
            }
            else
            {
                MessageBox.Show("Klasör hiyerarşisinden klasör seçin");
            }
        }
        static string GetDirectoryPermissions(string path , Dictionary<string , string> excelDataManager , Dictionary<string, string> pasifler)
        {
            StringBuilder result = new StringBuilder();
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            result.AppendLine("Kullanıcı \t Klasör/Dosya \t Yetki Seviyesi \t Yönetici \t Aktiflik \t Açıklama ");
            // Active Directory bağlamı oluştur
            PrincipalContext birincilDomain = new PrincipalContext(ContextType.Domain);
            PrincipalContext ikincilDomain = new PrincipalContext(ContextType.Domain , "Domain İsmi");
            //Çoğaltılabilir
           
            foreach (FileSystemInfo fileSystemInfo in dirInfo.GetFileSystemInfos("*", SearchOption.AllDirectories))
            {
                try
                {
                    FileSystemSecurity fileSecurity = null;
                   

                        if (fileSystemInfo is DirectoryInfo)
                        {
                            fileSecurity = ((DirectoryInfo)fileSystemInfo).GetAccessControl();
                        }
                        else if (fileSystemInfo is FileInfo)
                        {
                            fileSecurity = ((FileInfo)fileSystemInfo).GetAccessControl();
                        }
                    
                        if (fileSecurity != null)
                        {
                            AuthorizationRuleCollection acl = fileSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));

                            foreach (FileSystemAccessRule ace in acl)
                            {
                                if (ace.IdentityReference.Value != "NT AUTHORITY\\SYSTEM" && ace.IdentityReference.Value != "BUILTIN\\Administrators")
                                {
                                
                                string fullPath = fileSystemInfo.FullName;

                                // Yolu parçalara ayır
                                string[] pathParts = fullPath.Split('\\');
                                
                                //string user = new SecurityIdentifier(ace.IdentityReference.Value).Translate(typeof(NTAccount)).ToString();
                                string user = " ";
                                
                                try
                                {
                                    NTAccount account = (NTAccount)ace.IdentityReference.Translate(typeof(NTAccount));
                                     user = account.Value;
                                }
                                catch (IdentityNotMappedException)
                                {
                                     user = ace.IdentityReference.Value; // Eğer çevrilemezse SID olarak alır
                                }
                                
                                    // Son 3 dizini al
                                    string shortPath = string.Join("\\", pathParts.Skip(Math.Max(0, pathParts.Length - 3)));

                                string manager;
                                try
                                {
                                     manager = excelDataManager[user];
                                }
                                catch
                                {
                                     manager = "Yönetici Bulunamadı.";
                                }
                                string isActive = "Pasif";
                                try
                                {
                                    
                                        UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(birincilDomain, user);
                                        isActive = userPrincipal != null && userPrincipal.Enabled.HasValue && userPrincipal.Enabled.Value ? "Aktif" : "Pasif";
                                        
                                    if (isActive == "Pasif")
                                    {   
                                        UserPrincipal user1Principal = UserPrincipal.FindByIdentity(ikincilDomain, user);
                                        isActive = user1Principal != null && user1Principal.Enabled.HasValue && user1Principal.Enabled.Value ? "Aktif" : "Pasif";
                                    }
                                    if (isActive == "Pasif" && !pasifler.ContainsKey(user))
                                    {
                                      pasifler.Add(user, fullPath);                                                 
                                    }
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.Message);
                                    isActive = "Bilinmiyor";
                                }
                                result.AppendLine($"{user} \t {shortPath} \t {ace.FileSystemRights} \t {manager} \t {isActive}");
                                

                                }
                                //result.AppendLine($"File/Directory: {fileSystemInfo.FullName}");
                                //result.AppendLine($"User/Group: {ace.IdentityReference.Value}");
                                //result.AppendLine($"Permissions: {ace.FileSystemRights}");
                                //result.AppendLine($"Inherited: {ace.IsInherited}");
                                //result.AppendLine(new string('-', 50));
                            }
                        
                        }
                }
                catch (UnauthorizedAccessException)
                {
                    result.AppendLine($"Unauthorized to access {fileSystemInfo.FullName}");
                    result.AppendLine(new string('-', 50));
                }
                catch (Exception ex)
                {
                    result.AppendLine($"Error accessing {fileSystemInfo.FullName}: {ex.Message}");
                    result.AppendLine(new string('-', 50));
                }
            }

            return result.ToString();
        }  
        static string GetDirectoryUserPermissions(string path , string selectedUser , Dictionary<string, string> excelDataManager)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder baslik = new StringBuilder();
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            baslik.AppendLine("Kullanıcı \t Klasör/Dosya \t Yetki Seviyesi \t Yönetici \t Aktiflik \t Açıklama ");

            foreach (FileSystemInfo fileSystemInfo in dirInfo.GetFileSystemInfos("*", SearchOption.AllDirectories))
            {
                try
                {
                    FileSystemSecurity fileSecurity = null;
                   

                        if (fileSystemInfo is DirectoryInfo)
                        {
                            fileSecurity = ((DirectoryInfo)fileSystemInfo).GetAccessControl();
                        }
                        else if (fileSystemInfo is FileInfo)
                        {
                            fileSecurity = ((FileInfo)fileSystemInfo).GetAccessControl();
                        }
                    
                        if (fileSecurity != null)
                        {
                            AuthorizationRuleCollection acl = fileSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));

                            foreach (FileSystemAccessRule ace in acl)
                            {
                            if (ace.IdentityReference.Value != "NT AUTHORITY\\SYSTEM" && ace.IdentityReference.Value != "BUILTIN\\Administrators")
                            {
                                
                                string fullPath = fileSystemInfo.FullName;

                                // Yolu parçalara ayır
                                string[] pathParts = fullPath.Split('\\');
                                //string user = new SecurityIdentifier(ace.IdentityReference.Value).Translate(typeof(NTAccount)).ToString();
                                string user = " ";
                                try
                                {
                                    NTAccount account = (NTAccount)ace.IdentityReference.Translate(typeof(NTAccount));
                                     user = account.Value;
                                }
                                catch (IdentityNotMappedException)
                                {
                                     user = ace.IdentityReference.Value; // Eğer çevrilemezse SID olarak alır
                                }
                                if (user.ToLower().Contains(selectedUser.ToLower())) {
                                    // Son 3 dizini al
                                    string shortPath = string.Join("\\", pathParts.Skip(Math.Max(0, pathParts.Length - 3)));
                                    string manager;
                                    try
                                    {
                                        manager = excelDataManager[user];
                                    }
                                    catch
                                    {
                                        manager = "Yönetici Bulunamadı.";
                                    }
                                    result.AppendLine($"{user} \t {shortPath} \t {ace.FileSystemRights} \t {manager}");
                                    
                                }
                            }
                                //result.AppendLine($"File/Directory: {fileSystemInfo.FullName}");
                                //result.AppendLine($"User/Group: {ace.IdentityReference.Value}");
                                //result.AppendLine($"Permissions: {ace.FileSystemRights}");
                                //result.AppendLine($"Inherited: {ace.IsInherited}");
                                //result.AppendLine(new string('-', 50));
                                
                            }
                        
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    result.AppendLine($"Unauthorized to access {fileSystemInfo.FullName}");
                    result.AppendLine(new string('-', 50));
                }
                catch (Exception ex)
                {
                    result.AppendLine($"Error accessing {fileSystemInfo.FullName}: {ex.Message}");
                    result.AppendLine(new string('-', 50));
                }
            }
            if (!string.IsNullOrWhiteSpace(result.ToString()))
            {

                return baslik.AppendLine(result.ToString()).ToString();
               
            }
            else
            {
                MessageBox.Show("Yetki Bulunamadı.");
                return string.Empty;
            }


        } //Kullanıcı ve Klasör birlikte sorgulama

        static void yetkiKaldir(string user , string folderPath)
        {
            try
            {
                // Klasörün güvenlik ayarlarını al
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

                // Kullanıcının mevcut erişim haklarını al
                AuthorizationRuleCollection accessRules = directorySecurity.GetAccessRules(true, true, typeof(NTAccount));

                bool ruleRemoved = false;

                foreach (FileSystemAccessRule rule in accessRules)
                {
                    if (rule.IdentityReference.Value.Equals("Domain Adı\\"+user, StringComparison.CurrentCultureIgnoreCase))
                    {
                        // Kullanıcının izinlerini kaldır
                        directorySecurity.RemoveAccessRule(rule);
                        ruleRemoved = true;
                    }
                }

                if (ruleRemoved)
                {
                    // Güncellenmiş güvenlik ayarlarını klasöre uygula
                    directoryInfo.SetAccessControl(directorySecurity);
                    MessageBox.Show($"Kullanıcı {user} için izinler başarıyla kaldırıldı.");
                }
                else
                {
                    MessageBox.Show($"Kullanıcı {user} için herhangi bir izin bulunamadı.");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                    MessageBox.Show("Yetkisiz erişim hatası: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            // Yeni ölçek oranlarını hesaplayın
            float scaleWidth = this.Width / initialFormWidth;
            float scaleHeight = this.Height / initialFormHeight;

            // Yeni ölçek faktörünü oluşturun
            var scaleFactor = new System.Drawing.SizeF(scaleWidth, scaleHeight);

            // Tüm kontrolleri ölçeklendirin
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Scale(scaleFactor);
            }

            // Formun mevcut boyutlarını kaydedin
            initialFormWidth = this.Width;
            initialFormHeight = this.Height;
        }
        public void SetPermissions(string folderPath, string user,System.Windows.Forms.CheckBox cbRead, System.Windows.Forms.CheckBox cbWrite, System.Windows.Forms.CheckBox cbListDirectory, System.Windows.Forms.CheckBox cbModify, System.Windows.Forms.CheckBox cbReadAndExecute, System.Windows.Forms.CheckBox cbFullControl)
        {
            try
            {
                // Klasörün güvenlik ayarlarını al
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

                // Yeni bir izin değişkeni oluştur
                FileSystemRights rights = 0;

                // CheckBox'ların durumuna göre izinleri belirle
                if (cbRead.Checked)
                {
                    rights |= FileSystemRights.Read;
                }
                if (cbWrite.Checked)
                {
                    rights |= FileSystemRights.Write;
                }
                if (cbListDirectory.Checked)
                {
                    rights |= FileSystemRights.ListDirectory;
                }
                if (cbModify.Checked)
                {
                    rights |= FileSystemRights.Modify;
                }
                if (cbReadAndExecute.Checked)
                {
                    rights |= FileSystemRights.ReadAndExecute;
                }
                if (cbFullControl.Checked)
                {
                    rights |= FileSystemRights.FullControl;
                }

                // Yeni bir kural oluştur: işaretlenen izinler için
                FileSystemAccessRule accessRule = new FileSystemAccessRule(
                    user,
                    rights,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow);

                // Mevcut izinleri kontrol et ve yenisiyle değiştir
                directorySecurity.ModifyAccessRule(AccessControlModification.Set, accessRule, out bool modified);

                // Güncellenmiş güvenlik ayarlarını klasöre uygula
                directoryInfo.SetAccessControl(directorySecurity);

                if (modified)
                {
                    Console.WriteLine($"Kullanıcı {user} için izinler başarıyla verildi.");
                }
                else
                {
                    Console.WriteLine($"Kullanıcı {user} için izinler değiştirilemedi.");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Yetkisiz erişim hatası: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }
        }

        public void KaldirPermissions(string folderPath, string user, System.Windows.Forms.CheckBox cbRead, System.Windows.Forms.CheckBox cbWrite, System.Windows.Forms.CheckBox cbListDirectory, System.Windows.Forms.CheckBox cbModify, System.Windows.Forms.CheckBox cbReadAndExecute, System.Windows.Forms.CheckBox cbFullControl)
        {
            try
            {
                // Klasörün güvenlik ayarlarını al
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

                // Kaldırılacak izinleri belirle
                FileSystemRights rights = 0;

                // CheckBox'ların durumuna göre kaldırılacak izinleri belirle
                if (cbRead.Checked)
                {
                    rights |= FileSystemRights.Read;
                }
                if (cbWrite.Checked)
                {
                    rights |= FileSystemRights.Write;
                }
                if (cbListDirectory.Checked)
                {
                    rights |= FileSystemRights.ListDirectory;
                }
                if (cbModify.Checked)
                {
                    rights |= FileSystemRights.Modify;
                }
                if (cbReadAndExecute.Checked)
                {
                    rights |= FileSystemRights.ReadAndExecute;
                }
                if (cbFullControl.Checked)
                {
                    rights |= FileSystemRights.FullControl;
                }

                // Kaldırılacak kuralı oluştur
                FileSystemAccessRule accessRule = new FileSystemAccessRule(
                    user,
                    rights,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow);

                // Mevcut izinleri kaldır
                bool ruleRemoved = directorySecurity.RemoveAccessRule(accessRule);

                // Güncellenmiş güvenlik ayarlarını klasöre uygula
                directoryInfo.SetAccessControl(directorySecurity);

                if (ruleRemoved)
                {
                    Console.WriteLine($"Kullanıcı {user} için izinler başarıyla kaldırıldı.");
                }
                else
                {
                    Console.WriteLine($"Kullanıcı {user} için belirtilen izinler bulunamadı.");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Yetkisiz erişim hatası: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }

        }
        private void cbFullControl_CheckedChanged(object sender, EventArgs e)
        {
            if (fullcontrolCHCK.Checked)
            {
                // Diğer CheckBox'ları devre dışı bırak
                okumaCHCK.Enabled = false;
                yazmaCHCK.Enabled = false;
                listelemeCHCK.Enabled = false;
                degistirmeCHCK.Enabled = false;
                okumayurutmeCHCK.Enabled = false;

                // Diğer CheckBox'ların işaretlerini kaldır
                okumaCHCK.Checked = false;
                yazmaCHCK.Checked = false;
                listelemeCHCK.Checked = false;
                degistirmeCHCK.Checked = false;
                okumayurutmeCHCK.Checked = false;
            }
            else
            {
                // Diğer CheckBox'ları etkinleştir
                okumaCHCK.Enabled = true;
                yazmaCHCK.Enabled = true;
                listelemeCHCK.Enabled = true;
                degistirmeCHCK.Enabled = true;
                okumayurutmeCHCK.Enabled = true;
            }
        }
        public static Dictionary<string, string> ReadExcelToDictionary(string filePath)
        {
            // Excel uygulamasını başlatma
            Excel.Application excelApp = new Excel.Application();

            // Excel dosyasını açma
            Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);
            Excel.Worksheet worksheet = workbook.Sheets[1]; // İlk çalışma sayfasını seçme
            Excel.Range range = worksheet.UsedRange;

            // Satır sayısını alma
            int rowCount = range.Rows.Count;

            // Dictionary oluşturma
            Dictionary<string, string> data = new Dictionary<string, string>();

            // Satırları döngüyle okuma
            for (int row = 1; row <= rowCount; row++)
            {
                string key = (range.Cells[row, 1] as Excel.Range).Text;
                string value = (range.Cells[row, 2] as Excel.Range).Text;

                // Eğer anahtar boş değilse, Dictionary'ye ekleme
                if (!string.IsNullOrWhiteSpace(key) && !data.ContainsKey(key))
                {
                    data.Add(key, value);
                }
            }

            // Excel dosyasını kapatma
            workbook.Close(false);
            excelApp.Quit();

            // COM nesnelerini serbest bırakma
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            return data;
        }
        public static void CheckUserAccess(string folderPath , RichTextBox richTextBox1)
        {
            // Klasörün güvenlik ayarlarını al
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

            // Klasörde yetkisi olan kullanıcıları al
            AuthorizationRuleCollection accessRules = directorySecurity.GetAccessRules(true, true, typeof(NTAccount));

            // Active Directory bağlamı oluştur
            PrincipalContext context = new PrincipalContext(ContextType.Domain);

            foreach (FileSystemAccessRule rule in accessRules)
            {
                string user = rule.IdentityReference.Value;

                // Kullanıcıyı AD'den bul
                UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(context, user);

               
                
                    // Kullanıcının hesabı etkin mi?
                    bool isEnabled = userPrincipal.Enabled ?? false;
                richTextBox1.Text = isEnabled.ToString();
                
                
            }
           
        }
        public void RemovePermissionsForDisabledUsers(string folderPath , RichTextBox richTextBox1)
        {
            StringBuilder yetkisiAlinanlar = new StringBuilder();
            try
            {
                // Klasörün güvenlik ayarlarını al
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

                // Klasördeki tüm kullanıcı izinlerini al
                AuthorizationRuleCollection accessRules = directorySecurity.GetAccessRules(true, true, typeof(NTAccount));

                foreach (FileSystemAccessRule rule in accessRules)
                {
                    string userName = rule.IdentityReference.Value;

                    // Kullanıcının etkin olup olmadığını kontrol et
                    using (PrincipalContext context = new PrincipalContext(ContextType.Domain))

                        //-_-_-_-_-_-_-_ User sürekli null oluyor _-_-_-_-_-_-_-//
                        if (userName != "Everyone")
                        {
                            UserPrincipal user = UserPrincipal.FindByIdentity(context, userName);

                            if (user != null && !user.Enabled.HasValue || !user.Enabled.Value)
                            {
                                // Kullanıcı devre dışıysa veya kilitliyse izinlerini kaldır
                                directorySecurity.RemoveAccessRule(rule);
                                yetkisiAlinanlar.Append($"{userName} ,");
                            }

                        }

                
                }
                richTextBox1.Text = yetkisiAlinanlar.ToString();
                // Güncellenmiş güvenlik ayarlarını klasöre uygula
                directoryInfo.SetAccessControl(directorySecurity);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Yetkisiz erişim hatası: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }
        }
        static void RemoveUserPermissionsFromFolder(string userName, string folderPath , RichTextBox richTextBox1)
        {
            StringBuilder yetkisiAlinanlar = new StringBuilder();
            try
            {
                // Klasörün güvenlik bilgilerini al
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

                // Kullanıcının tüm yetkilerini kaldır
                AuthorizationRuleCollection accessRules = directorySecurity.GetAccessRules(true, true, typeof(NTAccount));

                bool hasRulesToRemove = false;

                //FileSystemAccessRule accessRule = new FileSystemAccessRule(
                //    userName,
                //    rights,
                //    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                //    PropagationFlags.None,
                //    AccessControlType.Allow);

                foreach (FileSystemAccessRule rule in accessRules)
                {
                    if (rule.IdentityReference.Value.Equals(userName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        directorySecurity.RemoveAccessRule(rule);
                        hasRulesToRemove = true;
                    }
                }

                if (hasRulesToRemove)
                {
                    // Değişiklikleri klasörün güvenlik ayarlarına uygula
                    directoryInfo.SetAccessControl(directorySecurity);
                    yetkisiAlinanlar.AppendLine($"{userName} kullanıcısının {folderPath} klasöründeki yetkileri başarıyla kaldırıldı.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }
            richTextBox1.Text = yetkisiAlinanlar.ToString();
        }



        //------------------Excel İşlemleri----------------//

        private void WriteToExcel(string filePath, string data)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Sheets[1];

            

            // Veriyi ayır ve hücrelere yaz
            string[] rows = data.Split('\n');
            for (int i = 0; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split("\t".ToCharArray()); // Satırları tab ile ayırıyoruz. Duruma göre farklı ayırıcılar kullanılabilir.
                for (int j = 0; j < columns.Length; j++)
                {
                    worksheet.Cells[i + 1, j + 1] = columns[j];
                }
            }
            worksheet.Columns.AutoFit();
            string startCell = "A1";
            string endCell = $"F{rows.Length.ToString()}";
            Excel.Range dataRange = worksheet.Range[startCell, endCell];
            Excel.ListObject table = worksheet.ListObjects.Add(
        Excel.XlListObjectSourceType.xlSrcRange,
        dataRange,
        System.Type.Missing,
        Excel.XlYesNoGuess.xlYes,
        System.Type.Missing);
            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();
        }
        private string GetSaveFileName()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Excel Dosyası Kaydet",
                DefaultExt = "xlsx",
                AddExtension = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return null;
        }
        

        private void excellOkuma()
        {
            // Excel dosyasının yolu
            string excelFilePath = @"excell dosya konumu";

            // Excel uygulamasını başlatma
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(excelFilePath);
            Excel.Worksheet worksheet = workbook.Sheets[1]; // İlk çalışma sayfasını seçme
            Excel.Range range = worksheet.UsedRange;

            // Verilerin tutulacağı liste
            List<object> data = new List<object>();

            // Satır ve sütun sayısını alma
            int rowCount = range.Rows.Count;
            int colCount = range.Columns.Count;

            // Satırları döngüyle okuma
            for (int row = 1; row <= rowCount; row++)
            {
                string[] rowData = new string[colCount];

                for (int col = 1; col <= colCount; col++)
                {
                    // Hücredeki değeri okuma
                    rowData[col - 1] = (range.Cells[row, col] as Excel.Range).Text;
                    rowData = rowData.Where(item => !string.IsNullOrWhiteSpace(item)).ToArray();
                }

                data.Add(rowData);
                // Listeye satır ekleme
                
            }

            // Excel dosyasını kapatma
            workbook.Close(false);
            excelApp.Quit();

            // COM nesnelerini serbest bırakma
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            // Okunan verileri ekrana yazdırma (isteğe bağlı)
            //foreach (var row in data)
            //{
            //    domaindekiKullanicilar.Add(row);
            //}
            domaindekiKullanicilar = data;
            MessageBox.Show("excell okuma");
        }
        private void LoadDataFromExcelToComboBox()
        {
            // Excel dosyasının yolu
            string excelFilePath = @"excel dosya konumu";

            // Excel uygulamasını başlatma
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(excelFilePath);
            Excel.Worksheet worksheet = workbook.Sheets[1]; // İlk çalışma sayfasını seçme
            Excel.Range range = worksheet.UsedRange;

            // Satır sayısını alma
            int rowCount = range.Rows.Count;

            // Satırları döngüyle okuma ve ComboBox'a ekleme
            for (int row = 1; row <= rowCount; row++)
            {
                string cellValue = (range.Cells[row, 1] as Excel.Range).Text;

                // Boş olmayan hücreleri ComboBox'a ekleme
                if (!string.IsNullOrWhiteSpace(cellValue))
                {
                    comboBox1.Items.Add(cellValue);
                    comboBox2.Items.Add(cellValue);
                }
            }

            // Excel dosyasını kapatma
            workbook.Close(false);
            excelApp.Quit();

            // COM nesnelerini serbest bırakma
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            // İlk öğeyi seçili hale getirmek için (isteğe bağlı)
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                foreach (var user in pasifler.Keys)
                {
                    RemoveUserPermissionsFromFolder(user.ToString(), pasifler[user].ToString() , richTextBox1);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (users2.Count != 0)
            {
                if (textBox1 != null)
                {
                    try
                    {
                        if (okumaCHCK != null || okumayurutmeCHCK != null || yazmaCHCK != null || listelemeCHCK != null || degistirmeCHCK != null || fullcontrolCHCK != null)
                        {
                            foreach (string user in users2)
                            {
                                
                                    KaldirPermissions(textBox1.Text, user, okumaCHCK, yazmaCHCK, listelemeCHCK, degistirmeCHCK, okumayurutmeCHCK, fullcontrolCHCK);
                                
                                MessageBox.Show($"Kullanıcı {user} için yetkiler başarıyla kaldırıldı.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Yetki Seviyesi Seçin");
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show("Yetkisiz erişim hatası: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Klasör hiyerarşisinden klasör seçin.");
                }

            }
            else
            {
                MessageBox.Show("Önce kullanıcı seçin");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (users2.Count != 0)
            {
                if (textBox1 != null)
                {
                    try
                    {
                        if (okumaCHCK != null || okumayurutmeCHCK != null || yazmaCHCK != null || listelemeCHCK != null || degistirmeCHCK != null || fullcontrolCHCK != null)
                        {
                            foreach (string user in users2)
                            {
                                
                                    SetPermissions(textBox1.Text, user, okumaCHCK, yazmaCHCK, listelemeCHCK, degistirmeCHCK, okumayurutmeCHCK, fullcontrolCHCK);
                                
                                MessageBox.Show($"Kullanıcı {user} için yetkiler başarıyla verildi.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Yetki Seviyesi Seçin");
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show("Yetkisiz erişim hatası: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Klasör hiyerarşisinden klasör seçin.");
                }

            }
            else
            {
                MessageBox.Show("Önce kullanıcı seçin");
            }
        }
    }
    //---------------------Sınıflar------------------------//
    public class Paths
    {
         public string uzunYol { get; set; }
         public string kisaYol { get; set; }

        public Paths(string uzunYol, string kisaYol)
        {
            this.uzunYol = uzunYol;
            this.kisaYol = kisaYol;
        }
     
    }
}

