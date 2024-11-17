using Lab5.Models;
using LabLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

public class LabsController : Controller
{
    [HttpGet]
    [Authorize]
    public IActionResult Index()
    {
        return View(new LabTextViewModel());
    }

    [HttpPost]
    [Authorize]
    public IActionResult Lab1(LabTextViewModel model)
    {
        ViewData["SelectedLab"] = "Lab1";
        model.OutputText = ProcessLab1(model.InputText);
        return View("Index", model);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Lab2(LabTextViewModel model)
    {
        ViewData["SelectedLab"] = "Lab2";
        model.OutputText = ProcessLab2(model.InputText);
        return View("Index", model);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Lab3(LabTextViewModel model)
    {
        ViewData["SelectedLab"] = "Lab3";
        model.OutputText = ProcessLab3(model.InputText);
        return View("Index", model);
    }

    private string ProcessLab1(string input)
    {
        return Lab1Lab.Run(input.Split(["\r\n", "\r", "\n"], StringSplitOptions.None));
    }

    private string ProcessLab2(string input)
    {
        return Lab2Lab.Run(input.Split(["\r\n", "\r", "\n"], StringSplitOptions.None));
    }

    private string ProcessLab3(string input)
    {

        return Lab3Lab.Run(input.Split(["\r\n", "\r", "\n"], StringSplitOptions.None));
    }
}