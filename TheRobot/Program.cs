// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using TheRobot;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("PLease Enter Input Below:");

var serviceProvider = new ServiceCollection()
               // Add your services here..
               .AddSingleton<IRoboInterface, Core>()
               .BuildServiceProvider();
// Now get Your Services like this
var RoboService = serviceProvider.GetRequiredService<IRoboInterface>();
RoboService.play();


