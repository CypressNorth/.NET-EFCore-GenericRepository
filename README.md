# .NET-EFCore-GenericRepository
A generic repository for EF Core and .NET Core

An example ApplicationDbContext is provided along with an example Entity model and EntityService using the Repository.

To use this generic repository with .NET Core, implement a service which inherits from the Repository. The ApplicationDbContext and Logger are injected using the built in dependency injection container in .NET Core.

To use your service, inject the service into your calling class, like a Controller in a web application. You will have access to the generic methods for the entity out of the box.

```C#
public class ExampleController
{
    private readonly IExampleService _exampleService;
    
    public ExampleController (IExampleService exampleService)
    {
        _exampleService = exampleService;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _exampleService.GetAll().ToListAsync();
        return View(model);
    }
  
}
```
