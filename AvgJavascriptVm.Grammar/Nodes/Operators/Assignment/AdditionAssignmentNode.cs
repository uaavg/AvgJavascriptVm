namespace AvgJavascriptVm.Grammar.Nodes
{
    public class AdditionAssignmentNode: AssignmentNode
    {
        protected override string AssignmentToken { get; } = "+=";

        public AdditionAssignmentNode(ExpressionNode lValue, ExpressionNode rValue) : base(lValue, rValue)
        {

        }        
    }
}