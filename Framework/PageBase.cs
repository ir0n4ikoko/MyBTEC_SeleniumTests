namespace Edi.Advance.BTEC.UiTests.Framework
{
    /// <summary>
    ///     The idea of Page Object is simple - Encapsulate all calls to controls on page:
    /// </summary>
    /// <remarks>
    ///     For more info read :
    ///     https://code.google.com/p/selenium/wiki/PageObjects?redir=1
    ///     http://slmoloch.blogspot.com/2009/11/design-of-selenium-tests-for-aspnet.html
    /// </remarks>
    public abstract class PageBase
    {
        protected readonly string url;

        protected PageBase(string url)
        {
            this.url = url;
        }

        public string PageUrl
        {
            get { return url; }
        }
    }
}