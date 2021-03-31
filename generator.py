import os
import sys
import re
from typing import Dict, List, Tuple

org_name = "ogm"
mod_name = "file"
proto_dir = os.path.join("../{}-msp-{}/proto".format(org_name, mod_name), mod_name)

template_gitignore = r"""
.vs/
app/bin/
app/obj/
bridge/bin/
bridge/obj/
module/bin/
module/obj/
winform/bin/
winform/obj/
*.user
"""

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

template_app_AppConfig_cs = r"""
using System;
using XTC.oelMVCS;

namespace app
{
    class AppConfig: Config
    {
        public override void Merge(string _content)
        {
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
            Config config = new AppConfig();
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

templete_bridge_view_cs = r"""
using XTC.oelMVCS;
namespace {{org}}.Module.{{mod}}
{
    public interface I{{service}}ViewBridge : View.Facade.Bridge
    {
{{rpc}}
    }
}
"""

templete_bridge_ui_cs = r"""
using XTC.oelMVCS;
namespace {{org}}.Module.{{mod}}
{
    public interface I{{service}}UiBridge : View.Facade.Bridge
    {
        object getRootPanel();
    }
}
"""

template_module_ModuleRoot_cs = r"""
using System.Collections.Generic;
using XTC.oelMVCS;

namespace {{org}}.Module.{{mod}}
{
    public class ModuleRoot
    {
        public ModuleRoot(Framework _framework)
        {
            framework_ = _framework;
        }

        public void Register()
        {
{{register}}
        }

        public void Cancel()
        {
{{cancel}}
        }

        private Framework framework_ = null; 
    }
}
"""

template_module_Model_cs = r"""
using System;
using XTC.oelMVCS;

namespace {{org}}.Module.{{mod}}
{
    public class {{service}}Model : Model
    {
        public const string NAME = "{{mod}}.{{service}}Model";

        public class {{service}}Status : Model.Status
        {
            public const string NAME = "{{mod}}.{{service}}Status";
        }

        protected override void preSetup()
        {
            Error err;
            status_ = spawnStatus<{{service}}Status>({{service}}Status.NAME, out err);
        }

        protected override void setup()
        {
            getLogger().Trace("setup {{service}}Model");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus({{service}}Status.NAME, out err);
        }

        private {{service}}Status status
        {
            get
            {
                return status_ as {{service}}Status;
            }
        }
    }
}
"""

template_module_View_cs = r"""
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace {{org}}.Module.{{mod}}
{
    public class {{service}}View: View
    {
        public const string NAME = "{{mod}}.{{service}}View";

        private Facade facade = null;
        private {{service}}Model model = null;
        private I{{service}}UiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel({{service}}Model.NAME) as {{service}}Model;
            var service = findService({{service}}Service.NAME) as {{service}}Service;
            facade = findFacade("{{mod}}.{{service}}Facade");
            {{service}}ViewBridge vb = new {{service}}ViewBridge();
            vb.view = this;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup {{service}}View");
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as I{{service}}UiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["/{{org}}/{{mod}}/{{service}}"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
        }
    }
}
"""

template_module_Controller_cs = r"""
using System;
using XTC.oelMVCS;

namespace {{org}}.Module.{{mod}}
{
    public class {{service}}Controller: Controller
    {
        public const string NAME = "{{mod}}.{{service}}Controller";

        protected override void setup()
        {
            getLogger().Trace("setup {{service}}Controller");
        }
    }
}
"""

template_module_ViewBridge_cs = r"""
using XTC.oelMVCS;
namespace {{org}}.Module.{{mod}}
{
    public class {{service}}ViewBridge : I{{service}}ViewBridge
    {
        public {{service}}View view{ get; set; }
        public {{service}}Service service{ get; set; }

{{rpc}}

    }
}
"""

template_module_Service_cs = r"""
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace {{org}}.Module.{{mod}}
{
    public class {{service}}Service: Service
    {
        public const string NAME = "{{mod}}.{{service}}Service";
        private {{service}}Model model = null;

        protected override void preSetup()
        {
            model = findModel({{service}}Model.NAME) as {{service}}Model;
        }

        protected override void setup()
        {
            getLogger().Trace("setup {{service}}Service");
        }
{{rpc}}
    }
}
"""


template_module_Protocol_cs = r"""
using System;
using System.Text;

