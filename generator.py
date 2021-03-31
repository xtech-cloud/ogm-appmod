import os
import sys
import re

org_name = 'ogm'
mod_name = 'file'

template_sln = r"""
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 16
VisualStudioVersion = 16.0.31112.23
MinimumVisualStudioVersion = 10.0.40219.1
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "module", "module\module.csproj", "{124ACB03-D1AC-479D-B95A-DE9F13C266FA}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "app", "app\app.csproj", "{F2F84FF1-7987-476F-8F03-8316DB67217F}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "winform", "winform\winform.csproj", "{ECEBC9A0-5079-470A-A380-5B80756DEA61}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "bridge", "bridge\bridge.csproj", "{8DF06770-ADA4-407D-ABAF-6C222C73962E}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{124ACB03-D1AC-479D-B95A-DE9F13C266FA}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{124ACB03-D1AC-479D-B95A-DE9F13C266FA}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{124ACB03-D1AC-479D-B95A-DE9F13C266FA}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{124ACB03-D1AC-479D-B95A-DE9F13C266FA}.Release|Any CPU.Build.0 = Release|Any CPU
		{F2F84FF1-7987-476F-8F03-8316DB67217F}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{F2F84FF1-7987-476F-8F03-8316DB67217F}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{F2F84FF1-7987-476F-8F03-8316DB67217F}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{F2F84FF1-7987-476F-8F03-8316DB67217F}.Release|Any CPU.Build.0 = Release|Any CPU
		{ECEBC9A0-5079-470A-A380-5B80756DEA61}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{ECEBC9A0-5079-470A-A380-5B80756DEA61}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{ECEBC9A0-5079-470A-A380-5B80756DEA61}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{ECEBC9A0-5079-470A-A380-5B80756DEA61}.Release|Any CPU.Build.0 = Release|Any CPU
		{8DF06770-ADA4-407D-ABAF-6C222C73962E}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{8DF06770-ADA4-407D-ABAF-6C222C73962E}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{8DF06770-ADA4-407D-ABAF-6C222C73962E}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{8DF06770-ADA4-407D-ABAF-6C222C73962E}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {089BAFA9-97A5-468A-9FA8-D368A7EE49A6}
	EndGlobalSection
EndGlobal
"""

template_proj_app = r"""
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
    <UseWindowsForms>true</UseWindowsForms>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\module\module.csproj" />
    <ProjectReference Include="..\winform\winform.csproj" />
  </ItemGroup>

  <ItemGroup>
    <Reference Include="oelMVCS">
      <HintPath>..\..\3rd\oelMVCS.dll</HintPath>
    </Reference>
  </ItemGroup>

</Project>
"""

template_proj_bridge = r"""
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>
    <AssemblyName>{{org}}-{{mod}}-bridge</AssemblyName>
  </PropertyGroup>

  <ItemGroup>
    <Reference Include="oelMVCS">
      <HintPath>..\..\3rd\oelMVCS.dll</HintPath>
    </Reference>
  </ItemGroup>

</Project>
"""

template_proj_module = r"""
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>
    <AssemblyName>{{org}}-{{mod}}-module</AssemblyName>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\bridge\bridge.csproj" />
  </ItemGroup>

  <ItemGroup>
    <Reference Include="oelMVCS">
      <HintPath>..\..\3rd\oelMVCS.dll</HintPath>
    </Reference>
  </ItemGroup>

</Project>
"""

template_proj_winform = r"""
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>
    <UseWindowsForms>true</UseWindowsForms>
    <AssemblyName>{{org}}-{{mod}}-winform</AssemblyName>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\bridge\bridge.csproj" />
  </ItemGroup>

  <ItemGroup>
    <Reference Include="oelMVCS">
      <HintPath>..\..\3rd\oelMVCS.dll</HintPath>
    </Reference>
  </ItemGroup>

</Project>
"""

template_app_AppFacade_cs = r"""
using XTC.oelMVCS;

namespace app
{
    class AppFacade : View.Facade
    {
        public const string NAME = "AppFacade";
        public RootForm rootForm { get; set; }
    }//class
}//namespace
"""

