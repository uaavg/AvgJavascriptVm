namespace AvgJavascriptVm.Grammar.Nodes
{
    public class SubstractionAssignmentNode: AssignmentNode
    {
        protected override string AssignmentToken { get; } = "-=";

        public SubstractionAssignmentNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {
        }

        
    }
}