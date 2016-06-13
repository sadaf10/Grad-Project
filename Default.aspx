<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Webtest2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="https://code.jquery.com/jquery-2.2.3.min.js" integrity="sha256-a23g1Nt4dtEYOj7bR+vTu7+T8VP13humZFBJNIYoEJo=" crossorigin="anonymous"></script>
    <script src="https://apis.google.com/js/platform.js" async defer></script>
    <meta name="google-signin-client_id" content="911335501357-onv0vmc8ajqpuq4s8k4omc62jbe2toib.apps.googleusercontent.com">


    <script type="text/javascript">



        function OnSuccess(response) {
            alert(response.d);
        }
    </script>

    <script type="text/javascript">


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
                       // window.location.href = "/Default.aspx";
                    }
                }
            };
            xhr.send('idtoken=' + id_token);
        }
    </script>
</head>
<body>





    <form id="form1" runat="server">
         <div class="g-signin2" data-onsuccess="onSignIn"></div>
        <a href="#" onclick="signOut();">Sign out</a>
        <script>
            function signOut() {
                var auth2 = gapi.auth2.getAuthInstance();
                auth2.signOut().then(function () {
                     window.location.href = "/login.aspx";
                    console.log('User signed out.');
                });
            }
        </script>
        <div>
            <fieldset>
                <legend>Recipe</legend>
                <asp:Label ID="RecipeNameLabel" runat="server">Recipe Name: </asp:Label><asp:TextBox ID="TextBoxRecipeName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorRecipeName" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Text" Display="Dynamic" ControlToValidate="TextBoxRecipeName" EnableTheming="true"></asp:RequiredFieldValidator><br />
                <br />
                <asp:Label ID="DifficultyLabel" runat="server">Difficulty: </asp:Label><asp:DropDownList ID="DropDownListDifficulty" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="-1" Selected="True">- Select -</asp:ListItem>
                    <asp:ListItem>Easy</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>
                    <asp:ListItem>Difficult</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:TextBox ID="TextBoxDifficulty" runat="server" Width="149px"></asp:TextBox>--%><asp:RequiredFieldValidator ID="RequiredFieldValidatorRecipeDifficulty" runat="server" Text="*" ForeColor="Red" ValidationGroup="Text" Display="Dynamic" ControlToValidate="DropDownListDifficulty" EnableTheming="true"></asp:RequiredFieldValidator><br />
                <br />
                <asp:Label ID="RecipeTypeLabel" runat="server">Recipe Type: </asp:Label><asp:TextBox ID="TextBoxRecipeType" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorRecipeType" runat="server" Text="*" ValidationGroup="Text" ForeColor="Red" Display="Dynamic" ControlToValidate="TextBoxRecipeType" EnableTheming="true"></asp:RequiredFieldValidator><br />
                <br />
                <asp:Label ID="CommentLabel" runat="server">Comment: </asp:Label><asp:TextBox ID="TextBoxComment" runat="server" Width="135px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorRecipeComment" runat="server" Text="*" ValidationGroup="Text" ForeColor="Red" Display="Dynamic" ControlToValidate="TextBoxComment" EnableTheming="true"></asp:RequiredFieldValidator><br />
                <br />
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <br />
                <br />
            </fieldset>
        </div>

        <div>
            <fieldset>
                <legend>Ingredientsss</legend>

                <asp:Label ID="LabelPrimaryKey" runat="server"></asp:Label>
                <asp:Label ID="QuantityLabel" runat="server">Quantity: </asp:Label><asp:TextBox ID="TextBoxQuantity" runat="server"></asp:TextBox>
                <asp:Label ID="UnitLabel" runat="server">Unit: </asp:Label><asp:TextBox ID="TextBoxUnit" runat="server"></asp:TextBox>
                <asp:Label ID="IngredientsLabel" runat="server">Ingredients: </asp:Label><asp:TextBox ID="TextBoxIngredient" runat="server"></asp:TextBox>
                <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click" />
                <asp:Label ID="LabelWarning" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:GridView ID="GridViewIngredients" runat="server" AutoGenerateColumns="false" EnableModelValidation="true" OnSelectedIndexChanged="GridViewIngredients_SelectedIndexChanged" OnRowCommand="GridViewIngredients_RowCommand" OnRowDeleting="GridViewIngredients_RowDeleting" DataKeyNames="IngredientId" SelectedIndex="0">
                    <Columns>
                        <%--<asp:BoundField DataField="RecipeID" HeaderText= "RecipeID" />--%>
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                        <asp:BoundField DataField="Ingredient" HeaderText="Ingredients" />
                        <asp:TemplateField HeaderText=" ">
                            <ItemTemplate>
                                <asp:LinkButton ID="deletebutton" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("IngredientId")  %>'></asp:LinkButton><%--OnClick="DeleteRowButton" --%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:CustomValidator ID="CustomValidatorIngredient" runat="server" Display="Dynamic" ErrorMessage="At least one ingredient must be entered" ValidationGroup="test"></asp:CustomValidator>
                <asp:Label ID="LabelwarningSubmit" runat="server" Text="" BackColor="red" Visible="false"></asp:Label>


            </fieldset>
            <asp:Label ID="labelError" runat="server" Visible="false"></asp:Label>
            <%--<asp:ValidationSummary HeaderText="Some required fields are missing denoted by *" ID="ValidationSummary1" ValidationGroup="test" runat="server"/>--%>
            <fieldset>
                <legend>Procedure</legend>
                <asp:Label ID="LabelProcedure" runat="server">Procedure: </asp:Label><asp:TextBox ID="TextBoxProcedure" runat="server"></asp:TextBox>
                <asp:Button ID="ButtonProcedureAdd" runat="server" Text="Add" OnClick="AddButtonProcedure_Click" />
                <asp:GridView ID="GridViewProcedures" runat="server" AutoGenerateColumns="false" EnableModelValidation="true" OnSelectedIndexChanged="GridViewProcedures_SelectedIndexChanged" OnRowCommand="GridViewProcedures_RowCommand" OnRowDeleting="GridViewProcedures_RowDeleting" DataKeyNames="ProcedureId" SelectedIndex="0">
                    <Columns>
                        <asp:BoundField DataField="Procedure" HeaderText="MyProcedure" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="deletebuttonProcedure" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("ProcedureId") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                <asp:CustomValidator ID="CustomValidatorProcedure" runat="server" Display="Dynamic" ErrorMessage="At least one Procedure must be entered" ValidationGroup="test"></asp:CustomValidator>


            </fieldset>


            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />

            <asp:Label runat="server" ID="lblsuccessmessage" ForeColor="Green"></asp:Label>


            <asp:Panel ID="panelError" runat="server" Visible="false">
                <div class="ErrorMessages">

                    <asp:Label runat="server" ID="lblErrorMessages"></asp:Label>

                </div>
            </asp:Panel>
        </div>
    </form>
</body>

</html>
