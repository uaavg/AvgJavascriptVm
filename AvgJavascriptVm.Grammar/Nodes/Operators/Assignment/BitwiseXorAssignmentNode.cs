namespace AvgJavascriptVm.Grammar.Nodes
{
    public class BitwiseXorAssignmentNode: AssignmentNode
    {
        protected override string AssignmentToken { get; } = "^=";

        public BitwiseXorAssignmentNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }
    }
}