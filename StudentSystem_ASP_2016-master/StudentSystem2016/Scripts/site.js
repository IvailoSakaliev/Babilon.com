﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var modeSearch = 0;

function VisibleSearch(id) {
    var element;
    if (id == 1) {
        element = $("#fullVersionSearch");
    }
    else {
        element = $("#mobileVersionSearch");
    }
   
    if (modeSearch == 0) {
        element.fadeIn(200);
        modeSearch = 1;
    }
    else {
        element.fadeOut(200);
        modeSearch = 0;
    }
}

function ChangeView(id) {
    var fullURL = window.location.href;
    var last = fullURL.lastIndexOf('=');
    var differenceBetweenLastAndFullUrl = fullURL.length + 1 - last;
    var page = fullURL.substr(last + 1, differenceBetweenLastAndFullUrl);
    GetCheck(id, page);
}

function GetCheck(id, page) {

    $.ajax({
        url: '/Product/ChangeViewProducts',
        type: 'POST',
        dataType: 'json',
        data: { id: id, page: page },
        success: function (data) {
            if (data == "1") {

                var url = "../Product/ListProduct?Curentpage=" + page;
                $('.products').load(url)
            }

            else if (data == "2") {
                var url = "../Product/GaleryProduct?Curentpage=" + page;
                $('.products').load(url);
            }


        },
        error: function () {
        }
    });
}

function ChangePriceTo() {
    ViewFilterDeleter();
    var element = $("#PriceTo").val();
    var fullURL = window.location.href;
    var last = fullURL.lastIndexOf('=');
    var differenceBetweenLastAndFullUrl = fullURL.length + 1 - last;
    var page = fullURL.substr(last + 1, differenceBetweenLastAndFullUrl);
    $.ajax({
        url: '/Product/FilterPriceTo',
        type: 'POST',
        dataType: 'json',
        data: { element: element },
        success: function (data) {
            if (data == "1") {
                var url = "../Product/ListProduct?Curentpage=" + page;
                $('.products').load(url)
            }
            else if (data == "2") {
                var url = "../Product/GaleryProduct?Curentpage=" + page;
                $('.products').load(url);
            }


        },
        error: function () {
        }
    });

}

function ChangePriceFrom() {
    ViewFilterDeleter();
    var element = $("#priceOF").val();
    var fullURL = window.location.href;
    var last = fullURL.lastIndexOf('=');
    var differenceBetweenLastAndFullUrl = fullURL.length + 1 - last;
    var page = fullURL.substr(last + 1, differenceBetweenLastAndFullUrl);
    $.ajax({
        url: '/Product/FilterPriceFrom',
        type: 'POST',
        dataType: 'json',
        data: { element: element },
        success: function (data) {
            if (data == "1") {
                var url = "../Product/ListProduct?Curentpage=" + page;
                $('.products').load(url);

            }

            else if (data == "2") {
                var url = "../Product/GaleryProduct?Curentpage=" + page;
                $('.products').load(url);
            }


        },
        error: function () {
        }
    });

}

function Restore() {

    $.ajax({
        url: '/Product/RestorePage',
        type: 'POST',
        dataType: 'json',
        data: { id: 1 },
        success: function (data) {



        },
        error: function () {
        }
    });
}

function DeleteImage(id) {
    var fullURL = window.location.href;
    var last = fullURL.lastIndexOf('/');
    var differenceBetweenLastAndFullUrl = fullURL.length + 1 - last;
    var page = fullURL.substr(last + 1, differenceBetweenLastAndFullUrl);
    $.ajax({
        url: '/Admin/DeleteImage',
        type: 'POST',
        dataType: 'json',
        data: { id: id },
        success: function (data) {
            if (data == "ok") {
                window.location.href = fullURL;
            }


        },
        error: function () {
        }
    });
}

function SetOrderInSession() {
    var fullURL = window.location.href;
    var last = fullURL.lastIndexOf('/');
    var differenceBetweenLastAndFullUrl = fullURL.length + 1 - last;
    var page = fullURL.substr(last + 1, differenceBetweenLastAndFullUrl);
    var quantity = $(".quantity").val();

    $.ajax({
        url: '/Order/SaveOrderInSession',
        type: 'POST',
        dataType: 'json',
        data: { page: page, quantity: quantity },
        success: function (data) {
            if (data == "ok") {
                $(".alertBox").fadeIn(500);
                setTimeout(function () { $(".alertBox").fadeOut(500); }, 4000);
                $('.circle').css("display", "block");
            }
            else if (data == "colision") {
                $(".dangerBox").fadeIn(500);
                setTimeout(function () { $(".dangerBox").fadeOut(500); }, 4000);
            }

        },
        error: function () {
        }
    });
}

