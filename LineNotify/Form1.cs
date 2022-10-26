using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace LineNotify
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

            string token = "CW9pGYhqJs6ZY8idMVk6O29FPE04ppC05XnCESPB6Sg";
        private void Form1_Load(object sender, EventArgs e)
        {
            send("開啟");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            send("關閉");
        }

        private void send(string message)
        {
            string url = "https://notify-api.line.me/api/notify";
            string postData = "message=" + WebUtility.HtmlEncode("\r\n" + message);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            Uri target = new Uri(url);
            WebRequest request = WebRequest.Create(target);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            request.Headers.Add("Authorization", "Bearer " + token);

            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
            }
            
        }
    }
}
