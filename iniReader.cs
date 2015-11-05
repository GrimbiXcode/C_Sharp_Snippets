using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows;


public class IniFile
{
  private

  List<string> propertyList = new List<string>();

  #region Constructors
  /// <summary>
  /// Create a new Ini instance.
  /// </summary>
  public IniFile(string filePath)
  {
      //read ini-file
      try
      {  
          if(!File.Exists(filePath))
          {
              genNew(filePath, Properties.Settings.Default.Propertystring);
              while(!File.Exists(filePath)){}
          }
          
          // Open the text file using a stream reader.
          using (StreamReader sr = new StreamReader(filePath))
          {
              // 3
              // Use while != null pattern for loop
              string line;
              while ((line = sr.ReadLine()) != null)
              {
                  // 4
                  // Insert logic here.
                  // ...
                  // "line" is a line in the file. Add it to our List.
                  propertyList.Add(line);
              }

              // 5
              // Print out all the lines.
              foreach (string s in propertyList)
              {
                  Console.WriteLine(s);
              }
              sr.Close();
          }
      }
      catch (Exception e)
      {
          MessageBox.Show("The ini-file could not be read: " + e.Message);
      }
  }
  #endregion

  #region methodes
  /// <summary>
  /// sends the value of the data you looking for.
  /// Out: string value of data
  /// In: name of Property as a string value
  /// </summary>
  public string getValue(string propertyName)
  {
      string output = "";
      foreach(string item in propertyList)
      {
          if (item.Contains(propertyName))
          {
              output = item.Substring(item.IndexOf("=") + 1);
          }
      }
      return output;
  }

  public void genNew(string path, string propertyString)
  {
      try
      {
          StreamWriter file = new StreamWriter(path);
          file.Write(propertyString);
          file.Close();
      }
      catch (Exception e)
      {
          MessageBox.Show("The new ini-file could not be written: " + e.Message);
      }
  }
  #endregion
}
