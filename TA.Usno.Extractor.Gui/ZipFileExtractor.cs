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
        private List<ClickCommand> commands;

        public ZipFileExtractor()
        {
            InitializeComponent();
            AttachCommands();
        }

        private void AttachCommands()
        {
            commands = new List<ClickCommand>
            {
                //attaches an on click handler to the button
                browseSource.AttachCommand(BrowseSource, CanBrowse),
                browseDestination.AttachCommand(BrowseDestination, CanBrowse),
                ExtractButton.AttachCommand(Extract, CanExtract),
                cancelButton.AttachCommand(CancelExtract, CanCancelExtract)

            };
        }

        private void CancelExtract()
        {
            console.StopProcess();
        }

        private bool CanCancelExtract()
        {
            return console.IsProcessRunning;
        }

        private bool CanExtract()
        {
            return !console.IsProcessRunning
                && IsValidDirectory(sourceDirectory.Text)
                && IsValidDirectory(destinationDirectory.Text);
        }

        private bool IsValidDirectory(string text)
        {
            try
            {
                var fullPath = Path.GetFullPath(text);
                var isValidFullPath = !string.IsNullOrWhiteSpace(fullPath);
                var exists = Directory.Exists(fullPath);
                return isValidFullPath && exists;
            }
            catch
            {
                return false;
            }
        }

        private void BrowseDestination()
        {
            var result = browseFolders.ShowDialog();
            if (result == DialogResult.OK)
            {
                var destination = browseFolders.SelectedPath;
                destinationDirectory.Text = destination;
                NotifyCanExecuteChanged();
            }
        }

        private bool CanBrowse()
        {
            return !console.IsProcessRunning;
        }

        void NotifyCanExecuteChanged()
        {
            foreach (var command in commands)
            {
                command.CanExecuteChanged();
            }
        }
        
        private void BrowseSource()
        {
            var result = browseFolders.ShowDialog();
            if (result == DialogResult.OK)
            {
                var source = browseFolders.SelectedPath;
                sourceDirectory.Text = source;
                NotifyCanExecuteChanged();
            }
        }

        //Build the command line and start extracting
        private void Extract() 
        {
            var assembly = Assembly.GetExecutingAssembly();
            var myExecutable = assembly.Location;
            var myDirectory = Path.GetDirectoryName(myExecutable);
            var extractorExecutable = Path.Combine(myDirectory, @"Extractor\TA.Usno.Extractor.exe");
            var builder = new StringBuilder();
            builder.Append($"--SourceDirectory \"{sourceDirectory.Text}\" ");
            builder.Append($" --DestinationDirectory \"{destinationDirectory.Text}\"");

            if (deleteArchive.Checked)
            {
                builder.Append(" --DeleteArchives");
            }
            //Start extraction
            console.WriteOutput($"{extractorExecutable} {builder.ToString()}\n", Color.PaleGoldenrod);
            console.StartProcess(extractorExecutable, builder.ToString());
            NotifyCanExecuteChanged();
        }



        //validating the text box input
        /*
        * Validating the source path.
        * 1. Is it "well-formed"? Use Path.GetFullPath(). If this works, then its well-formed.
        * 2. Is it a directory?
        *      (a) use Path.GetDirectoryName(source) and see if that is different to source
        *      (b) use Directory.Exists()
        * 3. Does it exist - use Directory.Exists()
        */

        //private bool CanBrowseSource()
        //{
            
        //    //Is the text box blank?
        //    if (String.IsNullOrWhiteSpace(sourceDirectory.Text))
        //    {
        //        errorProvider.SetError(sourceDirectory, "You must enter a source directory");
        //        return false;
        //    }
            
        //    //Is it a well formed directory?
        //    try
        //    {
        //        Path.GetFullPath(sourceDirectory.Text);
        //    }
        //    catch (Exception ex)
        //    {
        //        errorProvider.SetError(sourceDirectory, "This path is malformed");
        //        return false;
        //    };
            
        //    //Does the directory exist?
        //    string directory = Path.GetDirectoryName(sourceDirectory.Text);
        //    bool directoryExists = Directory.Exists(directory);
        //    if (directoryExists != true)
        //    {
        //        errorProvider.SetError(sourceDirectory, "This directory does not exist on disk");
        //        return false;
        //    }

        //    //Is it a directory?
        //    if (directory != sourceDirectory.Text)
        //    {
        //        errorProvider.SetError(sourceDirectory, "This is not a directory");
        //        return false;
        //    }
           
        //    return true;
                    

        //}
       

        private void ZipFileExtractor_Validated(object sender, EventArgs e)
        {
            errorProvider.Clear();
        }

        private void ZipFileExtractor_Load(object sender, EventArgs e)
        {
            console.ProcessInterface.OnProcessExit += ProcessInterface_OnProcessExit;
            console.ProcessInterface.OnProcessError += ProcessInterface_OnProcessError;
        }

        private void ProcessInterface_OnProcessError(object sender, ConsoleControlAPI.ProcessEventArgs args)
        {
            NotifyCanExecuteChanged();
        }

        private void ProcessInterface_OnProcessExit(object sender, ConsoleControlAPI.ProcessEventArgs args)
        {
            NotifyCanExecuteChanged();
        }

        private void DirectoryTextChanged(object sender, EventArgs e)
        {
            NotifyCanExecuteChanged();
        }


        /* 
         Command line syntax
          
         -s, --SourceDirectory        
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
