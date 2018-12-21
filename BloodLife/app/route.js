'use strict'

bloodserviceApp.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/store', {
                templateUrl: '/app/bloodservice.store/store.htm',
                controller: 'storeController'
            }).
            when('/cart', {
                templateUrl: '/app/bloodservice.cart/shoppingCart.htm',
                controller: 'bloodstoreController'
            }).
            otherwise({
                redirectTo: '/store'
            })
    }]);


bloodserviceApp.factory("DataService", function () {
    var myStore = new store();
    var myCart = new shoppingCart('bloodservice');

    // enable PayPal checkout
    // note: the second parameter identifies the merchant; in order to use the 
    // shopping cart with PayPal, you have to create a merchant account with 
    // PayPal. You can do that here:
    // https://www.paypal.com/webapps/mpp/merchant
    myCart.addCheckoutParameters("PayPal", "bernardo.castilho-facilitator@gmail.com");

    // enable Google Wallet checkout
    // note: the second parameter identifies the merchant; in order to use the 
    // shopping cart with Google Wallet, you have to create a merchant account with 
    // Google. You can do that here:
    // https://developers.google.com/commerce/wallet/digital/training/getting-started/merchant-setup
    myCart.addCheckoutParameters("Google", "500640663394527",
        {
            ship_method_name_1: "UPS Next Day Air",
            ship_method_price_1: "20.00",
            ship_method_currency_1: "USD",
            ship_method_name_2: "UPS Ground",
            ship_method_price_2: "15.00",
            ship_method_currency_2: "USD"
        }
    );

    return {
        store: myStore,
        cart: myCart
    };
});