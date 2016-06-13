using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webtest2
{
    public partial class Webtest2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }


        public void button1Clicked(object sender, EventArgs args)
        {


            button1.Text = "Search";

            String currurl = HttpContext.Current.Request.RawUrl;
            String querystring = null;

            // Check to make sure some query string variables
            // exist and if not add some and redirect.
            int iqs = currurl.IndexOf('?');
            if (iqs == -1)
            {
                //				String redirecturl = currurl + "?key=''&q=''&sort=''&page=''";
                //				Response.Redirect(redirecturl, true);
                querystring = currurl + "?key=''&q=''&sort=''&page=''";
            }
            // If query string variables exist, put them in
            // a string.
            else if (iqs >= 0)
            {
                querystring = (iqs < currurl.Length - 1) ? currurl.Substring(iqs + 1) : String.Empty;
            }

            // Parse the query string variables into a NameValueCollection.
            NameValueCollection qscoll = HttpUtility.ParseQueryString(querystring);

            // Iterate through the collection.
            StringBuilder sb = new StringBuilder("<br />");
            foreach (String s in qscoll.AllKeys)
            {
                sb.Append(s + " - " + qscoll[s] + "<br />");

            }

            // Write the result to a label.
            //ParseOutput.Text = sb.ToString();
            string search = qscoll[1];
            string sort = qscoll[2];
            string page = qscoll[3];
            search = textSearch.Text;

            sort = textSearchTwo.Text;
            //Response.Write("Search query is: " + search + "<br>");
            //Response.Write("Sort type is: " + sort + "<br>");
            //Response.Write("Page number is: " + page + "<br>");
            // Now you have the sb so you have to 
            Uri MyUrl = new Uri("/api/search?key=dd758c64471f633f528541304ce886f0", UriKind.Relative);//"http://food2fork.com/api/search?key=dd758c64471f633f528541304ce886f0&q=" + search + "&sort=" + sort + "&page=" + page);
                                                                                                      //Response.Write("URL Port: " + MyUrl.Port + "<br>");
                                                                                                      // write the result to a label.
                                                                                                      //websiteAddress.Text = " " + Server.HtmlEncode(MyUrl.AbsoluteUri) + "<br>";
            System.Diagnostics.Process.Start(MyUrl.ToString());

            //get the json string from webpage
            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] raw = wc.DownloadData("http://food2fork.com/api/search?key=dd758c64471f633f528541304ce886f0&q= " + search);
            string webData = System.Text.Encoding.UTF8.GetString(raw);

            //Parse into a JObject
            JObject mydata = JObject.Parse(webData);

            DataTable dt = new DataTable();
            var table = new System.Data.DataTable();



            //Label2.Text = mydata.ToString();
            //Get JSon Result object into a list
            IList<JToken> recipes = mydata["recipes"].Children().ToList();//["recipes"].Children().ToList();
            StringWriter stringwriter = new StringWriter();

            //using (HtmlTextWriter writer = new HtmlTextWriter (stringwriter)){

            DataTable Mydt = new DataTable();
            Mydt.Columns.AddRange(new DataColumn[8] {
                new DataColumn("Publisher", typeof(string)),
                new DataColumn("f2f_url", typeof(string)),
                new DataColumn("title", typeof(string)),
                new DataColumn("source_url", typeof(string)),
                new DataColumn("recipe_Id", typeof(string)),
                new DataColumn("image_url", typeof(string)),
                new DataColumn("social_rank", typeof(string)),
                new DataColumn("publisher_url", typeof(string))

            });
            //serialize JSON results into .NET objects
            IList<Search> searchResults = new List<Search>();
            //Regex r = new Regex(@"(https?://[^\s]+)");
            String f2f_url;
            int counter = 1;
            string publisher, title, source_url, recipe_id, image_url, publisher_url;
            decimal social_rank;
            //IEnumerable<Search>  query = searchResults.Where(result =>result ="publisher");
            foreach (JToken result in recipes)
            {

                Search searchResult = JsonConvert.DeserializeObject<Search>(result.ToString());
                searchResults.Add(searchResult);

                counter = 1;
                publisher = String.Empty;
                f2f_url = string.Empty;
                title = String.Empty;
                source_url = String.Empty;
                recipe_id = String.Empty;
                image_url = String.Empty;
                social_rank = Decimal.Zero;
                publisher_url = String.Empty;


                publisher = searchResult.publisher;

                f2f_url = searchResult.f2f_url;
                //Uri uri = new UriBuilder(f2f_url).Uri;

                //f2f_url = r.Replace(f2f_url, "<a href=\"$1\">$1</a>");

                title = searchResult.title;
                source_url = searchResult.source_url;
                recipe_id = searchResult.recipe_id;
                image_url = searchResult.image_url;
                social_rank = searchResult.social_rank;
                publisher_url = searchResult.publisher_url;
                Mydt.Rows.Add(publisher, f2f_url, title, source_url, recipe_id, image_url, social_rank, publisher_url);

                counter++;
                //IEnumerable<Search>  query = searchResults.Where(result =>result ="publisher");

                //Response.Write (result);
                //ListBox.


            }
            GridViewAllTheList.DataSource = Mydt;
            GridViewAllTheList.DataBind();

        }
    }
}
