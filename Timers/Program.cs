using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Timers
{
    class Program
    {
        // Evento do timer:
        static void TimerTick(object sender, EventArgs e)
        {
            Console.WriteLine("Timer 1: " + DateTime.Now.ToString("HH:mm:ss tt"));
        }

        // Evento do timer2:
        static void TimerTack(object sender)
        {
            Console.WriteLine("Timer 2: " + DateTime.Now.ToString("HH:mm:ss tt"));
        }

        static void Main(string[] args)
        {
            // ------ EXEMPLO ASSOCIADO AO NAMESPACE SYSTEM.TIMERS ------

            // ### Criando e configurando o Timer: ###


            /* Visto que estou usando duas referências que possuem uma classe
            homônima chamada Timer, que são System.Timers e System.Threading,
            se eu usar a sintaxe mais direta "Timer timer = new Timer(1000);"
            na instanciação, o programa não saberá identificar em qual classe
            Timer deverá instanciar o objeto timer, sendo assim, para evitar
            este erro de referência ambígua, eu precisarei usar a sintaxe mais
            comprida, conforme abaixo:
            */
            System.Timers.Timer timer = new System.Timers.Timer(1000); // O parâmetro indica o intervalo em que ocorre o evento
            // Timer timer = new Timer(1000); // Se não houver problema de referência ambígua


            /* Atribuído true para a Propriedade .AutoReset, toda vez que
            passar o intervalo configurado anteriormente, no caso 1000ms, o
            método associado ao Timer será executado. Isso ocorrerá até o
            */
            timer.AutoReset = true;

            // Cadastrando o(s) evento/múltiplos evento(s) ao objeto Timer: 
            timer.Elapsed += TimerTick;

            // Inicializando/Disparando o Timer, que rodará em paralelo:
            timer.Start();

            /* O programa segue seu fluxo enquanto o método associado ao objeto
            Timer vai sendo executado...
            */
            Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadKey();

            // Parando o Timer:
            timer.Stop();

            // ---------------------------------------------------------

            // ---- EXEMPLO ASSOCIADO AO NAMESPACE SYSTEM.THREADING ----

            // ### Criando e configurando o segundo Timer: ###


            /* Primeiro criamos o callback:
             * OBS: Step desnecessário se passarmos o método diretamente no parâmetro
            TimerCallback tcb = new TimerCallback(TimerTack);
            */


            /* Agora, instanciamos o timer2 evitando o erro pontual de
            referência ambígua. Ao mesmo tempo em que é instanciado é
            executado, ou seja, quando lidamos com um objeto da classe
            Timer do namespace System.Threading, não precisamos acionar
            um método .Start() ou algo do tipo, diferente do que ocorre
            com o objeto da classe Timer do namespace System.Timers, que 
            precisa ser startado com o método .Start().

             * Os argumentos na instanciação, são os seguintes:
            - TimerCallback callback = TimerTack/tcb // Evento que rodará em paralelo ou TimerCallback criado acima
            - object state = null // Para passar um objeto qualquer, se necessário
            - int dueTime = 0 // Delay antes executar novamente o evento
            - int period = 1000 // A cada 1s o método é executado
            */
            System.Threading.Timer timer2 = new System.Threading.Timer(TimerTack, null, 0, 1000);
            // Timer timer2 = new Timer(TimerTack, null, 0, 1000) // Quando não há referência ambígua

            
            /* O programa segue seu fluxo enquanto o método associado ao objeto
            Timer timer2 vai sendo executado...
            */
            Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadKey();

            // Parando o Timer:
            timer2.Dispose();
        }
    }
}
