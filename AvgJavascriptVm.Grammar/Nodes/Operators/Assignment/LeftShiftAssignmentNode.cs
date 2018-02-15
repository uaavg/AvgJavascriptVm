namespace AvgJavascriptVm.Grammar.Nodes
{
    public class LeftShiftAssignmentNode: AssignmentNode
    {
        protected override string AssignmentToken { get; } = "<<=";

        public LeftShiftAssignmentNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }        
    }
}