using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public class Note
        {
            public string Name { get; set; }
            public string State { get; set; }
        }
        public class NotesStore
        {
            public IList<Note> notesStores = new List<Note>();

            public NotesStore()
            {
                AddNote("active", "activename");
                AddNote("active", "activename2");
                AddNote("completed", "completedname");
                AddNote("others", "othersname");
            }

            public void AddNote(String state, String name) {
                
                if (name == null || name == "")
                {
                    throw new Exception("Name cannot be empty");
                }

                if (!state.Equals("active") && !state.Equals("completed") && !state.Equals("others"))
                {
                    throw new Exception("Invalid state " + state);
                }

                notesStores.Add(new Note() { Name = name, State = state });
            }
            public List<string> GetNotes(String state) {
                //returns a list of note names with the given state (string) added so far. 
                //The names are returned in the order the corresponding notes were added. In addition to that:
                //If the given state is not a valid note state, then it throws an Exception with the message 'Invalid state {state}'.
                //If no note is found in this state, it returns an empty list. GetNotes active

                // objList.Where(x => intList.Contains(x.id));
                IEnumerable<Note> filteredList = notesStores.Where(st => st.State == state).ToList();

                List<string> filteredListTwo = filteredList.Select(nm => nm.Name).ToList();


                if (!state.Equals("active") && !state.Equals("completed") && !state.Equals("others"))
                {
                    throw new Exception("Invalid state " + state);
                }

                return filteredListTwo;
            }
        }

        static void Main(string[] args)
        {

            var notesStoreObj = new NotesStore();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var operationInfo = Console.ReadLine().Split(' ');
                try
                {
                    if (operationInfo[0] == "AddNote")
                        notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
                    else if (operationInfo[0] == "GetNotes")
                    {
                        var result = notesStoreObj.GetNotes(operationInfo[1]);
                        if (result.Count == 0)
                            Console.WriteLine("No Notes");
                        else
                            Console.WriteLine(string.Join(",", result));
                    }
                    else
                    {
                        Console.WriteLine("Invalid Parameter");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}