function leaveChange() {
    var quantity = parseInt($(".quantity").val());
    var substringPrice = $(".priceOfProduct").text();
    var price= parseFloat(substringPrice);
    var total = $(".total");
    var result = quantity * price;
    var resultString = result.toString();
    var positionOfDot =  resultString.indexOf(".")
    if (positionOfDot == -1)
    {
        resultString += ".00";
    }
    else
    {
        var difrentOf = resultString.length - positionOfDot;
        if (difrentOf < 3)
        {
            resultString += "0";
        }
        if (difrentOf > 3) {
            var substringPrice = resultString.substr(0,5);
            resultString = substringPrice;
        }
    } 
    total.html("Общо: " + resultString + "лв.");
}

function OpenGalery() {
    $('.galery').fadeIn(600);
    $('.navbar').fadeOut(600);
}

function CloseGalery() {
    $('.galery').fadeOut(600);
    $('.navbar').fadeIn(600);
}

$(document).bind('keyup', function (e) {
    if (e.which == 39) {
        $('.carousel').carousel('next');
    }
    else if (e.which == 37) {
        $('.carousel').carousel('prev');
    }
    else if (e.which == 27) {
        CloseGalery();
    }

});

function DeleteOrderProduct(id) {
    var fullURL = window.location.href;
    var last = fullURL.lastIndexOf('/');
    var differenceBetweenLastAndFullUrl = fullURL.length + 1 - last;
    var page = fullURL.substr(last + 1, differenceBetweenLastAndFullUrl);
    $.ajax({
        url: '/Order/DeleteOrderProduct',
        type: 'POST',
        dataType: 'json',
        data: { id: id },
        success: function (data) {
            if (data == "ok") {
                window.location.href = fullURL;
            }


        },
        error: function () {
        }
    });
}

function ChangeQuantityOfProduct(id) {
    var element = $(".quantity").val();
    var fullURL = window.location.href;
    $.ajax({
        url: '/Order/ChangeQuantityOfProduct',
        type: 'POST',
        dataType: 'json',
        data: { id: id, element: element },
        success: function (data) {
            if (data == "ok") {
                window.location.href = fullURL;
            }


        },
        error: function () {
        }
    });
}

function ProductCategory(id) {
    ViewFilterDeleter();
    var fullURL = window.location.href;
    var last = fullURL.lastIndexOf('=');
    var differenceBetweenLastAndFullUrl = fullURL.length + 1 - last;
    var page = fullURL.substr(last + 1, differenceBetweenLastAndFullUrl);
    $.ajax({
        url: '/Product/ChangBaseTypeValue',
        type: 'POST',
        dataType: 'json',
        data: { id: id },
        success: function (data) {
            if (data == "1") {
                $(".delteFilter").css("display", "block"); $(".delteFilter").css("display", "block");
                var url = "../Product/ListProduct?Curentpage=" + page;
                $('.products').load(url);

            }
            else if (data == "2") {
                var url = "../Product/GaleryProduct?Curentpage=" + page;
                $('.products').load(url);
            }



        },
        error: function () {
        }
    });
}

function ChangeType(id) {
    $.ajax({
        url: '/Product/ChangeType',
        type: 'POST',
        dataType: 'json',
        data: { id: id },
        success: function (data) {
            if (data == "ok") {
                window.location.href = "../../Product/Index?Curentpage=1";
            }


        },
        error: function () {
        }
    });
}


$(document).ready(function () {
    var sessionValue = $('.session').text().trim();
    if (sessionValue === null || sessionValue === "") {
        $('.circle').css("display", "none");
    }
    else {
        $('.circle').css("display", "block")
    }
});

function ChangeEmailUser() {
    $.ajax({
        url: '/User/ChangeEmailUser',
        type: 'POST',
        dataType: 'json',
        data: {},
        success: function (data) {
            if (data == "ok") {
                $(".userinfo").load("../User/ChangeEmail");
            }


        },
        error: function () {
        }
    });
}

function ChangePasswordUser() {
    $.ajax({
        url: '/User/ChangePasswordlUser',
        type: 'POST',
        dataType: 'json',
        data: {},
        success: function (data) {
            if (data == "ok") {
                $(".userinfo").load("../User/ChangePassword");
            }


        },
        error: function () {
        }
    });
}

