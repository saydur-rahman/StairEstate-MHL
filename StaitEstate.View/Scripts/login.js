﻿$(document).ready(function () {
    login();
});
function login() {
    $(document).keypress(function (e) {
        if (e.which == 13) {
            loginMain();
        }
    });
    $("#btnSubmit").click(function () {
       
        loginMain();
    });
}
function loginMain() {
    $("#spinner").show();

    $.ajax({
        type: "POST",
        url: "/Home/CheckLogin",
        data: JSON.stringify({ username: $("#txtUsername").val(), password: $("#txtPassword").val() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (msg) {
            $("#spinner").hide();
            try {
                //localStorage.branchname = JSON.parse(msg.d).branch;
                //localStorage.branchaddress = JSON.parse(msg.d).branchaddress;
                //localStorage.branchtin = JSON.parse(msg.d).branchtin;
                //localStorage.branch_id = JSON.parse(msg.d).branch_id;
                //localStorage.username = JSON.parse(msg.d).username;
                //localStorage.companyname = JSON.parse(msg.d).companyname;
                //localStorage.full_name = JSON.parse(msg.d).full_name;
                //localStorage.userid = JSON.parse(msg.d).userid;
                //localStorage.usertypeid = JSON.parse(msg.d).usertypeid;
                //localStorage.fullname = JSON.parse(msg.d).fullname;

                var user = msg;
                JSON.stringify(msg.d);
                if (!user.isSuccess) {
                    throw "Username or password doesn't match!";
                }
                //console.log("Login success", data);
                localStorage.user = msg.d;
                
                window.location.href = "/Dashboard/Index";
            }
            catch (ex) {
                alert("Username or password doesn't match!", ex);
                $("#spinner").hide();
            }
            //if (msg.d == "ok") {
            //    $("#spinner").hide();
            //    location.replace("home.aspx");
            //}
            //else {
            //    alert("wrong password");
            //    $("#spinner").hide();
            //}
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //$("#spinner").hide();
            alert("Error: " + errorThrown);

        }
    });
}