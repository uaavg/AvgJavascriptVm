namespace AvgJavascriptVm.Grammar.Nodes
{
    public class ExponentiationAssignmentNode: AssignmentNode
    {
        protected override string AssignmentToken { get; } = "**=";

        public ExponentiationAssignmentNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }        
    }
}