namespace {{org}}.Module.{{mod}}.Proto
{
{{proto}}
}
"""

template_winform_FormRoot_cs = r"""
using XTC.oelMVCS;

namespace {{org}}.Module.{{mod}}
{
    public class FormRoot
    {
        public FormRoot(Framework _framework)
        {
            framework_ = _framework;
        }

        public void Register()
        {
{{register}}
        }

        public void Cancel()
        {
{{cancel}}
        }

        private Framework framework_ = null;
    }
}
"""

template_winform_Facade_cs = r"""
using XTC.oelMVCS;

namespace {{org}}.Module.{{mod}}
{
    public class {{service}}Facade : View.Facade
    {
        public const string NAME = "{{mod}}.{{service}}Facade";
    }
}
"""

template_winform_Panel_cs = r"""
using System;
using System.Windows.Forms;
using XTC.oelMVCS;

namespace {{org}}.Module.{{mod}}
{
    public partial class {{service}}Panel : UserControl
    {
        public class {{service}}UiBridge : I{{service}}UiBridge
        {
            public {{service}}Panel panel { get; set; }

            public object getRootPanel()
            {
                return panel;
            }
        }

        public {{service}}Facade facade { get; set; }

        public {{service}}Panel()
        {
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Location = new System.Drawing.Point(1, -3);
            this.Name = "rootPanel";
            this.Size = new System.Drawing.Size(1050, 801);
            this.TabIndex = 0;

            InitializeComponent();
        }
    }
}
"""

template_winform_Panel_resx = r"""
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

template_winform_Panel_Designer_cs = r"""

namespace {{org}}.Module.{{mod}}
{
    partial class {{service}}Panel
    {
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(62, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1109, 561);
            this.dataGridView1.TabIndex = 0;
            // 
            // RootPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RootPanel";
            this.Size = new System.Drawing.Size(1541, 761);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
"""

##############################################################################
##############################################################################
##############################################################################


services: Dict[str, Dict[str, Tuple]] = {}
"""
service Healthy {
  rpc Echo(EchoRequest) returns (EchoResponse) {}
}
转换为
{
    startkit: 
    {
        healthy: (EchoRequest, EchoResponse)
    }
}
"""

messages: Dict[str, List[Tuple]] = {}
"""
message EchoRequest {
  string msg = 1; 
}
转换为
{
    EchoRequest: 
    [ 
        (msg, string),
    ]
}
"""

enums: List[str] = []

type_dict = {
    "string": "string",
    "int32": "int",
    "uint32": "int",
    "int64": "long",
    "uint64": "long",
    "bool": "bool",
    "float32": "float",
    "float64": "double",
    "bytes": "byte[]",
    "enum": "int",
}

# 解析协议文件
for entry in os.listdir(proto_dir):
    # 跳过不是.proto的文件
    if not entry.endswith(".proto"):
        continue
    # 跳过Healthy.proto
    if entry.lower().find("healthy") >= 0:
        continue
    proto_name = os.path.splitext(entry)[0]
    with open(os.path.join(proto_dir, entry), "r", encoding="utf-8") as rf:
        content = rf.read()
        rf.close()
        #############################
        # 提取enum名
        #############################
        match = re.findall(r".*?enum\s*(.*?)\s*\{", content, re.S)
        for enum_name in match:
            enums.append(enum_name)
        #############################
        # 提取service语句块
        #############################
        match = re.findall(r".*?service\s*(.*?\}\s*\})", content, re.S)
        for service_block in match:
            # 提取服务名
            match = re.findall(r"(\w*?)\s*\{", service_block, re.S)
            service_name = match[0]
            services[service_name] = {}
            # 提取服务方法
            for line in str.splitlines(service_block):
                # 跳过不包含rpc的行
                if str.find(line, "rpc") < 0:
                    continue
                # 跳过包含stream的行
                if str.find(line, "stream") >= 0:
                    continue
                # 提取rpc语句块
                match = re.findall(r".*rpc\s*(.*?)\s*\{\s*\}", line, re.S)
                if len(match) == 0:
                    continue
                rpc_block = match[0]
                # 提取方法名
                match = re.findall(r"^(.*?)\s*\(", rpc_block, re.S)
                if len(match) == 0:
                    continue
                rpc_name = match[0]
                # 提取请求
                match = re.findall(r"\(\s*(.*?)\s*\)\s*returns", rpc_block, re.S)
                req_name = ""
                if len(match) > 0:
                    req_name = match[0]
                # 提取回复
                match = re.findall(r"returns\s*\(\s*(.*?)\s*\)", rpc_block, re.S)
                rsp_name = ""
                if len(match) > 0:
                    rsp_name = match[0]
                services[service_name][rpc_name] = (req_name, rsp_name)
        #############################
        # 提取message语句块
        #############################
        match = re.findall(r".*?message\s*(.*?\})", content, re.S)
        for message_block in match:
            # 提取消息名
            match = re.findall(r"(\w*?)\s*\{", message_block, re.S)
            message_name = match[0]
            messages[message_name] = []
            # 提取字段
            for line in str.splitlines(message_block):
                # 跳过不包含=的行
                if str.find(line, "=") < 0:
                    continue
                # 跳过不包含;的行
                if str.find(line, ";") < 0:
                    continue
                isRepeated = False
                if line.find("repeated") >= 0:
                    isRepeated = True
                    line = line.replace("repeated", "")
                # 提取字段类型
                match = re.findall(r"\s*(\w+)\s+\w+", line, re.S)
                field_type = ""
                if len(match) > 0:
                    field_type = match[0]
                if isRepeated:
                    field_type = field_type + "[]"
                # 提取字段名
                match = re.findall(r"\s+(\w+)\s+=", line, re.S)
                field_name = ""
                if len(match) > 0:
                    field_name = match[0]
                messages[message_name].append((field_name, field_type))