template_app_AppView_cs = r"""
using System.Collections.Generic;
using XTC.oelMVCS;

namespace app
{
    class AppView : View
    {
        public const string NAME = "AppView";

        private AppFacade appFacade = null;

        protected override void preSetup()
        {
            appFacade = findFacade(AppFacade.NAME) as AppFacade;
        }

        protected override void setup()
        {
            route("/module/view/attach", this.handleAttachView);
        }

        private void handleAttachView(Model.Status _status, object _data)
        {
            getLogger().Trace("attach view");
            Dictionary<string, object> data = _data as Dictionary<string, object>;
            foreach(string path in data.Keys)
            {
                appFacade.rootForm.AddPath(path, data[path]);
            }
        }
    }//class
}//namespace
"""

template_app_ConsoleLogger_cs = r"""
using System;
using XTC.oelMVCS;

namespace app
{
    class ConsoleLogger : Logger
    {
        protected override void trace(string _categoray, string _message)
        {
            Console.WriteLine("TRACE | {0} > {1}", _categoray, _message);
        }

        protected override void debug(string _categoray, string _message)
        {
            Console.WriteLine("DEBUG | {0} > {1}", _categoray, _message);
        }

        protected override void info(string _categoray, string _message)
        {
            Console.WriteLine("INFO | {0} > {1}", _categoray, _message);
        }

        protected override void warning(string _categoray, string _message)
        {
            Console.WriteLine("WARN | {0} > {1}", _categoray, _message);
        }

        protected override void error(string _categoray, string _message)
        {
            Console.WriteLine("ERROR | {0} > {1}", _categoray, _message);
        }

        protected override void exception(Exception _exception)
        {
            Console.WriteLine(_exception.ToString());
        }
    }//class
}//namespace
"""

template_app_Program_cs = r"""
using System;
using System.Windows.Forms;
using {{org}}.Module.{{mod}};
using XTC.oelMVCS;

namespace app
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RootForm rootForm = new RootForm();

            Logger logger = new ConsoleLogger();
            Config config = new Config();
            config.Merge("");
            Framework framework = new Framework();
            framework.setLogger(logger);
            framework.setConfig(config);
            framework.Initialize();

            AppFacade appFacade = new AppFacade();
            appFacade.rootForm = rootForm;
            framework.getStaticPipe().RegisterFacade(AppFacade.NAME, appFacade);
            AppView appView = new AppView();
            framework.getStaticPipe().RegisterView(AppView.NAME, appView);

            // 注册模块窗体
            FormRoot formRoot = new FormRoot(framework);
            formRoot.Register();
            // 注册模块逻辑
            ModuleRoot moduleRoot = new ModuleRoot(framework);
            moduleRoot.Register();

            framework.Setup();

            Application.Run(rootForm);

            moduleRoot.Cancel();
            formRoot.Cancel();

            framework.Dismantle();
            framework.Release();
        }
    }
}
"""

template_app_RootForm_cs = r"""
using System.Windows.Forms;

namespace app
{
    public class RootForm: Form
    {
        public RootForm()
        {
            InitializeComponent();
        }
        private TabControl tcPages;
        private TreeView tvPages;

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void AddPath(string _path, object _page)
        {
            ContainerControl page = _page as ContainerControl;
            //this.Controls.Add(panel);
            string[] sections = _path.Split("/");
            var nodes = this.tvPages.Nodes;
            foreach(string section in sections)
            {
                if(string.IsNullOrEmpty(section))
                    continue;
                var found = nodes.Find(section, false);
                if(found.Length == 0)
                {
                    TreeNode newNode = new TreeNode();
                    newNode.Name = section;
                    newNode.Text = section;
                    nodes.Add(newNode);
                    found = new TreeNode[]{newNode};
                }
                nodes = found[0].Nodes;
            }
            TabPage tabPage = new TabPage();
            tabPage.Location = new System.Drawing.Point(4, 5);
            tabPage.Name = _path;
            tabPage.Padding = new System.Windows.Forms.Padding(3);
            tabPage.Size = new System.Drawing.Size(1084, 1186);
            tabPage.TabIndex = 0;
            tabPage.Text = _path;
            tabPage.UseVisualStyleBackColor = true;
            tabPage.Controls.Add(page);
            this.tcPages.Controls.Add(tabPage);
            this.tvPages.ExpandAll();
        }

        private void InitializeComponent()
        {
            this.tcPages = new System.Windows.Forms.TabControl();
            this.tvPages = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tcPages
            // 
            this.tcPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcPages.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcPages.ItemSize = new System.Drawing.Size(0, 1);
            this.tcPages.Location = new System.Drawing.Point(216, 20);
            this.tcPages.Name = "tcPages";
            this.tcPages.SelectedIndex = 0;
            this.tcPages.Size = new System.Drawing.Size(1092, 1195);
            this.tcPages.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcPages.TabIndex = 1;
            // 
            // tvPages
            // 
            this.tvPages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvPages.Location = new System.Drawing.Point(13, 20);
            this.tvPages.Name = "tvPages";
            this.tvPages.PathSeparator = "/";
            this.tvPages.Size = new System.Drawing.Size(188, 1191);
            this.tvPages.TabIndex = 2;
            this.tvPages.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPages_AfterSelect);
            // 
            // RootForm
            // 
            this.ClientSize = new System.Drawing.Size(1320, 1241);
            this.Controls.Add(this.tvPages);
            this.Controls.Add(this.tcPages);
            this.Name = "RootForm";
            this.ResumeLayout(false);

        }

        private void tvPages_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }
    }

}
"""

