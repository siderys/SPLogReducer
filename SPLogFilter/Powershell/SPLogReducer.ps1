
#Require -Version 5.0

# PowerShell 5.0 now supports <using namespace NameSpace> sysntax like C#!

using namespace System.Collections.Generic;

CLS
  	
$PSScriptRoot
#region File Paths
[System.String]$scriptPath=$MyInvocation.MyCommand.Path
[System.String]$libraryFile= $PSScriptRoot + '\bin\Debug\SPLogFilter.dll'
[System.String]$fileName = 'C:\@Borrar\LogToReduce.log'
#endregion

[System.Reflection.Assembly]::LoadFile($libraryFile)

$colMsg=[SPLogFilter.LogTools+LogColumn]::Message
$colLev=[SPLogFilter.LogTools+LogColumn]::Level

#region Big File Parallel Processed
$logFileLines=[SPLogFilter.LogTools]::LoadLogFile($fileName) #Try not repeat without sense
#endregion

#region Sample Executions
[SPLogFilter.TextSearch]::Find($fileName, 'Table RequestUsage_Partition27 has 2066800640 bytes', $logFileLines, $colMsg);# You get a "FindMessage" folder for all searches you do
[SPLogFilter.Splitter]::Split($fileName, $logFileLines, [SPLogFilter.LogTools+LogColumn]::$colLev); # You get a "ByLevel" folder with any level into the log file
#endregion
