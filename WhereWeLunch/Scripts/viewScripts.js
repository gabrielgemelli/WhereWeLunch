function showLogin()
{
    document.querySelector("#liLogin").classList.remove("hide");
    document.querySelector("#liLogout").classList.add("hide");
}

function hideLogin()
{
    document.querySelector("#liLogin").classList.add("hide");
    document.querySelector("#liLogout").classList.remove("hide");
}

var webApiURL = "http://localhost:53518/api";

function AjaxGetWebAPI(url, successFunction)
{
    $.ajax({
        url: webApiURL + url,
        type: 'Get',
        success: successFunction,
        error: function (msg) { alert(msg); }
    });
}

function AjaxPostWebAPI(url, dataToPost, successFunction)
{
    $.ajax({
        url: webApiURL + url,
        type: 'POST',
        dataType: 'json',
        data: dataToPost,
        success: successFunction,
        error: function (msg) { alert(msg); }
    });
}

function UserIsLoaged(successFunction)
{
    AjaxGetWebAPI("/login/UserIsLoaged", successFunction);
}
