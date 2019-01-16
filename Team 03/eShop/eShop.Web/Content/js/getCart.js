$(document).ready(function () {
	loadData();
});

//Load Data function  
function loadData() {
	$.ajax({
		url: "GetCart",
		type: "GET",
		dataType: "json",
		contentType: "application/json;charset=utf-8",
		success: function (result) {
			var html = '';
			$.each(result.listProduct, function (key, item) {
				html += '<tr class="rem1">';
				html += '<td class="invert-image"><a href="/eShop/Shopping/ProductDetail/' + item.product.Id + '"><img src="../Content/images/Products/' + item.product.Image + '" alt=" " class="img-responsive"></a></td>';
				html += '<td class="invert"><div class="quantity"><div class="quantity-select">';
				html += '<div class="entry value-minus value-change" onclick="changeQuantity(' + (item.Quantity - 1) + ',' + item.product.Id + ',' + item.Price + ',' + item.CartId + ')">&nbsp;</div>';
				html += '<div class="entry value"><span class="txtQuantity">' + item.Quantity + '</span></div>';
				html += '<div class="entry value-plus value-change active" onclick="changeQuantity(' + (item.Quantity + 1) + ',' + item.product.Id + ',' + item.Price + ',' + item.CartId + ')">&nbsp;</div>';
				html += '</div></div></td>';
				html += '<td class="invert">' + item.product.Title + '</td>';
				html += '<td class="invert">$' + item.Price + '</td>';
				html += '<td class="invert"><div class="rem"><i class="fas fa-trash-alt fa-2x btnDelete" data-id="' + item.CartId + '" onclick="DeleteCartItem(' + item.CartId + ')"></i></div></td>';
				html += '</tr>';
			});
			$('#cartTBody').html(html);
			$('#cartItemCount').text(result.itemCount + '  Products');
			$('.card-text').text('$' + result.totalAmount);
			loadHeaderCart();
		},
		error: function (errormessage) {
			alert(errormessage.responseText);
		}
	});
}

function changeQuantity(quantity, productId, price, cartId) {
	if (quantity >= 1) {
		var cartList = [];
		cartList.push({
			Quantity: quantity,
			Product: {
				ID: productId
			},
			CartId: cartId,
			Price: price

		});

		$.ajax({
			url: '../Shopping/Update',
			data: { cartModel: JSON.stringify(cartList) },
			dataType: 'json',
			type: 'POST',
			success: function (res) {
				if (res.status === true) {
					loadData();
				}
			}
		});
	}
}

function DeleteCartItem(id) {
	$.ajax({
		url: '../Shopping/Delete',
		data: { id: id },
		dataType: 'json',
		type: 'POST',
		success: function (res) {
			if (res.status === true) {
				loadData();
			}
		}
	});
}