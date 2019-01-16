$(document).ready(function () {
    //loadUsers();
    GetPageData(1);
});

var globalCurrentPage = 1;

//function loadUsers() {
//    $.ajax({
//        url: 'UserAdmin/GetUsers',
//        type: "GET",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            var html = '';
//            $.each(result, function (key, user) {
//                html += '<tr>';
//                html += '<td style="width: 15%">' + formatDate(new Date(user.CreatedOn.match(/\d+/)[0] * 1)) + '</td>';
//                html += '<td style="width: 15%">' + user.Username + '</td>';
//                html += '<td>' + user.Email + '</td>';
//                html += '<td style="width: 10%">' + user.City + '</td>';
//                html += '<td style="width: 10%">' + user.Country + '</td>';
//                html += '<td style="width: 10px">' + user.OrderCount + '</td>';
//                html += '<td style="width: 10%; text-align:center">';
//                html += '<button id="btnUpdateUser" style="margin-right: 4px;" class="btn btn-sm btn-primary" onclick="GetUserById(' + user.Id + ')"><i class="fa fa-pencil-square-o"></i></button>';
//                html += '<button id="btnDeleteUser" style="margin-left: 4px;" class="btn btn-sm btn-danger" onclick="DeleteUser(' + user.Id + ')"><i class="fa fa-trash-o"></i></button>';
//                html += '</td>';
//                html += '</tr>';
//            });
//            $('.user-body').html(html);
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}

function formatDate(date) {
    var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec"];

    var day = date.getDate();
    var monthIndex = date.getMonth();
    var year = date.getFullYear();

    return day + ' - ' + monthNames[monthIndex] + ' - ' + year;
}

//function AddUser() {
//    var val = ValidateUser();
//    if (val == false) {
//        return false;
//    }

//    var userObj = {
//        Username: $('#txtUserName').val(),
//        FirstName: $('#txtFirstName').val(),
//        LastName: $('#txtLastName').val(),
//        Email: $('#txtEmail').val(),
//        Password: $('#txtPassword').val(),
//        City: $('#txtCity').val(),
//        Country: $('#txtCountry').val(),
//        OrderCount: parseInt($('#txtOrderCount').val()),
//        Role: parseInt($('#txtRole').val())
//    };
//    $.ajax({
//        url: "UserAdmin/AddOrUpdateUser",
//        type: 'POST',
//        dataType: "json",
//        data: { jsonUser: JSON.stringify(userObj) },
//        success: function (result) {
//            if (result) {
//                loadUsers();
//                $('#addUserModal').modal('hide');
//            }
//            else {
//                alert("Add user error!")
//            }
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}

