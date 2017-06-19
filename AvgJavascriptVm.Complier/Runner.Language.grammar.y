%namespace AvgJavascriptVm.Complier
%using AvgJavascriptVm.Core.BaseTypes
%partial
%parsertype RunnerParser
%visibility internal
%tokentype Token

%union { 			
            public JsValue v;
	   }

%start main

%token FUNCTION, IF, WHILE, DO, FOR
%token SEMICOLON, COMMA,  LPARENTH, RPARENTH, LCURLYBRACE, RCURLYBRACE
%token NUMBER, IDENTIFIER

%%

main : statements
     ;

statements : 
           | statement
           | statements statement
           ;

statement : block 
          | function_declaration
	      ;

function_declaration : FUNCTION LPARENTH arguments_list RPARENTH function_body
                     ;

function_body : block
              ;

block : LCURLYBRACE RCURLYBRACE
      ;

arguments_list : IDENTIFIER
               | arguments_list COMMA IDENTIFIER
               ;
%%