function AddNewEmail() {
    var email = $("#email").val();
    $.ajax({
        url: '/User/ChangeEmail',
        type: 'POST',
        dataType: 'json',
        data: { email, email },
        success: function (data) {
            if (data == "ok") {
                $(".alertBox").html('<img width="20px" src="../../images/ok.png" alt="Alternate Text" />Email was successful change!');
                $(".alertBox").fadeIn(500);
                setTimeout(function () { $(".alertBox").fadeOut(500); }, 4000);
                $("#email").val("");
            }


        },
        error: function () {
        }
    });
}

function AddNewPassword() {
    var pass = $("#pass").val();
    var cpass = $("#cpass").val();
    if (pass === cpass) {
        $.ajax({
            url: '/User/ChangePassword',
            type: 'POST',
            dataType: 'json',
            data: { password: pass },
            success: function (data) {
                if (data == "ok") {
                    $(".alertBox").html('<img width="20px" src="../../images/ok.png" alt="Alternate Text" />Password was successful change!');
                    $(".alertBox").fadeIn(500);
                    setTimeout(function () { $(".alertBox").fadeOut(500); }, 4000);
                    $("#pass").val("");
                    $("#cpass").val("")
                }


            },
            error: function () {
            }
        });
    }
    else {
        $(".dangerBox").html('Passwords is not equal!');
        $(".dangerBox").fadeIn(500);
        setTimeout(function () { $(".dangerBox").fadeOut(500); }, 4000);
    }
}

function ChangeDetails() {
    $.ajax({
        url: '/User/GetInfoForUser',
        type: 'POST',
        dataType: 'json',
        data: {},
        success: function (data) {
            if (data != null) {
                $(".userinfo").load("../User/ChangeDetails");
            }


        },
        error: function () {
        }
    });
}

// function ChangeUserDetails() {
//     var image = $("#file").val();
//         $.ajax({
//                 url: '/User/ChangeDetailsForUser',
//                 type: 'POST',
//                 dataType: 'json',
//                 data: $("#userInformation").serialize(),
//                 success: function (data) {
//                     if (data != null) {

//                     }


//                 },
//                 error: function () {
//                 }
//             });
// }

function ChangeSortOfProduct() {
    
    var fullURL = window.location.href;
    var last = fullURL.lastIndexOf('=');
    var differenceBetweenLastAndFullUrl = fullURL.length + 1 - last;
    var page = fullURL.substr(last + 1, differenceBetweenLastAndFullUrl);
    var id = $("#sortlist").val();
    $.ajax({
        url: '/Product/ChangeSortOfProduct',
        type: 'POST',
        dataType: 'json',
        data: { id: id },
        success: function (data) {
            if (data == "1") {
                var url = "../Product/ListProduct?Curentpage=" + page;
                $('.products').load(url)
            }
            else if (data == "2") {
                var url = "../Product/GaleryProduct?Curentpage=" + page;
                $('.products').load(url);
            }


        },
        error: function () {
        }
    });
}

// function AddID() {
//     $(".informarionForUserAndPRoduct").attr('id','slide');
// }
function showDetailsForOrder(id) {
    var elements = $(".addID").children(".informarionForUserAndPRoduct");
    var orders = $(".addID").children(".orderInformation");
    var oneElement = elements.get(id);
    var order = orders.get(id);
    var hiddenElementIValue = $("#mode").text();
    if (hiddenElementIValue == 0) {
        oneElement.id = "slide";
        order.id = "changeColor"
        $("#slide").slideDown(400);
        $("#mode").html("1");
    }
    else {

        $("#slide").slideUp(400);
        oneElement.id = "";
        order.id = ""
        $("#mode").html("0");
    }

}

