using Lab5.Dto;
using Lab5.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

[Authorize]
public class CustomersController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly Auth0Service _auth0TokenService;

    public CustomersController(IHttpClientFactory httpClientFactory, Auth0Service auth0TokenService)
    {
        _httpClientFactory = httpClientFactory;
        _auth0TokenService = auth0TokenService;
    }

    public async Task<IActionResult> Index(string? name, DateTime? date)
    {
        List<CustomerDto> customers = new();
        try
        {
            var accessToken = await _auth0TokenService.GetAccessTokenAsync();
            var client = _httpClientFactory.CreateClient("Lab6Api");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            // Build query parameters for the API request
            var query = $"api/Customer?";
            if (!string.IsNullOrWhiteSpace(name))
            {
                query += $"name={Uri.EscapeDataString(name)}&";
                ViewData["SearchName"] = name;
            }
            if (date.HasValue)
            {
                query += $"date={date.Value:yyyy-MM-dd}&";
                ViewData["SearchDate"] = date.Value.ToString("yyyy-MM-dd");
            }

            customers = await client.GetFromJsonAsync<List<CustomerDto>>(query) ?? new List<CustomerDto>();
        }
        catch (Exception ex)
        {
            // Log error and display message
            ViewBag.ErrorMessage = "Failed to load customers. Please try again later.";
            Console.WriteLine(ex.Message);
        }

        return View(customers);
    }

    
    public async Task<IActionResult> Details(int id)
    {
        CustomerFullDto customer = null;
        try
        {
            var accessToken = await _auth0TokenService.GetAccessTokenAsync();
            var client = _httpClientFactory.CreateClient("Lab6Api");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            customer = await client.GetFromJsonAsync<CustomerFullDto>($"api/Customer/{id}") ?? new CustomerFullDto();
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = "Failed to load customer details.";
            Console.WriteLine(ex.Message);
        }

        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }
}