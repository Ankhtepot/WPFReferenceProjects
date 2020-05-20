using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GridViewRef.Model
{
    public class DataMatrix : IEnumerable
    {
        public List<MatrixColumn> Columns { get; set; }
        public List<object[]> Rows { get; set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new GenericEnumerator(Rows.ToArray());
        }
    }
}
