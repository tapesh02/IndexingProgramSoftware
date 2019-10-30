using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndexingProgramV1
{
    public partial class startingForm : Form
    {

        private void startingForm_Load(object sender, EventArgs e)
        {
            btnViewReport.Visible = false;
        }

        // list contains all indexed words
        static List<string> collectedWords = new List<string>();

        // Dictionary of words and their index frequencey
        static Dictionary<string, int> searchedWords = new Dictionary<string, int>();

        // list if txt files collected
        List<TextFile> collectedTxtFiles = new List<TextFile>();

        // ignore list
        string[] blackList = new string[] {"is", "the", "of", "this", "how", "all", "ago", "me", "he", "he’ll",
            "he’s", "she", "she’ll", "she’s", "am", "in", "so", "is", "be", "let", "mr", "mrs", "we", "us",
            "you", "oh", "ok", "ex" };




        // search word
        string word;

        // total number of searches
        int totalSearches = 0;

        public startingForm()
        {
            InitializeComponent();
        }

        // methods
        private static string LongestWord (List<string> collectedWords)
        {
            string longestWord = "";
            foreach (var word in collectedWords)
            {
                // check if its longer
                if (word.Length > longestWord.Length)
                    longestWord = word;
            }
            return longestWord;
        }

        private static string ShortestWord(List<string> collectedWords)
        {
            string shortestWord = "";
            foreach (var word in collectedWords)
            {
                // assume first word is shortest
                if (shortestWord == "")
                    shortestWord = word;
                // check if its shorter
                if (word.Length < shortestWord.Length)
                    shortestWord = word;
            }
            return shortestWord;
        }

        private static Dictionary<string, int> MostFrequentWord(Dictionary<string, int> searchedWords)
        {
            string mostFrequentWord = "";
            int frequency = 0;
            foreach (KeyValuePair<string, int> word in searchedWords)
            {
                // assume first is most frequent
                if (mostFrequentWord == "")
                {
                    mostFrequentWord = word.Key;
                    frequency = word.Value;
                }

                // check if more frequent
                if (word.Value > frequency)
                {
                    mostFrequentWord = word.Key;
                    frequency = word.Value;
                }
            }
            Dictionary<string, int> result = new Dictionary<string, int>();
            result.Add(mostFrequentWord, frequency);
            return result;
        }
    
        private static Dictionary<string, int> LeastFrequentWord(Dictionary<string, int> searchedWords)
        {
            string leastFrequentWord = "";
            int frequency = 0;
            foreach (KeyValuePair<string, int> word in searchedWords)
            {
                // assume first is least frequent
                if (leastFrequentWord == "")
                {
                    leastFrequentWord = word.Key;
                    frequency = word.Value;
                }

                // check if least frequent
                if (word.Value < frequency)
                {
                    leastFrequentWord = word.Key;
                    frequency = word.Value;
                }
            }
            Dictionary<string, int> result = new Dictionary<string, int>();
            result.Add(leastFrequentWord, frequency);
            return result;
        }

        public static string GetBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }


        private void btnAddFolder_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                // set FileSystemWatcher path to root of this folder   Failed attempt
                //fileSystemWatcher.Path = Path.GetPathRoot(fbd.SelectedPath);
                //MessageBox.Show(fileSystemWatcher.Path);

                var selectedFolder = fbd.SelectedPath;
                var exists = false;

                // check if folder exists in listbox
                foreach (Folder item in lstBoxFolders.Items)
                {
                    if (item.Path == selectedFolder)
                    {
                        exists = true;
                    }
                }

                if (exists == true)
                {
                    MessageBox.Show("Folder already in showcase!");
                }
                else
                {
                    // instantiate folder object
                    var folder = new Folder();
                    folder.Name = Path.GetFileName(selectedFolder);
                    folder.Path = selectedFolder;
                    folder.TextFiles = new List<TextFile>();

                    lstBoxFolders.Items.Add(folder);

                    // txt files in selected folder to add to collection
                    var files = Directory.GetFiles(folder.Path, "*.txt");

                    if (files.Length != 0) // contains txt file
                    {
                        foreach (var txtFilePath in files)
                        {
                            var txtFile = new TextFile
                            {
                                Name = Path.GetFileName(txtFilePath),
                                Path = txtFilePath,
                                Folder = folder.Name
                            };
                            // add to folder
                            folder.TextFiles.Add(txtFile);
                            // add to collection
                            collectedTxtFiles.Add(txtFile);

                            MessageBox.Show($"'{txtFile.Name}' Added to collection");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"'{Path.GetFileName(selectedFolder)}' does not contain any txt file");
                    }
                }

            }

        }

        private void btnRemoveFolder_Click(object sender, EventArgs e)
        {
            var selectedItem = lstBoxFolders.SelectedItem;
            
            if (selectedItem != null)
            {
                // access properties of selected item
                Folder selectedFolder = (Folder)selectedItem;

                // remove all txt files from collection
                foreach (var txtFile in selectedFolder.TextFiles)
                {
                    collectedTxtFiles.Remove(txtFile);
                    MessageBox.Show($"'{txtFile.Name}' has been removed from collection");
                }
                // remove item
                lstBoxFolders.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("No item selected");
            }
        }

        private void btnSearchIndex_Click(object sender, EventArgs e)
        {
            // increase number of total searches
            totalSearches++;

            word = txtBoxSearchIndex.Text;
            double number;

            // add to searched dictionary
            // existing word
            if (searchedWords.ContainsKey(word))
            {
                searchedWords[word] += 1;
            }
            // new word
            else
            {
                searchedWords[word] = 1;
            }

            if (blackList.Contains(word)) // if blacklist
            {
                MessageBox.Show($"cannot index '{word}'!");
            }
            else if (word.Length == 1) // if 1 letter word
            {
                MessageBox.Show("Must be more than 1 letter");
            }
            else if (double.TryParse(word, out number)) // if it is a number
            {
                MessageBox.Show($"{word} is a number and cannot be indexed!");
            }
            else if (word == "") // if empty
            {
                MessageBox.Show("Please insert a word!");
            }
            else  // if valid
            {
                // report button visible
                btnViewReport.Visible = true;

                // clear ListView
                lstViewIndex.Items.Clear();

                // if new word
                if (!collectedWords.Contains(word))
                {
                    collectedWords.Add(word);
                    MessageBox.Show($"'{word}' is a new word and has been indexed!");
                }

                // *** indexing process ***
                var totalOccurrence = 0;

                // loop through txt files
                foreach (var txtFile in collectedTxtFiles)
                {
                    // search word in txt file
                    int occurrence = (new Regex(@"(?i)" + word + "")).Matches(File.ReadAllText(txtFile.Path)).Count;

                    totalOccurrence += occurrence;

                    // display in ListBox
                    if (occurrence == 0)
                    {
                        continue;
                    }
                    else
                    {
                        ListViewItem lvi = new ListViewItem(occurrence.ToString());
                        lvi.SubItems.Add(txtFile.ToString());
                        lvi.SubItems.Add(txtFile.Folder);

                        // substitute for binding object to listview
                        lvi.Tag = txtFile;

                        lstViewIndex.Items.Add(lvi);
                    }
                }

                txtBoxSearchIndex.Text = "";

                if (totalOccurrence == 0)
                {
                    lblSearchWord.Text = $"no results showing for '{word}'";
                }
                else
                {
                    lblSearchWord.Text = $"{totalOccurrence} total occurrences found for '{word}'";
                }

            }



        }

        private void lstViewIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstViewIndex.SelectedIndices.Count > 0)
            {
                var itemSelected = lstViewIndex.SelectedItems[0];

                // get object back from listview
                TextFile txtFile = (TextFile)itemSelected.Tag;

                rchTxtBoxFileDescription.Text = File.ReadAllText(txtFile.Path);
                lblTxtFileView.Text = $"'{txtFile.Name}' Text View";
                var index = 0;
                while (index < rchTxtBoxFileDescription.Text.LastIndexOf(word))
                {
                    // Searches the word in the RichTextBox
                    rchTxtBoxFileDescription.Find(word, index, rchTxtBoxFileDescription.TextLength, RichTextBoxFinds.None);
                    // Selection color
                    rchTxtBoxFileDescription.SelectionBackColor = Color.Yellow;
                    // after a match is found the index is increased
                    index = rchTxtBoxFileDescription.Text.IndexOf(word, index) + 1;
                }
            }



        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            string longestWordIndexed = LongestWord(collectedWords);

            string shortestWordIndexed = ShortestWord(collectedWords);
            Dictionary<string, int> mostFrequentWord = MostFrequentWord(searchedWords);
            Dictionary<string, int> leastFrequentWord = LeastFrequentWord(searchedWords);

            // pull out word frequency from dictionary into variables
            var frequentWord = "";
            var frequentwordCount = 0;
            var unfrequentWord = "";
            var unfrequentWordCount = 0;

            foreach (KeyValuePair<string, int> word in mostFrequentWord)
            {
                frequentWord = word.Key;
                frequentwordCount = word.Value;
            }
            foreach (KeyValuePair<string, int> word in leastFrequentWord)
            {
                unfrequentWord = word.Key;
                unfrequentWordCount = word.Value;
            }
            // time or times
            var frequentCountMessage = "";
            if (frequentwordCount > 1)
            {
                frequentCountMessage = "times";
            }
            else if (frequentwordCount == 1)
            {
                frequentCountMessage = "time";
            }
            else
            {
                frequentCountMessage = "";
            }

            var unfrequentCountMessage = "";
            if (unfrequentWordCount > 1)
            {
                unfrequentCountMessage = "times";
            }
            else if (unfrequentWordCount == 1)
            {
                unfrequentCountMessage = "time";
            }
            else
            {
                unfrequentCountMessage = "";
            }
            // display report
            MessageBox.Show($"total number of words Indexed: {totalSearches}{Environment.NewLine}" +
            $"total unique words indexed: {collectedWords.Count}{Environment.NewLine}" +
            $"-------------------------------------------{Environment.NewLine}" +
            $"longest word: '{longestWordIndexed}'{Environment.NewLine}" +
            $"shorestest word: '{shortestWordIndexed}'{Environment.NewLine}" +
            $"-------------------------------------------{Environment.NewLine}" +
            $"most frequent word: '{frequentWord}' indexed {frequentwordCount} {frequentCountMessage}{Environment.NewLine}" +
            $"least frequent word: '{unfrequentWord}' indexed {unfrequentWordCount} {unfrequentCountMessage}");

        }

        private void fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            // FAILED ATTEMPT

            //var attr = File.GetAttributes(e.FullPath);

            //// if it is a folder
            //if (attr == FileAttributes.Directory)
            //{
            //   //nothing
            //}
            //else // if its a file
            //{
            //    var extension = Path.GetExtension(e.FullPath);
            //    if (extension == ".txt")
            //    {
            //        MessageBox.Show("its a txt file");
            //        TextFile file = new TextFile();
            //        file.Name = Path.GetFileName(e.FullPath);
            //        file.Path = e.FullPath;
            //        file.Folder = Path.GetDirectoryName(e.FullPath);

            //        foreach (Folder folder in lstBoxFolders.Items)
            //        {
            //            // if txt file parent directory is in ListBox
            //            if (Path.GetFileName(Directory.GetParent(file.Path).FullName) == folder.Name)
            //            {
            //                collectedTxtFiles.Add(file);
            //                MessageBox.Show($"'{file.Name}' Added to collection");
            //            }
            //        }

            //        collectedTxtFiles.Add(file);
            //        MessageBox.Show($"{file.Name} file has been added to collection");
            //    }

            //}
        }

        private void fileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {

        }

        private void btnUrl_Click(object sender, EventArgs e)
        {
            string urlAddress = txtBoxUrl.Text;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                        MessageBox.Show("hi");
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    string data = readStream.ReadToEnd();

                    var titleContent = GetBetween(data, "<title>", "</title>");
                    var aContent = GetBetween(data, "<a", "</a>");
                    var scriptContent = GetBetween(data, "<script>", "</script>");

                    rchTxtBoxFileDescription.Text = $"Title: {titleContent}{Environment.NewLine}" +
                        $"Anchor: {aContent}{Environment.NewLine}" +
                        $"Script: {scriptContent}{Environment.NewLine}";

                    response.Close();
                    readStream.Close();
                }
            }
            catch
            {
                MessageBox.Show("Invalid url, make sure it is in the correct formal e.g: 'http://lol.com'");
            }

        }
    }
}
