<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Webtest2.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
<script   src="https://code.jquery.com/jquery-2.2.3.min.js"   integrity="sha256-a23g1Nt4dtEYOj7bR+vTu7+T8VP13humZFBJNIYoEJo="   crossorigin="anonymous"></script>
        <script src="https://apis.google.com/js/platform.js" async defer></script>
        <meta name="google-signin-client_id" content="911335501357-onv0vmc8ajqpuq4s8k4omc62jbe2toib.apps.googleusercontent.com">


<script type = "text/javascript">
   
    

function OnSuccess(response) {
    alert(response.d);
}
</script>

<script type = "text/javascript">


//    function ShowCurrentTime() {
//        $.ajax({
//            type: "POST",
//            url: "testajax.aspx/myMethod",
//            data: '{o : "objectdatastring"}', //{
//            //    iss: contact.iss,
//            //    at_hash: contact.at_hash,
//            //    sub: contact.sub,
//            //    email_verified: contact.email_verified,
//            //    azp: contact.azp,
//            //    email: contact.email,
//            //    iat: contact.iat,
//            //    exp: contact.exp,
//            //    name: contact.name,
//            //    given_name: contact.given_name,
//            //    family_name: contact.family_name,
//            //    locale: contact.locale,
//            //    alg: contact.alg,
//            //    kid: contact.kid
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: OnSuccess,
//        failure: function (response) {
//            alert(response.d)//response.d);
//        }
//    });
//}
//function OnSuccess(response) {
//    alert(response.d);
//}

function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    var id_token = googleUser.getAuthResponse().id_token;
    console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
    console.log('Name: ' + profile.getName());
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail());
    var xhr = new XMLHttpRequest();
    xhr.open('POST', 'https://www.googleapis.com/oauth2/v3/tokeninfo?id_token=' + id_token);
    xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    xhr.onload = function () {
        console.log('Signed in as: ' + xhr.responseText);
        var contact = JSON.parse(xhr.responseText);
        //var userObject= {
        //    iss: contact.iss,
        //    at_hash: contact.at_hash,
        //    sub: contact.sub,
        //    email_verified: contact.email_verified,
        //    azp: contact.azp,
        //    email: contact.email,
        //    iat: contact.iat,
        //    exp: contact.exp,
        //    name: contact.name,
        //    given_name: contact.given_name,
        //    family_name: contact.family_name,
        //    locale: contact.locale,
        //    alg: contact.alg,
        //    kid: contact.kid
        //}
       // var objectdatastring = JSON.stringify(object);
        //var obj = object.email;
        //document.getElementById("form1").innerHTML = "<br>Sign in as: " + object.sub
        console.log("contact :", contact);
        $.ajax({
            type: "POST",
            url: "login.aspx/AuthenticateUser",
            data: JSON.stringify({ email: contact.email, name: contact.name }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {
                alert(response.d);
            }
        });
    
        function OnSuccess(response) {
            console.log(response);
        if (response.d === "Invalid") {
            alert("Invalid Authentication");
        } else {
            window.location.href = "/Default.aspx";
        }
      }
    };
    xhr.send('idtoken=' + id_token);
}
</script> 
</head>

<body style = "font-family:Arial; font-size:10pt">
     <form id="form1" runat="server">
<div class="g-signin2" data-onsuccess="onSignIn"></div>
    <a href="#" onclick="signOut();">Sign out</a>
<script>
    function signOut() {
        var auth2 = gapi.auth2.getAuthInstance();
        auth2.signOut().then(function () {

            console.log('User signed out.');
        });
    }
</script>


<%--<div>
Your Name : 
<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
<input id="btnGetTime" type="button" value="Show Current Time" 
    onclick = "ShowCurrentTime()" />
</div>
    <asp:Label ID="lbltext" runat="server"></asp:Label>--%>

    </form>
</body>
</html>
