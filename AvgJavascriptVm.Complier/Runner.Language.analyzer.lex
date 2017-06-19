%namespace AvgJavascriptVm.Complier
%scannertype RunnerScanner
%visibility internal
%tokentype Token

%option stack, minimize, parser, verbose, persistbuffer, noembedbuffers 

Eol             (\r\n?|\n)
Space           [ \t]
Number          [0-9]+(.[0-9]+)?
Identifier      [a-z]+([a-z]|[0-9])*

%{

%}

%%

/* Scanner body */

"function"      { return (int)Token.FUNCTION; } 
"if"            { return (int)Token.IF; }
"while"         { return (int)Token.WHILE; }
"do"            { return (int)Token.DO; }
"for"           { return (int)Token.FOR; }
";"             { return (int)Token.SEMICOLON; }
","             { return (int)Token.COMMA; }
"("             { return (int)Token.LPARENTH; }
")"             { return (int)Token.RPARENTH; }
"{"             { return (int)Token.LCURLYBRACE; }
"}"             { return (int)Token.RCURLYBRACE; }
{Number}		{ GetNumber(); return (int)Token.NUMBER; }
{Identifier}    { GetIdentifier(); return (int)Token.IDENTIFIER; }
{Space}+		/* skip */

%%