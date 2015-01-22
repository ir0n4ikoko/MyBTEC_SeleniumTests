using System.Linq;
using Edi.Advance.BTEC.UiTests.Framework;
using Edi.Advance.BTEC.UiTests.PageObjects;
using System.Collections.Generic;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class ViewQualificationStep1Flow : SelectQualificationFlow<ViewQualificationStep1Flow>
    {
        private readonly ViewQualificationStep1Page page;

        public ViewQualificationStep1Flow(INavigator navigator, ViewQualificationStep1Page page)
            : base(navigator, page)
        {
            this.page = page;
        }

        public ViewQualificationStep2Flow Continue()
        {
            var step2Page = navigator.DoActionWaitForJQueryAndNavigate<ViewQualificationStep2Page>(page.Continue.Click);

            return new ViewQualificationStep2Flow(navigator, step2Page);
        }

        public HomeFlow Exit()
        {
            page.Exit.Click();

            var homePage = navigator.Navigate<HomePage>(page.ConfirmExit().Click);

            return new HomeFlow(navigator, homePage);
        }

        public ViewQualificationStep1Flow CompleteStep1ViewQual(string subject, string qualificationSuite, string pathway, string size)
        {
            return CompleteAllDropDowns(subject, qualificationSuite, pathway, size);

        }

        public ViewQualificationStep1Flow CompleteStep1ViewQualWithAllPossibleCombinations()
        {
            navigator.WaitForJQuery();

            List<string> subjectList = page.Subject.Options.Where(option => !option.Equals(UI.SelectSubject)).ToList();

            foreach (string subj in subjectList)
            {
                SelectSubject(subj, this);
                navigator.WaitForJQuery();
                
                List<string> qualificationsuiteList = page.QualificationSuite.Options.Where(option => !option.Equals(UI.SelectQualification)).ToList();

                foreach (string qualsuite in qualificationsuiteList)
                {
                    SelectQualificationSuite(qualsuite, this);
                    navigator.WaitForJQuery();
                    
                    List<string> pathwayList = page.Pathway.Options.Where(option => !option.Equals(UI.SelectPathway)).ToList();

                    foreach (string path in pathwayList)
                    {
                        SelectPathway(path, this);
                        navigator.WaitForJQuery();

                        List<string> qualsizeList = page.Size.Options.Where(option => !option.Equals(UI.SelectSize)).ToList();

                        foreach (string size in qualsizeList)
                        {

                            SelectSize(size, this);
                            navigator.WaitForJQuery();
                            Continue()
                            .Previous();
                        }
                    }
                }
            }
            return this;
        }

        public ViewQualificationStep1Flow CompleteAllDropDowns(string subject, string qualSuite, string pathway, string size)
        {
            SelectSubject(subject, this)
                .SelectQualificationSuite(qualSuite, this)
                .SelectPathway(pathway, this)
                .SelectSize(size, this)
                ;

            return this;
        }

    }
}