function ChangeOrderState(id) {
    $.ajax({
        url: '/Order/ChangeStatus',
        type: 'POST',
        dataType: 'json',
        data: { id: id },
        success: function (data) {
            if (data == "ok") {
                $(".alertBox").html('<img width="20px" src="../../images/ok.png" alt="Alternate Text" />Status was change successful! ');
                $(".alertBox").fadeIn(500);
                setTimeout(function () { $(".alertBox").fadeOut(500); }, 4000);
                $("#changeColor").css("background-color", "yellow")
                $("#changeColor").css("color", "black")
            }


        },
        error: function () {
            $(".dangerBox").html("Order can't change");
            $(".dangerBox").fadeIn(500);
            setTimeout(function () { $(".dangerBox").fadeOut(500); }, 4000);
        }
    });


}
function CloseOrder(id) {
    $.ajax({
        url: '/Order/CloseOrder',
        type: 'POST',
        dataType: 'json',
        data: { id: id },
        success: function (data) {
            if (data == "ok") {
                $(".alertBox").html('<img width="20px" src="../../images/ok.png" alt="Alternate Text" />Status was close successful! ');
                $(".alertBox").fadeIn(500);
                setTimeout(function () { $(".alertBox").fadeOut(500); }, 4000);
                $("#changeColor").css("background-color", "red")
            }


        },
        error: function () {
            $(".dangerBox").html("Order can't close");
            $(".dangerBox").fadeIn(500);
            setTimeout(function () { $(".dangerBox").fadeOut(500); }, 4000);
        }
    });
}



function AboardOrder(id) {
    $.ajax({
        url: '/Order/AboartOrder',
        type: 'POST',
        dataType: 'json',
        data: { id: id },
        success: function (data) {
            if (data == "ok") {
                var url = "../User/DetailsUserOrders";
                $('.orderDetailsUser').load(url)
            }


        },
        error: function () {
           
        }
    });


}

function ChangeStatusColor(id) {
    alert(id);
}
function GetDetailsForEmail(id) {
    $.ajax({
        url: '/Contact/ChangeEmailInformation',
        type: 'POST',
        dataType: 'json',
        data: { id: id },
        success: function (data) {
            $("#from").text(data.Email);
            $("#subject").text(data.Name);
            $("#message").val(data.Message);
            $("#date").text(data.Date);


        },
        error: function () {

        }
    });
}
function DeleteEmail(id) {
    var fullURL = window.location.href;
    $.ajax({
        url: '/Contact/DeleteEmail',
        type: 'POST',
        dataType: 'json',
        data: { id: id },
        success: function (data) {
            window.location.href = fullURL;
        },
        error: function () {
            $(".dangerBox").html("Order can't close");
            $(".dangerBox").fadeIn(500);
            setTimeout(function () { $(".dangerBox").fadeOut(500); }, 4000);
        }
    });
}

function GetOrdersByOrderNumber() {
    var filterValue = $("#orderNum").val();
    $.ajax({
        url: '/Order/OrderFilter',
        type: 'POST',
        dataType: 'json',
        data: { filterValue: filterValue },
        success: function (data) {
            var fullURL = window.location.href;
            var last = fullURL.lastIndexOf('=');
            var differenceBetweenLastAndFullUrl = fullURL.length + 1 - last;
            var page = fullURL.substr(last + 1, differenceBetweenLastAndFullUrl);
            var url = "../Order/ListOrders?Curentpage=" + page;
            $('.listOrder').load(url)
        },
        error: function () {

        }
    });
}
function GetOrdersByOrderDate() {
    var filterValue = $("#orderDate").val();
    $.ajax({
        url: '/Order/DateFilter',
        type: 'POST',
        dataType: 'json',
        data: { filterValue: filterValue },
        success: function (data) {
            var fullURL = window.location.href;
            var last = fullURL.lastIndexOf('=');
            var differenceBetweenLastAndFullUrl = fullURL.length + 1 - last;
            var page = fullURL.substr(last + 1, differenceBetweenLastAndFullUrl);
            var url = "../Order/ListOrders?Curentpage=" + page;
            $('.listOrder').load(url)
        },
        error: function () {

        }
    });
}


function ChangeCookieVAlue() {
    $.ajax({
        url: '/Home/CookieAcsept',
        type: 'POST',
        dataType: 'json',
        data: { id: 1 },
        success: function (data) {
            $(".cookieBody").css("display", "none");
        },
        error: function () {

        }
    });
}

function RestoreOrderFilter() {
    $.ajax({
        url: '/Order/Restore',
        type: 'POST',
        dataType: 'json',
        data: { id: 1 },
        success: function (data) {
            var url = "../Order/ListOrders?Curentpage=1";
            $('.listOrder').load(url)
        },
        error: function () {

        }
    });
}

