using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class ResourcesFlow : BtecMasterFlow<ResourcesFlow>
    {
        private readonly ResourcesPage page;

        public ResourcesFlow(INavigator navigator, ResourcesPage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public string Grid
        {
            get
            {
                return
                    page.ActiveView.GetAttribute("aria-labelledby")
                        .Equals("packView")
                        ? "resourcePackGrid"
                        : "centreResourceGrid";
            }
        }

        public ResourcesFlow CheckResourcePack(string id)
        {
            page.PackCheckbox(Grid, id).Click();

            return this;
        }

        public ResourcesFlow CheckAllResourcePacks()
        {
            navigator.WaitForJQuery();

            ReadOnlyCollection<IWebElement> chkbxs =
                SeleniumContext.WebDriver.FindElements(By.Name("cbResourcePack"));

            chkbxs.Where(chkbx => chkbx.Displayed)
                .ToList()
                .ForEach(chkbx => chkbx.Click());

            return this;
        }

        public ResourcesFlow CheckAllResources()
        {
            navigator.WaitForJQuery();

            ReadOnlyCollection<IWebElement> chkbxs =
                SeleniumContext.WebDriver.FindElements(By.Name("cbResource"));

            chkbxs.Where(chkbx => chkbx.Displayed)
                .ToList()
                .ForEach(chkbx => chkbx.Click());

            return this;
        }

        public ResourcesFlow SelectAllResources()
        {
            page.SelectAllResources.Click();

            return this;
        }

        public ResourcesFlow SelectActionForAllResources(string action)
        {
            page.ActionForAllResources.Text = action;

            navigator.WaitForJQuery();

            return this;
        }

        public ResourcesFlow GetAllCombinations()
        {
            if (
                File.Exists(Configuration.DownloadDir
                            + "\\AllSpecsSupport.txt"))
                return this;

            var txtQualifications = new StringBuilder();
            navigator.WaitForJQuery();

            foreach (
                string subject in
                    page.Subject.Options.Except(new[]
                    {UI.SelectSubject, UiConst.Subject.Business}))
            {
                page.Subject.Text = subject;
                navigator.WaitForJQuery();
                try
                {
                    foreach (
                        string suite in
                            page.QualificationSuite.Options.Except(new[]
                            {UI.SelectQualification}))
                    {
                        page.QualificationSuite.Text = suite;
                        navigator.WaitForJQuery();
                        try
                        {
                            foreach (
                                string pathway in
                                    page.Pathway.Options.Except(new[]
                                    {UI.SelectPathway}))
                            {
                                page.Pathway.Text = pathway;
                                navigator.WaitForJQuery();
                                try
                                {
                                    foreach (
                                        string size in
                                            page.Size.Options.Except(new[]
                                            {UI.SelectSize}))
                                    {
                                        page.Size.Text = size;
                                        navigator.WaitForJQuery();
                                        IEnumerable<string> units = page.Unit.Options;
                                        txtQualifications.AppendLine('"'
                                                                     + subject
                                                                     + '"' + ";"
                                                                     + '"'
                                                                     + suite
                                                                     + '"' + ";"
                                                                     + '"'
                                                                     + pathway
                                                                     + '"' + ";"
                                                                     + '"'
                                                                     + size
                                                                     + '"' + ";"
                                                                     + units
                                                                         .Count
                                                                         ()
                                                                     + '"');
                                    }
                                }
                                catch (WebDriverException e)
                                {
                                    txtQualifications.AppendLine("ERROR"
                                                                 + subject + '"'
                                                                 + ";" + '"'
                                                                 + suite + '"'
                                                                 + ";" + '"'
                                                                 + pathway
                                                                 + "    " + e);
                                    SeleniumContext.WebDriver.Navigate()
                                        .Refresh();
                                }
                            }
                        }
                        catch (WebDriverException e)
                        {
                            txtQualifications.AppendLine("ERROR" + subject + '"'
                                                         + ";" + '"' + suite
                                                         + '"' + ";" + "    "
                                                         + e);
                            SeleniumContext.WebDriver.Navigate().Refresh();
                        }
                    }
                }
                catch (WebDriverException e)
                {
                    txtQualifications.AppendLine("ERROR" + subject + '"' + ";"
                                                 + '"' + "    " + e);
                    SeleniumContext.WebDriver.Navigate().Refresh();
                }
            }


            File.WriteAllText(
                Configuration.DownloadDir + "\\AllSpecsSupport.txt",
                txtQualifications.ToString());

            return this;
        }

        public ResourcesFlow SelectSubject(string subject)
        {
            navigator.WaitForJQuery();

            page.Subject.Text = subject;

            return this;
        }

        public ResourcesFlow SelectQualificationSuite(string qualificationSuite)
        {
            navigator.WaitForJQuery();

            page.QualificationSuite.Text = qualificationSuite;

            return this;
        }

        public ResourcesFlow SelectPathway(string pathway)
        {
            navigator.WaitForJQuery();

            page.Pathway.Text = pathway;

            return this;
        }

        public ResourcesFlow SelectSize(string size)
        {
            navigator.WaitForJQuery();

            page.Size.Text = size;

            return this;
        }

        public ResourcesFlow AddUnit(string unit)
        {
            navigator.WaitForJQuery();

            page.Unit.Text = unit;

            return this;
        }

        public ResourcesFlow Search()
        {
            page.Search.Click();

            navigator.WaitForJQuery();

            return this;
        }

        public ResourcesFlow Clear()
        {
            page.Clear.Click();

            navigator.WaitForJQuery();

            return this;
        }

        public ResourcesFlow SelectUnit(string unit)
        {
            page.Unit.Text = unit;

            page.AddUnit.Click();

            navigator.WaitForJQuery();

            return this;
        }

        public ResourcesFlow CheckNotFound()
        {
            Assert.IsFalse(page.ResourcePackGrid.Displayed,
                "Grid exists but should be empty");

            return this;
        }

        public ResourcesFlow CheckPackTooltip(int index, string packName,
            string description)
        {
            Assert.AreEqual(packName, page.PackTitle(Grid, index).Text);
            Assert.AreEqual(description,
                page.PackTitle(Grid, index).GetAttribute("title"));

            return this;
        }

        public ResourcesFlow CheckPackNumber(int start, int end, int all)
        {
            Assert.AreEqual(UI.GridDataCounter.F(start, end, all),
                page.ResourcePackNumber.Text);

            return this;
        }

        public ResourcesFlow ExpandPack(int index)
        {
            page.PackExpand(Grid, index).Click();

            navigator.WaitForJQuery();

            return this;
        }

        public ResourcesFlow CheckResourceTooltip(int packIndex, int index,
            string resourceName,
            string description)
        {
            Assert.AreEqual(resourceName,
                page.ResourceTitle(Grid,
                    page.PackId(Grid, packIndex)
                        .GetAttribute("id"), index)
                    .Text);
            Assert.AreEqual(description,
                page.ResourceTitle(Grid,
                    page.PackId(Grid, packIndex)
                        .GetAttribute("id"), index)
                    .GetAttribute("title"));

            return this;
        }
    }
}