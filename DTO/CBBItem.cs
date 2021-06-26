using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCNPM.DTO
{
    public class CBBItem
    {
        private int _values;
        private string _text;

        public int Value { get => _values; set => _values = value; }
        public string Text { get => _text; set => _text = value; }


        public override string ToString()
        {
            return Text;
        }
    }
}
