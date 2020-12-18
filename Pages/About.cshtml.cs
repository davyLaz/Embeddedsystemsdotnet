using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Device.Gpio;

namespace MyApp.Namespace
{
    public class AboutModel : PageModel
    {

	private GpioController controller;
	public AboutModel(GpioController controller){
		this.controller = controller;
	}

	[BindProperty]
	public bool Output18 {get;set;}
	
	[BindProperty]
	public bool Output17 {get;set;}

	public bool Input22 {get;set;}

	public bool Input23 {get;set;}

	public void OnPost(){
		{	
			controller.Write(18, Output18?PinValue.High:PinValue.Low);
			controller.Write(17, Output17?PinValue.High:PinValue.Low);
		
			Input22 = (controller.Read(22) == PinValue.High);
			Input23 = (controller.Read(23) == PinValue.High);
		}
		Console.WriteLine($"Output 18 is {Output18}");
		Console.WriteLine($"Output 17 is {Output17}");
		Console.WriteLine($"Input 22 is {Input22}");
		Console.WriteLine($"Input 23 is {Input23}");

	}

        public void OnGet()
        {
        }
    }
}
