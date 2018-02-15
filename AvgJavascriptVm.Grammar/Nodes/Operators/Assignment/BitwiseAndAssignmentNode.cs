namespace AvgJavascriptVm.Grammar.Nodes
{
    public class BitwiseAndAssignmentNode: AssignmentNode
    {
        protected override string AssignmentToken { get; } = "&=";

        public BitwiseAndAssignmentNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {
        }
    }
}