function ChangeFilterOfProduct(id) {
    var element;

    switch (id) {
        case 1: element = $("#code").val(); break;
        case 2: element = $("#title").val(); break;
        case 3: element = $("#date").val(); break;
        case 4: element = $("#type").val(); break;
        case 5: element = $("#baseType").val(); break;
    }

    $.ajax({
        url: '/Admin/FilterProduct',
        type: 'POST',
        dataType: 'json',
        data: { id: id, element: element },
        success: function (data) {
            var fullURL = window.location.href;
            var last = fullURL.lastIndexOf('=');
            var differenceBetweenLastAndFullUrl = fullURL.length + 1 - last;
            var page = fullURL.substr(last + 1, differenceBetweenLastAndFullUrl);
            var url = "../Admin/ListProducts?Curentpage=" + page;
            $('.ProductListItem').load(url)
        },
        error: function () {

        }
    });
}

function ChangeTopProduct(id, mode) {
    $.ajax({
        url: '/Admin/ChangetopProduct',
        type: 'POST',
        dataType: 'json',
        data: { id: id, mode: mode },
        success: function (data) {
            if (data == "ok") {
                alert("success change top product");
            }
            else {
                alert("Top product have be 4");
            }
        },
        error: function () {

        }
    });
}

function RestoreAdminProduct() {

    $.ajax({
        url: '/Admin/Restore',
        type: 'POST',
        dataType: 'json',
        data: { id: 1 },
        success: function (data) {



        },
        error: function () {
        }
    });
}

function RestoreFilter() {
    var fullURL = window.location.href;
    var last = fullURL.lastIndexOf('=');
    var differenceBetweenLastAndFullUrl = fullURL.length + 1 - last;
    var page = fullURL.substr(last + 1, differenceBetweenLastAndFullUrl);
    $.ajax({
        url: '/Product/RestoreFilter',
        type: 'POST',
        dataType: 'json',
        data: {},
        success: function (data) {
            if (data == "1") {
                $("#PriceTo").val("");
                $("#priceOF").val("");
                $(".delteFilter").slideUp(200);
                $('.singleFilter input').prop('checked', false);

                var url = "../Product/ListProduct?Curentpage=" + page;
                $('.products').load(url)
            }
            else if (data == "2") {
                $("#PriceTo").val("");
                $("#priceOF").val("");
                $(".delteFilter").slideUp(200);
                $('.singleFilter input').prop('checked', false);
                var url = "../Product/GaleryProduct?Curentpage=" + page;
                $('.products').load(url);
            }


        },
        error: function () {
        }
    });
}
function ViewFilterDeleter() {
    $(".delteFilter").slideDown(500);
}

function ChangePageAdmin(id) {
    var fullURL = window.location.href;
    var last = fullURL.lastIndexOf('=');
    var differenceBetweenLastAndFullUrl = fullURL.length + 1 - last;
    var page = fullURL.substr(last + 1, differenceBetweenLastAndFullUrl);
    $.ajax({
        url: '/Admin/ListProducts?Curentpage = '+page ,
        type: 'GET',
        dataType: 'json',
        data: {},
        success: function (data) { 
                var url = "../Product/ListProduct?Curentpage=" + page;
                $('.ProductListItem').load(url)
            
        },
        error: function () {
        }
    });
}

function GoToProduct(id) {
    window.location.href = "../Order/Details/"+id;
}

$(document).ready(function () {
    $(".soc").hover(function () {
        $(this).removeClass("socialOut");
        $(this).addClass("social");
        $(this).css("opacity", "0");

    });
    $(".soc").mouseleave(function () {
        $(this).addClass("socialOut");
        $(this).removeClass("social");
        $(this).css("opacity", "1");
    });
});


var menuCount = 0;
var subMEnuCountGames = 0;
var subMEnuCountEdu = 0;

//  mobile version  menu 
 function SlideDownMainMenu()
 {
    if (menuCount == 0) {
        $(".sub_menu_mobile").slideDown(400);
        menuCount = 1;
    }
    else
    {
        $(".sub_menu_mobile").slideUp(400);
        menuCount = 0;
    }
 }

function SlideDownGames()
{
    if (subMEnuCountGames == 0) {
        $("#first").slideDown(400);
        subMEnuCountGames = 1;
    }
    else
    {
        $("#first").slideUp(400);
        subMEnuCountGames = 0;
    }
} 
function SlideDownEdu()
{
     if (subMEnuCountEdu == 0) {
        $("#second").slideDown(400);
        subMEnuCountEdu = 1;
    }
    else
    {
        $("#second").slideUp(400);
        subMEnuCountEdu = 0;
    }
}


