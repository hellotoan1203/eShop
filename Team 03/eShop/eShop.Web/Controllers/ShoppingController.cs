using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eShop.Service;
using eShop.Service.Services;
using eShop.Model.Models;
using eShop.Web.Models;
using System.Web.Script.Serialization;
using System.Web.Security;
using eShop.Web.Attributes;

namespace eShop.Web.Controllers
{
    public class ShoppingController : Controller
    {
        private const string CartSession = "CartSession";

        IProductService productService;
        IArtistService artistService;
        ICartService cartService;
        ICartItemService cartItemService;
        IOrderService orderService;
        IOrderDetailService orderDetailService;
        IOrderNumberService orderNumberService;

        public ShoppingController(IProductService productService, IArtistService artistService, ICartService cartService, ICartItemService cartItemService, IOrderService orderService, IOrderDetailService orderDetailService, IOrderNumberService orderNumberService)
        {
            this.productService = productService;
            this.artistService = artistService;
            this.cartService = cartService;
            this.cartItemService = cartItemService;
            this.orderService = orderService;
            this.orderDetailService = orderDetailService;
            this.orderNumberService = orderNumberService;
        }

        #region Using Cookies

        public ActionResult Cart()
        {
            return View();
        }

        public JsonResult GetCart()
        {
            string cookieValue = GetCartCookies();
            if (!string.IsNullOrEmpty(cookieValue))
            {
                var cart = cartService.GetMulti(x => x.Cookie == cookieValue).FirstOrDefault();

                var list = new List<ShoppingCart>();
                if (cart != null)
                {
                    var cartItem = cartItemService.GetMulti(x => x.CartId == cart.Id);
                    foreach (var item in cartItem)
                    {
                        var product = productService.GetSingleById(item.ProductId);

                        list.Add(new ShoppingCart
                        {
                            product = product,
                            Quantity = item.Quantity,
                            Price = product.Price * item.Quantity,
                            CartId = item.Id
                        });
                    }
                }
                var totalPrice = list.Sum(s => s.product.Price * s.Quantity);
                return Json(new
                {
                    listProduct = list,
                    totalAmount = totalPrice,
                    itemCount = list.Count
                }, JsonRequestBehavior.AllowGet);
            }

            return null;

        }

        public JsonResult AddToCart(int productId, int quantity)
        {
            var cookieValue = GetCartCookies();
            int cartId = 0;
            bool isCartItemExist = false;
            Product product = productService.GetSingleById(productId);

            //var productRemaining = product.QuantityRemaining - quantity;
            //if (productRemaining < 0)
            //{
            //    return Json(new
            //    {
            //        status = "NoProduct"
            //    });
            //}
            //Kiem tra gio hang da ton tai?
            var cart = cartService.GetMulti(x => x.Cookie == cookieValue).FirstOrDefault();
            if (cart != null)
            {
                //Kiem tra cart item da ton tai?
                var cartItem = cartItemService.GetMulti(x => x.CartId == cart.Id && x.ProductId == productId).FirstOrDefault();
                if (cartItem != null)
                {
                    //productRemaining = productRemaining - cartItem.Quantity;
                    //if (productRemaining < 0)
                    //{
                    //    return Json(new
                    //    {
                    //        status = "NoProduct"
                    //    });
                    //}
                    var newQuantity = cartItem.Quantity + quantity;
                    cartItem.Quantity = newQuantity;
                    cartItem.Price = product.Price * newQuantity;

                    cartItemService.Update(cartItem);
                    isCartItemExist = true;
                }
                else
                {
                    cart.ItemCount = cart.ItemCount + 1;
                    cartService.Update(cart);
                    cartId = cart.Id;
                }

            }
            else
            {
                Cart newCart = new Cart
                {
                    Cookie = cookieValue,
                    CartDate = DateTime.Now,
                    ItemCount = 1,
                    CreatedOn = DateTime.Now,
                    CreatedBy = 1,
                    ChangedOn = DateTime.Now,
                    ChangedBy = 1
                };
                cartService.Add(newCart);

                cartId = newCart.Id;
            }

            if (!isCartItemExist)
            {
                cartItemService.Add(new CartItem
                {
                    CartId = cartId,
                    ProductId = product.Id,
                    Price = product.Price * quantity,
                    Quantity = quantity,
                    CreatedOn = DateTime.Now,
                    CreatedBy = 1,
                    ChangedOn = DateTime.Now,
                    ChangedBy = 1
                });
            }

            return Json(new
            {
                status = "Successed"
            });
        }

