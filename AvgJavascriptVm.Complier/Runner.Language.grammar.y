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

%token FUNCTION, IF, WHILE, DO, FOR
%token SEMICOLON, COMMA,  LPARENTH, RPARENTH, LCURLYBRACE, RCURLYBRACE
%token NUMBER, IDENTIFIER

%%

main : statements { Result = (StatementsNode)$1.n; }
     | 
     ;

statements : 
           | statement { var stmts = new StatementsNode(); stmts.Statements.Add((StatementNode)$1.n); $$.n = stmts; }
           | statements statement { ((StatementsNode)$1.n).Statements.Add((StatementNode)$2.n); }
           ;

statement : block { $$.n = $1.n; }
          | function_declaration { $$.n = $1.n; }
	      ;

function_declaration : FUNCTION IDENTIFIER LPARENTH arguments_list RPARENTH function_body { $$.n = new FunctionNode(new IdentifierNode($2.str), (ArgumentsListNode)$4.n, (BlockNode)$6.n); }
                     ;

function_body : block { $$.n = $1.n; }
              ;

block : LCURLYBRACE RCURLYBRACE { $$.n = new BlockNode(new StatementsNode()); }
      ;

arguments_list : IDENTIFIER { $$.n = new ArgumentsListNode(new IdentifierNode($1.str)); }
               | arguments_list COMMA IDENTIFIER { $$.n = new ArgumentsListNode((ArgumentsListNode)$1.n, new IdentifierNode($3.str)); }
			   | /* empty */ { $$.n = new ArgumentsListNode(); }
               ;
%%