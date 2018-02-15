using System;
using AvgJavascriptVm.Grammar.Helpers;

namespace AvgJavascriptVm.Grammar.Nodes
{
    public class AssignmentNode: ExpressionNode
    {
        public ExpressionNode LValue { get; }

        public ExpressionNode RValue { get; }

        protected virtual string AssignmentToken { get; } = "=";

        public AssignmentNode(ExpressionNode lValue, ExpressionNode rValue)
        {
            if (!(lValue is IdentifierNode) && !(lValue is IndexerGetterNode) && !(lValue is PropertyGetterNode))
            {
                throw new ApplicationException("lvalue must be identifier, indexer getter or property getter node");
            }
            LValue = lValue;
            RValue = rValue;
        }

        public override void ToString(NodeStringBuilder strBuilder)
        {
            LValue.ToString(strBuilder);
            strBuilder.Append($" {AssignmentToken} ");
            RValue.ToString(strBuilder);
        }
    }
}