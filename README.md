# MyOrderCart
Create a Blazor Server APP [C# Net 5.0] to explore the opportunity to learn about different aspects of Blazor Application Development
![Sample Screenshot!](/Images/SampleApp.PNG "Sample screenshot")

## Requirments
<ul>
  <li>[x] Products table should have 2 columns: Title and Unit Price. Search on the table is possible by the title of the product</li>
<li>[x] Component 2 should be updated automatically without refresh of the page when a product is added/updated to the cart.</li>
<li>[x] The UI needs to provide the ability for the user to add a product from the list (component 1) to the cart.
  <ul><li>[x] When the same product is not yet added to the cart it will be added with a quantity of 1.</li>
<li>[x] When the product already exists, the quantity of the existing order line item is increased by 1</li></ul>
</li>
<li>[x] All products in the current order will be displayed in a table displaying the Product Title, Unit</li>
Price, Quantity and Total Price. In the bottom there should be shown the Total Price of the order. (component 2)</li>
<li>[x] At least the code of one functionality of the application should be covered by Unit Tests (XUnit).</li>
</ul>
Optional
<ul><li>[x] Confirm Order in External System.</li>
  <li>[x] Entity Framework Core.</li>
  <li>[x] BUnit to test one of the Blazor components.</li>
  </ul>


## Tech-Stack To Understand
<ul>
  <li>Blazor Server APP</li>
  <li>Dependancy Injection</li>
  <li>HTTPClient</li>
  <li>Third Party API Integration in Blazor</li>
  <li>Material Design Using MudBlazor</li>
  <li>State Provider in Blazor With Local Storage</li>
  <li>Entity Framework Core Integration</li>
  <li>SQLite Integration</li>
  <li>Confirm Dialog & SnackBar Implementation</li>
  <li>Custom Table With Search Implementation</li>
  <li>Unit Testing Blazor Component using xUnit & bUnit</li>
  <li>Mock & HttpClient Mocking in Blazor</li>
</ul>

## Folder & File Structure

### UI- Components
<ul>
  <li>MyOrderCart\Shared - MainLayout.razor : Layout of the application</li>
  <li>MyOrderCart\Shared - NavMenu.razor : Navigation Menu</li>
  <li>MyOrderCart\Shared\StateProvider.razor - A global component to manage the state of blazor application</li>
  <li>MyOrderCart\Pages\Component : Razor Components<ul>
  <li>CartComponent.razor - Display the list of cart item</li>
  <li>ProductList.razor - Display the table of product list with search & add to cart functionality</li>
  <li>OrderListComponent.razor - Display the list of shopping cart saved in database</li>
  </ul></li>
   <li>MyOrderCart\Pages - Index.razor : Default page of the application to load all other components</li>
 </ul>
 
### Data Models - MyOrderCart\Data
 <ul>
  <li>Product.cs - Model for product data list based on API response </li>
  <li>Rating.cs - Model supporting product data for rating</li>
  <li>CardData.cs - To support the actual data need to be stored in shopping cart</li>
  <li>Cart.cs - Actual shopping cart model, used also to store the final data on db</li>
  </ul>
  
### Database - SQLite
 <ul>
  <li>MyOrderCart\Data\DBContext - OrderContext.cs - Entity framework supported context to store Cart Object</li>
  <li>StartUp.cs - Configuration to create a in-memory SQLite database</li>
  </ul>
  
  `` 
  services.AddDbContextFactory<OrderContext>(opt =>
               opt.UseSqlite($"Data Source={nameof(OrderContext.OrderDb)}.db")); 
  ``

  
### Service - API Integration
 <ul>
  <li>MyOrderCart\Services\IFakeAPIService.cs - Fake API Service to get product list</li>
  <li>MyOrderCart\Services\IDummyRequestAPI.cs - Dummy request service to send order confirmation</li>
  <li>Configur API Serivce in StartUp Configuration</li>
</ul>

          services.AddSingleton<IFakeApiService, FakeApiService>();
          services.AddHttpClient<IFakeApiService, FakeApiService>(c =>
          {
          c.BaseAddress = new Uri(Configuration.GetValue<string>("APIUrl:FakeAPI"));
          });
          
### Unit Testing
Blazor Unit Testing of components can be done by following the [bUnit](https://bunit.dev/)
<ul>
  <li>MyOrderCart.Test - Test Project</li>
  <li>ProductListComponentTest.razor - Blazor razor component testing</li>
  <li>MyOrderCart.Test\Helper - MockHttpClientBunitHelpers.cs - For mocking HttpClient Calls</li>
  </ul>
  Example Test
  
          [Fact]
          public void ProductList_DisplayedCorrectly()
          {
            var productList = new List<Product>{ new Product()
              {
                id=1,
                category="Cat1",
                description="Desc1",
                title="Product1",
                price=10,
                image="",rating=new Rating()
                {
                  count=10,
                  rate=4.5
                }
              },
              new Product(){
                id=1,
                category="Cat1",
                description="Desc1",
                title="Product2",
                price=10,
                image="",rating=new Rating()
                {
                  count=10,
                  rate=4.5
                }
              }
            };
            using var ctx = new TestContext();
            ctx.Services.AddTransient<IFakeApiService, FakeApiService>();
            var mock = ctx.Services.AddMockHttpClient();
            mock.When("/product").RespondJson(productList);
            var fakeAPIServiceMock = Mock.Create<IFakeApiService>();
            Mock.Arrange(() => fakeAPIServiceMock.GetProductsAsync())
              .Returns(Task.FromResult<List<Product>>(productList));

            var cut = ctx.RenderComponent<ProductListComponent>();
            cut.Markup.Contains("Product1");
            cut.Markup.Contains("Product2");
          }

### Version & Depedancy 
 <ul>
  <li>Blazor C# .Net 5.0</li>
  <li>[MudBlazor 5.2.4](https://www.nuget.org/packages/MudBlazor/)</li>
  <li>[Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)</li>
  <li>[Microsoft.AspNetCore.ProtectedBrowserStorage 0.1.0] (https://www.nuget.org/packages/Microsoft.AspNetCore.ProtectedBrowserStorage/0.1.0-alpha.19521.1)</li>
  <li>[Microsoft.EntityFrameworkCore 5.0.15](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/7.0.0-preview.1.22076.6)</li>
  <li>[Microsoft.EntityFrameworkCore.Sqlite 5.0.15](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/7.0.0-preview.1.22076.6)</li>
  <li>[RichardSzalay.MockHttp 6.0.0](https://www.nuget.org/packages/RichardSzalay.MockHttp/)</li>
  <li>[xunit 2.4.1](https://www.nuget.org/packages/xunit/2.4.2-pre.12)</li>
  <li>[bunit 1.6.4](https://www.nuget.org/packages/bunit/)</li>
   <li>[JustMock 2022.1.223.1](https://www.nuget.org/packages/JustMock/)</li>
 </ul>
 
### Scope For Improvement
 <ul>
  <li>Database can be used NoSQL instead of Relational SQLite</li>
  <li>Unit testing of State Provide can be improved</li>
  <li>UI & Layout design can be simplified more</li>
  <li>Logging is missing currently</li>
  <li>Custom exception handling can be implemented for better user experience</li>
 </ul>
 
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

Distributed under the MIT License.
