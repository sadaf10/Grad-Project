using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webtest2
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        [System.Web.Services.WebMethod]
        public static string AuthenticateUser(string email , string name)
        {
            if (email == string.Empty)
            {
                return "Invalid";
            }
            else
            {
                HttpSessionState mSession = HttpContext.Current.Session;
                mSession["email"] = email ;
                mSession["name"] = name;
                return "Valid";
            }
        }

        //[System.Web.Services.WebMethod]
        //public static string GetCurrentTime(string name)
        //{
        //    return "Hello " + name + Environment.NewLine + "The Current Time is: "
        //        + DateTime.Now.ToString();
        //}
        // List<User> UserList = new List<User>();

        // [System.Web.Services.WebMethod]
        //public List<User> Getmethod(User o)
        //{
        //    string _iss = string.Empty;
        //    string _at_hash = string.Empty;
        //    string _aud = string.Empty;
        //    int _sub = 0;
        //    bool _email_verified = false;
        //    string _azp = string.Empty;
        //    string _email = string.Empty;
        //    int _iat = 0;
        //    int _exp = 0 ;
        //    string _name = string.Empty;
        //    string _given_name = string.Empty;
        //    string _family_name = string.Empty;
        //    string _locale = string.Empty;
        //    string _alg = string.Empty;
        //    string _kid = string.Empty;
        //    List<User> UserList = new List<User>();
        //    UserList.Add(new User() { iss = _iss});
        //    UserList.Add(new User() { at_hash = _at_hash });
        //    UserList.Add(new User() { aud = _aud });
        //    UserList.Add(new User() { sub = _sub });
        //    UserList.Add(new User() { email_verified = _email_verified });
        //    UserList.Add(new User() { azp = _azp });
        //    UserList.Add(new User() { email = _email });
        //    UserList.Add(new User() { iat = _iat });
        //    UserList.Add(new User() { exp = _exp });
        //    UserList.Add(new User() { name = _name });
        //    UserList.Add(new User() { given_name = _given_name });
        //    UserList.Add(new User() { family_name = _family_name });
        //    UserList.Add(new User() { locale = _locale });
        //    UserList.Add(new User() { alg = _alg });
        //    UserList.Add(new User() { kid = _kid });

        //    foreach (User auser in UserList)
        //    {
        //        //List User = (List)auser;
        //        Console.WriteLine(auser);
        //        return UserList;
        //    }

        //UserList.
        //UserList.Add("")



        //}

        [WebMethod]
    
        public static object myMethod(object userObject)
        {
            //throw new Exception("I am here");

            //User u = new User();
            //foreach (User u in o)
            //{
            //    u.email
            return "Hello The Current Time is: "+ DateTime.Now.ToString();
            //throw new Exception("Sadaf");
            //}
        }
    }
    //string iss, string at_hash, string aud, int sub, bool email_verified, string azp, string email, int iat, int exp, string name, string given_name, string family_name, string locale, string alg, string kid)
    // return "iss" + iss + "at_hash" + at_hash + "aud" + aud + "sub " + sub + "email_verified" + email_verified + "azp" + azp + "email" + email + "iat" + iat + "exp" + exp + "name" + name + "family_name" + family_name + "locale" +locale+ "alg" + alg + "kid" + kid;
}
