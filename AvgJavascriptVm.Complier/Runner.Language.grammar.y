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
%token SEMICOLON, DOT, COMMA,  LPARENTH, RPARENTH, LCURLYBRACE, RCURLYBRACE, ASSIGN, LBRACKET, RBRACKET, COLON
%token NUMBER, IDENTIFIER, STRING
%token THEN

%nonassoc THEN 
%nonassoc ELSE

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

statement_expression : statement_expression_no_property_getter { $$.n = $1.n; }
					 | property_getter { $$.n = $1.n; }
					 | LPARENTH expression RPARENTH { $$.n = $2.n; }
					 ;

statement_expression_no_property_getter : IDENTIFIER { $$.n = new IdentifierNode($1.str); }
										| NUMBER { $$.n = new NumberNode($1.num); }
										| STRING { $$.n = new StringNode($1.str); }
										| boolean { $$.n = $1.n; }
										| array { $$.n = $1.n; }
										| object { $$.n = $1.n; }
										| function_invocation { $$.n = $1.n; }	
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

function_invocation : statement_expression_no_property_getter LPARENTH function_invocation_arguments_list RPARENTH { $$.n = new FunctionInvocationNode((ExpressionNode)$1.n, (FunctionInvocationArgumentsListNode)$3.n); }		
                    | property_getter LPARENTH function_invocation_arguments_list RPARENTH { var pg = (PropertyGetterNode)$1.n; $$.n = new MethodInvocationNode(pg.This, pg.Property, (FunctionInvocationArgumentsListNode)$3.n); }		
					;

function_invocation_arguments_list  : expression { $$.n = new FunctionInvocationArgumentsListNode((ExpressionNode)$1.n); }
                                    | function_invocation_arguments_list COMMA expression { var al = (FunctionInvocationArgumentsListNode)$1.n; $$.n = al; al.Arguments.Add((ExpressionNode)$3.n); }
			                        | /* empty */ { $$.n = new FunctionInvocationArgumentsListNode(); }
                                    ;
indexer_getter : statement_expression_no_property_getter LBRACKET expression RBRACKET { $$.n = new IndexerGetterNode((ExpressionNode)$1.n, (ExpressionNode)$3.n); }
               ;

property_getter : statement_expression DOT IDENTIFIER { $$.n = new PropertyGetterNode((ExpressionNode)$1.n, new IdentifierNode($3.str)); }
                ;


				 
%%