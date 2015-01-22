using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects.Controls;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.PageObjects
{
    public abstract class AssigmentWizardPage : QualificationFilterPage
    {
        protected AssigmentWizardPage(string url)
            : base(url)
        {
        }

        public string Id
        {
            get { return new HiddenControl("Id").Text; }
        }

        public Link SaveAndContinue
        {
            get { return new Link("SaveContinue", By.ClassName); }
        }

        public Link Step4Tab
        {
            get { return new Link("//div[contains(@data-val, '4')]", By.XPath);}
        }

        public Link Previous
        {
            get { return new Link("Back", By.ClassName); }
        }

        public ControlBase Qualification
        {
            get
            {
                return
                    new ControlBase(
                        @"//div[contains(@class,'fieldspacer')]/div[contains(text(),'Qualification(s):')]/following-sibling::div//span",
                        By.XPath);
            }
        }
    }
}