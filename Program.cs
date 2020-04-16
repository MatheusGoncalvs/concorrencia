using System;
using System.Threading;

namespace concorrencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Item itemX = new Item(10);
            Item itemY = new Item(20);
            Item itemM = new Item(60);
            Item itemN = new Item(40);

            GerenciadorExecucao gerenciadorExecucao = new GerenciadorExecucao();

            Transacao t1 = new Transacao(1);
            Transacao t2 = new Transacao(2);
            Transacao t3 = new Transacao(3);
            /*
            //Plano do Luiz #1
            Operacao opT1_0 = new Operacao("wlock", itemX, null, null, t1, gerenciadorExecucao);
            opT1_0.Iniciar();
            Operacao opT1_1 = new Operacao("rlock", itemN, null, null, t1, gerenciadorExecucao);
            opT1_1.Iniciar();
            Operacao opT1_2 = new Operacao("ler", itemX, null, null, t1, gerenciadorExecucao);
            opT1_2.Iniciar();
            Operacao opT1_3 = new Operacao("ler", itemN, null, null, t1, gerenciadorExecucao);
            opT1_3.Iniciar();
            Operacao opT1_4 = new Operacao("subtrair", itemX, itemX, itemN, t1, gerenciadorExecucao);
            opT1_4.Iniciar();
            Operacao opT1_5 = new Operacao("gravar", itemX, null, null, t1, gerenciadorExecucao);
            opT1_5.Iniciar();
            Operacao opT1_6 = new Operacao("unlock", itemX, null, null, t1, gerenciadorExecucao);
            opT1_6.Iniciar();
            Operacao opT1_7 = new Operacao("wlock", itemY, null, null, t1, gerenciadorExecucao);
            opT1_7.Iniciar();
            Operacao opT1_8 = new Operacao("ler", itemY, null, null, t1, gerenciadorExecucao);
            opT1_8.Iniciar();
            Operacao opT1_9 = new Operacao("somar", itemY, itemY, itemN, t1, gerenciadorExecucao);
            opT1_9.Iniciar();
            Operacao opT1_10 = new Operacao("gravar", itemY, null, null, t1, gerenciadorExecucao);
            opT1_10.Iniciar();
            Operacao opT1_11 = new Operacao("unlock", itemY, null, null, t1, gerenciadorExecucao);
            opT1_11.Iniciar();
            Operacao opT1_12 = new Operacao("unlock", itemN, null, null, t1, gerenciadorExecucao);
            opT1_12.Iniciar();

            //Operação T2
            Operacao opT2_0 = new Operacao("wlock", itemX, null, null, t2, gerenciadorExecucao);
            opT2_0.Iniciar();
            Operacao opT2_1 = new Operacao("ler", itemX, null, null, t2, gerenciadorExecucao);
            opT2_1.Iniciar();
            Operacao opT2_2 = new Operacao("rlock", itemM, null, null, t2, gerenciadorExecucao);
            opT2_2.Iniciar();
            Operacao opT2_3 = new Operacao("ler", itemM, null, null, t2, gerenciadorExecucao);
            opT2_3.Iniciar();
            Operacao opT2_4 = new Operacao("somar", itemX, itemX, itemM, t2, gerenciadorExecucao);
            opT2_4.Iniciar();
            Operacao opT2_5 = new Operacao("gravar", itemX, null, null, t2, gerenciadorExecucao);
            opT2_5.Iniciar();
            Operacao opT2_6 = new Operacao("unlock", itemX, null, null, t2, gerenciadorExecucao);
            opT2_6.Iniciar();
            Operacao opT2_7 = new Operacao("unlock", itemM, null, null, t2, gerenciadorExecucao);
            opT2_7.Iniciar();
            */

            /*
            //Teste do Luiz #Embaralhado
            Operacao opT1_0 = new Operacao("wlock", itemX, null, null, t1, gerenciadorExecucao);
            opT1_0.Iniciar();
            Operacao opT1_1 = new Operacao("rlock", itemN, null, null, t1, gerenciadorExecucao);
            opT1_1.Iniciar();
            Operacao opT1_2 = new Operacao("ler", itemX, null, null, t1, gerenciadorExecucao);
            opT1_2.Iniciar();
            Operacao opT1_3 = new Operacao("ler", itemN, null, null, t1, gerenciadorExecucao);
            opT1_3.Iniciar();
            Operacao opT1_4 = new Operacao("subtrair", itemX, itemX, itemN, t1, gerenciadorExecucao);
            opT1_4.Iniciar();
            Operacao opT1_5 = new Operacao("gravar", itemX, null, null, t1, gerenciadorExecucao);
            opT1_5.Iniciar();
            Operacao opT1_6 = new Operacao("unlock", itemX, null, null, t1, gerenciadorExecucao);
            opT1_6.Iniciar();

            //Operação T2
            Operacao opT2_0 = new Operacao("wlock", itemX, null, null, t2, gerenciadorExecucao);
            opT2_0.Iniciar();
            Operacao opT2_1 = new Operacao("ler", itemX, null, null, t2, gerenciadorExecucao);
            opT2_1.Iniciar();
            Operacao opT2_2 = new Operacao("rlock", itemM, null, null, t2, gerenciadorExecucao);
            opT2_2.Iniciar();
            Operacao opT2_3 = new Operacao("ler", itemM, null, null, t2, gerenciadorExecucao);
            opT2_3.Iniciar();
            Operacao opT2_4 = new Operacao("somar", itemX, itemX, itemM, t2, gerenciadorExecucao);
            opT2_4.Iniciar();
            Operacao opT2_5 = new Operacao("gravar", itemX, null, null, t2, gerenciadorExecucao);
            opT2_5.Iniciar();
            Operacao opT2_6 = new Operacao("unlock", itemX, null, null, t2, gerenciadorExecucao);
            opT2_6.Iniciar();
            Operacao opT2_7 = new Operacao("unlock", itemM, null, null, t2, gerenciadorExecucao);
            opT2_7.Iniciar();

            //Continuando T1
            Operacao opT1_7 = new Operacao("wlock", itemY, null, null, t1, gerenciadorExecucao);
            opT1_7.Iniciar();
            Operacao opT1_8 = new Operacao("ler", itemY, null, null, t1, gerenciadorExecucao);
            opT1_8.Iniciar();
            Operacao opT1_9 = new Operacao("somar", itemY, itemY, itemN, t1, gerenciadorExecucao);
            opT1_9.Iniciar();
            Operacao opT1_10 = new Operacao("gravar", itemY, null, null, t1, gerenciadorExecucao);
            opT1_10.Iniciar();
            Operacao opT1_11 = new Operacao("unlock", itemY, null, null, t1, gerenciadorExecucao);
            opT1_11.Iniciar();
            Operacao opT1_12 = new Operacao("unlock", itemN, null, null, t1, gerenciadorExecucao);
            opT1_12.Iniciar();
            */

            //Teste do Luiz #1. Plano não serial
            Operacao opT1_0 = new Operacao("wlock", itemX, null, null, t1, gerenciadorExecucao);
            opT1_0.Iniciar();
            Operacao opT1_1 = new Operacao("rlock", itemN, null, null, t1, gerenciadorExecucao);
            opT1_1.Iniciar();
            Operacao opT1_2 = new Operacao("ler", itemX, null, null, t1, gerenciadorExecucao);
            opT1_2.Iniciar();
            Operacao opT1_3 = new Operacao("ler", itemN, null, null, t1, gerenciadorExecucao);
            opT1_3.Iniciar();
            Operacao opT1_4 = new Operacao("subtrair", itemX, itemX, itemN, t1, gerenciadorExecucao);
            opT1_4.Iniciar();
            Operacao opT1_5 = new Operacao("gravar", itemX, null, null, t1, gerenciadorExecucao);
            opT1_5.Iniciar();

             //Operação T2
            Operacao opT2_0 = new Operacao("wlock", itemX, null, null, t2, gerenciadorExecucao);
            opT2_0.Iniciar();
            Operacao opT2_1 = new Operacao("ler", itemX, null, null, t2, gerenciadorExecucao);
            opT2_1.Iniciar();
            Operacao opT2_2 = new Operacao("rlock", itemM, null, null, t2, gerenciadorExecucao);
            opT2_2.Iniciar();
            Operacao opT2_3 = new Operacao("ler", itemM, null, null, t2, gerenciadorExecucao);
            opT2_3.Iniciar();
            Operacao opT2_4 = new Operacao("somar", itemX, itemX, itemM, t2, gerenciadorExecucao);
            opT2_4.Iniciar();
            Operacao opT2_5 = new Operacao("gravar", itemX, null, null, t2, gerenciadorExecucao);
            opT2_5.Iniciar();
            Operacao opT2_6 = new Operacao("unlock", itemX, null, null, t2, gerenciadorExecucao);
            opT2_6.Iniciar();
            Operacao opT2_7 = new Operacao("unlock", itemM, null, null, t2, gerenciadorExecucao);
            opT2_7.Iniciar();

            //Voltando a T1
            Operacao opT1_6 = new Operacao("unlock", itemX, null, null, t1, gerenciadorExecucao);
            opT1_6.Iniciar();
            Operacao opT1_7 = new Operacao("wlock", itemY, null, null, t1, gerenciadorExecucao);
            opT1_7.Iniciar();
            Operacao opT1_8 = new Operacao("ler", itemY, null, null, t1, gerenciadorExecucao);
            opT1_8.Iniciar();
            Operacao opT1_9 = new Operacao("somar", itemY, itemY, itemN, t1, gerenciadorExecucao);
            opT1_9.Iniciar();
            Operacao opT1_10 = new Operacao("gravar", itemY, null, null, t1, gerenciadorExecucao);
            opT1_10.Iniciar();
            Operacao opT1_11 = new Operacao("unlock", itemY, null, null, t1, gerenciadorExecucao);
            opT1_11.Iniciar();
            Operacao opT1_12 = new Operacao("unlock", itemN, null, null, t1, gerenciadorExecucao);
            opT1_12.Iniciar();
        }
    }
}