# 生成..gitignore文件
os.makedirs("vs2019", exist_ok=True)
with open("./vs2019/.gitignore", "w", encoding="utf-8") as wf:
    wf.write(template_gitignore)
    wf.close()

# 生成.sln文件
os.makedirs("vs2019", exist_ok=True)
with open("./vs2019/{}-{}.sln".format(org_name, mod_name), "w", encoding="utf-8") as wf:
    wf.write(template_sln)
    wf.close()

# -----------------------------------------------------------------------------
# 生成 app 解决方案
# -----------------------------------------------------------------------------
os.makedirs("vs2019/app", exist_ok=True)
# 生成.proj文件
with open("./vs2019/app/app.csproj", "w", encoding="utf-8") as wf:
    wf.write(template_proj_app)
    wf.close()

# 生成AppFacade.cs
with open("./vs2019/app/AppFacade.cs", "w", encoding="utf-8") as wf:
    wf.write(template_app_AppFacade_cs)
    wf.close()

# 生成AppView.cs
with open("./vs2019/app/AppView.cs", "w", encoding="utf-8") as wf:
    wf.write(template_app_AppView_cs)
    wf.close()

# 生成ConsoleLogger.cs
with open("./vs2019/app/ConsoleLogger.cs", "w", encoding="utf-8") as wf:
    wf.write(template_app_ConsoleLogger_cs)
    wf.close()

# 生成AppConfig.cs
with open("./vs2019/app/AppConfig.cs", "w", encoding="utf-8") as wf:
    wf.write(template_app_AppConfig_cs)
    wf.close()


# 生成Program.cs
with open("./vs2019/app/Program.cs", "w", encoding="utf-8") as wf:
    wf.write(
        template_app_Program_cs.replace("{{org}}", org_name.upper()).replace(
            "{{mod}}", mod_name.capitalize()
        )
    )
    wf.close()

# 生成RootForm.cs
with open("./vs2019/app/RootForm.cs", "w", encoding="utf-8") as wf:
    wf.write(template_app_RootForm_cs)
    wf.close()

# 生成RootForm.resx
with open("./vs2019/app/RootForm.resx", "w", encoding="utf-8") as wf:
    wf.write(template_app_RootForm_resx)
    wf.close()

# -----------------------------------------------------------------------------
# 生成 bridge 解决方案
# -----------------------------------------------------------------------------
os.makedirs("vs2019/bridge", exist_ok=True)
# 生成.proj文件
with open("./vs2019/bridge/bridge.csproj", "w", encoding="utf-8") as wf:
    wf.write(
        template_proj_bridge.replace("{{org}}", org_name).replace("{{mod}}", mod_name)
    )
    wf.close()

