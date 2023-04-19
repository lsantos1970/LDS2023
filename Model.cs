using System;
using System.Collections.Generic;
using System.IO;


namespace AnaliseImagens
{

    //Definição do objecto ColorPercentages
    public class ColorPercentages
    {
        public double RedPercentage { get; set; }
        public double GreenPercentage { get; set; }
        public double BluePercentage { get; set; }
    }
   
    public delegate void ResultsHandler(object sender, Events e);
    class Model
    {
        //Atributo da classe
        private List<string> listCmds;
      
        public delegate void CommandExecutor(string commandReceived);
        public delegate void ResultsHandler(object sender, Events e);

        //Declaração de evento
        public event ResultsHandler OnResultsAvailable;

        private Dictionary<string, CommandExecutor> commandExecutors;

        //Construtor
        public Model()
        {
          
            listCmds = new List<string> {"analisar..."};

            // Inicializar o dicionário e adicionar um delegado para cada comando
            commandExecutors = new Dictionary<string, CommandExecutor>
            {
                { "analyze", ExecutarComando }
            };
        }

        /*
         * Implementação do método que lança o evento 'OnResultsAvailable'
        */
        protected virtual void RaiseResultsAvailable(ColorPercentages results)
        {
            OnResultsAvailable?.Invoke(this, new Events(results));
        }

        /*
         * Retorna a lista de comandos disponíveis  
        */
        public void ListarComandos(ref List<string> commands) 
        {
            commands = listCmds;
        }


        /*
         * Executa comando introduzido pelo utilizador. Se comando for executado com sucesso, o evento 'OnResultsAvailable' é lançado
         */
        public void ExecutarComando(string commandReceived)
        {
            /*
             * TO DO - O comando possui na verdade o comando em si e o path da imagem. É necessário um método que separe ambos, valide 
             * e lance uma excepção consoante o tipo de erro, por exemplo:
             *  - Se comando inválido lança a excepção CommandNotValid
             *  - Se imagem inválid lança a excepção InvalidPath
             *  - Se operação não foi executada com sucesso, lança a excepção OperationError
             */

            if (commandExecutors.TryGetValue(commandReceived, out CommandExecutor executor))
            {
                executor(commandReceived);
                OnResultsAvailable?.Invoke(this,  new Events(FornecerResultado()));
            }
            else
            {
                throw new CommandNotValid(commandReceived);
            }
        }


       public void FornecerResultado(ref ColorPercentages results)
        {
            // Calcular as percentagens de cada cor e retornar resultado como objecto do tipo ColorPercentages
            results = new ColorPercentages
            {
                RedPercentage = 0.30,
                GreenPercentage = 0.3,
                BluePercentage = 0.4,
            };

        }
        
     }

}