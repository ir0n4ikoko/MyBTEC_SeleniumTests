using System;

namespace Edi.Advance.BTEC.UiTests.Framework
{
    public interface INavigator
    {
        TPage Open<TPage>() where TPage : PageBase, new();

        TPage Navigate<TPage>(Action action) where TPage : PageBase, new();

        TPage NavigateNewTab<TPage>(Action action) where TPage : PageBase, new();

        TPage WaitForJQueryAndNavigate<TPage>(Action action) where TPage : PageBase, new();

        TPage DoActionWaitForJQueryAndNavigate<TPage>(Action action) where TPage : PageBase, new();

        TPage DoActionWaitUrlChangedAndNavigate<TPage>(Action action) where TPage : PageBase, new();

        void ClickAndWaitForElement(Action action, Func<string> controlId);

        void ClickAndWaitForJQuery(Action action);

        void WaitElementIsPresent(Func<string> controlId);

        void WaitForJQuery();

        bool DoActionCheckNewTabOpened(Action action);

        bool CheckUrlNewTabOpened(string url);

        void GoToUrl(string url);

        void WaitForFileDownloaded(string path);
    }
}