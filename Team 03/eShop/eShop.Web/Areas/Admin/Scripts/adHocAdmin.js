$(document).ready(function () {

});


function ClearAdHoc() {
    $('#txtAdHocQuery').val('');
}


function BuiltQuery() {
    switch ($('#slBuiltQuery').val()) {
        case 'RecordCount':
            $('#txtAdHocQuery').val('SELECT \
	                                Artist = (SELECT COUNT(Id) FROM Artist),\
                                    Cart = (SELECT COUNT(Id) FROM Cart), \
                                    CartItems = (SELECT COUNT(Id) FROM CartItem), \
                                    Error = (SELECT COUNT(Id) FROM[Error]),\
                                    [Order] = (SELECT COUNT(Id) FROM[Order]),\
                                    OrderDetail = (SELECT COUNT(Id) FROM OrderDetail),\
                                    OrderNumber = (SELECT COUNT(Id) FROM OrderNumber), \
                                    Product = (SELECT COUNT(Id) FROM Product),\
                                    Rating = (SELECT COUNT(Id) FROM Rating),\
                                    [User] = (SELECT COUNT(Id) FROM[User])');
            break;
        case 'OrderUser':
            $('#txtAdHocQuery').val('SELECT U.Username, O.OrderNumber, O.OrderDate, O.ItemCount, O.TotalPrice \
                                    FROM[User] AS U \
	                                JOIN[Order] AS O ON U.Id = O.UserId \
                                    ORDER BY O.OrderDate');
            break;
        case 'ProductArtist':
            $('#txtAdHocQuery').val('SELECT A.Name AS Artist, A.Born, P.Title AS ArtWork \
                                    FROM[Artist] AS A \
	                                JOIN[Product] AS P ON A.Id = P.ArtistId');
            break;
        case 'UpdateStatics':
            $('#txtAdHocQuery').val('UpdateStatics');
            break;
        default:
            $('#txtAdHocQuery').val('');
    }
}


function AdHocQuery() {
    var query = $('#txtAdHocQuery').val();
    if (!query || query === '') {
        alert("Query text is empty. Please insert query text!")
        return false;
    }

    $.ajax({
        url: "AdHocAdmin/AdHocQuery",
        data: { query: query },
        type: "GET",
        dataType: "json",
        success: function (result) {
            var html = '';
            if (result.Data.length > 0) {
                html += '<thead><tr>'
                for (var i = 0; i < result.Header.length; i++) {
                    html += '<th>' + result.Header[i] + '</th>'
                }
                html += '</tr></thead>'

                html += '<tbody>'
                for (var i = 0; i < result.Data.length; i++) {
                    html += '<tr>';
                    for (var j = 0; j < result.Data[i].length; j++) {
                        html += '<td>' + result.Data[i][j] + '</td>';
                    }
                    html += '</tr>';
                }
                html += '</tbody>'
            }
            else {
                html += '<tr>No result!</tr> ';
            }
            $('#adHocResult').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}