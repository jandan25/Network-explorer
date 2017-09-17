using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using ExtractLargeIconFromFile;

namespace File_explorer
{
    public partial class MainForm : Form
    {
        List<string> listFiles = new List<string>();
        bool scan_complete = false;
        bool mess = true;
        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateNetwork()
        {
            mess = true;
            network_tv.Nodes[0].Nodes.Clear();
            scan_complete = false;
            files_lv.Clear();
            path_tB.Clear();
            path_tB.Clear();
            pc_l.Visible = false;
            ip_l.Visible = false;
            network_tv.Nodes[0].Nodes.Clear();
            files_lv.Clear();
            var pcs_name = DisplayComputers();
            if (pcs_name != null)
                foreach (var pc in pcs_name)
                    network_tv.Nodes[0].Nodes.Add(pc.ServerName).ImageIndex = 0;
        }
        private void GetNameIP()
        {
            try
            {
                if (!pc_l.Visible && !ip_l.Visible)
                {
                    int num = network_tv.SelectedNode.Index;
                    string name = network_tv.SelectedNode.Text;
                    IPHostEntry ipE = Dns.GetHostByName(name);
                    IPAddress[] IpA = ipE.AddressList;
                    pc_l.Text = "Имя компьютера в сети: " + ipE.HostName.ToString();
                    pc_l.Visible = true;
                    ip_l.Text = "IP адрес компьютера в сети: " + IpA[0].ToString();
                    ip_l.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("Выберите компьютер в сети!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pc_l.Visible = false;
                ip_l.Visible = false;
            }
        }
        private void DirectoryRecursive(TreeNode node, DirectoryInfo dir)
        {
            try
            {
                var dirs = dir.GetDirectories();
                foreach (var subdir in dirs)
                    DirectoryRecursive(AddNode(node, subdir.Name), subdir);
            }
            catch (Exception ex)
            {
               if (ex.HResult == -2147024891)
                    node.ImageIndex = 1;
               else
                    node.ImageIndex = 3;
            }
        }
        private void ScanRecursive(TreeNode node, DirectoryInfo dir)
        {
            try
            {
                var dirs = dir.GetDirectories();
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2147024891)
                    node.ImageIndex = 1;
                else
                    node.ImageIndex = 3;
            }
        }

        private TreeNode AddNode(TreeNode node, string text)
        {
            node.ImageIndex = 1;
            return node.Nodes.Add(text);
        }
        public static List<PC> DisplayComputers()
        {
            // Create a child process
            Process process = new Process();
            // Starts a new instance of the Windows command interpreter
            process.StartInfo.FileName = "cmd.exe";
            // Carries out the NET VIEW command and then terminates
            process.StartInfo.Arguments = "/c net view";
            process.StartInfo.CreateNoWindow = true;
            // Redirect the output stream of the child process.
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            // Start!
            process.Start();
            List<PC> pcs = new List<PC>();
            StringBuilder pc;
            // Read the output stream
            while (!process.StandardOutput.EndOfStream)
            {
                File.WriteAllText("./temp", process.StandardOutput.ReadLine(), System.Text.Encoding.GetEncoding(1251));
                string line = File.ReadAllText("./temp", System.Text.Encoding.GetEncoding("CP866"));
                // ref: http://support.microsoft.com/kb/103013
                if (line == "There are no entries in the list.")
                    return null;
                // Find/Parse the pc name
                if (line != string.Empty)
                {
                    if (line[0] == '\\' && line[1] == '\\')
                    {
                        pc = new StringBuilder();
                        for (int y = 2; y < line.Length; y++)
                        {
                            if (line[y] == ' ')
                                break;
                            else
                                pc.Append(line[y]);
                        }
                        // Add the current PC to the PC list
                        pcs.Add(new PC { ServerName = pc.ToString() });
                    }
                }
            }
            // Wait indefinitely for the associated process to exit
            process.WaitForExit();
            // Frees all the resources
            process.Close();
            return pcs;
        }
        public static List<SHD> DisplaySharedFiles(string c_n)
        {
            // Create a child process
            Process process = new Process();
            // Starts a new instance of the Windows command interpreter
            process.StartInfo.FileName = "cmd.exe";
            // Carries out the NET VIEW command and then terminates
            process.StartInfo.Arguments = @"/c net view \\" + c_n;
            process.StartInfo.CreateNoWindow = true;
            // Redirect the output stream of the child process.
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            // Start!
            process.Start();
            List<SHD> shd = new List<SHD>();
            StringBuilder shf = null;
          //  StringBuilder sht = null;
            bool files = false;
            // Read the output stream
            while (!process.StandardOutput.EndOfStream)
            {
                // This is the current stream data
                File.WriteAllText("./temp", process.StandardOutput.ReadLine(), System.Text.Encoding.GetEncoding(1251));
                string line = File.ReadAllText("./temp", System.Text.Encoding.GetEncoding("CP866"));
                // ref: http://support.microsoft.com/kb/103013
                if (line == "There are no entries in the list.")
                    return null;
                if (line == "Команда выполнена успешно.")
                    continue;
                if (line != string.Empty && line[0] == '-')
                {
                    files = true;
                    continue;
                }
                // Find/Parse the pc name
                if (line != string.Empty && line[0] != '-' && files == true)
                {
                    if (files && line[0] != '-')
                    {
                        shf = new StringBuilder();
                        for (int y = 0; y < line.Length; y++)
                        {
                            if (line[y] == ' ' && line[y+1] == ' ')
                                break;
                            else
                                shf.Append(line[y]);
                        }
                    }
                    // Add the current PC to the PC list
                    shd.Add(new SHD { SharedFile = shf.ToString() });
                   // shd.Add(new SHD { SharedType = sht.ToString() });
                }
            }
            // Wait indefinitely for the associated process to exit
            process.WaitForExit();
            // Frees all the resources
            process.Close();
            return shd;
        }

        private void scan_btn_Click(object sender, EventArgs e)
        {
            GetNameIP();
            try
            {
                int count_pc = network_tv.SelectedNode.Index;
                TreeNode tn = network_tv.SelectedNode;
                if (tn.Text == network_tv.TopNode.Text && pc_l.Visible)
                    MessageBox.Show("Выберите компьютер в сети!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (tn.Nodes.Count == 0)
                {
                    var pcs = DisplaySharedFiles(tn.Text);
                    if (pcs != null)
                    {
                        foreach (var pcc in pcs)
                            ScanRecursive(network_tv.Nodes[0].Nodes[count_pc].Nodes.Add(pcc.SharedFile), new DirectoryInfo(@"\\" + tn.Text + @"\" + pcc.SharedFile));
                    }
                    scan_complete = true;
                }
            }
            catch
            { }
        }

        private void network_tv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                listFiles.Clear();
                files_lv.Items.Clear();
                icons_files_iL.Images.Clear();
                TreeNode node = network_tv.SelectedNode;
                string path = node.FullPath.Substring(4);
                path_tB.Text = @"\"+path + @"\";
                if (node.Nodes.Count == 0)
                {
                    if (recur_cb.Checked && mess && node.Level > 1)
                    {
                        MessageBox.Show("Из за особенностей общего доступа"+ '\n'+
                            "построение дерева может занять некоторое время", "Будьте терпливы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mess = false;
                    }
                    foreach (string item in Directory.GetDirectories(path_tB.Text))
                    {
                        DirectoryInfo di = new DirectoryInfo(item);
                        if (recur_cb.Checked)
                            DirectoryRecursive(network_tv.SelectedNode.Nodes.Add(di.Name), new DirectoryInfo(di.FullName));
                        else
                            network_tv.SelectedNode.Nodes.Add(di.Name);
                    }
                }

                if (cat_cb.Checked)
                {
                    foreach (string item in Directory.GetDirectories(path_tB.Text))
                    {
                        var size = ShellEx.IconSizeEnum.MediumIcon32;
                        icons_files_iL.Images.Add(ShellEx.GetBitmapFromFilePath(item, size));
                        DirectoryInfo di = new DirectoryInfo(item);
                        listFiles.Add(di.FullName);
                        files_lv.Items.Add(di.Name, icons_files_iL.Images.Count - 1);
                    }
                }
                foreach (string item in Directory.GetFiles(path_tB.Text))
                {
                    var size = ShellEx.IconSizeEnum.MediumIcon32;
                    icons_files_iL.Images.Add(ShellEx.GetBitmapFromFilePath(item, size));
                    FileInfo fi = new FileInfo(item);
                    listFiles.Add(fi.FullName);
                    files_lv.Items.Add(fi.Name, icons_files_iL.Images.Count - 1);
                }
            }
            catch
            { }
        }

        private void files_lv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (files_lv.FocusedItem != null)
                Process.Start(listFiles[files_lv.FocusedItem.Index]);
        }

        private void find_btn_Click(object sender, EventArgs e)
        {
            UpdateNetwork();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateNetwork();
        }
    }
}