# 生成ViewBridge.cs文件
for service in services.keys():
    with open(
        "./vs2019/bridge/I{}ViewBridge.cs".format(service), "w", encoding="utf-8"
    ) as wf:
        template_method = r"        void On{{rpc}}Submit({{args}});"
        rpc_block = ""
        for rpc_name in services[service].keys():
            rpc = template_method.replace("{{rpc}}", rpc_name)
            rpc_block = rpc_block + str.format("{}\n", rpc)
            req_name = services[service][rpc_name][0]
            args_block = ""
            for field in messages[req_name]:
                field_name = field[0]
                field_type = field[1]
                # 转换枚举类型
                if field_type in enums:
                    field_type = "enum"
                # 转换类型
                field_type = type_dict[field_type]
                args_block = args_block + str.format("{} _{}, ", field_type, field_name)
            # 移除末尾的 ', '
            if len(args_block) > 0:
                args_block = args_block[0:-2]
            rpc_block = rpc_block.replace("{{args}}", args_block)
        code = templete_bridge_view_cs
        code = code.replace("{{org}}", org_name.upper())
        code = code.replace("{{mod}}", mod_name.capitalize())
        code = code.replace("{{service}}", service)
        code = code.replace("{{rpc}}", rpc_block)
        wf.write(code)
        wf.close()

# 生成UiBridge.cs文件
for service in services.keys():
    with open(
        "./vs2019/bridge/I{}UiBridge.cs".format(service), "w", encoding="utf-8"
    ) as wf:
        code = templete_bridge_ui_cs
        code = code.replace("{{org}}", org_name.upper())
        code = code.replace("{{mod}}", mod_name.capitalize())
        code = code.replace("{{service}}", service)
        wf.write(code)
        wf.close()


# -----------------------------------------------------------------------------
# 生成 module 解决方案
# -----------------------------------------------------------------------------
os.makedirs("vs2019/module", exist_ok=True)
# 生成.proj文件
with open("./vs2019/module/module.csproj", "w", encoding="utf-8") as wf:
    wf.write(
        template_proj_module.replace("{{org}}", org_name).replace("{{mod}}", mod_name)
    )
    wf.close()


# 生成ModuleRoot.cs文件
with open("./vs2019/module/ModuleRoot.cs", "w", encoding="utf-8") as wf:
    template_register_block = r"""
            // 注册数据层
            framework_.getStaticPipe().RegisterModel({{service}}Model.NAME, new {{service}}Model());
            // 注册视图层
            framework_.getStaticPipe().RegisterView({{service}}View.NAME, new {{service}}View());
            // 注册控制层
            framework_.getStaticPipe().RegisterController({{service}}Controller.NAME, new {{service}}Controller());
            // 注册服务层
            framework_.getStaticPipe().RegisterService({{service}}Service.NAME, new {{service}}Service());
    """
    template_cancel_block = r"""
            // 注销服务层
            framework_.getStaticPipe().CancelService({{service}}Service.NAME);
            // 注销控制层
            framework_.getStaticPipe().CancelController({{service}}Controller.NAME);
            // 注销视图层
            framework_.getStaticPipe().CancelView({{service}}View.NAME);
            // 注销数据层
            framework_.getStaticPipe().CancelModel({{service}}Model.NAME);
    """
    register_block = ""
    cancel_block = ""
    for service in services.keys():
        register_block = register_block + template_register_block.replace(
            "{{service}}", service
        )
        cancel_block = cancel_block + template_cancel_block.replace(
            "{{service}}", service
        )
    code = template_module_ModuleRoot_cs
    code = code.replace("{{org}}", org_name.upper())
    code = code.replace("{{mod}}", mod_name.capitalize())
    code = code.replace("{{register}}", register_block)
    code = code.replace("{{cancel}}", cancel_block)
    wf.write(code)
    wf.close()

# 生成Model.cs文件
for service in services.keys():
    with open(
        "./vs2019/module/{}Model.cs".format(service), "w", encoding="utf-8"
    ) as wf:
        code = template_module_Model_cs
        code = code.replace("{{org}}", org_name.upper())
        code = code.replace("{{mod}}", mod_name.capitalize())
        code = code.replace("{{service}}", service)
        wf.write(code)
        wf.close()

# 生成View.cs文件
for service in services.keys():
    with open("./vs2019/module/{}View.cs".format(service), "w", encoding="utf-8") as wf:
        code = template_module_View_cs
        code = code.replace("{{org}}", org_name.upper())
        code = code.replace("{{mod}}", mod_name.capitalize())
        code = code.replace("{{service}}", service)
        wf.write(code)
        wf.close()

