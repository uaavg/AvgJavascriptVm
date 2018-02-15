%namespace AvgJavascriptVm.Complier
%scannertype RunnerScanner
%visibility internal
%tokentype Token

%option stack, minimize, parser, verbose, persistbuffer, noembedbuffers 

Eol             (\r\n?|\n)
Space           [ \t]
Number          [0-9]+(\.[0-9]+)?
Identifier      [a-zA-Z]+([a-zA-Z]|[0-9])*

%x STRING

%{

%}

%%

/* Scanner body */

"function"      { return (int)Token.FUNCTION; } 
"if"            { return (int)Token.IF; }
"else"          { return (int)Token.ELSE; }
"while"         { return (int)Token.WHILE; }
"do"            { return (int)Token.DO; }
"for"           { return (int)Token.FOR; }
"return"        { return (int)Token.RETURN; }
"var"           { return (int)Token.VAR; }
"true"          { return (int)Token.TRUE; }
"false"         { return (int)Token.TRUE; }


"==="           { return (int)Token.STRICTEQUAL; }
"!=="           { return (int)Token.STRICTNOTEQUAL; }
"=="            { return (int)Token.EQUAL; }
"!="            { return (int)Token.NOTEQUAL; }
">"             { return (int)Token.GREATERTHAN; }
">="            { return (int)Token.GREATERTHANOREQUAL; }
"<"             { return (int)Token.LESSTHAN; }
"<="            { return (int)Token.LESSTHANOREQUAL; }

"="             { return (int)Token.ASSIGN; }
"+="            { return (int)Token.ADDASSG; }
"-="            { return (int)Token.SUBASSG; }
"*="            { return (int)Token.MULTASSG; }
"/="            { return (int)Token.DIVASSG; }
"%="            { return (int)Token.REMASSG; }
"**="           { return (int)Token.EXPASSG; }
"<<="           { return (int)Token.LEFTSHFTASSG; }
">>="           { return (int)Token.RIGHTSHFTASSG; }
">>>="          { return (int)Token.URIGHTSHFTASSG; }
"&="            { return (int)Token.BITWISEANDASSG; }
"^="            { return (int)Token.BITWISEXORASSG; }
"|="            { return (int)Token.BITWISEORASSG; }

"%"             { return (int)Token.REMAINDER; }
"++"            { return (int)Token.INCREMENT; }
"--"            { return (int)Token.DECREMENT; }
"**"            { return (int)Token.EXPONENTIATION; } 
"+"             { return (int)Token.ADDITION; } 
"-"             { return (int)Token.SUBTRACTION; } 
"*"             { return (int)Token.MULTIPLICATION; } 
"/"             { return (int)Token.DIVISION; } 

"&"             { return (int)Token.BITWISEAND; } 
"|"             { return (int)Token.BITWISEOR; } 
"^"             { return (int)Token.BITWISEXOR; } 
"~"             { return (int)Token.BITWISENOT; } 
"<<"            { return (int)Token.LEFTSHIFT; } 
">>>"           { return (int)Token.ZEROFILLRIGHTSHIFT; } 
">>"            { return (int)Token.SIGNPROPRIGHTSHIFT; } 

";"             { return (int)Token.SEMICOLON; }
","             { return (int)Token.COMMA; }
"."             { return (int)Token.DOT; }
"("             { return (int)Token.LPARENTH; }
")"             { return (int)Token.RPARENTH; }
"{"             { return (int)Token.LCURLYBRACE; }
"}"             { return (int)Token.RCURLYBRACE; }
"["             { return (int)Token.LBRACKET; }
"]"             { return (int)Token.RBRACKET; }
":"             { return (int)Token.COLON; }
{Number}		{ GetNumber(); return (int)Token.NUMBER; }
{Identifier}    { GetIdentifier(); return (int)Token.IDENTIFIER; }
{Space}+		/* skip */

/* Begin string */
(\"|\')                                            { BeginString(); }
<STRING>(\"|\')                                    { if(AppendString()) return (int)Token.STRING; }
<STRING>\\[b|t|n|v|f|f|r|\"|\'|\\]                 { AppendStringEscapedSymbol(); }
<STRING>\\u([0-9a-fA-F]){4}                        { AppendStringUnicodeSymbol(); }
<STRING>[\r|\n|\v]                                 { throw new ApplicationException("Inside string cannot contains end of line"); }
<STRING>[^(\r\n?|\n)|\"|\'|\\]*                    { AppendString(); }       
/* End string */


%{
  yylloc = new QUT.Gppg.LexLocation(tokLin, tokCol, tokELin, tokECol);
%}


%%