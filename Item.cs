using System;
using System.Collections.Generic;

namespace concorrencia
{
    public class Item
    {
        public int Valor { get; set; }
        public int ValorTemp { get; set; }
        public Estado Estado { get; set; }
        public int QuantidadeLeitores { get; set; }

        internal List<Transacao> transacoes;

        public Item(int valor)
        {
            Valor = valor;
            ValorTemp = valor;
            Estado = Estado.UNLOCK;
            transacoes = new List<Transacao>();
        }

        public void AcrescentarUmLeitor()
        {
            QuantidadeLeitores++;
        }

        public void RetirarUmLeitor()
        {
            QuantidadeLeitores--;
        }
    }
}