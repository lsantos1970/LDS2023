using System;
using System.Collections.Generic;
using System.IO;


namespace AnaliseImagens
{

    public class ColorPercentages
    {
        public double RedPercentage { get; set; }
        public double GreenPercentage { get; set; }
        public double BluePercentage { get; set; }
    }
   
    public delegate void ResultsHandler(object sender, ResultsEventArgs e);
    class Model
    {
        //Atributo da classe
        private List<string> listCmds;
      
        public delegate void CommandExecutor(string commandReceived);
        public delegate void ResultsHandler(object sender, ResultsEventArgs e);
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
         * Retorna a lista de comandos disponíveis  
        */
        public List<string> ListarComandos() 
        {
            return listCmds;
        }

         protected virtual void RaiseResultsAvailable(ColorPercentages results)
        {
            OnResultsAvailable?.Invoke(this, new ResultsEventArgs(results));
        }


        public void ExecutarComando(string commandReceived)
        {
            if (commandExecutors.TryGetValue(commandReceived, out CommandExecutor executor))
            {
                executor(commandReceived);
                OnResultsAvailable?.Invoke(this,  new ResultsEventArgs(FornecerResultado()));
            }
            else
            {
                throw new CommandNotValid(commandReceived);
            }
        }


       public ColorPercentages FornecerResultado()
        {
            // Calcular as percentagens de cada cor e retornar resultado como objecto do tipo ColorPercentages
            ColorPercentages colorPercentages = new ColorPercentages
            {
                RedPercentage = 0.30,
                GreenPercentage = 0.3,
                BluePercentage = 0.4,
            };

            return colorPercentages;
        }
        
     }

}