# 生成Controller.cs文件
for service in services.keys():
    with open(
        "./vs2019/module/{}Controller.cs".format(service), "w", encoding="utf-8"
    ) as wf:
        code = template_module_Controller_cs
        code = code.replace("{{org}}", org_name.upper())
        code = code.replace("{{mod}}", mod_name.capitalize())
        code = code.replace("{{service}}", service)
        wf.write(code)
        wf.close()

# 生成ViewBridge.cs文件
for service in services.keys():
    with open(
        "./vs2019/module/{}ViewBridge.cs".format(service), "w", encoding="utf-8"
    ) as wf:
        template_method = r"""
        public void On{{rpc}}Submit({{args}})
        {
            Proto.{{service}}{{rpc}}Request req = new Proto.{{service}}{{rpc}}Request();
{{assign}}
            service.Post{{rpc}}(req);
        }
        """
        rpc_block = ""
        for rpc_name in services[service].keys():
            rpc = template_method.replace("{{rpc}}", rpc_name)
            rpc = rpc.replace("{{service}}", service)
            rpc_block = rpc_block + str.format("{}\n", rpc)
            req_name = services[service][rpc_name][0]
            args_block = ""
            assign_block = ""
            for field in messages[req_name]:
                field_name = field[0]
                field_type = field[1]
                # 转换枚举类型
                if field_type in enums:
                    field_type = "enum"
                # 转换类型
                field_type = type_dict[field_type]
                args_block = args_block + str.format("{} _{}, ", field_type, field_name)
                assign_block = assign_block + str.format(
                    "            req.{} = _{};\n", field_name, field_name
                )
            # 移除末尾的 ', '
            if len(args_block) > 0:
                args_block = args_block[0:-2]
            rpc_block = rpc_block.replace("{{args}}", args_block)
            rpc_block = rpc_block.replace("{{assign}}", assign_block)
        code = template_module_ViewBridge_cs
        code = code.replace("{{org}}", org_name.upper())
        code = code.replace("{{mod}}", mod_name.capitalize())
        code = code.replace("{{service}}", service)
        code = code.replace("{{rpc}}", rpc_block)
        wf.write(code)
        wf.close()


# 生成Service.cs文件
for service in services.keys():
    with open(
        "./vs2019/module/{}Service.cs".format(service), "w", encoding="utf-8"
    ) as wf:
        template_method = r"""
        public void Post{{rpc}}(Proto.{{req}} _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
{{assign}}
            post("/{{org}}/{{mod}}/{{service}}/{{rpc}}", paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.{{rsp}}>(_reply);
                {{service}}Model.{{service}}Status status = Model.Status.New<{{service}}Model.{{service}}Status>(rsp.status.code, rsp.status.message);
                model.Broadcast("/{{org}}/{{mod}}/{{service}}/{{rpc}}", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        """
        rpc_block = ""
        for rpc_name in services[service].keys():
            rpc = template_method.replace("{{org}}", org_name)
            rpc = rpc.replace("{{mod}}", mod_name)
            rpc = rpc.replace("{{service}}", service)
            rpc = rpc.replace("{{rpc}}", rpc_name)
            rpc = rpc.replace("{{req}}", services[service][rpc_name][0])
            rpc = rpc.replace("{{rsp}}", services[service][rpc_name][1])
            rpc_block = rpc_block + str.format("{}\n", rpc)
            req_name = services[service][rpc_name][0]
            assign_block = ""
            for field in messages[req_name]:
                field_name = field[0]
                field_type = field[1]
                # 转换枚举类型
                if field_type in enums:
                    field_type = "enum"
                # 转换类型
                field_type = type_dict[field_type]
                assign_block = assign_block + str.format(
                    '            paramMap["{}"] = Any.From{}(_request.{});\n',
                    field_name,
                    field_type.capitalize(),
                    field_name,
                )
            rpc_block = rpc_block.replace("{{assign}}", assign_block)
        code = template_module_Service_cs
        code = code.replace("{{org}}", org_name.upper())
        code = code.replace("{{mod}}", mod_name.capitalize())
        code = code.replace("{{service}}", service)
        code = code.replace("{{rpc}}", rpc_block)
        wf.write(code)
        wf.close()

