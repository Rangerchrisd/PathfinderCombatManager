using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class CombineTextFiles : MonoBehaviour
{
    public bool doThing, textfiles,htmlFiles;
        string sourceDirectory = "TextManipulation/textsIn/TextInput - Copy";
        string destfile = "TextManipulation/textOut/out.txt";

    // Start is called before the first frame update
    void Start()
    {
        if(doThing){
            combineAllTextFiles();
            doThing = false;
        }
    }

    public void combineAllTextFiles(){
        List<string> fileNames = new List<string>(Directory.GetFiles(sourceDirectory));

        File.WriteAllText(destfile, "");
        //IEnumerable<string> lines;
        foreach(string i in fileNames){
            if(textfiles && i.EndsWith(".txt")){
                //lines = File.ReadLines(i);
                
                removeHTMLAndWritetoText(i);
                //File.AppendAllLines(destfile, lines);
            }else if(htmlFiles && i.EndsWith(".html")&& !i.EndsWith("index.html")){
                Debug.Log(i);
                removeHTMLAndWritetoText(i);
            }
        }


    }
    public void removeHTMLAndWritetoText(string htmlPath){

        StreamReader streamReader;
        StreamWriter streamWriter;
        streamReader = new StreamReader(htmlPath,true);
        streamWriter = new StreamWriter(destfile,true);
        string source = streamReader.ReadToEnd();
        string output = Regex.Replace(source, "<[^>]*>", string.Empty);
        output = Regex.Replace(output, "^(?:[\t ]*(?:\r?\n|\r))+", string.Empty);
        output = Regex.Replace(output, "&nbsp;", string.Empty);
        output = Regex.Replace(output, "&#8^;", string.Empty);
            streamWriter.Write(output);
            streamWriter.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
