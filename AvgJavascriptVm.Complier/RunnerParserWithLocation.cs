using AvgJavascriptVm.Core.Infrastructure;

namespace AvgJavascriptVm.Complier
{
    class RunnerParserWithLocation: RunnerParser
    {
        public RunnerParserWithLocation(GlobalScope globalEnvironment) : base(globalEnvironment)
        {

        }

        protected override void DoAction(int action)
        {
            base.DoAction(action);
            
            CurrentSemanticValue.n?.SetLocation(CurrentLocationSpan.StartLine, CurrentLocationSpan.StartColumn);
        }
    }
}
