///////////////////////////////////////////////////////////////////////
//
// FILENAME: UpdateVersion.js
//
// DESCRIPTION: Updates build version in AssemblyInfo.cs file
//
//
///////////////////////////////////////////////////////////////////////
//


// Parse Command Line
var argc = WScript.arguments.length;
if (argc > 0) {
    strPATH = WScript.arguments.item(0);
}
if (argc > 1) {
    strBuildNo = WScript.arguments.item(1);
}

var fso = WScript.CreateObject("Scripting.FileSystemObject");
var strFileIN = strPATH + "AssemblyInfo.cs"
var strFileOUT = strPATH + "AssemblyInfoTemp.cs"

WScript.echo("Updating " + strFileIN + " to Version: " + GetNewVersionString());

var ts = fso.OpenTextFile(strFileIN);
var tsOUT = fso.CreateTextFile(strFileOUT);

//Loop while not at the end of file.
var strLine;
var re = /AssemblyVersion\(\"[0-9,\.,\*]*\"\)/;
while (!ts.AtEndOfStream) {
    strLine = ts.ReadLine();
    tsOUT.WriteLine(strLine.replace(re, "AssemblyVersion(" + GetNewVersionString() + ")"));
    //WScript.echo(strLine);
}


//Close the file.
ts.Close();
tsOUT.Close();

// Replace the original file 
fso.CopyFile(strFileOUT, strFileIN, true);
fso.DeleteFile(strFileOUT, true);
fso = null;


function GetNewVersionString() {
    var result = 0;
    var strFile = strBuildNo;
    if (strFile == "")
        strFile = fso.GetParentFolderName(strPATH) + "\\buildno.h";

    if (fso.FileExists(strFile)) {
        var ts = fso.OpenTextFile(strFile);

        //Loop while not at the end of file.
        var re = /\s/;
        var strLine;
        while (!ts.AtEndOfStream && result == 0) {

            strLine = ts.ReadLine();

            var strArray = strLine.split(re);
            if (strArray.length > 1) {
                if (strArray[1] == "VERSIONSTR") {
                    result = strArray[2];
                    break;
                }
            }
        }

        // Close the file.
        ts.Close();
    }
    return result;
}
	
	
