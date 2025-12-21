using System;
using System.Collections.Generic;
using System.Text;

namespace AppInitializer
{
    public class App
    {
        public string Title { get; set; } = "Darkborn: Watchers of Fate ";
        private string AppVersion { get; } = "v0.0.1";

        public string setTitle()
        {
            string title = Title + AppVersion;
            return title;
        }
    }
}
