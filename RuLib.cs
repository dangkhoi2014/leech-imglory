using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace RuProject
{
    class RuLib
    {
        public string file_setting { get; set; }
        public static Dictionary<string, string> GetSetting()
        {
            try
            {
                Dictionary<string, string> Config = new Dictionary<string, string>();
                string duongDanFile = "Setting.xml";

                XmlDocument docXML = new XmlDocument();
                docXML.Load(duongDanFile);
                string xpath = "//item";

                XmlNodeList nameList = docXML.SelectNodes(xpath); // Lấy ra tất cả các Node con "name" hiện có.
                foreach (XmlNode bl in nameList) // Truy xuất tất cả các Node con trong nameList
                {
                    Config.Add(bl.Attributes["key"].Value, bl.Attributes["value"].Value);
                }

                return Config;
            }
            catch
            {
                Dictionary<string, string> Config = new Dictionary<string, string>();
                return Config;
            }
        }

        public static void SetSetting(string key, string value)
        {
            try
            {
                Dictionary<string, string> Config = new Dictionary<string, string>();
                string duongDanFile = "Setting.xml";

                XmlDocument docXML = new XmlDocument();
                docXML.Load(duongDanFile);
                string xpath = "//item";

                XmlNodeList nameList = docXML.SelectNodes(xpath); // Lấy ra tất cả các Node con "name" hiện có.
                foreach (XmlNode bl in nameList) // Truy xuất tất cả các Node con trong nameList
                {
                    if (bl.Attributes["key"].Value == key)
                    {
                        bl.Attributes["value"].Value = value;

                    }
                }
                docXML.Save(duongDanFile);
                return;
            }
            catch
            {
                Dictionary<string, string> Config = new Dictionary<string, string>();
                return;
            }
        }
        //check sử tồn tại của key dynamic
        public static bool IsPropertyExist(dynamic settings, string name)
        {
            if (settings is System.Dynamic.ExpandoObject)
                return ((IDictionary<string, object>)settings).ContainsKey(name);

            return settings.GetType().GetProperty(name) != null;
        }

        public static dynamic GetJson(string responseString)
        {
            try
            {
                dynamic results = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<dynamic>(responseString);
                return results;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string SetJson(dynamic obj)
        {
            try
            {
                var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(obj);
                return json;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool CheckStringContains(string source_string, string check_string)
        {
            bool flag;
            flag = (source_string.IndexOf(check_string, 0, StringComparison.CurrentCultureIgnoreCase) >= 0 ? true : false);
            return flag;
        }
        public static bool IsBase64(string base64String)
        {
            if (base64String == null || base64String.Length == 0 || base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch
            {
                // Handle the exception
            }
            return false;
        }
        public static string GetRegexString(string input, string key, int iType)
        {
            string value = string.Empty;
            if (iType == 1)
            {
                value = Regex.Match(input, "name=([\\\\]+|)(\"|')" + key + "([\\\\]+|)(\"|') value=([\\\\]+|)(\"|')(?<val>[^'\"\\\\]+)([\\\\]+|)(\"|')", RegexOptions.IgnoreCase).Groups["val"].Value;
            }
            else if (iType == 2)
            {
                value = Regex.Match(input, "([\\\\]+|)(\"|')" + key + "([\\\\]+|)(\"|')([\\s]+|):([\\s]+|)([\\\\]+|)(\"|')(?<val>[^'\"\\\\]+)([\\\\]+|)(\"|')", RegexOptions.IgnoreCase).Groups["val"].Value;
            }
            return value;
        }
        //Sping
        public static int RandomNumber(int MaxNumber, int MinNumber = 0)
        {
            Random r = new Random();
            if (MinNumber > MaxNumber)
            {
                int t = MinNumber;
                MinNumber = MaxNumber;
                MaxNumber = t;
            }

            return r.Next(MinNumber, MaxNumber);
        }
        private string SpinEvaluator(Match match)
        {
            string v = match.ToString();
            if (v.Contains("{"))
            {
                string[] x = v.Split(new Char[] { '|' });
                string kwd = x[RandomNumber(x.Length, 0)].Replace("{", "").Replace("}", "");
                return kwd;
            }
            else
            {
                return v;
            }
        }//Sping

        public static List<string> getAttribute(string pattern, string soure)
        {
            List<string> attribute = new List<string>();
            System.Text.RegularExpressions.MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(soure, pattern);

            if (matches.Count > 0)
            {
                foreach (System.Text.RegularExpressions.Match m in matches)
                {
                    attribute.Add(m.Groups[1].ToString());
                }
            }

            return attribute;
        }

        public static List<HtmlAgilityPack.HtmlNode> getXpath(string xpath, string pageSoure)
        {
            List<HtmlAgilityPack.HtmlNode> _return = new List<HtmlAgilityPack.HtmlNode>();
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(pageSoure);
            var node = htmlDocument.DocumentNode.SelectNodes(xpath);
            try
            {
                foreach (var item in node)
                {
                    _return.Add(item);
                }
            }
            catch
            {

            }

            return _return;
        }

        public static string DecodeEncodedNonAsciiCharacters(string value)
        {
            string str = Regex.Replace(value, "\\\\u(?<Value>[a-fA-F0-9]{4})", (Match m) => ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString());
            return str;
        }

        static public void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))

                Directory.CreateDirectory(destFolder);

            string[] files = Directory.GetFiles(sourceFolder);

            foreach (string file in files)

            {

                string name = Path.GetFileName(file);

                string dest = Path.Combine(destFolder, name);

                File.Copy(file, dest);

            }

            string[] folders = Directory.GetDirectories(sourceFolder);

            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);

            }
        }

        public static string GetRandomFile(string path)
        {
            string file = null;
            if (!string.IsNullOrEmpty(path))
            {
                var extensions = new string[] { ".png", ".jpg", ".gif" };
                try
                {
                    var di = new DirectoryInfo(path);
                    var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                    Random R = new Random();
                    file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;
                }
                catch { }
            }
            return file;
        }


        public static bool SoketConnect(string host, int port)
        {
            var is_success = false;
            try
            {
                var connsock = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
                connsock.SetSocketOption(System.Net.Sockets.SocketOptionLevel.Socket, System.Net.Sockets.SocketOptionName.SendTimeout, 200);
                System.Threading.Thread.Sleep(500);
                var hip = System.Net.IPAddress.Parse(host);
                var ipep = new System.Net.IPEndPoint(hip, port);
                connsock.Connect(ipep);
                if (connsock.Connected)
                {
                    is_success = true;
                }
                connsock.Close();
            }
            catch (Exception)
            {
                is_success = false;
            }
            return is_success;
        }

        public static void WriteFile(string path, string content)
        {
            string result = string.Empty;
            if (File.Exists(path))
            {
                string[] resultF = File.ReadAllLines(path);
                result = string.Join("\r\n", resultF) + "\r\n" + content.Trim();
            }
            else
            {
                result = content;

            }

            File.WriteAllText(path, String.Empty);
            File.Create(path).Close();
            using (StreamWriter streamWriter = new StreamWriter(path, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(result);
                streamWriter.Flush();
            }
            File.Exists(path);
        }

        public static string LocKyTu(string str)
        {
            var charsToRemove = new string[] { "@", ",", ".", ";", "'", "-", "+", "!", "#", "$", "%", "^", "&", "*", "(", ")", "{", "}", "'", "\"" };
            foreach (var c in charsToRemove)
            {
                str = str.Replace(c, string.Empty);
            }
            return str;
        }
        //kiểm tra kết nối internet
        public static Dictionary<string, string> IsConnectedToInternet(string host)
        {
            Dictionary<string, string> backcall = new Dictionary<string, string>();
            backcall["Status"] = "TimedOut";
            backcall["RoundtripTime"] = "0";
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            try
            {
                System.Net.NetworkInformation.PingReply pr = p.Send(host, 3000);
                if (pr.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    backcall["Status"] = pr.Status.ToString();//Success
                    backcall["RoundtripTime"] = pr.RoundtripTime.ToString();
                }
            }
            catch (Exception)
            {


            }
            return backcall;
        }

        public static void CopySelectedValuesToClipboard(ListView lv)
        {
            var builder = new StringBuilder();
            foreach (ListViewItem item in lv.SelectedItems)
            {
                List<string> text = new List<string>();

                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    text.Add(item.SubItems[i].Text);
                }
                builder.AppendLine(string.Join("|", text));
            }
            System.Windows.Forms.Clipboard.SetText(builder.ToString());
        }
        public static void DelSelectedValuesToClipboard(ListView lv)
        {
            for (int i = 0; i < lv.Items.Count; i++)
            {
                if (lv.Items[i].Selected)
                {
                    lv.Items[i].Remove();
                    i--;
                }
            }
        }
        public static void CreateShortcut(string shortcutName, string shortcutPath,string folderPortable, string targetFileLocation)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutLocation);
            shortcut.WorkingDirectory = targetFileLocation;
            shortcut.Description = "";
            shortcut.IconLocation = targetFileLocation + "\\chrome.exe";
            string strShortcut = targetFileLocation + "\\chrome.exe";
            shortcut.TargetPath = strShortcut;
            shortcut.Arguments = "--profile-directory=\"Default\" --user-data-dir=\""+folderPortable+"\"";
            shortcut.Save();
        }
        public static string RunScript(string scriptText)
        {

            System.Management.Automation.Runspaces.Runspace runspace = System.Management.Automation.Runspaces.RunspaceFactory.CreateRunspace();
            runspace.Open();
            System.Management.Automation.Runspaces.Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);
            pipeline.Commands.Add("Out-String");

            System.Collections.ObjectModel.Collection<PSObject> results = pipeline.Invoke();

            runspace.Close();

            StringBuilder stringBuilder = new StringBuilder();
            foreach (System.Management.Automation.PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            return stringBuilder.ToString();
        }

        public static string GetRandomLineFile(string path)
        {
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                Random r = new Random();
                int start2 = r.Next(0, lines.Length);
                return lines[start2];
            }
            else
            {
                return "";
            }
        }

    }
}
