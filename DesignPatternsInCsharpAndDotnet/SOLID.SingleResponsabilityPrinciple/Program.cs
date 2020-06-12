using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SOLID.SingleResponsabilityPrinciple
{
    class Program
    {
        /// <summary>
        /// This class breaks the single responsability principle beccause it handles adding and removing journal entries 
        /// but it also handles saving and loading entries from files and the disk. Since it handles more than one responsability,
        /// it breaks the Single Responsability Principle
        /// </summary>
        // just stores a couple of journal entries and ways of
        // working with them
        public class Journal
        {
            private readonly List<string> entries = new List<string>();

            private static int count = 0;

            public int AddEntry(string text)
            {
                entries.Add($"{++count}: {text}");
                return count; // memento pattern!
            }

            public void RemoveEntry(int index)
            {
                entries.RemoveAt(index);
            }

            public override string ToString()
            {
                return string.Join(Environment.NewLine, entries);
            }

            // breaks single responsibility principle
            public void Save(string filename, bool overwrite = false)
            {
                File.WriteAllText(filename, ToString());
            }

            public void Load(string filename)
            {

            }

            public void Load(Uri uri)
            {

            }
        }

        /// <summary>
        /// This class follows the single responsability principle because it only handles the responsability of persisting objects
        /// </summary>
        public class Persistence
        {
            public void SaveToFile(Journal journal, string filename, bool overwrite = false)
            {
                if (overwrite || !File.Exists(filename))
                    File.WriteAllText(filename, journal.ToString());
            }
        }

        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today.");
            j.AddEntry("I ate a bug.");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename);
            Process.Start(filename);
        }
    }
}
