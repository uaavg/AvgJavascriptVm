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
	   }

%start main

%token FUNCTION, IF, ELSE, WHILE, DO, FOR, RETURN
%token SEMICOLON, COMMA,  LPARENTH, RPARENTH, LCURLYBRACE, RCURLYBRACE
%token NUMBER, IDENTIFIER
%token THEN

%nonassoc THEN 
%nonassoc ELSE

%%

main : statements_and_declarations { CheckIfReturnInMain(); Result = (StatementsAndDeclarations)$1.n; }
     | /* empty */ { Result = new StatementsAndDeclarations(); }
     ;

statements_and_declarations : statement_or_declaration { var nodes = new StatementsAndDeclarations(); nodes.Nodes.Add($1.n); $$.n = nodes; }
                            | statements_and_declarations statement_or_declaration { ((StatementsAndDeclarations)$1.n).Nodes.Add($2.n); }
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
	      ;

expression: IDENTIFIER { $$.n = new IdentifierNode($1.str); }
          ;

block : LCURLYBRACE RCURLYBRACE { $$.n = new BlockNode((StatementsNode)$2.n); } 
      | LCURLYBRACE statements RCURLYBRACE { $$.n = new BlockNode((StatementsNode)$2.n); }
      ;

statement_or_expression_or_semicolon: statement { $$.n = $1.n; } 
                                    | expression SEMICOLON { $$.n = $1.n; }
								    | SEMICOLON { $$.n = new EmptyExpression(); }
					                ; 
 
function_declaration : FUNCTION IDENTIFIER LPARENTH arguments_list RPARENTH function_body { $$.n = new FunctionDeclarationNode(new IdentifierNode($2.str), (ArgumentsListNode)$4.n, (StatementsAndDeclarations)$6.n); LastReturnNode = null; }
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

while : WHILE LPARENTH expression RPARENTH statement_or_expression_or_semicolon { $$.n = new WhileNode((ExpressionNode)$3.n, (StatementNode)$5.n); }      
	  ;

dowhile : DO block WHILE LPARENTH expression RPARENTH SEMICOLON { $$.n = new DoWhileNode((ExpressionNode)$5.n, (StatementNode)$2.n); }
        ;

for : FOR LPARENTH expression_or_empty SEMICOLON expression_or_empty SEMICOLON expression_or_empty RPARENTH statement_or_expression_or_semicolon { $$.n = new ForNode((StatementNode)$3.n, (StatementNode)$5.n, (StatementNode)$7.n, (StatementNode)$9.n); }    
	;

expression_or_empty : expression { $$.n = $1.n; }
                    | /* empty */ 
					;

if : IF LPARENTH expression RPARENTH statement_or_expression_or_semicolon %prec THEN { $$.n = new IfNode((ExpressionNode)$3.n, (StatementNode)$5.n); } 
   | IF LPARENTH expression RPARENTH statement_or_expression_or_semicolon ELSE statement_or_expression_or_semicolon  { $$.n = new IfElseNode((ExpressionNode)$3.n, (StatementNode)$5.n, (StatementNode)$7.n); }
   ;
		
%%