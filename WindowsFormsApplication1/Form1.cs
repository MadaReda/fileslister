using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Text;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string path,filepath;
        public Form1()
        {
            InitializeComponent();
        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            path = pathtxt.Text;
            filepath = path + "\\files.txt";
            MessageBox.Show(filepath);

            try
            {

                // Delete the file if it exists. 
                if (File.Exists(filepath))
                {
                    // Note that no lock is put on the 
                    // file and the possibility exists 
                    // that another process could do 
                    // something with it between 
                    // the calls to Exists and Delete.
                    File.Delete(filepath);
                }

                // Create the file. 
                using (StreamWriter fs = File.CreateText(filepath))
                {

                    //Get files
                    foreach (var npath in Directory.GetFiles(path))
                    {
                        Console.WriteLine(npath); // full path
                        Console.WriteLine(System.IO.Path.GetFileName(npath)); // file name
                        // Add some information to the file.
                        fs.WriteLine(npath);
                    }


                    
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }


    }
}
