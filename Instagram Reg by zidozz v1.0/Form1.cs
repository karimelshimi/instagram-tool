using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Instagram_Reg_by_zidozz_v1._0
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public static string email;

        public static string pass;

        public static string user;

        public static string name;
        string[] text;
        string[] text1;
        string[] text2;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void reg()
        {
            register(email, pass, user, name);
        }
        public static object register(string Email, string Pass, string user, string Name)
        {
            string s = "email=" + Email + "&password=" + Pass + "&username=" + user + "&first_name=" + Name;
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            byte[] bytes = uTF8Encoding.GetBytes(s);
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.instagram.com/accounts/web_create_ajax/");
            httpWebRequest.Headers.Add("X-CSRFToken", "4d1RHxO1YEYiEBys2mR28DEWDlbVN1yl");
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Headers.Add("X-Instagram-AJAX", "1");
            httpWebRequest.Headers.Add("X-Requested-With", "XMLHttpRequest");
            httpWebRequest.Headers.Add("Cookie", "mid=Wj3lBwALAAF2wYavnSmiFaFZiJzC; js_datr=JbBhWCXpCLhu_i0Hy89QBFIG; csrftoken=4d1RHxO1YEYiEBys2mR28DEWDlbVN1yl; ig_pr=1.25; ig_vw=1525; ig_dru_dismiss=1485866364904; ig_aib_du=1487800189834; js_reg_ext_ref=http%3A%2F%2Fhelp.instagram.com; js_reg_fb_ref=https%3A%2F%2Fwww.facebook.com%2Fhelp%2Finstagram%2Fcontact%2F1652567838289083; js_reg_fb_gate=https%3A%2F%2Fwww.facebook.com%2Fhelp%2Finstagram%2F292478487812558; wd=1525x724; dpr=1.25");
            httpWebRequest.Method = "POST";
            httpWebRequest.KeepAlive = true;
            CookieContainer cookieContainer = default(CookieContainer);
            httpWebRequest.CookieContainer = cookieContainer;
            httpWebRequest.Referer = "https://www.instagram.com/";
            httpWebRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; ru; rv:1.9.2.3) Gecko/20100401 Firefox/4.0 (.NET CLR 3.5.30729)";
            checked
            {
                httpWebRequest.ContentLength = (int)unchecked((IntPtr)bytes.LongLength);
                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(bytes, 0, (int)unchecked((IntPtr)bytes.LongLength));
                requestStream.Close();
            }
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string text = streamReader.ReadToEnd();
            if (text.Contains("Another account is using"))
            {
               // Console.ForegroundColor = ConsoleColor.DarkRed;
               // Console.WriteLine(user + "Fail Register !!");
                MessageBox.Show(user + "Fail Register !!");
            }
            else
            {
                // Console.ForegroundColor = ConsoleColor.DarkGreen;
               // Console.WriteLine(user + "Done Register !!");
                MessageBox.Show(user + "Done Register !!");
            }
            object result = default(object);
            return result;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            email = textBox1.Text;
            pass = textBox2.Text;
            user = textBox3.Text;
            name = textBox4.Text;
            Thread thread = new Thread(reg);
            thread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    // string text = File.ReadAllText(file);
                     text = File.ReadAllLines(file);
                    foreach (string texta in text)
                    {
                        ListViewItem email = new ListViewItem();
                        email.Text = texta;
                        email.SubItems.Add("");
                        email.SubItems.Add("");
                        email.ImageIndex = 0;
                        listView1.Items.Add(email);
                        
                    }
                   
                }
                catch (IOException)
                {
                    MessageBox.Show("error!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int o=0;
            
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    // string text = File.ReadAllText(file);
                     text1 = File.ReadAllLines(file);
                    foreach (string textaa in text1)
                    {
                        ListViewItem username = new ListViewItem();
                        //username.SubItems.Add(textaa);
                        username.ImageIndex = 1;
                        listView1.Items[o].SubItems[1].Text = textaa;
                        o++;
                    }

                }
                catch (IOException)
                {
                    MessageBox.Show("error!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int o = 0;

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    // string text = File.ReadAllText(file);
                    text2 = File.ReadAllLines(file);
                    foreach (string textaa in text2)
                    {
                        ListViewItem name = new ListViewItem();
                        //username.SubItems.Add(textaa);
                        name.ImageIndex = 2;
                        listView1.Items[o].SubItems[2].Text = textaa;
                        o++;
                    }

                }
                catch (IOException)
                {
                    MessageBox.Show("error!");
                }
            }
        }
    }
}
