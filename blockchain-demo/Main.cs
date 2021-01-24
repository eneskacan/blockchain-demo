﻿using blockchain_demo.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blockchain_demo
{
    public partial class Main : Form
    {
        Hashtable coins = new Hashtable();
        Hashtable deploys = new Hashtable();

        string selected = "";
        string directory = "";

        public Main()
        {
            InitializeComponent();
        }

        private void OnInput(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var input = ParseInput(txt_Input.Text);

                StringBuilder builder = new StringBuilder(input);
                builder.Replace("None", "'null'");
                var objects = JObject.Parse(builder.ToString());

                Execute(objects);  
            }

            try
            {
                lbl_Error.Text = ParseInput(txt_Input.Text);
            }
            catch (Exception exception)
            {
                lbl_Error.Text = exception.Message;
            }
        }

        String ParseInput(string input)
        {
            // Create Process Info
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\eneskacan\anaconda3\python.exe";

            // Provide script and arguments
            var script = string.Format("{0}lib\\parse_string.py", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));
            psi.Arguments = $"\"{script}\" \"{input}\"";

            // Process configuration
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            // Execute process and get output
            var errors = "";
            var output = "";

            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                output = process.StandardOutput.ReadToEnd();
            }

            if(errors.Length != 0)
            {
                throw new Exception(errors);
            }

            return output;
        }

        void Execute(JObject parameters)
        {
            switch(parameters.GetValue("command").ToString())
            {
                case "create":
                    if(parameters.GetValue("type").ToString().Equals("coin")) 
                    { 
                        CreateCoin(parameters.GetValue("coinname").ToString()); 
                    }
                    else 
                    { 
                        CreateUser(parameters.GetValue("username").ToString()); 
                    }                    
                    break;

                case "select":
                    SelectCoin(parameters.GetValue("coinname").ToString());
                    break;

                case "set":
                    if (parameters.GetValue("type").ToString().Equals("total amount as"))
                    {
                        SetTotalAmount(selected, parameters.GetValue("amount").ToString());
                    }
                    else
                    {
                        SetUserBalance(parameters.GetValue("username").ToString(), parameters.GetValue("amont").ToString());
                    }
                    break;
                case "deploy project":
                    DeployProject();
                    break;

                case "get balance of":
                    GetUserBalance(parameters.GetValue("username").ToString());
                    break;

                case "transfer":
                    Transfer(parameters.GetValue("coinname").ToString(), parameters.GetValue("amount").ToString(),
                        parameters.GetValue("sender").ToString(), parameters.GetValue("receiver").ToString());
                    break;

                case "exit":
                    Exit();
                    break;
            }
        }

        void CreateCoin(String coinname)
        {
            string coin_code = Resources.coin_source;
            string deploy_code = Resources.deploy_source;

            StringBuilder builder = new StringBuilder(coin_code);
            builder.Replace("#coin_name#", coinname);
            coins.Add(coinname, builder.ToString());

            builder = new StringBuilder(deploy_code);
            builder.Replace("#coin_name#", coinname);
            deploys.Add(coinname, builder.ToString());

            SelectCoin(coinname);
        }        

        void SelectCoin(String coinname)
        {
            selected = coinname;
        }

        void SetTotalAmount(String coinname, string amount)
        {
            string coin_code = coins[coinname].ToString();

            StringBuilder builder = new StringBuilder(coin_code);
            builder.Replace("#total_amount#", amount);
            coins[coinname] = builder.ToString();
        }

        private void DeployProject()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Please select a folder to save project!";


            if (fbd.ShowDialog() == DialogResult.OK)
            {
                directory = fbd.SelectedPath;
            }

            String str = directory + @"\deployable";
            MessageBox.Show(str);
            if (!System.IO.Directory.Exists(str))  System.IO.Directory.CreateDirectory(str);
            if (!System.IO.Directory.Exists(str + @"\contracts"))  System.IO.Directory.CreateDirectory(str + @"\contracts");
            if (!System.IO.Directory.Exists(str + @"\migrations"))  System.IO.Directory.CreateDirectory(str + @"\migrations");

            File.WriteAllText(str + @"\truffle-config.js", Resources.truffle_config);
            File.WriteAllText(str + @"\package-lock.json", Resources.package_lock);
            File.WriteAllText(str + @"\package.json", Resources.package);
            File.WriteAllText(str + @"\bs-config.json", Resources.bs_config);
            File.WriteAllText(str + @"\deploy.bat", Resources.deploy);
            File.WriteAllText(str + @"\migrations\1_initial_migration.js", Resources.initial_migration);
            File.WriteAllText(str + @"\contracts\Migrations.sol", Resources.migrations);

            foreach (string k in coins.Keys)
            {
                File.WriteAllText(str + @"\contracts\" + k + ".sol", coins[k].ToString());
            }

            foreach (string k in deploys.Keys)
            {
                File.WriteAllText(str + @"\migrations\2_deploy_contracts.js", deploys[k].ToString());
            }

            Process process = null;
            try
            {
                process = new Process();
                process.StartInfo.WorkingDirectory = string.Format(str);
                process.StartInfo.FileName = "deploy.bat";
                process.StartInfo.CreateNoWindow = false;
                process.Start();
                process.WaitForExit();
                MessageBox.Show("Contracts are deployed successfuly!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }

            void CreateUser(String username)
        {
        }

        private void SetUserBalance(string username, string amount)
        {
            throw new NotImplementedException();
        }

        private void GetUserBalance(string username)
        {
            throw new NotImplementedException();
        }

        private void Transfer(string coinname, string amount, string sender, string receiver)
        {
            throw new NotImplementedException();
        }

        private void Exit()
        {
            throw new NotImplementedException();
        }
    }
}