# 生成Proto.cs文件
with open("./vs2019/module/Protocol.cs", "w", encoding="utf-8") as wf:
    template_class = r"""
        public class {{message}}
        {
{{field}}
        }
    """
    proto_block = ""
    for message_name in messages.keys():
        field_block = ""
        for field in messages[message_name]:
            field_name = field[0]
            field_type = field[1]
            # 转换枚举类型
            if field_type in enums:
                field_type = "enum"
            # 转换类型
            if field_type in type_dict.keys():
                field_type = type_dict[field_type]
            field_block = field_block + str.format(
                "            public {} {};\n", field_type, field_name
            )
        message_block = template_class.replace("{{message}}", message_name)
        message_block = message_block.replace("{{field}}", field_block)
        proto_block = proto_block + message_block
    code = template_module_Protocol_cs
    code = code.replace("{{org}}", org_name.upper())
    code = code.replace("{{mod}}", mod_name.capitalize())
    code = code.replace("{{proto}}", proto_block)
    wf.write(code)
    wf.close()


# -----------------------------------------------------------------------------
# 生成 winform 解决方案
# -----------------------------------------------------------------------------
os.makedirs("vs2019/winform", exist_ok=True)
# 生成.proj文件
with open("./vs2019/winform/winform.csproj", "w", encoding="utf-8") as wf:
    wf.write(
        template_proj_winform.replace("{{org}}", org_name).replace("{{mod}}", mod_name)
    )
    wf.close()

# 生成FormRoot.cs文件
with open("./vs2019/winform/FormRoot.cs", "w", encoding="utf-8") as wf:
    template_register_block = r"""
            // 注册UI装饰
            {{service}}Facade facade{{service}} = new {{service}}Facade();
            framework_.getStaticPipe().RegisterFacade({{service}}Facade.NAME, facade{{service}});
            {{service}}Panel panel{{service}} = new {{service}}Panel();
            panel{{service}}.facade = facade{{service}};
            {{service}}Panel.{{service}}UiBridge ui{{service}}Bridge = new {{service}}Panel.{{service}}UiBridge();
            ui{{service}}Bridge.panel = panel{{service}};
            facade{{service}}.setUiBridge(ui{{service}}Bridge);
        """
    template_cancel_block = r"""
            // 注销UI装饰
            framework_.getStaticPipe().CancelFacade({{service}}Facade.NAME);
        """
    register_block = ""
    cancel_block = ""
    for service in services.keys():
        register_block = register_block + template_register_block.replace(
            "{{service}}", service
        )
        cancel_block = cancel_block + template_cancel_block.replace(
            "{{service}}", service
        )
    code = template_winform_FormRoot_cs
    code = code.replace("{{org}}", org_name.upper())
    code = code.replace("{{mod}}", mod_name.capitalize())
    code = code.replace("{{register}}", register_block)
    code = code.replace("{{cancel}}", cancel_block)
    wf.write(code)
    wf.close()

# 生成Facade.cs文件
for service in services.keys():
    with open(
        "./vs2019/winform/{}Facade.cs".format(service), "w", encoding="utf-8"
    ) as wf:
        code = template_winform_Facade_cs
        code = code.replace("{{org}}", org_name.upper())
        code = code.replace("{{mod}}", mod_name.capitalize())
        code = code.replace("{{service}}", service)
        wf.write(code)
        wf.close()

# 生成Panel.cs文件
for service in services.keys():
    with open(
        "./vs2019/winform/{}Panel.cs".format(service), "w", encoding="utf-8"
    ) as wf:
        code = template_winform_Panel_cs
        code = code.replace("{{org}}", org_name.upper())
        code = code.replace("{{mod}}", mod_name.capitalize())
        code = code.replace("{{service}}", service)
        wf.write(code)
        wf.close()

# 生成Panel.resx文件
for service in services.keys():
    with open(
        "./vs2019/winform/{}Panel.resx".format(service), "w", encoding="utf-8"
    ) as wf:
        code = template_winform_Panel_resx
        wf.write(code)
        wf.close()

# 生成Panel.Designer.cs文件
for service in services.keys():
    with open(
        "./vs2019/winform/{}.Designer.cs".format(service), "w", encoding="utf-8"
    ) as wf:
        code = template_winform_Panel_Designer_cs
        code = code.replace("{{org}}", org_name.upper())
        code = code.replace("{{mod}}", mod_name.capitalize())
        code = code.replace("{{service}}", service)
        wf.write(code)
        wf.close()
