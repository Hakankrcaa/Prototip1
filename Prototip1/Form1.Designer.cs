namespace Prototip1
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.klasorSec = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.yazdir = new System.Windows.Forms.Button();
            this.temizle = new System.Windows.Forms.Button();
            this.hiyerarsiSec = new System.Windows.Forms.Button();
            this.sorgula = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.temizlee = new System.Windows.Forms.Button();
            this.kullaniciSorgula = new System.Windows.Forms.Button();
            this.excelCiktiKullanici = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kullaniciKlasor = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.yetkiKisiSec = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.okumayurutmeCHCK = new System.Windows.Forms.CheckBox();
            this.yazmaCHCK = new System.Windows.Forms.CheckBox();
            this.listelemeCHCK = new System.Windows.Forms.CheckBox();
            this.degistirmeCHCK = new System.Windows.Forms.CheckBox();
            this.okumaCHCK = new System.Windows.Forms.CheckBox();
            this.fullcontrolCHCK = new System.Windows.Forms.CheckBox();
            this.yetkiKaldirr = new System.Windows.Forms.Button();
            this.yetkiVerr = new System.Windows.Forms.Button();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.klasorSecc = new System.Windows.Forms.Button();
            this.kullaniciSecc = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // klasorSec
            // 
            this.klasorSec.Location = new System.Drawing.Point(33, 199);
            this.klasorSec.Name = "klasorSec";
            this.klasorSec.Size = new System.Drawing.Size(75, 23);
            this.klasorSec.TabIndex = 1;
            this.klasorSec.Text = "Klasör seç";
            this.klasorSec.UseVisualStyleBackColor = true;
            this.klasorSec.Click += new System.EventHandler(this.klasorSec_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBox1.Location = new System.Drawing.Point(9, 30);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(749, 163);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Tüm Dosyalar (*.*)|*.*";
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.ReadOnlyChecked = true;
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.ShowReadOnly = true;
            this.openFileDialog1.Title = "Dosya Seç";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.yazdir);
            this.panel1.Controls.Add(this.temizle);
            this.panel1.Controls.Add(this.hiyerarsiSec);
            this.panel1.Controls.Add(this.sorgula);
            this.panel1.Controls.Add(this.klasorSec);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Location = new System.Drawing.Point(276, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 229);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 27);
            this.button1.TabIndex = 10;
            this.button1.Text = "Pasif Kullanıcı Yetki Kaldır";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(5, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dosya Bazlı Sorgulama Paneli";
            // 
            // yazdir
            // 
            this.yazdir.BackColor = System.Drawing.Color.Lime;
            this.yazdir.Location = new System.Drawing.Point(579, 203);
            this.yazdir.Name = "yazdir";
            this.yazdir.Size = new System.Drawing.Size(75, 23);
            this.yazdir.TabIndex = 5;
            this.yazdir.Text = "Excel Çıktısı";
            this.yazdir.UseVisualStyleBackColor = false;
            this.yazdir.Click += new System.EventHandler(this.yazdir_Click);
            // 
            // temizle
            // 
            this.temizle.BackColor = System.Drawing.Color.Red;
            this.temizle.Location = new System.Drawing.Point(498, 203);
            this.temizle.Name = "temizle";
            this.temizle.Size = new System.Drawing.Size(75, 23);
            this.temizle.TabIndex = 4;
            this.temizle.Text = "Temizle";
            this.temizle.UseVisualStyleBackColor = false;
            this.temizle.Click += new System.EventHandler(this.temizle_Click);
            // 
            // hiyerarsiSec
            // 
            this.hiyerarsiSec.Location = new System.Drawing.Point(114, 199);
            this.hiyerarsiSec.Name = "hiyerarsiSec";
            this.hiyerarsiSec.Size = new System.Drawing.Size(96, 23);
            this.hiyerarsiSec.TabIndex = 9;
            this.hiyerarsiSec.Text = "Seç";
            this.hiyerarsiSec.UseVisualStyleBackColor = true;
            this.hiyerarsiSec.Click += new System.EventHandler(this.hiyerarsiSec_Click);
            // 
            // sorgula
            // 
            this.sorgula.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.sorgula.Location = new System.Drawing.Point(382, 203);
            this.sorgula.Name = "sorgula";
            this.sorgula.Size = new System.Drawing.Size(108, 23);
            this.sorgula.TabIndex = 3;
            this.sorgula.Text = "Sorgula";
            this.sorgula.UseVisualStyleBackColor = false;
            this.sorgula.Click += new System.EventHandler(this.sorgula_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.Location = new System.Drawing.Point(395, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 47);
            this.button3.TabIndex = 4;
            this.button3.Text = "Kullanıcıları Güncelle";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.kullaniciGuncelle_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(87, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Kullanıcı :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.temizlee);
            this.panel2.Controls.Add(this.kullaniciSorgula);
            this.panel2.Controls.Add(this.excelCiktiKullanici);
            this.panel2.Controls.Add(this.richTextBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.kullaniciKlasor);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(276, 265);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(763, 192);
            this.panel2.TabIndex = 7;
            // 
            // temizlee
            // 
            this.temizlee.BackColor = System.Drawing.Color.Red;
            this.temizlee.Location = new System.Drawing.Point(496, 162);
            this.temizlee.Name = "temizlee";
            this.temizlee.Size = new System.Drawing.Size(75, 23);
            this.temizlee.TabIndex = 14;
            this.temizlee.Text = "Temizle";
            this.temizlee.UseVisualStyleBackColor = false;
            this.temizlee.Click += new System.EventHandler(this.temizlee_Click);
            // 
            // kullaniciSorgula
            // 
            this.kullaniciSorgula.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.kullaniciSorgula.Location = new System.Drawing.Point(380, 162);
            this.kullaniciSorgula.Name = "kullaniciSorgula";
            this.kullaniciSorgula.Size = new System.Drawing.Size(108, 23);
            this.kullaniciSorgula.TabIndex = 13;
            this.kullaniciSorgula.Text = "Sorgula";
            this.kullaniciSorgula.UseVisualStyleBackColor = false;
            this.kullaniciSorgula.Click += new System.EventHandler(this.kullaniciSorgula_Click);
            // 
            // excelCiktiKullanici
            // 
            this.excelCiktiKullanici.BackColor = System.Drawing.Color.Lime;
            this.excelCiktiKullanici.Location = new System.Drawing.Point(577, 162);
            this.excelCiktiKullanici.Name = "excelCiktiKullanici";
            this.excelCiktiKullanici.Size = new System.Drawing.Size(75, 23);
            this.excelCiktiKullanici.TabIndex = 12;
            this.excelCiktiKullanici.Text = "Excel Çıktısı";
            this.excelCiktiKullanici.UseVisualStyleBackColor = false;
            this.excelCiktiKullanici.Click += new System.EventHandler(this.excelCiktiKullanici_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Enabled = false;
            this.richTextBox2.Location = new System.Drawing.Point(3, 63);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(753, 96);
            this.richTextBox2.TabIndex = 11;
            this.richTextBox2.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Kullanıcı Filtreli Sorgulama Paneli";
            // 
            // kullaniciKlasor
            // 
            this.kullaniciKlasor.Location = new System.Drawing.Point(295, 25);
            this.kullaniciKlasor.Name = "kullaniciKlasor";
            this.kullaniciKlasor.Size = new System.Drawing.Size(94, 35);
            this.kullaniciKlasor.TabIndex = 9;
            this.kullaniciKlasor.Text = "Sorgulanacak klasörü seç";
            this.kullaniciKlasor.UseVisualStyleBackColor = true;
            this.kullaniciKlasor.Click += new System.EventHandler(this.kullaniciKlasor_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(214, 30);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 30);
            this.button4.TabIndex = 7;
            this.button4.Text = "Kullanıcı seç";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.kullaniciSec_Click);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.treeView1.Location = new System.Drawing.Point(4, 30);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(266, 580);
            this.treeView1.TabIndex = 8;
            // 
            // ımageList1
            // 
            this.ımageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ımageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // yetkiKisiSec
            // 
            this.yetkiKisiSec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.yetkiKisiSec.Enabled = false;
            this.yetkiKisiSec.Location = new System.Drawing.Point(4, 635);
            this.yetkiKisiSec.Name = "yetkiKisiSec";
            this.yetkiKisiSec.Size = new System.Drawing.Size(266, 20);
            this.yetkiKisiSec.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.okumayurutmeCHCK);
            this.panel3.Controls.Add(this.yazmaCHCK);
            this.panel3.Controls.Add(this.listelemeCHCK);
            this.panel3.Controls.Add(this.degistirmeCHCK);
            this.panel3.Controls.Add(this.okumaCHCK);
            this.panel3.Controls.Add(this.fullcontrolCHCK);
            this.panel3.Controls.Add(this.yetkiKaldirr);
            this.panel3.Controls.Add(this.yetkiVerr);
            this.panel3.Controls.Add(this.richTextBox3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.klasorSecc);
            this.panel3.Controls.Add(this.kullaniciSecc);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.comboBox2);
            this.panel3.Location = new System.Drawing.Point(276, 463);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(763, 192);
            this.panel3.TabIndex = 12;
            // 
            // okumayurutmeCHCK
            // 
            this.okumayurutmeCHCK.AutoSize = true;
            this.okumayurutmeCHCK.Location = new System.Drawing.Point(516, 43);
            this.okumayurutmeCHCK.Name = "okumayurutmeCHCK";
            this.okumayurutmeCHCK.Size = new System.Drawing.Size(117, 17);
            this.okumayurutmeCHCK.TabIndex = 15;
            this.okumayurutmeCHCK.Text = "Okuma ve Yürütme";
            this.okumayurutmeCHCK.UseVisualStyleBackColor = true;
            // 
            // yazmaCHCK
            // 
            this.yazmaCHCK.AutoSize = true;
            this.yazmaCHCK.Location = new System.Drawing.Point(411, 25);
            this.yazmaCHCK.Name = "yazmaCHCK";
            this.yazmaCHCK.Size = new System.Drawing.Size(101, 17);
            this.yazmaCHCK.TabIndex = 15;
            this.yazmaCHCK.Text = "Yalnızca Yazma";
            this.yazmaCHCK.UseVisualStyleBackColor = true;
            // 
            // listelemeCHCK
            // 
            this.listelemeCHCK.AutoSize = true;
            this.listelemeCHCK.Location = new System.Drawing.Point(411, 43);
            this.listelemeCHCK.Name = "listelemeCHCK";
            this.listelemeCHCK.Size = new System.Drawing.Size(99, 17);
            this.listelemeCHCK.TabIndex = 15;
            this.listelemeCHCK.Text = "İçerik Listeleme";
            this.listelemeCHCK.UseVisualStyleBackColor = true;
            // 
            // degistirmeCHCK
            // 
            this.degistirmeCHCK.AutoSize = true;
            this.degistirmeCHCK.Location = new System.Drawing.Point(516, 25);
            this.degistirmeCHCK.Name = "degistirmeCHCK";
            this.degistirmeCHCK.Size = new System.Drawing.Size(75, 17);
            this.degistirmeCHCK.TabIndex = 15;
            this.degistirmeCHCK.Text = "Değiştirme";
            this.degistirmeCHCK.UseVisualStyleBackColor = true;
            // 
            // okumaCHCK
            // 
            this.okumaCHCK.AutoSize = true;
            this.okumaCHCK.Location = new System.Drawing.Point(639, 25);
            this.okumaCHCK.Name = "okumaCHCK";
            this.okumaCHCK.Size = new System.Drawing.Size(103, 17);
            this.okumaCHCK.TabIndex = 15;
            this.okumaCHCK.Text = "Yalnızca Okuma";
            this.okumaCHCK.UseVisualStyleBackColor = true;
            // 
            // fullcontrolCHCK
            // 
            this.fullcontrolCHCK.AutoSize = true;
            this.fullcontrolCHCK.Location = new System.Drawing.Point(639, 43);
            this.fullcontrolCHCK.Name = "fullcontrolCHCK";
            this.fullcontrolCHCK.Size = new System.Drawing.Size(89, 17);
            this.fullcontrolCHCK.TabIndex = 15;
            this.fullcontrolCHCK.Text = "Tam Denetim";
            this.fullcontrolCHCK.UseVisualStyleBackColor = true;
            // 
            // yetkiKaldirr
            // 
            this.yetkiKaldirr.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.yetkiKaldirr.Location = new System.Drawing.Point(507, 162);
            this.yetkiKaldirr.Name = "yetkiKaldirr";
            this.yetkiKaldirr.Size = new System.Drawing.Size(91, 23);
            this.yetkiKaldirr.TabIndex = 14;
            this.yetkiKaldirr.Text = "Yetki Kaldır";
            this.yetkiKaldirr.UseVisualStyleBackColor = false;
            this.yetkiKaldirr.Click += new System.EventHandler(this.yetkiKaldirr_Click);
            // 
            // yetkiVerr
            // 
            this.yetkiVerr.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.yetkiVerr.Location = new System.Drawing.Point(613, 162);
            this.yetkiVerr.Name = "yetkiVerr";
            this.yetkiVerr.Size = new System.Drawing.Size(91, 23);
            this.yetkiVerr.TabIndex = 13;
            this.yetkiVerr.Text = "Yetki ver";
            this.yetkiVerr.UseVisualStyleBackColor = false;
            this.yetkiVerr.Click += new System.EventHandler(this.yetkiVerr_Click);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(3, 63);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(753, 96);
            this.richTextBox3.TabIndex = 11;
            this.richTextBox3.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, -2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Yetki Ekleme / Kaldırma Paneli ";
            // 
            // klasorSecc
            // 
            this.klasorSecc.Location = new System.Drawing.Point(295, 25);
            this.klasorSecc.Name = "klasorSecc";
            this.klasorSecc.Size = new System.Drawing.Size(94, 35);
            this.klasorSecc.TabIndex = 9;
            this.klasorSecc.Text = "Sorgulanacak klasörü seç";
            this.klasorSecc.UseVisualStyleBackColor = true;
            this.klasorSecc.Click += new System.EventHandler(this.klasorSecc_Click);
            // 
            // kullaniciSecc
            // 
            this.kullaniciSecc.Location = new System.Drawing.Point(214, 30);
            this.kullaniciSecc.Name = "kullaniciSecc";
            this.kullaniciSecc.Size = new System.Drawing.Size(75, 30);
            this.kullaniciSecc.TabIndex = 7;
            this.kullaniciSecc.Text = "Kullanıcı seç";
            this.kullaniciSecc.UseVisualStyleBackColor = true;
            this.kullaniciSecc.Click += new System.EventHandler(this.kullaniciSecc_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 22);
            this.label5.TabIndex = 6;
            this.label5.Text = "Kullanıcı :";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(87, 33);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(12, 613);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "Son Seçilen Klasör :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1035, 20);
            this.textBox1.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button2.Location = new System.Drawing.Point(283, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Yetki Kaldır";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button5.Location = new System.Drawing.Point(380, 162);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(91, 23);
            this.button5.TabIndex = 17;
            this.button5.Text = "Yetki ver";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1067, 670);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.yetkiKisiSec);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button klasorSec;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button sorgula;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button kullaniciKlasor;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Button hiyerarsiSec;
        private System.Windows.Forms.Button temizle;
        private System.Windows.Forms.Button yazdir;
        private System.Windows.Forms.TextBox yetkiKisiSec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button klasorSecc;
        private System.Windows.Forms.Button kullaniciSecc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button excelCiktiKullanici;
        private System.Windows.Forms.Button yetkiKaldirr;
        private System.Windows.Forms.Button yetkiVerr;
        private System.Windows.Forms.Button temizlee;
        private System.Windows.Forms.Button kullaniciSorgula;
        private System.Windows.Forms.CheckBox degistirmeCHCK;
        private System.Windows.Forms.CheckBox okumaCHCK;
        private System.Windows.Forms.CheckBox fullcontrolCHCK;
        private System.Windows.Forms.CheckBox okumayurutmeCHCK;
        private System.Windows.Forms.CheckBox yazmaCHCK;
        private System.Windows.Forms.CheckBox listelemeCHCK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button2;
    }
}

