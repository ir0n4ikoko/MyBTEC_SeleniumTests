using System;
using Edi.Advance.BTEC.UiTests.Framework;

namespace Edi.Advance.BTEC.UiTests.Flows
{
    public class FlowResult<TFlow> where TFlow : BtecMasterFlow<TFlow>
    {
        public FlowResult(string id)
        {
            CreatedId = id;
        }

        public TFlow Flow { get; set; }

        public string CreatedId { get; set; }

        public TFlowResult Next<TFlowResult>(Func<TFlow, string, TFlowResult> func)
            where TFlowResult : FlowBase<TFlowResult>
        {
            return func(Flow, CreatedId);
        }
    }
}