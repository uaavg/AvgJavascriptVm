namespace AvgJavascriptVm.Grammar.Nodes
{
    public class UnsignedRightShiftAssignmentNode: AssignmentNode
    {
        protected override string AssignmentToken { get; } = ">>>=";

        public UnsignedRightShiftAssignmentNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }
    }
}