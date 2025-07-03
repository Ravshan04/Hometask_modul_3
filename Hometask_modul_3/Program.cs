using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        var lights = new[] { "Red", "Yellow", "Green" };
        int current = 0;

        AnsiConsole.Clear();

        AnsiConsole.Live(new Panel(GetTrafficLight(lights[current])))
            .Start(ctx =>
            {
                while (true)
                {
                    // Yangilanish
                    ctx.UpdateTarget(new Panel(GetTrafficLight(lights[current])));

                    // Keyingi chiroq
                    current = (current + 1) % lights.Length;

                    // Har bir chiroq turish vaqti
                    Thread.Sleep(GetDelay(lights[current]));
                }
            });
    }

    static string GetTrafficLight(string active)
    {
        string red = active == "Red" ? "[bold red]●[/]" : "[grey]●[/]";
        string yellow = active == "Yellow" ? "[bold yellow]●[/]" : "[grey]●[/]";
        string green = active == "Green" ? "[bold green]●[/]" : "[grey]●[/]";

        return $"{red}\n{yellow}\n{green}";
    }

    static int GetDelay(string color)
    {
        return color switch
        {
            "Red" => 3000,
            "Yellow" => 1500,
            "Green" => 4000,
            _ => 1000
        };
    }
}
