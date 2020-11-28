using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolAutoSTV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        ChromeDriver chrome;
        Thread thread;
        Random ran=new Random();
        int time;
        private void btdangnhap_Click(object sender, EventArgs e)
        {
            if(btdangnhap.Text=="Đăng Nhập")
            {
                btdangnhap.Text = "Thoát";
                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;
                ChromeOptions option = new ChromeOptions();
                option.AddArgument("user-data-dir=profile");
                option.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.83 Safari/537.36");
                chrome = new ChromeDriver(service, option);
                chrome.Navigate().GoToUrl("http://sangtacviet.com/");
            }
            else
            {
                try
                {
                    thread.Abort();
                }
                catch { }
                try
                {
                    chrome.Close();
                    chrome.Quit();
                }
                catch { }                
                btdangnhap.Text = "Đăng Nhập";
            }
        }

        private void btcay_Click(object sender, EventArgs e)
        {
            if(btcay.Text=="Cày")
            {
                btcay.Text = "Dừng";
                thread = new Thread(Cay);
                thread.Start();
            }
            else
            {
                btcay.Text = "Cày";
                try
                {
                    thread.Abort();
                }
                catch { }
            }
        }
        void Cay()
        {
            while(true)
            {             
                if(link1.Text!="")
                {
                    for (int i = 1; i <= (int)tr1.Value; i++)
                    {
                        try
                        {
                            chrome.Navigate().GoToUrl(link1.Text + i + "/");
                        }
                        catch (Exception)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(8));
                        }
                        Thread.Sleep(TimeSpan.FromSeconds(8));
                        NhatBao();                      
                    }
                }
                if (link2.Text != "")
                {
                    for (int i = 1; i <= (int)tr2.Value; i++)
                    {
                        try
                        {
                            chrome.Navigate().GoToUrl(link2.Text + i + "/");
                        }
                        catch (Exception)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(8));
                        }
                        Thread.Sleep(TimeSpan.FromSeconds(8));
                        NhatBao();
                    }
                }
                if (link3.Text != "")
                {
                    for (int i = 1; i <= (int)tr3.Value; i++)
                    {
                        try
                        {
                            chrome.Navigate().GoToUrl(link3.Text + i + "/");
                        }
                        catch (Exception)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(8));
                        }
                        Thread.Sleep(TimeSpan.FromSeconds(8));
                        NhatBao();
                    }
                }
                if (link4.Text != "")
                {
                    for (int i = 1; i <= (int)tr4.Value; i++)
                    {
                        try
                        {
                            chrome.Navigate().GoToUrl(link4.Text + i + "/");
                        }
                        catch (Exception)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(8));
                        }
                        Thread.Sleep(TimeSpan.FromSeconds(8));
                        NhatBao();
                    }
                }
            }
        }
        int sl=0;
        void NhatBao()
        {

            time = ran.Next((int)min.Value / 9, (int)max.Value / 9);
            try
            {
                for (int i = 1; i <= 9; i++)
                {
                    chrome.ExecuteScript("window.scrollTo( 0, " + i + "*document.body.scrollHeight/9)");
                    Thread.Sleep(TimeSpan.FromSeconds(time));
                }
                chrome.FindElementByXPath("//*[contains(text(),'Nhặt bảo')]").Click();
                Thread.Sleep(5000);
                chrome.FindElementByXPath("//*[contains(text(),'Ok')]").Click();
                Thread.Sleep(5000);
                sl++;
                bao.Text = "Bảo:" + sl;
            }
            catch { }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                thread.Abort();
            }
            catch { }
            try
            {
                chrome.Close();
                chrome.Quit();
            }
            catch { }
        }
    }
}
