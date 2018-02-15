namespace AvgJavascriptVm.Grammar.Nodes
{
    public class RightShiftAssignmentNode: AssignmentNode
    {
        protected override string AssignmentToken { get; } = ">>=";

        public RightShiftAssignmentNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }    
    }
}