using blockchain_demo.Properties;
using Nethereum.Web3;
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
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using System.Numerics;

namespace blockchain_demo
{
    public partial class Main : Form
    {
        Hashtable coins = new Hashtable();
        Hashtable deploys = new Hashtable();

        Hashtable users = new Hashtable();

        string selected = "";
        string directory = "";

        string abi = "";
        string bytecode = "";
        string url = "HTTP://localhost:7545";

        string python = @"C:\Users\eneskacan\anaconda3\python.exe";

        bool isDeployed = false;

        public Main()
        {
            InitializeComponent();
        }

        private void OnInputChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_Error.Text = ParseInput(txt_Input.Text);
            }
            catch (Exception exception)
            {
                lbl_Error.Text = exception.Message;
            }
        }

        private void OnInputCompleted(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var input = ParseInput(txt_Input.Text);
                txt_Input.Text = "";

                StringBuilder builder = new StringBuilder(input);
                builder.Replace("None", "'null'");
                var objects = JObject.Parse(builder.ToString());

                Execute(objects);
            }
        }

        String ParseInput(string input)
        {
            // Create Process Info
            var psi = new ProcessStartInfo();
            psi.FileName = python;

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
                    Transfer(parameters.GetValue("amount").ToString(), parameters.GetValue("sender").ToString(), parameters.GetValue("receiver").ToString());
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
            GetCoinInfo();
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
            directory = str;
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
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();
                isDeployed = true;
                GetCoinInfo();
                MessageBox.Show("Contracts are deployed successfuly!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }

        void SetBase()
        {
            users.Add("base", "0x6953ebf1222Dab5dfD3C17F5BeC3E96119Bd27CA");
        }

        void CreateUser(String username)
        {
            users.Add(username, CreateNewEthereumAddressAsync("pass"));
        }

        public String CreateNewEthereumAddressAsync(string password)
        {
            Web3 web3 = new Web3(url);

            var address = web3.Personal.NewAccount.SendRequestAsync(password);
            address.Wait();

            return address.Result.ToString();
        }

        private void SetUserBalance(string username, string amount)
        {
            Web3 web3 = new Web3(url);

            Transfer(amount, "base", username);
        }

        async void GetUserBalance(string username)
        {
            Web3 web3 = new Web3(url);
            Contract contract = web3.Eth.GetContract(abi, bytecode);

            var getUserAtIndex = contract.GetFunction("getBalance");
            var result = getUserAtIndex.CallAsync<BigInteger>(users[username]);
            result.Wait();

            MessageBox.Show($"Total balance of {username} is {result.Result.ToString()}");            
        }

        private void Transfer(string amount, string sender, string receiver)
        {
            Web3 web3 = new Web3(url);
            Contract contract = web3.Eth.GetContract(abi, bytecode);

            HexBigInteger gas = new HexBigInteger(new BigInteger(400000));
            HexBigInteger value = new HexBigInteger(new BigInteger(0));
            Task<string> castVoteFunction = contract.GetFunction("sendCoin").SendTransactionAsync(users[sender].ToString(), gas, value, users[receiver], Int32.Parse(amount));
            castVoteFunction.Wait();
        }

        private void Exit()
        {
            Environment.Exit(0);
        }

        void GetCoinInfo()
        {
            //test
            isDeployed = true;
            if(isDeployed)
            {
                //string file = @"\build\contracts\" + selected + ".json";
                string file = @"\build\contracts\" + "Enes" + ".json";
                directory = @"C:\Users\eneskacan\Desktop\deployable";

                // Create Process Info
                var psi = new ProcessStartInfo();
                psi.FileName = python;

                // Provide script and arguments
                var script = string.Format("{0}lib\\get_coin_info.py", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));
                psi.Arguments = $"\"{script}\" \"{directory}\" \"{file}\"";

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
                    string standard_output;
                    while ((standard_output = process.StandardOutput.ReadLine()) != null)
                    {
                        if (output.Length == 0)
                        {
                            output = standard_output;
                        }
                        else if (bytecode.Length == 0)
                        {
                            bytecode = standard_output;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (errors.Length != 0)
                {
                    throw new Exception(errors);
                }

                StringBuilder builder = new StringBuilder(output);
                builder.Replace("None", "'null'");
                builder.Replace("False", "false");
                builder.Replace("True", "true");

                abi = JArray.Parse(builder.ToString()).ToString();
            }
        }
    }
}
