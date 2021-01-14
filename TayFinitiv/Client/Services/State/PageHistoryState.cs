using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TayFinitiv.Client.Services.State
{
    public class PageHistoryState
    {
        private class Page
        {
            public string Route { get; set; }
            public Page PreviousPage { get; set; }
            public Page(string pageRoute)
            {
                Route = pageRoute;
                PreviousPage = null;
            }

            public Page(string pageRoute, Page previous)
            {
                Route = pageRoute;
                PreviousPage = previous;
            }
        }
        private Stack<Page> previousPages;
        private NavigationManager _navManager;

        public PageHistoryState(NavigationManager navManager)
        {
            _navManager = navManager;
            previousPages = new Stack<Page>();
        }
        public void AddPage(string pageRoute)
        {
            Page lastPageVisited, newPage;
            newPage = new Page(pageRoute);
            if (previousPages.TryPeek(out lastPageVisited))
            {
                newPage.PreviousPage = lastPageVisited;
            }
            previousPages.Push(newPage);
        }

        public string PreviousPage()
        {
            Page currentPage;
            currentPage = previousPages.Peek();
            if (currentPage.PreviousPage != null)
            {
                previousPages.Pop();
                return currentPage.PreviousPage.Route;
            }
            return "";
        }

        public bool CanGoBack()
        {
            return previousPages.Count > 1;
        }
    }
}
