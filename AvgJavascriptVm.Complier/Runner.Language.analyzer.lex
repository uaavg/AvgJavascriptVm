%namespace AvgJavascriptVm.Complier
%scannertype RunnerScanner
%visibility internal
%tokentype Token

%option stack, minimize, parser, verbose, persistbuffer, noembedbuffers 

Eol             (\r\n?|\n)
Space           [ \t]
Number          [0-9]+(\.[0-9]+)?
Identifier      [a-z]+([a-z]|[0-9])*

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
";"             { return (int)Token.SEMICOLON; }
","             { return (int)Token.COMMA; }
"("             { return (int)Token.LPARENTH; }
")"             { return (int)Token.RPARENTH; }
"{"             { return (int)Token.LCURLYBRACE; }
"}"             { return (int)Token.RCURLYBRACE; }
"["             { return (int)Token.LBRACKET; }
"]"             { return (int)Token.RBRACKET; }
"="             { return (int)Token.ASSIGN; }
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