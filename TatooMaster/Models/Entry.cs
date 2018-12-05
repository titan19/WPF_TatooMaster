using System;

namespace TatooMaster.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int MasterId { get; set; }
    }
}