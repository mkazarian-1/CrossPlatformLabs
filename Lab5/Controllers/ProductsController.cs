using Lab5.Dto;
using Lab5.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

[Authorize]
public class ProductsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly Auth0Service _auth0TokenService;

    public ProductsController(IHttpClientFactory httpClientFactory, Auth0Service auth0TokenService)
    {
        _httpClientFactory = httpClientFactory;
        _auth0TokenService = auth0TokenService;
    }

    public async Task<IActionResult> Index()
    {
        List<ProductDto> products = new();
        try
        {
            var accessToken = await _auth0TokenService.GetAccessTokenAsync();
            var client = _httpClientFactory.CreateClient("Lab6Api");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            products = await client.GetFromJsonAsync<List<ProductDto>>("api/Product") ?? new List<ProductDto>();
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = "Failed to load products. Please try again later.";
            Console.WriteLine(ex.Message);
        }

        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        ProductFullDto? product = null;
        try
        {
            var accessToken = await _auth0TokenService.GetAccessTokenAsync();
            var client = _httpClientFactory.CreateClient("Lab6Api");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            product = await client.GetFromJsonAsync<ProductFullDto>($"api/Product/{id}");
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = "Failed to load product details. Please try again later.";
            Console.WriteLine(ex.Message);
        }

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }
}
