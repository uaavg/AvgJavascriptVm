%namespace AvgJavascriptVm.Complier
%using AvgJavascriptVm.Core.BaseTypes
%using AvgJavascriptVm.Grammar.Nodes
%partial
%parsertype RunnerParser
%visibility internal
%tokentype Token

%union { 			
			public double num;
            public string str;
			public Node n;
			public object add;
	   }

%start main

%token FUNCTION, IF, ELSE, WHILE, DO, FOR, RETURN, VAR, TRUE, FALSE
%token SEMICOLON, DOT, COMMA,  LPARENTH, RPARENTH, LCURLYBRACE, RCURLYBRACE, LBRACKET, RBRACKET, COLON
%token ASSIGN, ADDASSG, SUBASSG, MULTASSG, DIVASSG, REMASSG, EXPASSG, LEFTSHFTASG, RIGHTSHFTASSG, URIGHTSHIFTASSG, BITWISEANDASSG, BITWISEXORASSG, BITWISEORASSG
%token REMAINDER, INCREMENT, DECREMENT, EXPONENTIATION, ADDITION, SUBTRACTION, MULTIPLICATION, DIVISION, UNARYPLUS, UNARYMINUS, POSTFIX, PREFIX
%token BITWISEAND, BITWISEOR, BITWISEXOR, BITWISENOT, LEFTSHIFT, ZEROFILLRIGHTSHIFT, SIGNPROPRIGHTSHIFT
%token NUMBER, IDENTIFIER, STRING
%token THEN

%nonassoc THEN 
%nonassoc ELSE
%right ASSIGN, ADDASSG, SUBASSG, MULTASSG, DIVASSG, REMASSG, EXPASSG, LEFTSHFTASSG, RIGHTSHFTASSG, URIGHTSHFTASSG, BITWISEANDASSG, BITWISEXORASSG, BITWISEORASSG
%left STRICTEQUAL, STRICTNOTEQUAL, EQUAL, NOTEQUAL
%left GREATERTHAN, GREATERTHANOREQUAL, LESSTHAN, LESSTHANOREQUAL
%left ADDITION, SUBTRACTION
%left MULTIPLICATION, DIVISION, REMAINDER
%left EXPONENTIATION
%right UNARYPLUS, UNARYMINUS, PREFIX, INCREMENT, DECREMENT
%nonassoc POSTFIX
%left DOT
%left RBRACKET, LBRACKET
%nonassoc LPARENTH, RPARENTH


%%

main : statements_and_declarations { CheckIfReturnInMain(); Result = (StatementsAndDeclarations)$1.n; $$.n = Result; }
     | /* empty */ { Result = new StatementsAndDeclarations(); $$.n = Result; }
     ;

statements_and_declarations : statement_or_declaration { var nodes = new StatementsAndDeclarations(); nodes.Nodes.Add($1.n); $$.n = nodes; }
                            | statements_and_declarations statement_or_declaration { var nodes = ((StatementsAndDeclarations)$1.n); nodes.Nodes.Add($2.n);  $$.n = nodes;}
							;

statement_or_declaration : statement
                         | function_declaration
						 ;

statements : statement { var stmts = new StatementsNode(); stmts.Statements.Add((StatementNode)$1.n); $$.n = stmts; }
           | statements statement { ((StatementsNode)$1.n).Statements.Add((StatementNode)$2.n); }
           ;

statement : block { $$.n = $1.n; } 
		  | while { $$.n = $1.n; }
		  | dowhile { $$.n = $1.n; }
		  | for { $$.n = $1.n; }
		  | if { $$.n = $1.n; }
		  | return { $$.n = $1.n; }
		  | variable_declaration SEMICOLON { $$.n = $1.n; }
		  | statement_expression SEMICOLON { $$.n = $1.n;}
	      ;

expression : statement_expression { $$.n = $1.n; }
           | function_expression { $$.n = $1.n; }
		   | function_named_expression { $$.n = $1.n; }
           ;

statement_expression : assignment { $$.n = $1.n; }							 
                     | binary_valid_expression { $$.n = $1.n; }
					 ;

binary_valid_expression : arithmetic { $$.n = $1.n; }
                        | indexer_expression { $$.n = $1.n; }
						| comparison { $$.n = $1.n; }
						;

indexer_expression : lvalue
                   | NUMBER { $$.n = new NumberNode($1.num); }
				   | STRING { $$.n = new StringNode($1.str); }
				   | boolean { $$.n = $1.n; }
				   | array { $$.n = $1.n; }
				   | object { $$.n = $1.n; }				   
				   | function_invocation { $$.n = $1.n; }				   				   	   
				   | LPARENTH expression RPARENTH { $$.n = $2.n; }	
				   ;

lvalue : IDENTIFIER { $$.n = new IdentifierNode($1.str); }
       | property_getter { $$.n = $1.n; }
       | indexer_getter { $$.n = $1.n; }
	   ;

