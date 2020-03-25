using System;

namespace concorrencia
{
    public class Item
    {
        public int Valor { get; set; }
        public int ValorTemp { get; set; }
        public Estado estado { get; set; }
    }
}