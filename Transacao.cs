using System;

namespace concorrencia
{
    public class Transacao
    {
        public Modo Modo { get; set; }
        public DateTime TimeStamp { get; set; }
        public GerenciadorExecucao GerenciadorExecucao { get; set; }
        public int Id { get; }

        public Transacao(int id)
        {
            Modo = Modo.ATIVO;
            TimeStamp = DateTime.Now;
            this.Id = id;
        }

        public void Rlock(Item item)
        {
            if (item.Estado == Estado.UNLOCK)
            {
                item.Estado = Estado.RLOCK;
                item.AcrescentarUmLeitor();
                item.transacoes.Add(this);
            }
            else if (item.Estado == Estado.RLOCK)
            {
                item.AcrescentarUmLeitor();
                item.transacoes.Add(this);
            }
            else
            {
                //Aguardar um item liberado
                this.Modo = Modo.ESPERA;
            }
        }

        public void Wlock(Item item)
        {
            if (item.Estado == Estado.UNLOCK)
            {
                item.Estado = Estado.WLOCK;
                item.transacoes.Add(this);
                Console.WriteLine("Wlock..");
            }
            else
            {
                //Aguardar um item ser liberado
                this.Modo = Modo.ESPERA;
            }
        }

        public void Unlock(Item item)
        {
            if (item.Estado == Estado.WLOCK)
            {
                item.Estado = Estado.UNLOCK;
                item.transacoes.Remove(this);
                Console.WriteLine("Unlock...");
                //Acordar uma transacao  da fila de espera
                this.Modo = Modo.ATIVO;
            }
            else if (item.Estado == Estado.RLOCK)
            {
                item.RetirarUmLeitor();
                if (item.QuantidadeLeitores == 0)
                {
                    item.Estado = Estado.UNLOCK;
                    item.transacoes.Remove(this);
                    //Acordar uma transacao da fila de espera
                    this.Modo = Modo.ATIVO;
                }
            }
        }
    }
}