$(document).ready(function () {
	loadHeaderCart();
});

//Load Data function  
function loadHeaderCart() {
	$.ajax({
		type: "GET",
		url: "/eShop/Shopping/GetHeaderCart",	
		dataType: "json",
		contentType: "application/json;charset=utf-8",
		success: function (itemCount) {
			var html = '<span class="CartIcon fas fa-cart-arrow-down" style="width:100px;">Cart (' + itemCount + ')</span>';
			$('.top_toys_cart').html(html);
		},
		error: function (errormessage) {
			alert(errormessage.responseText);
		}
	});
}