template_app_RootForm_resx = r"""
<root>
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
  <resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
</root>
"""








proto_dir = os.path.join('../{}-msp-{}/proto'.format(org_name, mod_name), mod_name)
protos = {}
# 解析协议文件
for entry in os.listdir(proto_dir):
    if not entry.endswith('.proto'):
        continue
    with open(os.path.join(proto_dir, entry), 'r', encoding='utf-8') as rf:
        content = rf.read()
        rf.close()
        # 匹配出service
        match = re.findall(r'.*service (.*?\n\}\n)', content, re.S)
        print(match[0])

# 生成.sln文件
os.makedirs('vs2019', exist_ok=True)
with open('./vs2019/{}-{}.sln'.format(org_name, mod_name), 'w', encoding='utf-8') as wf:
    wf.write(template_sln)
    wf.close()

#-----------------------------------------------------------------------------
# 生成 app 解决方案
#-----------------------------------------------------------------------------
os.makedirs('vs2019/app', exist_ok=True)
# 生成.proj文件
with open('./vs2019/app/app.csproj', 'w', encoding='utf-8') as wf:
    wf.write(template_proj_app)
    wf.close()

# 生成AppFacade.cs
with open('./vs2019/app/AppFacade.cs', 'w', encoding='utf-8') as wf:
    wf.write(template_app_AppFacade_cs)
    wf.close()

# 生成AppView.cs
with open('./vs2019/app/AppView.cs', 'w', encoding='utf-8') as wf:
    wf.write(template_app_AppView_cs)
    wf.close()

# 生成ConsoleLogger.cs
with open('./vs2019/app/ConsoleLogger.cs', 'w', encoding='utf-8') as wf:
    wf.write(template_app_ConsoleLogger_cs)
    wf.close()

# 生成Program.cs
with open('./vs2019/app/Program.cs', 'w', encoding='utf-8') as wf:
    wf.write(template_app_Program_cs.replace('{{org}}', org_name.upper()).replace('{{mod}}', mod_name.capitalize()))
    wf.close()

# 生成RootForm.cs
with open('./vs2019/app/RootForm.cs', 'w', encoding='utf-8') as wf:
    wf.write(template_app_RootForm_cs)
    wf.close()

# 生成RootForm.resx
with open('./vs2019/app/RootForm.resx', 'w', encoding='utf-8') as wf:
    wf.write(template_app_RootForm_resx)
    wf.close()






# 生成bridge的.proj文件
os.makedirs('vs2019/bridge', exist_ok=True)
with open('./vs2019/bridge/bridge.csproj', 'w', encoding='utf-8') as wf:
    wf.write(template_proj_bridge.replace('{{org}}', org_name).replace('{{mod}}', mod_name))
    wf.close()

# 生成bridge的.proj文件
os.makedirs('vs2019/module', exist_ok=True)
with open('./vs2019/module/module.csproj', 'w', encoding='utf-8') as wf:
    wf.write(template_proj_module.replace('{{org}}', org_name).replace('{{mod}}', mod_name))
    wf.close()

# 生成winform的.proj文件
os.makedirs('vs2019/winform', exist_ok=True)
with open('./vs2019/winform/winform.csproj', 'w', encoding='utf-8') as wf:
    wf.write(template_proj_winform.replace('{{org}}', org_name).replace('{{mod}}', mod_name))
    wf.close()



