﻿using System;
namespace ItemsAsGridLine.Model
{
    public class ColumnConfig
    {
        public Enums.ItemType ItemType { get; set; }

        public ColumnConfig() : this(Enums.ItemType.Text) { }
        public ColumnConfig(Enums.ItemType itemType)
        {
            ItemType = itemType;
        }
    }
}
