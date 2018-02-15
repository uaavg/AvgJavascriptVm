namespace AvgJavascriptVm.Grammar.Nodes
{
    public class DivisonAssignmentNode: AssignmentNode
    {
        protected override string AssignmentToken { get; } = "/=";

        public DivisonAssignmentNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {
        }
    }
}