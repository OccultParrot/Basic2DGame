using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Basic2DGame.GameFiles
{
    /// <summary>
    /// This class is used to write text to an opened Error Log File.
    /// </summary>
    public static class DebugLogger
    {
        public static string DebugFolderPath { get { return debugFolderPath; } private set { debugFolderPath = value; } }
        private static string debugFolderPath = "ErrorLog/";

        private static string openFilePath;

        /// <summary>
        /// Call this to open a file so that you can write with the logger.
        /// </summary>
        /// <param name="fileName">The name of the file, NOT THE PATH</param>
        public static void Open(string fileName) { openFilePath = DebugFolderPath + fileName + ".txt"; }
        
        /// <summary>
        /// Call this to close a file after you are done writing.
        /// </summary>
        public static void Close() {  openFilePath = null; }

        /// <summary>
        /// Used to write a line in the opened Error Log file. YOU MUST CALL OPEN BEFORE WRITING TO FILE.
        /// </summary>
        /// <param name="value">The text you want to write in the Error Log file.</param>
        public static void WriteLine(string value)
        {
            if (!Directory.Exists(DebugFolderPath)) { Directory.CreateDirectory(DebugFolderPath);}
            try
            {
                using StreamWriter stream = new(openFilePath, true);
                stream.WriteLine(value);
            }
            catch (Exception ex)
            {
                Open("errorList");
                using StreamWriter stream = new StreamWriter(openFilePath, append: true);
                stream.WriteLine("An Error has occurred: " + ex.Message);
                Close();
            }
        }
        
        /// <summary>
        /// Used to write a line in the opened Error Log file. YOU MUST CALL OPEN BEFORE WRITING TO FILE.
        /// </summary>
        /// <param name="value">The text you want to write in the Error Log file.</param>
        public static void WriteLine(bool value)
        {
            if (!Directory.Exists(DebugFolderPath)) { Directory.CreateDirectory(DebugFolderPath); }
            try
            {
                using StreamWriter stream = new(openFilePath, true);
                stream.WriteLine(value);
            }
            catch (Exception ex)
            {
                Open("errorList");
                using StreamWriter stream = new StreamWriter(openFilePath, append: true);
                stream.WriteLine("An Error has occurred: " + ex.Message);
                Close();
            }
        }

        /// <summary>
        /// Used to write a string to the open Error Log file. YOU MUST CALL OPEN BEFORE WRITING TO FILE.
        /// </summary>
        /// <param name="text">The text you want to write in the Error Log file.</param>
        public static void Write(string value)
        {
            if (!Directory.Exists(DebugFolderPath)) { Directory.CreateDirectory(DebugFolderPath); }

            try
            {
                using StreamWriter stream = new(openFilePath, true);
                stream.WriteLine(value);
            }
            catch (Exception ex)
            {
                Open("errorList");
                using StreamWriter stream = new StreamWriter(openFilePath, append: true);
                stream.Write("An Error has occurred: " + ex.Message);
                Close();
            }
        }

        /// <summary>
        /// Used to write a string to the open Error Log file. YOU MUST CALL OPEN BEFORE WRITING TO FILE.
        /// </summary>
        /// <param name="text">The text you want to write in the Error Log file.</param>
        public static void Write(bool value)
        {
            if (!Directory.Exists(DebugFolderPath)) { Directory.CreateDirectory(DebugFolderPath); }

            try
            {
                using StreamWriter stream = new(openFilePath, true);
                stream.WriteLine(value);
            }
            catch (Exception ex)
            {
                Open("errorList");
                using StreamWriter stream = new StreamWriter(openFilePath, append: true);
                stream.Write("An Error has occurred: " + ex.Message);
                Close();
            }
        }
    }
}
