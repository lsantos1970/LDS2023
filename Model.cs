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
        //Atributos
        private List<string> listCmds;
      
        public delegate void CommandValidator(string commandReceived);
        public delegate void CommandExecutor(string commandReceived);
        public delegate void ResultsHandler(object sender, ResultsEventArgs e);
        public event ResultsHandler OnResultsAvailable;

        private Dictionary<string, CommandValidator> commandValidators;
        private Dictionary<string, CommandExecutor> commandExecutors;

        //Construtor
        public Model()
        {
          
            listCmds = new List<string> {"analisar..."};

            // Inicializar os dicionários e adicionar um delegado para cada comando
            commandValidators = new Dictionary<string, CommandValidator>
            {
                { "analyze", ValidarComando }
            };

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

        public void ValidarComando(string commandReceived)
        {
            if (commandValidators.TryGetValue(commandReceived, out CommandValidator validator))
            {
                validator(commandReceived);
            }
            else
            {
                throw new CommandNotValid(commandReceived);
            }
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
            // Calculate color percentages and return the result as a ColorPercentages object
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