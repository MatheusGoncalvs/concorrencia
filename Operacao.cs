using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concorrencia
{
    public class Operacao
    {
        public Item ItemA { get; set; }
        public Item ItemB { get; set; }
        public Item ItemC { get; set; }
        public string Nome { get; set; }
        public Transacao Transacao { get; set; }
        public GerenciadorExecucao Gerenciador { get; }

        public Operacao(string nome, Item itemA, Item itemB, Item itemC, Transacao transacao, GerenciadorExecucao gerenciador)
        {
            Nome = nome.ToLower();
            ItemA = itemA;
            ItemB = itemB;
            ItemC = itemC;
            Transacao = transacao;
            Gerenciador = gerenciador;
        }

        public void Iniciar()
        {
            if (Nome == "ler")
                Ler();
            else if (Nome == "gravar")
                Gravar();
            else if (Nome == "somar")
                Somar();
            else if (Nome == "subtrair")
                Subtrair();
            else if (Nome == "rlock")
                Rlock();
            else if (Nome == "wlock")
                Wlock();
            else if (Nome == "unlock")
                Unlock();
            else
                Console.WriteLine("Opcao inexistente. Algo deu errado...");
        }

        private bool ExisteItemUtilizado()
        {
            return ItemA.Estado == Estado.RLOCK ||
                ItemA.Estado == Estado.WLOCK &&
                ItemA.transacoes.Contains(Transacao);
        }

        private void VerificarEstadoTransacao()
        {
            if (Transacao.Modo == Modo.ESPERA)
            {
                Console.WriteLine("Entrando na fila...");
                Gerenciador.operacoes.Add(this);
            }
        }

        public Operacao GetPrimeiraOperacaoListaExecucao()
        {
            return Gerenciador.operacoes.FirstOrDefault();
        }

        private void IniciarProximaTransacao()
        {
            try
            {
                if (Gerenciador.operacoes.Count() == 0)
                    Console.WriteLine("Nenhum item aguardando execução :)");
                else
                {
                    var operacao = (from o in Gerenciador.operacoes
                                    where o.Transacao.Id == GetPrimeiraOperacaoListaExecucao().Transacao.Id
                                    select o);

                    operacao.AsParallel().ForAll(o => { o.Iniciar(); Gerenciador.operacoes.Remove(o); });
                }
            }
            catch
            {
                Console.WriteLine("Erro ao iniciar próxima transacão...");
            }
        }

        private void Unlock()
        {
            Transacao.Unlock(ItemA);
            IniciarProximaTransacao();
        }

        private void Wlock()
        {
            Transacao.Wlock(ItemA);
            VerificarEstadoTransacao();
        }

        private void Rlock()
        {
            Transacao.Rlock(ItemA);
            VerificarEstadoTransacao();
        }

        private void Subtrair()
        {
            if (ExisteItemUtilizado())
            {
                ItemA.ValorTemp = ItemB.Valor - ItemC.Valor;
                Console.WriteLine($"Subtração realizada: {ItemB.Valor} - {ItemC.Valor} = {ItemA.ValorTemp}");
            }
            else
            {
                Console.WriteLine("A subtração não pôde ser realizada.");
                VerificarEstadoTransacao();
            }
        }

        private void Somar()
        {
            if (ExisteItemUtilizado())
            {
                ItemA.ValorTemp = ItemB.Valor + ItemC.Valor;
                Console.WriteLine($"Soma realizada: {ItemB.Valor} + {ItemC.Valor} = {ItemA.ValorTemp}");
            }
            else
            {
                Console.WriteLine("Soma não pode ser realizada.");
                VerificarEstadoTransacao();
            }
        }

        private void Gravar()
        {
            if (ItemA.Estado == Estado.WLOCK &&
                ItemA.transacoes.Contains(Transacao))
            {
                ItemA.Valor = ItemA.ValorTemp;
                Console.WriteLine($"Gravacao Realizada: {ItemA.Valor}.");
            }
            else
            {
                Console.WriteLine("Não foi possível Gravar neste momento.");
                VerificarEstadoTransacao();
            }
        }

        private void Ler()
        {
            if (ExisteItemUtilizado())
            {
                ItemA.ValorTemp = ItemA.Valor;
                Console.WriteLine($"Leitura Realizada: {ItemA.Valor}.");
            }
            else
            {
                Console.WriteLine("Não foi possível ler neste momento.");
                VerificarEstadoTransacao();
            }
        }

    }
}