block : LCURLYBRACE RCURLYBRACE { $$.n = new BlockNode((StatementsNode)$2.n); } 
      | LCURLYBRACE statements RCURLYBRACE { $$.n = new BlockNode((StatementsNode)$2.n); }
      ;

statement_or_semicolon : statement { $$.n = $1.n; } 
                       | SEMICOLON { $$.n = new EmptyExpression(); }
					   ; 
 
function_declaration : FUNCTION IDENTIFIER LPARENTH arguments_list RPARENTH function_body { $$.n = new FunctionDeclarationNode(new IdentifierNode($2.str), (ArgumentsListNode)$4.n, (StatementsAndDeclarations)$6.n); LastReturnNode = null; }
                     ;

function_expression : FUNCTION LPARENTH arguments_list RPARENTH function_body { $$.n = new FunctionExpressionNode((ArgumentsListNode)$3.n, (StatementsAndDeclarations)$5.n); LastReturnNode = null; }
					;

function_named_expression : FUNCTION IDENTIFIER LPARENTH arguments_list RPARENTH function_body {$$.n = new FunctionNamedExpressionNode(new IdentifierNode($2.str), (ArgumentsListNode)$4.n, (StatementsAndDeclarations)$6.n); LastReturnNode = null; }
					;


function_body : LCURLYBRACE RCURLYBRACE { $$.n = new StatementsAndDeclarations(); }
              | LCURLYBRACE statements_and_declarations RCURLYBRACE { $$.n = $2.n; }
              ;

return: RETURN SEMICOLON { LastReturnNode = new ReturnNode(); $$.n = LastReturnNode; }
      | RETURN expression SEMICOLON { LastReturnNode = new ReturnNode(); $$.n = LastReturnNode; }
                     ;

arguments_list : IDENTIFIER { $$.n = new ArgumentsListNode(new IdentifierNode($1.str)); }
               | arguments_list COMMA IDENTIFIER { $$.n = new ArgumentsListNode((ArgumentsListNode)$1.n, new IdentifierNode($3.str)); }
			   | /* empty */ { $$.n = new ArgumentsListNode(); }
               ;

while : WHILE LPARENTH expression RPARENTH statement_or_semicolon { $$.n = new WhileNode((ExpressionNode)$3.n, (StatementNode)$5.n); }      
	  ;

dowhile : DO block WHILE LPARENTH expression RPARENTH SEMICOLON { $$.n = new DoWhileNode((ExpressionNode)$5.n, (StatementNode)$2.n); }
        ;

for : FOR LPARENTH expression_or_empty SEMICOLON expression_or_empty SEMICOLON expression_or_empty RPARENTH statement_or_semicolon { $$.n = new ForNode((StatementNode)$3.n, (StatementNode)$5.n, (StatementNode)$7.n, (StatementNode)$9.n); }    
	;

expression_or_empty : expression { $$.n = $1.n; }
                    | /* empty */ 
					;

if : IF LPARENTH expression RPARENTH statement_or_semicolon %prec THEN { $$.n = new IfNode((ExpressionNode)$3.n, (StatementNode)$5.n); } 
   | IF LPARENTH expression RPARENTH statement_or_semicolon ELSE statement_or_semicolon  { $$.n = new IfElseNode((ExpressionNode)$3.n, (StatementNode)$5.n, (StatementNode)$7.n); }
   ;

variable_declaration : VAR variable_declaration_identifier { $$.n = new VariableDeclarationNode((VariableDeclarationIdentifierNode)$2.n); }
                     | variable_declaration COMMA variable_declaration_identifier { var nodes = ((VariableDeclarationNode)$1.n); nodes.Declarations.Add((VariableDeclarationIdentifierNode)$3.n); $$.n = nodes; }
					 ;

variable_declaration_identifier : IDENTIFIER { $$.n = new VariableDeclarationIdentifierNode($1.str); }
                                | IDENTIFIER ASSIGN expression { $$.n = new VariableDeclarationIdentifierNode($1.str, (ExpressionNode)$3.n); }
					            ;

boolean : TRUE { $$.n = new BooleanNode(true); }
        | FALSE { $$.n = new BooleanNode(false); }
		;

array : LBRACKET array_list RBRACKET { $$.n = $2.n; }
      | LBRACKET RBRACKET { $$.n = new ArrayNode(); }
	  ;

array_list : expression { var arr = new ArrayNode(); arr.Values.Add((ExpressionNode)$1.n); $$.n = arr; }
           | array_list COMMA expression { var arr = (ArrayNode)$1.n; arr.Values.Add((ExpressionNode)$3.n); $$.n = arr; }
		   ;

object : LCURLYBRACE object_properties_list RCURLYBRACE { $$.n = new ObjectNode((List<ObjectPropertyNode>)$2.add); }
       ;

object_properties_list : object_property { var l = new List<ObjectPropertyNode>(); l.Add((ObjectPropertyNode)$1.n); $$.add = l; }
                       | object_property COMMA object_properties_list { var l = (List<ObjectPropertyNode>)$3.add; l.Add((ObjectPropertyNode)$1.n); $$.add = l; }
					   ;

