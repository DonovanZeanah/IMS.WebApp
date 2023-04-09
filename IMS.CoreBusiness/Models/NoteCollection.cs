using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public class NoteCollection : ICollection<Note>
    {
        private List<Note> _notes;

        public NoteCollection()
        {
            _notes = new List<Note>();
        }

        public void Add(Note note)
        {
            _notes.Add(note);
        }

        public bool Remove(Note note)
        {
            return _notes.Remove(note);
        }

        public int Count
        {
            get { return _notes.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Clear()
        {
            _notes.Clear();
        }

        public bool Contains(Note note)
        {
            return _notes.Contains(note);
        }

        public void CopyTo(Note[] array, int arrayIndex)
        {
            _notes.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Note> GetEnumerator()
        {
            return _notes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}



