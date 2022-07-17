using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Stripe;
using Stripe.Checkout;
using Newtonsoft.Json;
using WebApi.Helpers;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebApi.Controllers
{

    [Route("api/payment/create-checkout-session/")]
    [ApiController]
    public class CheckoutApiController : Controller
    {

        

        [HttpPost]
        public ActionResult Create()
        {
            var domain = "https://mynixer.com:4242";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
                    Price = "price_1L0tv9F2jBbzNarUtk2yo9sz",
                    Quantity = 1,
                  },
                },
                Mode = "payment",
                SuccessUrl = domain + "?success=true",
                CancelUrl = domain + "?canceled=true",
            };
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public void createProduct()
        {

            StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";

            var options = new ProductCreateOptions
            {
                Name = "Gold Special",
            };
            var service = new ProductService();
            service.Create(options);


        }

    }

    [Route("api/payment/create-payment-intent")]
    [ApiController]
    public class PaymentIntentApiController : Controller
    {

        public readonly DataContext _context;

        public PaymentIntentApiController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult Create(PaymentIntentCreateRequest request)
        {            BusinessServiceModel businessService = _context.BusinessServices.Find(Int32.Parse(request.Items[0].Id));

            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = paymentIntentService.Create(new PaymentIntentCreateOptions
            {
                Amount = businessService.price * 100,
                Currency = "eur",
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
            });

            return Json(new { clientSecret = paymentIntent.ClientSecret, businessService });
        }

        private int CalculateOrderAmountAsync(string id)
        {


            var businessService = _context.BusinessServices.FindAsync(id);
            // Replace this constant with a calculation of the order's amount
            // Calculate the order total on the server to prevent
            // people from directly manipulating the amount on the client
            return 1;
        }

        public class Item
        {
            [JsonProperty("id")]
            public string Id { get; set; }
        }

        public class PaymentIntentCreateRequest
        {
            [JsonProperty("items")]
            public Item[] Items { get; set; }
        }
    }

}





