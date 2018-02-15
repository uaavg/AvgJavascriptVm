namespace AvgJavascriptVm.Grammar.Nodes
{
    public class BitwiseOrAssignmentNode: AssignmentNode
    {
        protected override string AssignmentToken { get; } = "|=";

        public BitwiseOrAssignmentNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }
    }
}