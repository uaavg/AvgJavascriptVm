namespace AvgJavascriptVm.Grammar.Nodes
{
    public class MultiplicationAssignmentNode: AssignmentNode
    {
        protected override string AssignmentToken { get; } = "*=";

        public MultiplicationAssignmentNode(ExpressionNode lValue, ExpressionNode rValue):
            base(lValue, rValue)
        {
            
        }        
    }
}