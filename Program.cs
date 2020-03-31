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
            Item itemM = new Item(30);
            Item itemN = new Item(40);

            GerenciadorExecucao gerenciadorExecucao = new GerenciadorExecucao();

            Transacao transacao1 = new Transacao(1);
            Transacao transacao2 = new Transacao(2);
            Transacao transacao3 = new Transacao(3);

            //Plano Serial
            /*
            //Bloquear Escrita de X
            Operacao operacao = new Operacao("wlock", itemX, null, null, transacao1);
            operacao.Iniciar();
            //Bloquear Leitura de X
            Operacao operacao1 = new Operacao("rlock", itemY, null, null, transacao1);
            operacao1.Iniciar();
            //Ler X
            Operacao operacao2 = new Operacao("ler", itemX, null, null, transacao1);
            operacao2.Iniciar();
            //Ler Y
            Operacao operacao3 = new Operacao("ler", itemY, null, null, transacao1);
            operacao3.Iniciar();
            //Somar X + Y
            Operacao operacao4 = new Operacao("somar", itemX, itemX, itemY, transacao1);
            operacao4.Iniciar();
            //Ler X
            Operacao operacao5 = new Operacao("gravar", itemX, null, null, transacao1);
            operacao5.Iniciar();
            //Desbloquear X
            Operacao operacao6 = new Operacao("unlock", itemX, null, null, transacao1);
            operacao6.Iniciar();
            */

            /*
            //Plano 2PL Com locks
            Console.WriteLine("Transacao 1...");
            //Bloquear escrita de X
            Operacao operacao0 = new Operacao("wlock", itemX, null, null, transacao1);
            operacao0.Iniciar();
            //Ler X
            Operacao operacao1 = new Operacao("ler", itemX, null, null, transacao1);
            operacao1.Iniciar();
            //Subtrair X - Y
            Operacao operacao2 = new Operacao("subtrair", itemX, itemX, itemY, transacao1);
            operacao2.Iniciar();
            //Gravar X
            Operacao operacao3 = new Operacao("gravar", itemX, null, null, transacao1);
            operacao3.Iniciar();
            //Bloquear escrita de Y
            Operacao operacao4 = new Operacao("wlock", itemY, null, null, transacao1);
            operacao4.Iniciar();
            //Liberar X
            Operacao operacao5 = new Operacao("unlock", itemX, null, null, transacao1);
            operacao5.Iniciar();

            //Transacao2
            Console.WriteLine("Transacao 2...");
            //Bloquear escrita de X
            Operacao operacao0_t2 = new Operacao("wlock", itemX, null, null, transacao2);
            operacao0_t2.Iniciar();
            //Ler X
            Operacao operacao1_t2 = new Operacao("ler", itemX, null, null, transacao2);
            operacao1_t2.Iniciar();
            //Somar X + M
            Operacao operacao2_t2 = new Operacao("somar", itemX, itemX, itemM, transacao2);
            operacao2_t2.Iniciar();
            //Gravar X
            Operacao operacao3_t2 = new Operacao("gravar", itemX, null, null, transacao2);
            operacao3_t2.Iniciar();
            //Liberar X
            Operacao operacao4_t2 = new Operacao("unlock", itemX, null, null, transacao2);
            operacao4_t2.Iniciar();

            //Transacao1
            Console.WriteLine("Transacao 1...");
            //Ler Y
            Operacao operacao6_t1 = new Operacao("ler", itemY, null, null, transacao1);
            operacao6_t1.Iniciar();
            //Somar Y + N
            Operacao operacao7_t1 = new Operacao("somar", itemY, itemY, itemN, transacao1);
            operacao7_t1.Iniciar();
            //Gravar Y
            Operacao operacao8_t1 = new Operacao("gravar", itemY, null, null, transacao1);
            operacao8_t1.Iniciar();
            //Liberar Y
            Operacao operacao9_t1 = new Operacao("unlock", itemY, null, null, transacao1);
            operacao9_t1.Iniciar();
            */
            //Plano com concorrencia
            Console.WriteLine("Transacao 1...");
            //Bloquear escrita de X
            Operacao operacao0 = new Operacao("wlock", itemX, null, null, transacao1, gerenciadorExecucao);
            operacao0.Iniciar();
            //Ler X
            Operacao operacao1 = new Operacao("ler", itemX, null, null, transacao1, gerenciadorExecucao);
            operacao1.Iniciar();
            //Subtrair X - Y
            Operacao operacao2 = new Operacao("subtrair", itemX, itemX, itemY, transacao1, gerenciadorExecucao);
            operacao2.Iniciar();
            //Gravar X
            Operacao operacao3 = new Operacao("gravar", itemX, null, null, transacao1, gerenciadorExecucao);
            operacao3.Iniciar();
            //Liberar X
            //Operacao operacao5 = new Operacao("unlock", itemX, null, null, transacao1);
            //operacao5.Iniciar();

            //Transacao2
            Console.WriteLine("Transacao 2...");
            //Bloquear escrita de X
            Operacao operacao0_t2 = new Operacao("wlock", itemX, null, null, transacao2, gerenciadorExecucao);
            operacao0_t2.Iniciar();
            //Ler X
            Operacao operacao1_t2 = new Operacao("ler", itemX, null, null, transacao2, gerenciadorExecucao);
            operacao1_t2.Iniciar();
            //Somar X + M
            Operacao operacao2_t2 = new Operacao("somar", itemX, itemX, itemM, transacao2, gerenciadorExecucao);
            operacao2_t2.Iniciar();
            //Gravar X
            Operacao operacao3_t2 = new Operacao("gravar", itemX, null, null, transacao2, gerenciadorExecucao);
            operacao3_t2.Iniciar();
            //Liberar X
            Operacao operacao4_t2 = new Operacao("unlock", itemX, null, null, transacao2, gerenciadorExecucao);
            operacao4_t2.Iniciar();

            //Transacao 3
            Console.WriteLine("Transacao 3");
            //Bloquear escrita de X
            Operacao operacao0_t1_2 = new Operacao("wlock", itemX, null, null, transacao3, gerenciadorExecucao);
            operacao0_t1_2.Iniciar();
            //Ler X
            Operacao operacao1_t1_2 = new Operacao("ler", itemX, null, null, transacao3, gerenciadorExecucao);
            operacao1_t1_2.Iniciar();
            //Somar X + M
            Operacao operacao2_t1_2 = new Operacao("somar", itemX, itemX, itemM, transacao3, gerenciadorExecucao);
            operacao2_t1_2.Iniciar();
            //Gravar X
            Operacao operacao3_t1_2 = new Operacao("gravar", itemX, null, null, transacao3, gerenciadorExecucao);
            operacao3_t1_2.Iniciar();

            //Liberar X
            Operacao operacao4_t2_2 = new Operacao("unlock", itemX, null, null, transacao1, gerenciadorExecucao);
            operacao4_t2_2.Iniciar();
        }
    }
}
