namespace DiscordEmbedSender
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbTarget = new System.Windows.Forms.GroupBox();
            this.tableLayoutTarget = new System.Windows.Forms.TableLayoutPanel();
            this.rbChannel = new System.Windows.Forms.RadioButton();
            this.rbDM = new System.Windows.Forms.RadioButton();
            this.lblServer = new System.Windows.Forms.Label();
            this.cmbServerSelection = new System.Windows.Forms.ComboBox();
            this.lblChannel = new System.Windows.Forms.Label();
            this.cmbChannelSelection = new System.Windows.Forms.ComboBox();
            this.lblUserSearch = new System.Windows.Forms.Label();
            this.txtUserSearch = new System.Windows.Forms.TextBox();
            this.btnSearchUsers = new System.Windows.Forms.Button();
            this.lblUserSelection = new System.Windows.Forms.Label();
            this.cmbUserSelection = new System.Windows.Forms.ComboBox();
            this.gbEmbed = new System.Windows.Forms.GroupBox();
            this.tableLayoutEmbed = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.lblThumbnail = new System.Windows.Forms.Label();
            this.txtThumbnail = new System.Windows.Forms.TextBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.lblFooter = new System.Windows.Forms.Label();
            this.txtFooter = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.chkTimestamp = new System.Windows.Forms.CheckBox();
            this.gbFields = new System.Windows.Forms.GroupBox();
            this.panelFields = new System.Windows.Forms.Panel();
            this.dgvFields = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInline = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelFieldButtons = new System.Windows.Forms.Panel();
            this.btnRemoveField = new System.Windows.Forms.Button();
            this.btnAddField = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnSendEmbed = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.tableLayoutMain.SuspendLayout();
            this.gbTarget.SuspendLayout();
            this.tableLayoutTarget.SuspendLayout();
            this.gbEmbed.SuspendLayout();
            this.tableLayoutEmbed.SuspendLayout();
            this.gbFields.SuspendLayout();
            this.panelFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).BeginInit();
            this.panelFieldButtons.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 1;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Controls.Add(this.gbTarget, 0, 0);
            this.tableLayoutMain.Controls.Add(this.gbEmbed, 0, 1);
            this.tableLayoutMain.Controls.Add(this.gbFields, 0, 2);
            this.tableLayoutMain.Controls.Add(this.panelButtons, 0, 3);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutMain.RowCount = 4;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutMain.Size = new System.Drawing.Size(884, 661);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // gbTarget
            // 
            this.gbTarget.Controls.Add(this.tableLayoutTarget);
            this.gbTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTarget.Location = new System.Drawing.Point(13, 13);
            this.gbTarget.Name = "gbTarget";
            this.gbTarget.Padding = new System.Windows.Forms.Padding(10);
            this.gbTarget.Size = new System.Drawing.Size(858, 120);
            this.gbTarget.TabIndex = 0;
            this.gbTarget.TabStop = false;
            this.gbTarget.Text = "Ziel auswählen";
            // 
            // tableLayoutTarget
            // 
            this.tableLayoutTarget.ColumnCount = 5;
            this.tableLayoutTarget.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutTarget.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutTarget.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutTarget.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutTarget.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutTarget.Controls.Add(this.rbChannel, 0, 0);
            this.tableLayoutTarget.Controls.Add(this.rbDM, 1, 0);
            this.tableLayoutTarget.Controls.Add(this.lblServer, 0, 1);
            this.tableLayoutTarget.Controls.Add(this.cmbServerSelection, 1, 1);
            this.tableLayoutTarget.Controls.Add(this.lblChannel, 3, 1);
            this.tableLayoutTarget.Controls.Add(this.cmbChannelSelection, 4, 1);
            this.tableLayoutTarget.Controls.Add(this.lblUserSearch, 0, 2);
            this.tableLayoutTarget.Controls.Add(this.txtUserSearch, 1, 2);
            this.tableLayoutTarget.Controls.Add(this.btnSearchUsers, 2, 2);
            this.tableLayoutTarget.Controls.Add(this.lblUserSelection, 3, 2);
            this.tableLayoutTarget.Controls.Add(this.cmbUserSelection, 4, 2);
            this.tableLayoutTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutTarget.Location = new System.Drawing.Point(10, 25);
            this.tableLayoutTarget.Name = "tableLayoutTarget";
            this.tableLayoutTarget.RowCount = 3;
            this.tableLayoutTarget.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutTarget.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutTarget.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutTarget.Size = new System.Drawing.Size(838, 85);
            this.tableLayoutTarget.TabIndex = 0;
            // 
            // rbChannel
            // 
            this.rbChannel.AutoSize = true;
            this.rbChannel.Checked = true;
            this.rbChannel.Location = new System.Drawing.Point(3, 3);
            this.rbChannel.Name = "rbChannel";
            this.rbChannel.Size = new System.Drawing.Size(54, 17);
            this.rbChannel.TabIndex = 0;
            this.rbChannel.TabStop = true;
            this.rbChannel.Text = "Kanal";
            this.rbChannel.UseVisualStyleBackColor = true;
            this.rbChannel.CheckedChanged += new System.EventHandler(this.RbChannel_CheckedChanged);
            // 
            // rbDM
            // 
            this.rbDM.AutoSize = true;
            this.rbDM.Location = new System.Drawing.Point(63, 3);
            this.rbDM.Name = "rbDM";
            this.rbDM.Size = new System.Drawing.Size(108, 17);
            this.rbDM.TabIndex = 1;
            this.rbDM.Text = "Direct Message";
            this.rbDM.UseVisualStyleBackColor = true;
            this.rbDM.CheckedChanged += new System.EventHandler(this.RbDM_CheckedChanged);
            // 
            // lblServer
            // 
            this.lblServer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(3, 33);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(41, 13);
            this.lblServer.TabIndex = 2;
            this.lblServer.Text = "Server:";
            // 
            // cmbServerSelection
            // 
            this.cmbServerSelection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbServerSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServerSelection.FormattingEnabled = true;
            this.cmbServerSelection.Location = new System.Drawing.Point(63, 29);
            this.cmbServerSelection.Name = "cmbServerSelection";
            this.cmbServerSelection.Size = new System.Drawing.Size(200, 21);
            this.cmbServerSelection.TabIndex = 3;
            this.cmbServerSelection.SelectedIndexChanged += new System.EventHandler(this.CmbServerSelection_SelectedIndexChanged);
            // 
            // lblChannel
            // 
            this.lblChannel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblChannel.AutoSize = true;
            this.lblChannel.Location = new System.Drawing.Point(417, 33);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(38, 13);
            this.lblChannel.TabIndex = 4;
            this.lblChannel.Text = "Kanal:";
            // 
            // cmbChannelSelection
            // 
            this.cmbChannelSelection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbChannelSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannelSelection.FormattingEnabled = true;
            this.cmbChannelSelection.Location = new System.Drawing.Point(461, 29);
            this.cmbChannelSelection.Name = "cmbChannelSelection";
            this.cmbChannelSelection.Size = new System.Drawing.Size(200, 21);
            this.cmbChannelSelection.TabIndex = 5;
            // 
            // lblUserSearch
            // 
            this.lblUserSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUserSearch.AutoSize = true;
            this.lblUserSearch.Location = new System.Drawing.Point(3, 62);
            this.lblUserSearch.Name = "lblUserSearch";
            this.lblUserSearch.Size = new System.Drawing.Size(44, 13);
            this.lblUserSearch.TabIndex = 6;
            this.lblUserSearch.Text = "Suchen:";
            // 
            // txtUserSearch
            // 
            this.txtUserSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUserSearch.Location = new System.Drawing.Point(63, 58);
            this.txtUserSearch.Name = "txtUserSearch";
            this.txtUserSearch.Size = new System.Drawing.Size(150, 20);
            this.txtUserSearch.TabIndex = 7;
            // 
            // btnSearchUsers
            // 
            this.btnSearchUsers.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSearchUsers.Location = new System.Drawing.Point(269, 57);
            this.btnSearchUsers.Name = "btnSearchUsers";
            this.btnSearchUsers.Size = new System.Drawing.Size(80, 23);
            this.btnSearchUsers.TabIndex = 8;
            this.btnSearchUsers.Text = "Suchen";
            this.btnSearchUsers.UseVisualStyleBackColor = true;
            this.btnSearchUsers.Click += new System.EventHandler(this.BtnSearchUsers_Click);
            // 
            // lblUserSelection
            // 
            this.lblUserSelection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUserSelection.AutoSize = true;
            this.lblUserSelection.Location = new System.Drawing.Point(417, 62);
            this.lblUserSelection.Name = "lblUserSelection";
            this.lblUserSelection.Size = new System.Drawing.Size(41, 13);
            this.lblUserSelection.TabIndex = 9;
            this.lblUserSelection.Text = "Nutzer:";
            // 
            // cmbUserSelection
            // 
            this.cmbUserSelection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbUserSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserSelection.FormattingEnabled = true;
            this.cmbUserSelection.Location = new System.Drawing.Point(461, 58);
            this.cmbUserSelection.Name = "cmbUserSelection";
            this.cmbUserSelection.Size = new System.Drawing.Size(200, 21);
            this.cmbUserSelection.TabIndex = 10;
            // 
            // gbEmbed
            // 
            this.gbEmbed.Controls.Add(this.tableLayoutEmbed);
            this.gbEmbed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEmbed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEmbed.Location = new System.Drawing.Point(13, 139);
            this.gbEmbed.Name = "gbEmbed";
            this.gbEmbed.Padding = new System.Windows.Forms.Padding(10);
            this.gbEmbed.Size = new System.Drawing.Size(858, 180);
            this.gbEmbed.TabIndex = 1;
            this.gbEmbed.TabStop = false;
            this.gbEmbed.Text = "Embed Konfiguration";
            // 
            // tableLayoutEmbed
            // 
            this.tableLayoutEmbed.ColumnCount = 4;
            this.tableLayoutEmbed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutEmbed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutEmbed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutEmbed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutEmbed.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutEmbed.Controls.Add(this.txtTitle, 1, 0);
            this.tableLayoutEmbed.Controls.Add(this.lblDescription, 2, 0);
            this.tableLayoutEmbed.Controls.Add(this.txtDescription, 3, 0);
            this.tableLayoutEmbed.Controls.Add(this.lblColor, 0, 1);
            this.tableLayoutEmbed.Controls.Add(this.txtColor, 1, 1);
            this.tableLayoutEmbed.Controls.Add(this.lblThumbnail, 2, 1);
            this.tableLayoutEmbed.Controls.Add(this.txtThumbnail, 3, 1);
            this.tableLayoutEmbed.Controls.Add(this.lblImage, 0, 2);
            this.tableLayoutEmbed.Controls.Add(this.txtImage, 1, 2);
            this.tableLayoutEmbed.Controls.Add(this.lblFooter, 2, 2);
            this.tableLayoutEmbed.Controls.Add(this.txtFooter, 3, 2);
            this.tableLayoutEmbed.Controls.Add(this.lblAuthor, 0, 3);
            this.tableLayoutEmbed.Controls.Add(this.txtAuthor, 1, 3);
            this.tableLayoutEmbed.Controls.Add(this.lblUrl, 2, 3);
            this.tableLayoutEmbed.Controls.Add(this.txtUrl, 3, 3);
            this.tableLayoutEmbed.Controls.Add(this.chkTimestamp, 0, 4);
            this.tableLayoutEmbed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutEmbed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutEmbed.Location = new System.Drawing.Point(10, 25);
            this.tableLayoutEmbed.Name = "tableLayoutEmbed";
            this.tableLayoutEmbed.RowCount = 5;
            this.tableLayoutEmbed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutEmbed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutEmbed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutEmbed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutEmbed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutEmbed.Size = new System.Drawing.Size(838, 145);
            this.tableLayoutEmbed.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Titel:";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(88, 3);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(324, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(418, 6);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(75, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Beschreibung:";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(514, 3);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(321, 20);
            this.txtDescription.TabIndex = 3;
            // 
            // lblColor
            // 
            this.lblColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(3, 32);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(69, 13);
            this.lblColor.TabIndex = 4;
            this.lblColor.Text = "Farbe (Hex):";
            // 
            // txtColor
            // 
            this.txtColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtColor.Location = new System.Drawing.Point(88, 29);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(324, 20);
            this.txtColor.TabIndex = 5;
            this.txtColor.Text = "#3498db";
            this.txtColor.Leave += new System.EventHandler(this.TxtColor_Leave);
            // 
            // lblThumbnail
            // 
            this.lblThumbnail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblThumbnail.AutoSize = true;
            this.lblThumbnail.Location = new System.Drawing.Point(418, 32);
            this.lblThumbnail.Name = "lblThumbnail";
            this.lblThumbnail.Size = new System.Drawing.Size(90, 13);
            this.lblThumbnail.TabIndex = 6;
            this.lblThumbnail.Text = "Thumbnail URL:";
            // 
            // txtThumbnail
            // 
            this.txtThumbnail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtThumbnail.Location = new System.Drawing.Point(514, 29);
            this.txtThumbnail.Name = "txtThumbnail";
            this.txtThumbnail.Size = new System.Drawing.Size(321, 20);
            this.txtThumbnail.TabIndex = 7;
            // 
            // lblImage
            // 
            this.lblImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(3, 58);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(58, 13);
            this.lblImage.TabIndex = 8;
            this.lblImage.Text = "Bild URL:";
            // 
            // txtImage
            // 
            this.txtImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImage.Location = new System.Drawing.Point(88, 55);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(324, 20);
            this.txtImage.TabIndex = 9;
            // 
            // lblFooter
            // 
            this.lblFooter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFooter.AutoSize = true;
            this.lblFooter.Location = new System.Drawing.Point(418, 58);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(40, 13);
            this.lblFooter.TabIndex = 10;
            this.lblFooter.Text = "Footer:";
            // 
            // txtFooter
            // 
            this.txtFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFooter.Location = new System.Drawing.Point(514, 55);
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.Size = new System.Drawing.Size(321, 20);
            this.txtFooter.TabIndex = 11;
            // 
            // lblAuthor
            // 
            this.lblAuthor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(3, 84);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(37, 13);
            this.lblAuthor.TabIndex = 12;
            this.lblAuthor.Text = "Autor:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthor.Location = new System.Drawing.Point(88, 81);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(324, 20);
            this.txtAuthor.TabIndex = 13;
            // 
            // lblUrl
            // 
            this.lblUrl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(418, 84);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(32, 13);
            this.lblUrl.TabIndex = 14;
            this.lblUrl.Text = "URL:";
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(514, 81);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(321, 20);
            this.txtUrl.TabIndex = 15;
            // 
            // chkTimestamp
            // 
            this.chkTimestamp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkTimestamp.AutoSize = true;
            this.tableLayoutEmbed.SetColumnSpan(this.chkTimestamp, 2);
            this.chkTimestamp.Location = new System.Drawing.Point(3, 110);
            this.chkTimestamp.Name = "chkTimestamp";
            this.chkTimestamp.Size = new System.Drawing.Size(205, 17);
            this.chkTimestamp.TabIndex = 16;
            this.chkTimestamp.Text = "Aktuellen Zeitstempel hinzufügen";
            this.chkTimestamp.UseVisualStyleBackColor = true;
            // 
            // gbFields
            // 
            this.gbFields.Controls.Add(this.panelFields);
            this.gbFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFields.Location = new System.Drawing.Point(13, 325);
            this.gbFields.Name = "gbFields";
            this.gbFields.Padding = new System.Windows.Forms.Padding(10);
            this.gbFields.Size = new System.Drawing.Size(858, 269);
            this.gbFields.TabIndex = 2;
            this.gbFields.TabStop = false;
            this.gbFields.Text = "Embed Fields";
            // 
            // panelFields
            // 
            this.panelFields.Controls.Add(this.dgvFields);
            this.panelFields.Controls.Add(this.panelFieldButtons);
            this.panelFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFields.Location = new System.Drawing.Point(10, 25);
            this.panelFields.Name = "panelFields";
            this.panelFields.Size = new System.Drawing.Size(838, 234);
            this.panelFields.TabIndex = 0;
            // 
            // dgvFields
            // 
            this.dgvFields.AllowUserToAddRows = false;
            this.dgvFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colValue,
            this.colInline});
            this.dgvFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFields.Location = new System.Drawing.Point(0, 0);
            this.dgvFields.MultiSelect = false;
            this.dgvFields.Name = "dgvFields";
            this.dgvFields.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFields.Size = new System.Drawing.Size(838, 194);
            this.dgvFields.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 200;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "Wert";
            this.colValue.Name = "colValue";
            this.colValue.Width = 400;
            // 
            // colInline
            // 
            this.colInline.HeaderText = "Inline";
            this.colInline.Name = "colInline";
            this.colInline.Width = 80;
            // 
            // panelFieldButtons
            // 
            this.panelFieldButtons.Controls.Add(this.btnRemoveField);
            this.panelFieldButtons.Controls.Add(this.btnAddField);
            this.panelFieldButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFieldButtons.Location = new System.Drawing.Point(0, 194);
            this.panelFieldButtons.Name = "panelFieldButtons";
            this.panelFieldButtons.Size = new System.Drawing.Size(838, 40);
            this.panelFieldButtons.TabIndex = 1;
            // 
            // btnRemoveField
            // 
            this.btnRemoveField.Location = new System.Drawing.Point(140, 8);
            this.btnRemoveField.Name = "btnRemoveField";
            this.btnRemoveField.Size = new System.Drawing.Size(120, 30);
            this.btnRemoveField.TabIndex = 1;
            this.btnRemoveField.Text = "Field entfernen";
            this.btnRemoveField.UseVisualStyleBackColor = true;
            this.btnRemoveField.Click += new System.EventHandler(this.BtnRemoveField_Click);
            // 
            // btnAddField
            // 
            this.btnAddField.Location = new System.Drawing.Point(10, 8);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(120, 30);
            this.btnAddField.TabIndex = 0;
            this.btnAddField.Text = "Field hinzufügen";
            this.btnAddField.UseVisualStyleBackColor = true;
            this.btnAddField.Click += new System.EventHandler(this.BtnAddField_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnSendEmbed);
            this.panelButtons.Controls.Add(this.btnPreview);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(13, 600);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(858, 48);
            this.panelButtons.TabIndex = 3;
            // 
            // btnSendEmbed
            // 
            this.btnSendEmbed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendEmbed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmbed.Location = new System.Drawing.Point(728, 10);
            this.btnSendEmbed.Name = "btnSendEmbed";
            this.btnSendEmbed.Size = new System.Drawing.Size(120, 35);
            this.btnSendEmbed.TabIndex = 1;
            this.btnSendEmbed.Text = "Embed Senden";
            this.btnSendEmbed.UseVisualStyleBackColor = true;
            this.btnSendEmbed.Click += new System.EventHandler(this.BtnSendEmbed_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(602, 10);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(120, 35);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "Vorschau";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.tableLayoutMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discord Embed Sender";
            this.tableLayoutMain.ResumeLayout(false);
            this.gbTarget.ResumeLayout(false);
            this.tableLayoutTarget.ResumeLayout(false);
            this.tableLayoutTarget.PerformLayout();
            this.gbEmbed.ResumeLayout(false);
            this.tableLayoutEmbed.ResumeLayout(false);
            this.tableLayoutEmbed.PerformLayout();
            this.gbFields.ResumeLayout(false);
            this.panelFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).EndInit();
            this.panelFieldButtons.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.GroupBox gbTarget;
        private System.Windows.Forms.TableLayoutPanel tableLayoutTarget;
        private System.Windows.Forms.RadioButton rbChannel;
        private System.Windows.Forms.RadioButton rbDM;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.ComboBox cmbServerSelection;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.ComboBox cmbChannelSelection;
        private System.Windows.Forms.Label lblUserSearch;
        private System.Windows.Forms.TextBox txtUserSearch;
        private System.Windows.Forms.Button btnSearchUsers;
        private System.Windows.Forms.Label lblUserSelection;
        private System.Windows.Forms.ComboBox cmbUserSelection;
        private System.Windows.Forms.GroupBox gbEmbed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutEmbed;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblThumbnail;
        private System.Windows.Forms.TextBox txtThumbnail;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.TextBox txtFooter;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.CheckBox chkTimestamp;
        private System.Windows.Forms.GroupBox gbFields;
        private System.Windows.Forms.Panel panelFields;
        private System.Windows.Forms.DataGridView dgvFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colInline;
        private System.Windows.Forms.Panel panelFieldButtons;
        private System.Windows.Forms.Button btnRemoveField;
        private System.Windows.Forms.Button btnAddField;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSendEmbed;
        private System.Windows.Forms.Button btnPreview;
    }
}