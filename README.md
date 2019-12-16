# Code Fellows ASP.NET 401 eCommerce Website Project - TINY PLANTS

## TINY PLANTS
*Authors: Karina Chen and Kyungrae Kim*

---

### Deployed Website
https://dotnet-ecommerce-tiny-plants.azurewebsites.net/

---

### About This Program
This is an eCommerce store TINY PLANTS built with ASP.NET Core's MVC and Razor Pages. The web app features a user login security system, a welcoming home page, a product page, and a product details page that allows the user to add items into cart for checkout. This web app is built to provide a satisfying shopping experience to our users.

---

### Features
#### Products
This e-commerce store sells tiny plants including cactuses, flowers, and evergreen plants that can be placed indoor. There are currently total of 10 products available on this website.
#### Claims
This web app captures claims of a user's first and last name. After a user registers a new account or logins to the site, a greeting message shows up on the top right corner of the nav bar with the user's first and last name.
#### Policies
This web app uses "AdminOnly" policy to grant Admin special access previllages to /Admin and /Inventory page. This policy has been enforced so that only Admin can control the store inventory. To test the policy, use the following credential to log into the Admin account:
    * Account: JONATHAN'S GMAIL ADDRESS (re*************@g****.com)
    * Password: Admin1234!
#### Entity Relationship Diagram
![erd](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/erd.png)
* Cart table has one to many relationship with CarItems table
* Order table has one to many relationship with OrderItems table
* Product table has one to many relationship with CartItems table
* Product table has one to many relationship with OrderItems table

---

### Vulnerability Report
https://github.com/jeremymaya/Code-401-eCommerce/blob/master/vulnerability-report.md

---

### Link to Code
https://dev.azure.com/dotnet-ecommerce/_git/dotnetd9-ecommerce-karina-kyungrae?_a=contents&version=GBmaster

---

### Visuals
#### Home
##### Home - Logged Out
![home-loggedout](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/home-loggedout.png)
##### Home - Logged In (User)
![home-loggedin-user](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/home-loggedin-user.png)

#### Account
##### Register
![account-register](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/account-register.png)
##### Login
![account-login](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/account-login.png)
##### User Profile
![user-profile](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/user-profile.png)
##### Manage Orders (User)
![orders-user](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/orders-user.png)
##### Manage Order Details (User)
![order-details-user](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/order-details-user.png)

#### Shop
##### Shop
![shop](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/shop.png)
##### Shop/Product - Logged Out
![shop-product-loggedout](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/shop-product-loggedout.png)
##### Shop/Product - Logged In
![shop-product-loggedin](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/shop-product-loggedin.png)
##### Shop/Product - MiniCart
![shop-product-loggedin-minicart](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/shop-product-loggedin-minicart.png)
##### Shop/Cart (Empty)
![shop-cart-empty](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/shop-cart-empty.png)
##### Shop/Cart
![shop-cart](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/shop-cart.png)

#### Checkout
##### Checkout
![checkout](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/checkout.png)
##### Checkout/Receipt
![checkout-receipt](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/checkout-receipt.png)

#### Admin
##### Admin
![admin](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/admin.png)
##### Manage Blob
![admin-blob](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/admin-blob.png)
##### Manage Orders (Admin)
![orders-admin](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/orders-admin.png)
##### Manage Order Details (Admin)
![order-details-admin](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/order-details-admin.png)
##### Inventory
![inventory-home](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/inventory-home.png)
##### Inventory/Create
![inventory-create](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/inventory-create.png)
##### Inventory/Edit
![inventory-edit](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/inventory-edit.png)
##### Inventory/Details
![inventory-details](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/inventory-details.png)
##### Inventory/Delete
![inventory-delete](https://github.com/jeremymaya/Code-401-eCommerce/blob/master/dotnet_ECommerce/dotnet_ECommerce/wwwroot/captures/inventory-delete.png)

---

### Resources
[Add or Remove Multiple Entities in Entity Framework](https://www.entityframeworktutorial.net/entityframework6/addrange-removerange.aspx)  
[Adding Email](https://www.learnrazorpages.com/razor-pages/tutorial/bakery/email)  
[Azure Blob storage client library v12 for .NET](https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-dotnet)  
[Azure Storage CRUD Operations In MVC Using C#](https://www.c-sharpcorner.com/article/azure-storage-crud-operations-in-mvc-using-c-sharp-part-two/)  
[Handler Methods in Razor Pages](https://www.learnrazorpages.com/razor-pages/handler-methods)  
[HtmlHelper - Editor](https://www.tutorialsteacher.com/mvc/htmlhelper-editor-editorfor)  
[Model Binding](https://www.learnrazorpages.com/razor-pages/model-binding)  
[Upload files in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-3.1)  
[Upload File In Azure Blob Storage Using ASP.NET Core](https://www.c-sharpcorner.com/article/upload-files-in-azure-blob-storage-using-asp-net-core/)

---

### Change Log
1.2: Sprint 3 Completed, Initial Submission - 16 Dec 2019  
1.1: Sprint 2 Completed, Initial Submission - 03 Dec 2019  
1.0: Sprint 1 Completed, Initial Submission - 26 Nov 2019  
0.0: Project Initiated - 18 Nov 2019  
