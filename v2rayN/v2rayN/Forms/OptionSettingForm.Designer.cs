﻿namespace v2rayN.Forms
{
    partial class OptionSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionSettingForm));
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmblistenerType = new System.Windows.Forms.ComboBox();
            this.chksniffingEnabled2 = new System.Windows.Forms.CheckBox();
            this.chksniffingEnabled = new System.Windows.Forms.CheckBox();
            this.txtremoteDNS = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkmuxEnabled = new System.Windows.Forms.CheckBox();
            this.chkAllowIn2 = new System.Windows.Forms.CheckBox();
            this.chkudpEnabled2 = new System.Windows.Forms.CheckBox();
            this.cmbprotocol2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtlocalPort2 = new System.Windows.Forms.TextBox();
            this.cmbprotocol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkudpEnabled = new System.Windows.Forms.CheckBox();
            this.chklogEnabled = new System.Windows.Forms.CheckBox();
            this.cmbloglevel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtlocalPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabRouting = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtUseragent = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtUserdirect = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtUserblock = new System.Windows.Forms.TextBox();
            this.tabPreDefinedRules = new System.Windows.Forms.TabPage();
            this.cmbroutingMode = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.linkLabelRoutingDoc = new System.Windows.Forms.LinkLabel();
            this.btnSetDefRountingRule = new System.Windows.Forms.Button();
            this.labRoutingTips = new System.Windows.Forms.Label();
            this.cmbdomainStrategy = new System.Windows.Forms.ComboBox();
            this.tabKCP = new System.Windows.Forms.TabPage();
            this.chkKcpcongestion = new System.Windows.Forms.CheckBox();
            this.txtKcpwriteBufferSize = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtKcpreadBufferSize = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtKcpdownlinkCapacity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKcpuplinkCapacity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtKcptti = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKcpmtu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabGUI = new System.Windows.Forms.TabPage();
            this.chkKeepOlderDedupl = new System.Windows.Forms.CheckBox();
            this.cbFreshrate = new System.Windows.Forms.ComboBox();
            this.lbFreshrate = new System.Windows.Forms.Label();
            this.chkEnableStatistics = new System.Windows.Forms.CheckBox();
            this.chkAllowLANConn = new System.Windows.Forms.CheckBox();
            this.txturlGFWList = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.tabUserPAC = new System.Windows.Forms.TabPage();
            this.txtuserPacRule = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkInterlaceColoring = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabRouting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPreDefinedRules.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabKCP.SuspendLayout();
            this.tabGUI.SuspendLayout();
            this.tabUserPAC.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBasic);
            this.tabControl1.Controls.Add(this.tabRouting);
            this.tabControl1.Controls.Add(this.tabKCP);
            this.tabControl1.Controls.Add(this.tabGUI);
            this.tabControl1.Controls.Add(this.tabUserPAC);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabBasic
            // 
            this.tabBasic.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabBasic, "tabBasic");
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cmblistenerType);
            this.groupBox1.Controls.Add(this.chksniffingEnabled2);
            this.groupBox1.Controls.Add(this.chksniffingEnabled);
            this.groupBox1.Controls.Add(this.txtremoteDNS);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.chkmuxEnabled);
            this.groupBox1.Controls.Add(this.chkAllowIn2);
            this.groupBox1.Controls.Add(this.chkudpEnabled2);
            this.groupBox1.Controls.Add(this.cmbprotocol2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtlocalPort2);
            this.groupBox1.Controls.Add(this.cmbprotocol);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkudpEnabled);
            this.groupBox1.Controls.Add(this.chklogEnabled);
            this.groupBox1.Controls.Add(this.cmbloglevel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtlocalPort);
            this.groupBox1.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // cmblistenerType
            // 
            this.cmblistenerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmblistenerType.FormattingEnabled = true;
            this.cmblistenerType.Items.AddRange(new object[] {
            resources.GetString("cmblistenerType.Items"),
            resources.GetString("cmblistenerType.Items1"),
            resources.GetString("cmblistenerType.Items2"),
            resources.GetString("cmblistenerType.Items3"),
            resources.GetString("cmblistenerType.Items4"),
            resources.GetString("cmblistenerType.Items5"),
            resources.GetString("cmblistenerType.Items6")});
            resources.ApplyResources(this.cmblistenerType, "cmblistenerType");
            this.cmblistenerType.Name = "cmblistenerType";
            // 
            // chksniffingEnabled2
            // 
            resources.ApplyResources(this.chksniffingEnabled2, "chksniffingEnabled2");
            this.chksniffingEnabled2.Name = "chksniffingEnabled2";
            this.chksniffingEnabled2.UseVisualStyleBackColor = true;
            // 
            // chksniffingEnabled
            // 
            resources.ApplyResources(this.chksniffingEnabled, "chksniffingEnabled");
            this.chksniffingEnabled.Name = "chksniffingEnabled";
            this.chksniffingEnabled.UseVisualStyleBackColor = true;
            // 
            // txtremoteDNS
            // 
            resources.ApplyResources(this.txtremoteDNS, "txtremoteDNS");
            this.txtremoteDNS.Name = "txtremoteDNS";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // chkmuxEnabled
            // 
            resources.ApplyResources(this.chkmuxEnabled, "chkmuxEnabled");
            this.chkmuxEnabled.Name = "chkmuxEnabled";
            this.chkmuxEnabled.UseVisualStyleBackColor = true;
            // 
            // chkAllowIn2
            // 
            resources.ApplyResources(this.chkAllowIn2, "chkAllowIn2");
            this.chkAllowIn2.Name = "chkAllowIn2";
            this.chkAllowIn2.UseVisualStyleBackColor = true;
            this.chkAllowIn2.CheckedChanged += new System.EventHandler(this.chkAllowIn2_CheckedChanged);
            // 
            // chkudpEnabled2
            // 
            resources.ApplyResources(this.chkudpEnabled2, "chkudpEnabled2");
            this.chkudpEnabled2.Name = "chkudpEnabled2";
            this.chkudpEnabled2.UseVisualStyleBackColor = true;
            // 
            // cmbprotocol2
            // 
            this.cmbprotocol2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbprotocol2.FormattingEnabled = true;
            this.cmbprotocol2.Items.AddRange(new object[] {
            resources.GetString("cmbprotocol2.Items"),
            resources.GetString("cmbprotocol2.Items1")});
            resources.ApplyResources(this.cmbprotocol2, "cmbprotocol2");
            this.cmbprotocol2.Name = "cmbprotocol2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtlocalPort2
            // 
            resources.ApplyResources(this.txtlocalPort2, "txtlocalPort2");
            this.txtlocalPort2.Name = "txtlocalPort2";
            // 
            // cmbprotocol
            // 
            this.cmbprotocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbprotocol, "cmbprotocol");
            this.cmbprotocol.FormattingEnabled = true;
            this.cmbprotocol.Items.AddRange(new object[] {
            resources.GetString("cmbprotocol.Items"),
            resources.GetString("cmbprotocol.Items1")});
            this.cmbprotocol.Name = "cmbprotocol";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // chkudpEnabled
            // 
            resources.ApplyResources(this.chkudpEnabled, "chkudpEnabled");
            this.chkudpEnabled.Name = "chkudpEnabled";
            this.chkudpEnabled.UseVisualStyleBackColor = true;
            // 
            // chklogEnabled
            // 
            resources.ApplyResources(this.chklogEnabled, "chklogEnabled");
            this.chklogEnabled.Name = "chklogEnabled";
            this.chklogEnabled.UseVisualStyleBackColor = true;
            // 
            // cmbloglevel
            // 
            this.cmbloglevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbloglevel.FormattingEnabled = true;
            this.cmbloglevel.Items.AddRange(new object[] {
            resources.GetString("cmbloglevel.Items"),
            resources.GetString("cmbloglevel.Items1"),
            resources.GetString("cmbloglevel.Items2"),
            resources.GetString("cmbloglevel.Items3"),
            resources.GetString("cmbloglevel.Items4")});
            resources.ApplyResources(this.cmbloglevel, "cmbloglevel");
            this.cmbloglevel.Name = "cmbloglevel";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtlocalPort
            // 
            resources.ApplyResources(this.txtlocalPort, "txtlocalPort");
            this.txtlocalPort.Name = "txtlocalPort";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tabRouting
            // 
            this.tabRouting.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.tabRouting, "tabRouting");
            this.tabRouting.Name = "tabRouting";
            this.tabRouting.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl2);
            this.groupBox2.Controls.Add(this.panel3);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPreDefinedRules);
            resources.ApplyResources(this.tabControl2, "tabControl2");
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtUseragent);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtUseragent
            // 
            resources.ApplyResources(this.txtUseragent, "txtUseragent");
            this.txtUseragent.Name = "txtUseragent";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtUserdirect);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtUserdirect
            // 
            resources.ApplyResources(this.txtUserdirect, "txtUserdirect");
            this.txtUserdirect.Name = "txtUserdirect";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtUserblock);
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // txtUserblock
            // 
            resources.ApplyResources(this.txtUserblock, "txtUserblock");
            this.txtUserblock.Name = "txtUserblock";
            // 
            // tabPreDefinedRules
            // 
            this.tabPreDefinedRules.Controls.Add(this.cmbroutingMode);
            resources.ApplyResources(this.tabPreDefinedRules, "tabPreDefinedRules");
            this.tabPreDefinedRules.Name = "tabPreDefinedRules";
            this.tabPreDefinedRules.UseVisualStyleBackColor = true;
            // 
            // cmbroutingMode
            // 
            this.cmbroutingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbroutingMode.FormattingEnabled = true;
            this.cmbroutingMode.Items.AddRange(new object[] {
            resources.GetString("cmbroutingMode.Items"),
            resources.GetString("cmbroutingMode.Items1"),
            resources.GetString("cmbroutingMode.Items2"),
            resources.GetString("cmbroutingMode.Items3")});
            resources.ApplyResources(this.cmbroutingMode, "cmbroutingMode");
            this.cmbroutingMode.Name = "cmbroutingMode";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.linkLabelRoutingDoc);
            this.panel3.Controls.Add(this.btnSetDefRountingRule);
            this.panel3.Controls.Add(this.labRoutingTips);
            this.panel3.Controls.Add(this.cmbdomainStrategy);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // linkLabelRoutingDoc
            // 
            resources.ApplyResources(this.linkLabelRoutingDoc, "linkLabelRoutingDoc");
            this.linkLabelRoutingDoc.Name = "linkLabelRoutingDoc";
            this.linkLabelRoutingDoc.TabStop = true;
            this.linkLabelRoutingDoc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRoutingDoc_LinkClicked);
            // 
            // btnSetDefRountingRule
            // 
            resources.ApplyResources(this.btnSetDefRountingRule, "btnSetDefRountingRule");
            this.btnSetDefRountingRule.Name = "btnSetDefRountingRule";
            this.btnSetDefRountingRule.UseVisualStyleBackColor = true;
            this.btnSetDefRountingRule.Click += new System.EventHandler(this.btnSetDefRountingRule_Click);
            // 
            // labRoutingTips
            // 
            this.labRoutingTips.ForeColor = System.Drawing.Color.Brown;
            resources.ApplyResources(this.labRoutingTips, "labRoutingTips");
            this.labRoutingTips.Name = "labRoutingTips";
            // 
            // cmbdomainStrategy
            // 
            this.cmbdomainStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdomainStrategy.FormattingEnabled = true;
            this.cmbdomainStrategy.Items.AddRange(new object[] {
            resources.GetString("cmbdomainStrategy.Items"),
            resources.GetString("cmbdomainStrategy.Items1"),
            resources.GetString("cmbdomainStrategy.Items2")});
            resources.ApplyResources(this.cmbdomainStrategy, "cmbdomainStrategy");
            this.cmbdomainStrategy.Name = "cmbdomainStrategy";
            // 
            // tabKCP
            // 
            this.tabKCP.Controls.Add(this.chkKcpcongestion);
            this.tabKCP.Controls.Add(this.txtKcpwriteBufferSize);
            this.tabKCP.Controls.Add(this.label10);
            this.tabKCP.Controls.Add(this.txtKcpreadBufferSize);
            this.tabKCP.Controls.Add(this.label11);
            this.tabKCP.Controls.Add(this.txtKcpdownlinkCapacity);
            this.tabKCP.Controls.Add(this.label8);
            this.tabKCP.Controls.Add(this.txtKcpuplinkCapacity);
            this.tabKCP.Controls.Add(this.label9);
            this.tabKCP.Controls.Add(this.txtKcptti);
            this.tabKCP.Controls.Add(this.label7);
            this.tabKCP.Controls.Add(this.txtKcpmtu);
            this.tabKCP.Controls.Add(this.label6);
            resources.ApplyResources(this.tabKCP, "tabKCP");
            this.tabKCP.Name = "tabKCP";
            this.tabKCP.UseVisualStyleBackColor = true;
            // 
            // chkKcpcongestion
            // 
            resources.ApplyResources(this.chkKcpcongestion, "chkKcpcongestion");
            this.chkKcpcongestion.Name = "chkKcpcongestion";
            this.chkKcpcongestion.UseVisualStyleBackColor = true;
            // 
            // txtKcpwriteBufferSize
            // 
            resources.ApplyResources(this.txtKcpwriteBufferSize, "txtKcpwriteBufferSize");
            this.txtKcpwriteBufferSize.Name = "txtKcpwriteBufferSize";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // txtKcpreadBufferSize
            // 
            resources.ApplyResources(this.txtKcpreadBufferSize, "txtKcpreadBufferSize");
            this.txtKcpreadBufferSize.Name = "txtKcpreadBufferSize";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // txtKcpdownlinkCapacity
            // 
            resources.ApplyResources(this.txtKcpdownlinkCapacity, "txtKcpdownlinkCapacity");
            this.txtKcpdownlinkCapacity.Name = "txtKcpdownlinkCapacity";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtKcpuplinkCapacity
            // 
            resources.ApplyResources(this.txtKcpuplinkCapacity, "txtKcpuplinkCapacity");
            this.txtKcpuplinkCapacity.Name = "txtKcpuplinkCapacity";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtKcptti
            // 
            resources.ApplyResources(this.txtKcptti, "txtKcptti");
            this.txtKcptti.Name = "txtKcptti";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtKcpmtu
            // 
            resources.ApplyResources(this.txtKcpmtu, "txtKcpmtu");
            this.txtKcpmtu.Name = "txtKcpmtu";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tabGUI
            // 
            this.tabGUI.Controls.Add(this.chkInterlaceColoring);
            this.tabGUI.Controls.Add(this.chkKeepOlderDedupl);
            this.tabGUI.Controls.Add(this.cbFreshrate);
            this.tabGUI.Controls.Add(this.lbFreshrate);
            this.tabGUI.Controls.Add(this.chkEnableStatistics);
            this.tabGUI.Controls.Add(this.chkAllowLANConn);
            this.tabGUI.Controls.Add(this.txturlGFWList);
            this.tabGUI.Controls.Add(this.label13);
            this.tabGUI.Controls.Add(this.chkAutoRun);
            resources.ApplyResources(this.tabGUI, "tabGUI");
            this.tabGUI.Name = "tabGUI";
            this.tabGUI.UseVisualStyleBackColor = true;
            // 
            // chkKeepOlderDedupl
            // 
            resources.ApplyResources(this.chkKeepOlderDedupl, "chkKeepOlderDedupl");
            this.chkKeepOlderDedupl.Name = "chkKeepOlderDedupl";
            this.chkKeepOlderDedupl.UseVisualStyleBackColor = true;
            // 
            // cbFreshrate
            // 
            this.cbFreshrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFreshrate.FormattingEnabled = true;
            resources.ApplyResources(this.cbFreshrate, "cbFreshrate");
            this.cbFreshrate.Name = "cbFreshrate";
            // 
            // lbFreshrate
            // 
            resources.ApplyResources(this.lbFreshrate, "lbFreshrate");
            this.lbFreshrate.Name = "lbFreshrate";
            // 
            // chkEnableStatistics
            // 
            resources.ApplyResources(this.chkEnableStatistics, "chkEnableStatistics");
            this.chkEnableStatistics.Name = "chkEnableStatistics";
            this.chkEnableStatistics.UseVisualStyleBackColor = true;
            // 
            // chkAllowLANConn
            // 
            resources.ApplyResources(this.chkAllowLANConn, "chkAllowLANConn");
            this.chkAllowLANConn.Name = "chkAllowLANConn";
            this.chkAllowLANConn.UseVisualStyleBackColor = true;
            // 
            // txturlGFWList
            // 
            resources.ApplyResources(this.txturlGFWList, "txturlGFWList");
            this.txturlGFWList.Name = "txturlGFWList";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // chkAutoRun
            // 
            resources.ApplyResources(this.chkAutoRun, "chkAutoRun");
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.UseVisualStyleBackColor = true;
            // 
            // tabUserPAC
            // 
            this.tabUserPAC.Controls.Add(this.txtuserPacRule);
            this.tabUserPAC.Controls.Add(this.panel4);
            resources.ApplyResources(this.tabUserPAC, "tabUserPAC");
            this.tabUserPAC.Name = "tabUserPAC";
            this.tabUserPAC.UseVisualStyleBackColor = true;
            // 
            // txtuserPacRule
            // 
            resources.ApplyResources(this.txtuserPacRule, "txtuserPacRule");
            this.txtuserPacRule.Name = "txtuserPacRule";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Brown;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnOK);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // chkInterlaceColoring
            // 
            resources.ApplyResources(this.chkInterlaceColoring, "chkInterlaceColoring");
            this.chkInterlaceColoring.Name = "chkInterlaceColoring";
            this.chkInterlaceColoring.UseVisualStyleBackColor = true;
            // 
            // OptionSettingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OptionSettingForm";
            this.Load += new System.EventHandler(this.OptionSettingForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabRouting.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPreDefinedRules.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabKCP.ResumeLayout(false);
            this.tabKCP.PerformLayout();
            this.tabGUI.ResumeLayout(false);
            this.tabGUI.PerformLayout();
            this.tabUserPAC.ResumeLayout(false);
            this.tabUserPAC.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbloglevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtlocalPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chklogEnabled;
        private System.Windows.Forms.CheckBox chkudpEnabled;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBasic;
        private System.Windows.Forms.TabPage tabRouting;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbprotocol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbprotocol2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtlocalPort2;
        private System.Windows.Forms.CheckBox chkudpEnabled2;
        private System.Windows.Forms.CheckBox chkAllowIn2;
        private System.Windows.Forms.CheckBox chkmuxEnabled;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label labRoutingTips;
        private System.Windows.Forms.TextBox txtUseragent;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox txtUserdirect;
        private System.Windows.Forms.TextBox txtUserblock;
        private System.Windows.Forms.TabPage tabKCP;
        private System.Windows.Forms.TextBox txtKcpmtu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKcptti;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKcpwriteBufferSize;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtKcpreadBufferSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtKcpdownlinkCapacity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKcpuplinkCapacity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkKcpcongestion;
        private System.Windows.Forms.TabPage tabGUI;
        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txturlGFWList;
        private System.Windows.Forms.CheckBox chkAllowLANConn;
        private System.Windows.Forms.TextBox txtremoteDNS;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbdomainStrategy;
        private System.Windows.Forms.ComboBox cmbroutingMode;
        private System.Windows.Forms.CheckBox chksniffingEnabled;
        private System.Windows.Forms.CheckBox chksniffingEnabled2;
        private System.Windows.Forms.Button btnSetDefRountingRule;
        private System.Windows.Forms.CheckBox chkEnableStatistics;
        private System.Windows.Forms.ComboBox cbFreshrate;
        private System.Windows.Forms.Label lbFreshrate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmblistenerType;
        private System.Windows.Forms.TabPage tabPreDefinedRules;
        private System.Windows.Forms.TabPage tabUserPAC;
        private System.Windows.Forms.TextBox txtuserPacRule;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkKeepOlderDedupl;
        private System.Windows.Forms.LinkLabel linkLabelRoutingDoc;
        private System.Windows.Forms.CheckBox chkInterlaceColoring;
    }
}