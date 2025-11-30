using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers;

public class HelloWorldController : Controller
{
    // Get /HelloWorld/
    public string Index()
    {
        return "This is my default action....";
    }
    //
    // Get /HelloWorld/Welcome/
    public string Welcome(string name, int numTimes = 1)
    {
        return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is : {numTimes}");
    }
}