        [HttpPost]
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<ShoppingCart>>(cartModel);

            foreach (var item in jsonCart)
            {
                //Check Quantity Remain
                Product product = productService.GetSingleById(item.product.Id);
                //var productRemaining = product.QuantityRemaining - item.Quantity;
                //if (productRemaining < 0)
                //{
                //    return Json(new
                //    {
                //        status = false
                //    });
                //}
                //else

                //Update Cart
                var cartItem = cartItemService.GetSingleById(item.CartId);
                var quantityChange = cartItem.Quantity - item.Quantity;
                cartItem.Quantity = item.Quantity;
                cartItem.Price = product.Price * item.Quantity;
                cartItemService.Update(cartItem);
                return Json(new
                {
                    status = true
                });

            }
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var cartItem = cartItemService.GetMulti(x => x.Id == id).FirstOrDefault();
            cartItemService.Delete(id);

            var cart = cartService.GetSingleById(cartItem.CartId);
            cart.ItemCount = cart.ItemCount - 1;
            cartService.Update(cart);

            return Json(new
            {
                status = true
            });
        }

        public ActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckOut(string status)
        {
            var cookieValue = GetCartCookies();
            var currentUser = UserHelper.GetCurrentUser();

            double totalPrice = 0;
            List<string> productImage = new List<string>();
            if (currentUser != null)
            {
                var userId = Convert.ToInt32(currentUser.Id);
                var cart = cartService.GetMulti(x => x.Cookie == cookieValue).FirstOrDefault();
                if (cart != null)
                {
                    var cartItem = cartItemService.GetMulti(s => s.CartId == cart.Id);
                    if (cartItem.Any())
                    {
                        totalPrice = cartItem.Sum(s => s.Price);
                        var itemCount = cart.ItemCount;

                        int newOrderNumber = 1001;
                        var orderNumber = orderNumberService.GetAll().OrderByDescending(x => x.Id).FirstOrDefault();

                        if (orderNumber != null)
                        {
                            newOrderNumber = orderNumber.Number + 1;
                        }
                        orderNumberService.Add(new OrderNumber
                        {
                            Number = newOrderNumber,
                            CreatedBy = 1,
                            CreatedOn = DateTime.Now,
                            ChangedBy = 1,
                            ChangedOn = DateTime.Now
                        });

                        //CREATE NEW ORDER
                        Order order = new Order
                        {
                            UserId = userId,
                            OrderDate = DateTime.Now,
                            TotalPrice = totalPrice,
                            OrderNumber = newOrderNumber,
                            ItemCount = itemCount,
                            CreatedOn = DateTime.Now,
                            CreatedBy = userId,
                            ChangedOn = DateTime.Now,
                            ChangedBy = userId
                        };

                        orderService.Add(order);
                        int orderId = order.Id;

                        //CREATE NEW ORDER DETAIL
                        foreach (var item in cartItem.ToList())
                        {
                            orderDetailService.Add(new OrderDetail
                            {
                                OrderId = orderId,
                                ProductId = item.ProductId,
                                Price = item.Price,
                                Quantity = item.Quantity,
                                CreatedOn = DateTime.Now,
                                CreatedBy = userId,
                                ChangedOn = DateTime.Now,
                                ChangedBy = userId
                            });

                            //Update Product
                            Product product = productService.GetSingleById(item.ProductId);
                            product.QuantitySold = product.QuantitySold + item.Quantity;
                            productService.Update(product);

                            productImage.Add(product.Image);

                            //DELETE CART ITEM
                            cartItemService.Delete(item.Id);
                        }

                        //DELETE CART
                        cartService.Delete(cart.Id);
                    }
                }
            }
            ViewBag.Image = productImage;
            ViewBag.TotalPrice = totalPrice;
            return View("~/Views/Shopping/Confirmation.cshtml");
        }

