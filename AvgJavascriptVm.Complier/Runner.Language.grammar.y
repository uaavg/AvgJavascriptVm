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

%token FUNCTION, IF, WHILE, DO, FOR, RETURN
%token SEMICOLON, COMMA,  LPARENTH, RPARENTH, LCURLYBRACE, RCURLYBRACE
%token NUMBER, IDENTIFIER

%%

main : statements { Result = (StatementsNode)$1.n; }
     | 
     ;

statements : /* empty */ { $$.n = new StatementsNode(); }
           | statement { var stmts = new StatementsNode(); stmts.Statements.Add((StatementNode)$1.n); $$.n = stmts; }
           | statements statement { ((StatementsNode)$1.n).Statements.Add((StatementNode)$2.n); }
           ;

statement : block { $$.n = $1.n; }
          | function_declaration { $$.n = $1.n; }
		  | while
		  | dowhile
		  | for		  		  
	      ;

expression: IDENTIFIER { $$.n = new IdentifierNode($1.str); }
          ;

block : LCURLYBRACE statements RCURLYBRACE { $$.n = new BlockNode((StatementsNode)$2.n); }
      ;

function_declaration : FUNCTION IDENTIFIER LPARENTH arguments_list RPARENTH function_body { $$.n = new FunctionNode(new IdentifierNode($2.str), (ArgumentsListNode)$4.n, (BlockNode)$6.n); }
                     ;

function_body : LCURLYBRACE function_statements RCURLYBRACE { $$.n = new BlockNode((StatementsNode)$2.n); }
              ;

function_statements : /* empty */ { $$.n = new StatementsNode(); }
                    | function_statement { var stmts = new StatementsNode(); stmts.Statements.Add((StatementNode)$1.n); $$.n = stmts; }
                    | function_statements function_statement { ((StatementsNode)$1.n).Statements.Add((StatementNode)$2.n); }
					;

function_statement: statement { $$.n = $1.n; }
                  | return { $$.n = $1.n; }
				  ;

return: RETURN SEMICOLON { $$.n = new ReturnNode(); }
      | RETURN expression SEMICOLON { $$.n = new ReturnNode((ExpressionNode)$2.n); }
                     ;
while : WHILE LPARENTH expression RPARENTH expression { $$.n = new WhileNode((ExpressionNode)$3.n, (StatementNode)$5.n); }
      | WHILE LPARENTH expression RPARENTH block { $$.n = new WhileNode((ExpressionNode)$3.n, (StatementNode)$5.n); }
	  ;

dowhile : DO block WHILE LPARENTH expression RPARENTH SEMICOLON { $$.n = new DoWhileNode((ExpressionNode)$5.n, (StatementNode)$2.n); }
        ;

for : FOR LPARENTH expression_or_empty SEMICOLON expression_or_empty SEMICOLON expression_or_empty RPARENTH expression { $$.n = new ForNode((StatementNode)$3.n, (StatementNode)$5.n, (StatementNode)$7.n, (StatementNode)$9.n); }
    | FOR LPARENTH expression_or_empty SEMICOLON expression_or_empty SEMICOLON expression_or_empty RPARENTH block { $$.n = new ForNode((StatementNode)$3.n, (StatementNode)$5.n, (StatementNode)$7.n, (StatementNode)$9.n); }
	| FOR LPARENTH expression_or_empty SEMICOLON expression_or_empty SEMICOLON expression_or_empty RPARENTH SEMICOLON { $$.n = new ForNode((StatementNode)$3.n, (StatementNode)$5.n, (StatementNode)$7.n, null); }
	;

expression_or_empty : expression { $$.n = $1.n; }
                    | /* empty */ 
					;

arguments_list : IDENTIFIER { $$.n = new ArgumentsListNode(new IdentifierNode($1.str)); }
               | arguments_list COMMA IDENTIFIER { $$.n = new ArgumentsListNode((ArgumentsListNode)$1.n, new IdentifierNode($3.str)); }
			   | /* empty */ { $$.n = new ArgumentsListNode(); }
               ;
%%