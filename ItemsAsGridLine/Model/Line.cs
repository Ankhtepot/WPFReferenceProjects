using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static ItemsAsGridLine.Model.Enums;

namespace ItemsAsGridLine.Model
{
    public class Line
    {
        public List<string> Entries { get; set; }
        public ItemType ItemType { get; set; }
    }
}
