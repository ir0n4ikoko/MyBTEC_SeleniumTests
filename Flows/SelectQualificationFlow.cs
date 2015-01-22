using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using Edi.Advance.Core.Common;

using OpenQA.Selenium;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class SelectQualificationFlow<TFlow> : BtecMasterFlow<TFlow>
        where TFlow : BtecMasterFlow<TFlow>
    {
        private readonly QualificationFilterPage page;
        protected List<CreateCourseContext> courseList;

        public SelectQualificationFlow(INavigator navigator, QualificationFilterPage page)
            : base(navigator, page)
        {
            this.page = page;
        }

        /// <summary>
        ///     Get all possible combinations subject-qualification suite-pathway-size
        /// </summary>
        /// <returns>write in txt file all qualification flow combinations</returns>
        public SelectQualificationFlow<TFlow> GetAllPosibleCombinations()
        {
            if (File.Exists(Configuration.DownloadDir + "\\Qualifications.txt"))
                return this;

            var txtQualifications = new StringBuilder();

            navigator.WaitForJQuery();
            IEnumerable<IWebElement> subject = page.Subject.ElementOptions;
            foreach (IWebElement subj in subject.Where(subj => subj.Text != UI.SelectSubject))
            {
                string subjText = subj.Text;
                subj.Click();
                navigator.WaitForJQuery();
                IEnumerable<IWebElement> qualification = page.QualificationSuite.ElementOptions;
                foreach (IWebElement suite in qualification.Where(suite => suite.Text != UI.SelectQualification))
                {
                    string suiteText = suite.Text;
                    suite.Click();
                    navigator.WaitForJQuery();
                    IEnumerable<IWebElement> pathway = page.Pathway.ElementOptions;
                    foreach (IWebElement path in pathway.Where(path => path.Text != UI.SelectPathway))
                    {
                        string pathText = path.Text;
                        path.Click();
                        navigator.WaitForJQuery();
                        IEnumerable<IWebElement> qualifSize = page.Size.ElementOptions;
                        foreach (
                            string sizeText in
                                qualifSize.Where(size => size.Text != UI.SelectSize).Select(size => size.Text))
                        {
                            txtQualifications.AppendLine('"' + subjText + '"' + ";" + '"' + suiteText + '"' + ";" + '"' +
                                                         pathText + '"' + ";" + '"' + sizeText + '"');
                        }
                    }
                }
            }
            File.WriteAllText(Configuration.DownloadDir + "\\Qualifications.txt", txtQualifications.ToString());
            return this;
        }

        public TFlow SelectSubject(string subject, TFlow toReturnFlow)
        {
            navigator.WaitForJQuery();

            page.Subject.Text = subject;

            return toReturnFlow;
        }

        public TFlow SelectQualificationSuite(string qualificationSuite, TFlow toReturnFlow)
        {
            navigator.WaitForJQuery();

            page.QualificationSuite.Text = qualificationSuite;

            return toReturnFlow;
        }

        public TFlow SelectPathway(string pathway, TFlow toReturnFlow)
        {
            if (pathway.IsNotNullOrEmpty())
            {
                navigator.WaitForJQuery();

                page.Pathway.Text = pathway;
            }

            return toReturnFlow;
        }

        public TFlow SelectSize(string size, TFlow toReturnFlow)
        {
            if (size.IsNotNullOrEmpty())
            {
                navigator.WaitForJQuery();

                page.Size.Text = size;
            }

            return toReturnFlow;
        }
    }
}