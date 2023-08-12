using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Chrome;
using xNet;
using System.Web.Script.Serialization;
using HtmlAgilityPack;
using System.Web.UI.WebControls;

namespace RuProject
{
    class TaskRun
    {
        public Dictionary<string, string> Setting;
        public ClsReturn clsReturn = new ClsReturn();        
        public string link = string.Empty;
        public string linkSong = string.Empty;
        public delegate void StatusEventHandler(ClsReturn callback, int index = 0);
        public static event StatusEventHandler callback;
        public int index_row;//cột trả về

        public Task Run(CancellationToken token)
        {
            Task t = Task.Run(() =>
            {
                bool flag = false;
                Dictionary<string, string> feedback = new Dictionary<string, string>();
                clsReturn.msg = "Bắt đầu";
                clsReturn.status = "Run";
                callback.Invoke(clsReturn, index_row);


                try
                {
                    List<string> listSong = getSoure(link);
                    int coutList = listSong.Count;
                    clsReturn.msg = "0/" + listSong.Count;
                    clsReturn.status = "Run";
                    callback.Invoke(clsReturn, index_row);
                    SendLink(listSong, index_row, 1, coutList);
                }
                catch (Exception)
                {
                    clsReturn.msg = "Fail";
                }

                clsReturn.status = "End";
                callback.Invoke(clsReturn, index_row);
            }, token);
            return t;
        }
        public void SendLink(List<string> listSong, int index_row, int stt = 1, int coutList = 0)
        {
            int stt1 = stt;
            ClsSong song = new ClsSong();
            if (listSong.Count > 0)
            {
                foreach (var item in listSong)
                {
                    var runningTask = Task.Factory.StartNew(() => {
                        song = getMedia(item);
                    });
                    runningTask.Wait();
                    clsReturn.msg = stt.ToString() + "/" + coutList.ToString();
                    clsReturn.status = "Run";
                    clsReturn.data = song.artist + "	" + song.linkartist;
                    clsReturn.data = song.testlyric;
                     callback.Invoke(clsReturn, index_row);
                    stt1++;
                }
            }
        }

        public ClsSong getMedia(string urlcheck)
        {
            ClsSong song = new ClsSong();
            using (HttpRequest httpRequest = new HttpRequest())
            {
                httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36 Edg/80.0.361.69";
                httpRequest.AddHeader("Accept-Language", "en-US,en;q=0.9");
                string pageSoure = httpRequest.Get(urlcheck, null).ToString();
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(pageSoure);
                // for (int i=1;i<100;i++)
                // {
                try
                {
                    var linkartist = htmlDoc.DocumentNode.SelectNodes("/html/body/div[2]/main/div/div[1]/div/div[2]/div[1]/div/div[2]/div[2]/div[1]/p[2]/a");
                    foreach (var item in linkartist)
                    {
                        try
                        {
                            song.linkartist = item.Attributes["href"].Value;
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                catch
                {

                }


                try
                {


                    return song;
                }
                catch (Exception)
                {
                    return song;
                }
                //}

            }
        }
        public List<string> getSoure(string linkGet)
        {

            List<string> listSong = new List<string>();
            using (HttpRequest httpRequest = new HttpRequest())
            {
                httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36 Edg/80.0.361.69";
                httpRequest.AddHeader("Accept-Language", "en-US,en;q=0.9");
                string pageSoure = httpRequest.Get(linkGet, null).ToString();
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(pageSoure);
            //    for (int i = 1; i < 350; i++)
            //    {
            //        try
            //        {
            //            var link = htmlDoc.DocumentNode.SelectNodes("/html/body/div[1]/div/section/article/div[2]/div[2]/div/ol/li["+i+"]/a");
            //            foreach (var item in link)
            //            {
            //                try
            //                {
            //                    listSong.Add("https://www.countrynoise.net" + item.Attributes["href"].Value);

            //                }
            //                catch (Exception)
            //                {
                                
            //                }
            //            }
            //        }
            //        catch
            //        {
            //            break;
            //        }

            //    }

            }
            listSong.Add(linkGet);
            return listSong;
        }
        public Dictionary<string, string> ParseJSON(string s)
        {
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("\"(?<Key>[\\w]*)\":\"?(?<Value>([\\s\\w\\d\\.\\\\\\-/:_\\+]+(,[,\\s\\w\\d\\.\\\\\\-/:_\\+]*)?)*)\"?");
            System.Text.RegularExpressions.MatchCollection mc = r.Matches(s);

            Dictionary<string, string> json = new Dictionary<string, string>();

            foreach (System.Text.RegularExpressions.Match k in mc)
            {
                json.Add(k.Groups["Key"].Value, k.Groups["Value"].Value);

            }
            return json;
        }
    }    
}
