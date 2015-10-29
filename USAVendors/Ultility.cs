using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using JRO;

namespace USAVendors
{
    public class Utility
    {

        /// <summary>The connection to use to connect to
        /// an Access database using JET.</summary>
        public const string AccessOleDbConnectionStringFormat =
         "Data Source={0};Provider=Microsoft.Jet.OLEDB.4.0;";
        public string ConnectionStr;
        public String Con
        {
            set
            {
                this.ConnectionStr = value;
            }
            get
            {
                return this.ConnectionStr;
            }
        }

        /// <summary>
        /// Compacts an Access database using Microsoft JET COM
        /// interop.
        /// </summary>
        /// <param name="fileName">
        /// The filename of the Access database to compact. This
        /// filename will be mapped to the appropriate path on the
        /// web server, so use a tilde (~) to specify the web site
        /// root folder. For example, "~/Downloads/Export.mdb".
        /// The ASP.NET worker process must have been granted
        /// permission to read and write this file, as well as to
        /// create files in the folder in which this file resides.
        /// In addition, Microsoft JET 4.0 or later must be
        /// present on the server.
        /// </param>
        /// <returns>
        /// True if the compact was successful. False can indicate
        /// several possible problems including: unable to create
        /// JET COM object, unable to find source file, unable to
        /// create new compacted file, or unable to delete
        /// original file.
        /// </returns>
        /// 
        public static void SetirajString(String ime)
        {
            this.Con = ime;
        }
        public static void CompactJetDatabase(string fileName)
        {
            // I use this function as part of an AJAX page, so rather
            // than throwing exceptions if errors are encountered, I
            // simply return false and allow the page to handle the
            // failure generically.
            try
            {
                // Find the database on the web server
                string oldFileName = fileName;

                // JET will not compact the database in place, so we
                // need to create a temporary filename to use
                string newFileName =
                 Path.Combine(Path.GetDirectoryName(oldFileName),
                 Guid.NewGuid().ToString("N") + ".mdb");

                // Obtain a reference to the JET engine
                
                
                JetEngine engine = 
                 (JetEngine)HttpContext.Current.Server.CreateObject(
                 "JRO.JetEngine");

                // Compact the database (saves the compacted version to
                // newFileName)
                
                engine.CompactDatabase(
                 String.Format(
                  AccessOleDbConnectionStringFormat, oldFileName),
                 String.Format(
                  AccessOleDbConnectionStringFormat, newFileName));

                // Delete the original database
                File.Delete(oldFileName);

                // Move (rename) the temporary compacted database to
                // the original filename
                File.Move(newFileName, oldFileName);

                // The operation was successful
               
            }
            catch (Exception ex)
            {
                // We encountered an error
                MessageBox.Show("Greska : " + ex.Message);
               
            }
        }

    }

}
