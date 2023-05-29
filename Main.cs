using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AstroConnectCSharpClient.Models;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AstroConnectCSharpClient
{
    public partial class Main : Form
    {
        private string _accessToken;

        public Main()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtBaseUrl.Text = "https://astroconnectmasons.azurewebsites.net";
            txtUser.Text = "nadun";
            txtPassword.Text = "nethuli2015";

           



        }

        private void btnAuthenticate_Click(object sender, EventArgs e)
        {



            //worker.DoWork += (s, args) =>
            //{
                lblStatus.Text = "Processing... Please wait";
                var client = new HttpClient();
                TokenData tokenData = new TokenData();
                tokenData.UserName = txtUser.Text;
                tokenData.Password = txtPassword.Text;
                var tokenUrl = $"{txtBaseUrl.Text}/api/v2/json/Account/token";
                var json = JsonConvert.SerializeObject(tokenData);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(tokenUrl, data);
                if (response.Result.StatusCode == HttpStatusCode.OK)
                {
                    //lblStatus.Text = "Authenticated";
                     

                    var responseContent = response.Result.Content.ReadAsStringAsync();
                    var tokenResponseJson = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponseData>(responseContent.Result);
                    _accessToken = tokenResponseJson?.Token;

                    if (!string.IsNullOrEmpty(_accessToken))
                    {
                        //var operatorTypes = GetOperatorTypes(_accessToken);
                        //var accomodationOperatorTypes = operatorTypes.Where(x => x.ServiceType == 7)
                        //    .Select(x => x.SupplierServiceOperatorId).ToList();
                        var operators = GetOperators(_accessToken);
                        cmbAccomodation.DataSource = operators;
                        cmbAccomodation.ValueMember = "Id";
                        cmbAccomodation.DisplayMember = "Name";
                        var islands = GetIslands(_accessToken);
                        cmbIslands.DataSource = islands;
                        cmbIslands.ValueMember = "Id";
                        cmbIslands.DisplayMember = "Name";


                    lblStatus.Text = "Data Loaded";
                }

                }
                else if (response.Result.StatusCode == HttpStatusCode.Forbidden)
                {
                    lblStatus.Text = "Authentication Error";
                }
                else if (response.Result.StatusCode == HttpStatusCode.BadRequest)
                {
                    lblStatus.Text = "Bad Request";
                }
                else
                {
                    lblStatus.Text = "Unknown Error";
                }
            //};
        }


        /// <summary>
        /// Helper method to determin if invoke required, if so will rerun method on correct thread.
        /// if not do nothing.
        /// </summary>
        /// <param name="c">Control that might require invoking</param>
        /// <param name="a">action to preform on control thread if so.</param>
        /// <returns>true if invoke required</returns>
        //public bool ControlInvokeRequired(Control c, Action a)
        //{
        //    if (c.InvokeRequired) c.Invoke(new MethodInvoker(delegate { a(); }));
        //    else return false;

        //    return true;
        //}

        //public void UpdateTextBox1(String text)
        //{
        //    //Check if invoke requied if so return - as i will be recalled in correct thread
        //    if (ControlInvokeRequired(textBox1, () => UpdateTextBox1(text))) return;
        //    textBox1.Text = ellapsed;
        //}

        //Or any control
        //public void UpdateControl(Color c, String s)
        //{
        //    //Check if invoke requied if so return - as i will be recalled in correct thread
        //    if (ControlInvokeRequired(lblStatus, () => UpdateControl(c, s))) return;
        //    lblStatus.Text = s;
        //    lblStatus.BackColor = c;
        //}




        private List<OperatorResponseData> GetOperators(string accessToken)
        {
            var operatorHttpClient = new HttpClient();
            var operatorUrl = $"{txtBaseUrl.Text}/api/v2/json/data/accommodation-operators";
            operatorHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", " " + accessToken);
            var responseOperators = operatorHttpClient.GetAsync(operatorUrl).ConfigureAwait(false).GetAwaiter().GetResult();
            if (responseOperators.StatusCode == HttpStatusCode.OK)
            {
                var responseOperatorContent = responseOperators.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                var operatorsResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<List<OperatorResponseData>>(responseOperatorContent);
                return operatorsResponse;
            }
            return new List<OperatorResponseData>();
        }

        private List<OperatorServiceTypeData> GetOperatorTypes(string accessToken)
        {
            var operatorTypeHttpClient = new HttpClient();
            var operatorTypeUrl = $"{txtBaseUrl.Text}/api/v2/json/Database/supplieroperatorservicetype";
            operatorTypeHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", " " + accessToken);
            var responseTypeOperators = operatorTypeHttpClient.GetAsync(operatorTypeUrl).ConfigureAwait(false).GetAwaiter().GetResult();
            if (responseTypeOperators.StatusCode == HttpStatusCode.OK)
            {
                var responseOperatorContent = responseTypeOperators.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                var operatorTypesResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<List<OperatorServiceTypeData>>(responseOperatorContent);
                return operatorTypesResponse;
            }
            return new List<OperatorServiceTypeData>();
        }

        private List<IdNameData> GetIslands(string accessToken)
        {
            var islandHttpClient = new HttpClient();
            var islandsUrl = $"{txtBaseUrl.Text}/api/v2/json/data/geo-locations/islands";
            islandHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", " " + accessToken);
            var responseTypeOperators = islandHttpClient.GetAsync(islandsUrl).ConfigureAwait(false).GetAwaiter().GetResult();
            if (responseTypeOperators.StatusCode == HttpStatusCode.OK)
            {
                var islandOperatorContent = responseTypeOperators.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                var islandTypesResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IdNameData>>(islandOperatorContent);
                return islandTypesResponse;
            }
            return new List<IdNameData>();
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