        public JsonResult GetHeaderCart()
        {
            string cookieValue = GetCartCookies();
            int itemCount = 0;
            if (!string.IsNullOrEmpty(cookieValue))
            {
                var cart = cartService.GetMulti(x => x.Cookie == cookieValue).FirstOrDefault();

                if (cart != null)
                {
                    itemCount = cart.ItemCount;
                }
            }

            return Json(itemCount, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Using Database
        // GET: ShoppingCart
        //public ActionResult Cart()
        //{
        //    var cart = cartService.GetMulti(x => x.CreatedBy == 1).FirstOrDefault();

        //    var list = new List<ShoppingCart>();
        //    if (cart != null)
        //    {
        //        var cartItem = cartItemService.GetMulti(x => x.CartId == cart.Id);
        //        foreach (var item in cartItem)
        //        {
        //            var product = productService.GetSingleById(item.ProductId);
        //            list.Add(new ShoppingCart
        //            {
        //                product = product,
        //                Quantity = item.Quantity,
        //                Price = product.Price,
        //                CartId = item.Id
        //            });
        //        }
        //    }
        //    ViewBag.TotalPrice = list.Sum(s => s.product.Price * s.Quantity);
        //    return View(list);
        //}

        //public ActionResult Cart()
        //{
        //    return View();
        //}

        //public JsonResult GetCart()
        //{
        //    var currentUser = Membership.GetUser();
        //    if (currentUser != null)
        //    {
        //        var userId = Convert.ToInt32(currentUser.ProviderUserKey);
        //        var cart = cartService.GetMulti(x => x.CreatedBy == userId).FirstOrDefault();

        //        var list = new List<ShoppingCart>();
        //        if (cart != null)
        //        {
        //            var cartItem = cartItemService.GetMulti(x => x.CartId == cart.Id);
        //            foreach (var item in cartItem)
        //            {
        //                var product = productService.GetSingleById(item.ProductId);

        //                list.Add(new ShoppingCart
        //                {
        //                    product = product,
        //                    Quantity = item.Quantity,
        //                    Price = product.Price * item.Quantity,
        //                    CartId = item.Id
        //                });
        //            }
        //        }
        //        var totalPrice = list.Sum(s => s.product.Price * s.Quantity);
        //        return Json(new
        //        {
        //            listProduct = list,
        //            totalAmount = totalPrice,
        //            itemCount = list.Count
        //        }, JsonRequestBehavior.AllowGet);
        //    }

        //    return null;

        //}

        //public JsonResult AddToCart(int productId, int quantity)
        //{
        //    var currentUser = Membership.GetUser();
        //    int cartId = 0;
        //    bool isCartItemExist = false;
        //    Product product = productService.GetSingleById(productId);

        //    if (currentUser == null)
        //    {
        //        return Json(new
        //        {
        //            status = "NotLogin"
        //        });
        //    }
        //    var productRemaining = product.QuantityRemaining - quantity;
        //    if (productRemaining < 0)
        //    {
        //        return Json(new
        //        {
        //            status = "NoProduct"
        //        });
        //    }
        //    //Kiem tra gio hang da ton tai?
        //    var userId = Convert.ToInt32(currentUser.ProviderUserKey);
        //    var cart = cartService.GetMulti(x => x.CreatedBy == userId).FirstOrDefault();
        //    if (cart != null)
        //    {
        //        //Kiem tra cart item da ton tai?
        //        var cartItem = cartItemService.GetMulti(x => x.CartId == cart.Id && x.ProductId == productId).FirstOrDefault();
        //        if (cartItem != null)
        //        {
        //            productRemaining = productRemaining - cartItem.Quantity;
        //            if (productRemaining < 0)
        //            {
        //                return Json(new
        //                {
        //                    status = "NoProduct"
        //                });
        //            }
        //            var newQuantity = cartItem.Quantity + quantity;
        //            cartItem.Quantity = newQuantity;
        //            cartItem.Price = product.Price * newQuantity;

        //            cartItemService.Update(cartItem);
        //            isCartItemExist = true;
        //        }
        //        else
        //        {
        //            cart.ItemCount = cart.ItemCount + 1;
        //            cartService.Update(cart);
        //            cartId = cart.Id;
        //        }

        //    }
        //    else
        //    {
        //        Cart newCart = new Cart
        //        {
        //            Cookie = "No",
        //            CartDate = DateTime.Now,
        //            ItemCount = 1,
        //            CreatedOn = DateTime.Now,
        //            CreatedBy = userId,
        //            ChangedOn = DateTime.Now,
        //            ChangedBy = userId
        //        };
        //        cartService.Add(newCart);

        //        cartId = newCart.Id;
        //    }

        //    if (!isCartItemExist)
        //    {
        //        cartItemService.Add(new CartItem
        //        {
        //            CartId = cartId,
        //            ProductId = product.Id,
        //            Price = product.Price * quantity,
        //            Quantity = quantity,
        //            CreatedOn = DateTime.Now,
        //            CreatedBy = userId,
        //            ChangedOn = DateTime.Now,
        //            ChangedBy = userId
        //        });
        //    }

        //    return Json(new
        //    {
        //        status = "Successed"
        //    });
        //}

        //public JsonResult Update(string cartModel)
        //{
        //    var jsonCart = new JavaScriptSerializer().Deserialize<List<ShoppingCart>>(cartModel);

        //    foreach (var item in jsonCart)
        //    {
        //        Product product = productService.GetSingleById(item.product.Id);
        //        var productRemaining = product.QuantityRemaining - item.Quantity;
        //        if (productRemaining < 0)
        //        {
        //            return Json(new
        //            {
        //                status = false
        //            });
        //        }
        //        else
        //        {
        //            var cartItem = cartItemService.GetSingleById(item.CartId);
        //            var quantityChange = cartItem.Quantity - item.Quantity;
        //            cartItem.Quantity = item.Quantity;
        //            cartItem.Price = item.Price * item.Quantity;
        //            cartItemService.Update(cartItem);
        //            return Json(new
        //            {
        //                status = true
        //            });
        //        }

        //    }
        //    return Json(new
        //    {
        //        status = true
        //    });
        //}

        //public JsonResult Delete(int id)
        //{
        //    var cartItem = cartItemService.GetMulti(x => x.Id == id).FirstOrDefault();
        //    cartItemService.Delete(id);

        //    var cart = cartService.GetSingleById(cartItem.CartId);
        //    cart.ItemCount = cart.ItemCount - 1;
        //    cartService.Update(cart);

        //    return Json(new
        //    {
        //        status = true
        //    });
        //}

        //public ActionResult CheckOut()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CheckOut(string status)
        //{
        //    var currentUser = Membership.GetUser();
        //    if (currentUser != null)
        //    {
        //        var userId = Convert.ToInt32(currentUser.ProviderUserKey);
        //        var cart = cartService.GetMulti(x => x.CreatedBy == userId).FirstOrDefault();
        //        if (cart != null)
        //        {
        //            var cartItem = cartItemService.GetMulti(s => s.CartId == cart.Id);
        //            if (cartItem.Any())
        //            {
        //                var totalPrice = cartItem.Sum(s => s.Price);
        //                var itemCount = cart.ItemCount;

        //                //CREATE NEW ORDER
        //                Order order = new Order
        //                {
        //                    UserId = userId,
        //                    OrderDate = DateTime.Now,
        //                    TotalPrice = totalPrice,
        //                    OrderNumber = 1003,
        //                    ItemCount = itemCount,
        //                    CreatedOn = DateTime.Now,
        //                    CreatedBy = userId,
        //                    ChangedOn = DateTime.Now,
        //                    ChangedBy = userId
        //                };

        //                orderService.Add(order);
        //                int orderId = order.Id;

        //                //CREATE NEW ORDER DETAIL
        //                foreach (var item in cartItem.ToList())
        //                {
        //                    orderDetailService.Add(new OrderDetail
        //                    {
        //                        OrderId = orderId,
        //                        ProductId = item.ProductId,
        //                        Price = item.Price,
        //                        Quantity = item.Quantity,
        //                        CreatedOn = DateTime.Now,
        //                        CreatedBy = userId,
        //                        ChangedOn = DateTime.Now,
        //                        ChangedBy = userId
        //                    });

        //                    //Update Product
        //                    Product product = productService.GetSingleById(item.ProductId);
        //                    product.QuantitySold = product.QuantitySold + item.Quantity;
        //                    productService.Update(product);

        //                    //DELETE CART ITEM
        //                    cartItemService.Delete(item.Id);
        //                }

        //                //DELETE CART
        //                cartService.Delete(cart.Id);
        //            }

        //        }
        //    }
        //    return RedirectToAction("Cart");
        //}

        //public JsonResult GetHeaderCart()
        //{
        //    int itemCount = 0;
        //    var currentUser = Membership.GetUser();
        //    if (currentUser != null)
        //    {
        //        var userId = Convert.ToInt32(currentUser.ProviderUserKey);
        //        var cart = cartService.GetMulti(x => x.CreatedBy == userId).FirstOrDefault();

        //        if (cart != null)
        //        {
        //            itemCount = cart.ItemCount;
        //        }
        //    }

        //    return Json(itemCount, JsonRequestBehavior.AllowGet);
        //}
        #endregion


        public ActionResult ProductDetail(int id)
        {
            ViewBag.current = "Shop";
            var product = productService.GetSingleById(id);
            ViewBag.artist = artistService.GetSingleById(product.ArtistId);
            return View(product);
        }

        public JsonResult CheckLoginBeforeCheckOut()
        {
            var currentUser = UserHelper.GetCurrentUser();
            if (currentUser != null)
            {
                var cookieValue = GetCartCookies();
                var userId = Convert.ToInt32(currentUser.Id);
                var cart = cartService.GetMulti(x => x.Cookie == cookieValue).FirstOrDefault();
                if (cart == null)
                    return Json("ProductRequired", JsonRequestBehavior.AllowGet);
                var cartItem = cartItemService.GetMulti(s => s.CartId == cart.Id);
                if (!cartItem.Any())
                {
                    return Json("ProductRequired", JsonRequestBehavior.AllowGet);
                }
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            return Json("LoginRequired", JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        public ActionResult HeaderCart()
        {
            var cart = cartService.GetMulti(x => x.CreatedBy == 1).FirstOrDefault();
            int itemCount = 0;
            if (cart != null)
            {
                itemCount = cart.ItemCount;
            }
            ViewBag.ItemCount = itemCount;
            return PartialView("~/Views/Shared/_HeaderCart.cshtml");
        }

        public string GetCartCookies()
        {
            string cookievalue;
            if (Request.Cookies["CartCookie"] != null)
            {
                cookievalue = Request.Cookies["CartCookie"].Value;
            }
            else
            {
                cookievalue = Guid.NewGuid().ToString();
                Response.Cookies["CartCookie"].Value = cookievalue;
                Response.Cookies["CartCookie"].Expires = DateTime.Now.AddMinutes(15); // add expiry time
            }
            return cookievalue;
        }

    }
}