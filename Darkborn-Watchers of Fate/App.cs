using System;
using System.Collections.Generic;
using System.Text;

namespace AppInitializer
{
    public class App
    {
        public string Title { get; set; } = "Darkborn: Watchers of Fate";

        public void setTitle(string title)
        {
            Title = title;
            Console.Title = title;
        }
    }
}
