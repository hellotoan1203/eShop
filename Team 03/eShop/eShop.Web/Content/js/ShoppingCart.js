$('#btnAddToCart').off('click').on('click', function () {
	$.ajax({
		url: '../../shopping/addtocart',
		data: { productId: $('#ddlQuantity').data('productid'), quantity: $('#ddlQuantity').val() },
		dataType: 'json',
		type: 'POST',
		success: function (res) {
			if (res.status === "Successed") {
				bootbox.alert({
					title: "Success",
					message: "<i class='fas fa-check-circle' style='color:green'></i> Added 1 item to your cart",
					callback: function () {
						loadHeaderCart();
					}
				});
			}
			else if (res.status === "NoProduct") {
				bootbox.alert("Not Enough");
			}
		}
	});
});

$('#btnContinue').off('click').on('click', function () {
	window.location.href = "/eshop/product";
});

$('#btnCheckOut').off('click').on('click', function () {
	$.ajax({
		type: "GET",
		url: "../Shopping/CheckLoginBeforeCheckOut",
		dataType: "json",
		contentType: "application/json;charset=utf-8",
		success: function (result) {
			if (result === "Success") {
				window.location.href = "/eshop/shopping/checkout";
			}
			else if (result === "LoginRequired")
			{
				bootbox.alert("<b style='color:red'>Login Required</b>");
			}
			else if (result === "ProductRequired") {
				bootbox.alert("<b style='color:red'>No Product in your Cart</b>");
			}
		},
		error: function (errormessage) {
			alert(errormessage.responseText);
		}
	});
	
});