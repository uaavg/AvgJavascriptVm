namespace AvgJavascriptVm.Grammar.Nodes
{
    public class RemainderAssignmentNode: AssignmentNode
    {
        protected override string AssignmentToken { get; } = "%=";

        public RemainderAssignmentNode(ExpressionNode lValue, ExpressionNode rValue) : 
            base(lValue, rValue)
        {

        }        
    }
}