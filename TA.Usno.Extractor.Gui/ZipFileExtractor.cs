using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TA.Usno.Extractor.Gui
{
    public partial class ZipFileExtractor : Form
    {
        public ZipFileExtractor()
        {
            InitializeComponent();
        }

        private void Extract()
        {

            var assembly = Assembly.GetExecutingAssembly();
            var myExecutable = assembly.Location;
            var myDirectory = Path.GetDirectoryName(myExecutable);
            var extractorExecutable = Path.Combine(myDirectory, @"Extractor\TA.Usno.Extractor.exe");
            var builder = new StringBuilder();
            builder.Append($"--SourceDirectory {sourceText.Text}");
            builder.Append($" --DestinationDirectory {destinationText.Text}");
            if (deleteArchive.Checked)
            {
                builder.Append(" --DeleteArchives");
            }
            console.StartProcess(extractorExecutable, builder.ToString());
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            Extract();
        }

        /* 
         * -s, --SourceDirectory        
         Required. Specify the source directory where archives are located.
         
         -d, --DestinationDirectory
         Specify the destination directory for extracted files.

        --DeleteArchives
        (Default: false) Deletes each archive after a successful extraction.

        --help
        Display this help screen.

        --version
        Display version information.
        */
    }
}
