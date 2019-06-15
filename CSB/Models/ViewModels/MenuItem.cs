using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSB.Models.ViewModels
{
    public class MenuItem
    {
        public string action;
        public string controller;
        public string title;

        public MenuItem(string Title, string Action, string Controller)
        {
            action = Action;
            title = Title;
            controller = Controller;
        }
    }
}