function GetUserById(userId) {
    $('#divUserId').css('display', 'block');

    $.ajax({
        url: "UserAdmin/GetUserById",
        type: 'GET',
        dataType: "json",
        data: { userId: userId },
        success: function (result) {
            if (result) {
                $('#txtUserId').val(result.Id);
                $('#txtUserName').val(result.Username);
                $('#txtFirstName').val(result.FirstName);
                $('#txtLastName').val(result.LastName);
                $('#txtEmail').val(result.Email);
                $('#txtPassword').val(result.Password);
                $('#txtCity').val(result.City);
                $('#txtCountry').val(result.Country);
                $('#txtOrderCount').val(result.OrderCount);
                $('#txtRole').val(result.Role);
                $('#txtCreatedOn').val(formatDate(new Date(result.CreatedOn.match(/\d+/)[0] * 1)));
                $('#txtSignUpDate').val(formatDate(new Date(result.SignupDate.match(/\d+/)[0] * 1)));
                $('#txtCreatedBy').val(result.CreatedBy);

                $('#addUserModal').modal('show');
            }
            else {
                alert("Get user error!")
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function AddOrUpdateUser() {
    var res = ValidateUser();
    if (res == false) {
        return false;
    }

    var userObj = {
        Id: $('#txtUserId').val(),
        Username: $('#txtUserName').val(),
        FirstName: $('#txtFirstName').val(),
        LastName: $('#txtLastName').val(),
        Email: $('#txtEmail').val(),
        Password: $('#txtPassword').val(),
        City: $('#txtCity').val(),
        Country: $('#txtCountry').val(),
        OrderCount: parseInt($('#txtOrderCount').val()),
        Role: parseInt($('#txtRole').val()),

        CreatedOn: new Date($('#txtCreatedOn').val().replace(/\s/g, '')),
        SignupDate: new Date($('#txtSignUpDate').val().replace(/\s/g, '')),
        CreatedBy: parseInt($('#txtCreatedBy').val()),
    };
    $.ajax({
        url: "UserAdmin/AddOrUpdateUser",
        data: { jsonUser: JSON.stringify(userObj) },
        type: "POST",
        dataType: "json",
        success: function (result) {
            if (result) {
                //loadUsers();
                $('#addUserModal').modal('hide');
                $('#txtUserName').val('');
                $('#txtFirstName').val('');
                $('#txtLastName').val('');
                $('#txtEmail').val('');
                $('#txtPassword').val('');
                $('#txtCity').val('');
                $('#txtCountry').val('');
                $('#txtOrderCount').val('');
                $('#txtRole').val('');

                GetPageData(globalCurrentPage, $('#selectedId').val(), $('#slSortBy').val())
            }
            else {
                alert("Update user error!")
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for clearing the textboxes  
function ClearTextBox() {
    $('#divUserId').css('display', 'none');

    $('#txtUserId').val("");
    $('#txtUserName').val('');
    $('#txtFirstName').val('');
    $('#txtLastName').val('');
    $('#txtEmail').val('');
    $('#txtPassword').val('');
    $('#txtCity').val('');
    $('#txtCountry').val('');
    $('#txtOrderCount').val('');
    $('#txtRole').val('');

    $('#txtUserName').css('border-color', 'lightgrey');
    $('#txtFirstName').css('border-color', 'lightgrey');
    $('#txtLastName').css('border-color', 'lightgrey');
    $('#txtEmail').css('border-color', 'lightgrey');
    $('#txtPassword').css('border-color', 'lightgrey');
    $('#txtCity').css('border-color', 'lightgrey');
    $('#txtCountry').css('border-color', 'lightgrey');
    $('#txtEmail').css('border-color', 'lightgrey');
    $('#txtOrderCount').css('border-color', 'lightgrey');
    $('#txtRole').css('border-color', 'lightgrey');

    $('#divCreatedOn').css('display', 'none');
    $('#divSignupDate').css('display', 'none');
    $('#divCreatedBy').css('display', 'none');
}

//Valdidation using jquery  
function ValidateUser() {
    var isValid = true;
    if ($('#txtUserName').val().trim() == "") {
        $('#txtUserName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtUserName').css('border-color', 'lightgrey');
    }

    if ($('#txtFirstName').val().trim() == "") {
        $('#txtFirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtFirstName').css('border-color', 'lightgrey');
    }

    if ($('#txtLastName').val().trim() == "") {
        $('#txtLastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtLastName').css('border-color', 'lightgrey');
    }

    if ($('#txtEmail').val().trim() == "") {
        $('#txtEmail').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtEmail').css('border-color', 'lightgrey');
    }

    if ($('#txtPassword').val().trim() == "") {
        $('#txtPassword').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtPassword').css('border-color', 'lightgrey');
    }

    if ($('#txtCity').val().trim() == "") {
        $('#txtCity').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtCity').css('border-color', 'lightgrey');
    }

    if ($('#txtCountry').val().trim() == "") {
        $('#txtCountry').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtCountry').css('border-color', 'lightgrey');
    }

    if ($('#txtOrderCount').val().trim() == "") {
        $('#txtOrderCount').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtOrderCount').css('border-color', 'lightgrey');
    }

    if ($('#txtRole').val().trim() == "") {
        $('#txtRole').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtRole').css('border-color', 'lightgrey');
    }
    return isValid;
}


function GetPageData(pageNum, pageSize, sortBy) {
    //After every trigger remove previous data and paging
    $("#tblData").empty();
    $("#paged").empty();

    $.ajax({
        url: "UserAdmin/GetPaggedData",
        data: { pageNumber: pageNum, pageSize: pageSize, sortBy: sortBy },
        type: "GET",
        dataType: "json",
        success: function (result) {
            var html = '';
            for (var i = 0; i < result.Data.length; i++) {
                html += '<tr>';
                html += '<td style="width: 15%">' + formatDate(new Date(result.Data[i].CreatedOn.match(/\d+/)[0] * 1)) + '</td>';
                html += '<td style="width: 15%">' + result.Data[i].Username + '</td>';
                html += '<td>' + result.Data[i].Email + '</td>';
                html += '<td style="width: 10%">' + result.Data[i].City + '</td>';
                html += '<td style="width: 10%">' + result.Data[i].Country + '</td>';
                html += '<td style="width: 10px">' + result.Data[i].OrderCount + '</td>';
                html += '<td style="width: 10%; text-align:center">';
                html += '<button id="btnUpdateUser" style="margin-right: 4px;" class="btn btn-sm btn-primary" onclick="GetUserById(' + result.Data[i].Id + ')"><i class="fa fa-pencil-square-o"></i></button>';
                html += '<button id="btnDeleteUser" style="margin-left: 4px;" class="btn btn-sm btn-danger" onclick="DeleteUser(' + result.Data[i].Id + ',' + result.CurrentPage + ')"><i class="fa fa-trash-o"></i></button>';
                html += '</td>';
                html += '</tr>';
            }
            $('.user-body').html(html);

            globalCurrentPage = result.CurrentPage;

            PaggingTemplate(result.TotalPages, result.CurrentPage);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//This is paging temlpate ,you should just copy paste
function PaggingTemplate(totalPage, currentPage) {
    var template = "";
    var TotalPages = totalPage;
    var CurrentPage = currentPage;
    var PageNumberArray = Array();


    var countIncr = 1;
    for (var i = currentPage; i <= totalPage; i++) {
        PageNumberArray[0] = currentPage;
        if (totalPage != currentPage && PageNumberArray[countIncr - 1] != totalPage) {
            PageNumberArray[countIncr] = i + 1;
        }
        countIncr++;
    };
    PageNumberArray = PageNumberArray.slice(0, 5);
    var FirstPage = 1;
    var ForwardOne = 1;
    var BackwardOne = 1;

    var LastPage = totalPage;

    if (totalPage != currentPage) {
        ForwardOne = currentPage + 1;
    }

    if (currentPage > 1) {
        BackwardOne = currentPage - 1;
    }

    template = '<p style="margin-left: 8px"><strong>' + CurrentPage + " of " + TotalPages + ' pages</strong></p>';
    template = template + '<ul class="pager">' +
        '<li class="previous"><a href="#" onclick="GetPageData(' + FirstPage + ')"><i class="fa fa-fast-backward"></i>&nbsp;First</a></li>' +
        //'<li><select id="selectedId"><option value="20">20</option><option value="50">50</option><option value="100">100</option><option value="150">150</option></select> </li>' +
        '<li><a href="#" onclick="GetPageData(' + BackwardOne + ')"><i class="glyphicon glyphicon-backward"></i></a>';

    var numberingLoop = "";
    for (var i = 0; i < PageNumberArray.length; i++) {
        numberingLoop = numberingLoop + '<a class="page-number active" onclick="GetPageData(' + PageNumberArray[i] + ')" href="#">' + PageNumberArray[i] + ' &nbsp;&nbsp;</a>'
    }
    template = template + numberingLoop + '<a href="#" onclick="GetPageData(' + ForwardOne + ')" ><i class="glyphicon glyphicon-forward"></i></a></li>' +
        '<li class="next"><a href="#" onclick="GetPageData(' + LastPage + ')">Last&nbsp;<i class="fa fa-fast-forward"></i></a></li></ul>';
    $("#paged").append(template);
    //$('#selectedId').change(function () {
    //    GetPageData(1, $(this).val());
    //});
}

function SortUser() {
    GetPageData(globalCurrentPage, $('#selectedId').val(), $('#slSortBy').val())
}


function DeleteUser(userId, currentPage) {
    var ans = confirm("Are you sure you want to delete this user?");
    if (ans) {
        $.ajax({
            url: 'UserAdmin/DeleteUser',
            type: 'POST',
            data: { userId: userId },
            dataType: 'json',
            success: function (result) {
                if (result)
                    GetPageData(currentPage, $('#selectedId').val(), $('#slSortBy').val())
                //loadUsers();
                else
                    alert("Delete user error!")
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}