object_property : object_property_identifier COLON expression { $$.n = new ObjectPropertyNode((ObjectPropertyIdentifierNode)$1.n, (ExpressionNode)$3.n); }
                ;

object_property_identifier : IDENTIFIER { $$.n = new ObjectPropertyIdentifierNode(new IdentifierNode($1.str)); }
                           | STRING { $$.n = new ObjectPropertyIdentifierNode(new StringNode($1.str)); }
                           ;

function_invocation : indexer_expression LPARENTH function_invocation_arguments_list RPARENTH { $$.n = new FunctionInvocationNode((ExpressionNode)$1.n, (FunctionInvocationArgumentsListNode)$3.n); }		                    
					;

function_invocation_arguments_list  : expression { $$.n = new FunctionInvocationArgumentsListNode((ExpressionNode)$1.n); }
                                    | function_invocation_arguments_list COMMA expression { var al = (FunctionInvocationArgumentsListNode)$1.n; $$.n = al; al.Arguments.Add((ExpressionNode)$3.n); }
			                        | /* empty */ { $$.n = new FunctionInvocationArgumentsListNode(); }
                                    ;

indexer_getter : indexer_expression LBRACKET expression RBRACKET { $$.n = new IndexerGetterNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
               ;

property_getter : indexer_expression DOT IDENTIFIER { $$.n = new PropertyGetterNode((ExpressionNode)$1.n, new IdentifierNode($3.str)); }
                ;

assignment : lvalue ASSIGN expression { $$.n = new AssignmentNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); } 
           | lvalue ADDASSG expression { $$.n = new AdditionAssignmentNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | lvalue SUBASSG expression { $$.n = new SubstractionAssignmentNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | lvalue MULTASSG expression { $$.n = new MultiplicationAssignmentNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | lvalue DIVASSG expression { $$.n = new DivisonAssignmentNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | lvalue REMASSG expression { $$.n = new RemainderAssignmentNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | lvalue EXPASSG expression { $$.n = new ExponentiationAssignmentNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | lvalue LEFTSHFTASG expression { $$.n = new LeftShiftAssignmentNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | lvalue RIGHTSHFTASSG expression { $$.n = new RightShiftAssignmentNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | lvalue URIGHTSHFTASSG expression { $$.n = new UnsignedRightShiftAssignmentNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | lvalue BITWISEANDASSG expression { $$.n = new BitwiseAndAssignmentNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | lvalue BITWISEXORASSG expression { $$.n = new BitwiseXorAssignmentNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | lvalue BITWISEORASSG expression { $$.n = new BitwiseOrAssignmentNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   ;

comparison : binary_valid_expression EQUAL binary_valid_expression { $$.n = new EqualNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
           | binary_valid_expression NOTEQUAL binary_valid_expression { $$.n = new NotEqualNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | binary_valid_expression STRICTEQUAL binary_valid_expression { $$.n = new StrictEqualNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | binary_valid_expression STRICTNOTEQUAL binary_valid_expression { $$.n = new StrictNotEqualNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | binary_valid_expression GREATERTHAN binary_valid_expression { $$.n = new GreaterThanNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | binary_valid_expression GREATERTHANOREQUAL binary_valid_expression { $$.n = new GreaterThanOrEqualNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | binary_valid_expression LESSTHAN binary_valid_expression { $$.n = new LessThanNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | binary_valid_expression LESSTHANOREQUAL binary_valid_expression { $$.n = new LessThanOrEqualNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   ;

arithmetic : binary_valid_expression ADDITION binary_valid_expression { $$.n = new AdditionNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }         
           | binary_valid_expression SUBTRACTION binary_valid_expression { $$.n = new SubtractionNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); } 
		   | binary_valid_expression MULTIPLICATION binary_valid_expression { $$.n = new MultiplicationNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | binary_valid_expression DIVISION binary_valid_expression { $$.n = new DivisionNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | binary_valid_expression REMAINDER indexer_expression { $$.n = new RemainderNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); } 
		   | binary_valid_expression EXPONENTIATION binary_valid_expression { $$.n = new ExponentiationNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
		   | ADDITION indexer_expression %prec UNARYPLUS { $$.n = new UnaryPlusNode((ExpressionNode)$2.n); } 
		   | SUBTRACTION indexer_expression %prec UNARYMINUS { $$.n = new UnaryNegationNode((ExpressionNode)$2.n); } 		   
		   | INCREMENT lvalue %prec PREFIX { $$.n = new PrefixIncrement((ExpressionNode)$1.n); } 		   
		   | lvalue INCREMENT %prec POSTFIX { $$.n = new PostfixIncrement((ExpressionNode)$1.n); } 
		   | DECREMENT lvalue %prec PREFIX { $$.n = new PrefixDecrement((ExpressionNode)$2.n); } 
		   | lvalue DECREMENT %prec POSTFIX { $$.n = new PostfixDecrement((ExpressionNode)$1.n); }
		   ;

%%