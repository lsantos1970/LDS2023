using System;
using System.Collections.Generic;
using System.IO;
using static AnaliseImagens.Model;


namespace AnaliseImagens
{

    //Definição do objecto ColorPercentages
    public class ColorPercentages
    {
        public double RedPercentage { get; set; }
        public double GreenPercentage { get; set; }
        public double BluePercentage { get; set; }
    }
   
    class Model
    {
        //Atributo da classe
        private List<string> listCmds;
             
       /* ------------------------- CODIGO BRUNO -------------------------------------
        * public delegate void CommandValidator(string commandReceived);
        public delegate void CommandExecutor(string commandReceived);
        private Dictionary<string, CommandValidator> commandValidators;
        private Dictionary<string, CommandExecutor> commandExecutors;
       */

        public delegate void ResultsHandler(object sender, ResultsEventArgs e);
        public event ResultsHandler OnResultsAvailable;

       

        //Construtor
        public Model()
        {
          
            listCmds = new List<string> {"analisar..."};

            // Inicializar o dicionário e adicionar um delegado para cada comando
            /*
             * ----------------------------- CÓDIGO BRUNO ----------------------------------
             * commandValidators = new Dictionary<string, CommandValidator>
            {
                { "analyze", ValidarComando }
            };

            commandExecutors = new Dictionary<string, CommandExecutor>
            {
                { "analyze", ExecutarComando }
            };*/
        }

        /*
         * Implementação do método que lança o evento 'OnResultsAvailable'
        */
        protected virtual void RaiseResultsAvailable(ColorPercentages results)
        {
            OnResultsAvailable?.Invoke(this, new ResultsEventArgs(results));
        }


        /*
         * Retorna a lista de comandos disponíveis  
        */
        public void ListarComandos(ref List<string> commands) 
        {
            commands = listCmds;
        }


        public void ValidarComando(string commandReceived, ref string cmd, ref string path)
        {


            /*
          * TO DO - O comando possui na verdade o comando em si e o path da imagem. É necessário um método que separe ambos, valide 
          * e lance uma excepção consoante o tipo de erro, por exemplo:
          *  - Se comando inválido lança a excepção CommandNotValid
          *  - Se imagem inválid lança a excepção InvalidPath
          *  - Se operação não foi executada com sucesso, lança a excepção OperationError
          */

            /*
             * ------------------------- CODIGO BRUNO ------------------------------------------- 
             * if (commandValidators.TryGetValue(commandReceived, out CommandValidator validator))
            {
                validator(commandReceived);
            }
            else
            {
                throw new CommandNotValid(commandReceived);
            }*/
        }

        /*
         * Executa comando introduzido pelo utilizador. Se comando for executado com sucesso, o evento 'OnResultsAvailable' é lançado
         */
        public void ExecutarComando(string cmd, string path)
        {

            // Calcular as percentagens de cada cor e retornar resultado como objecto do tipo ColorPercentages
            ColorPercentages results = new ColorPercentages
            {
                RedPercentage = 0.30,
                GreenPercentage = 0.3,
                BluePercentage = 0.4,
            };

            //Quando os resultados estão prontos, é lançado o evento
            RaiseResultsAvailable(results);

            /* 
             * ---------------- CODIGO BRUNO ---------------------
             * 
             * if (commandExecutors.TryGetValue(commandReceived, out CommandExecutor executor))
             {
                 executor(commandReceived);
                 OnResultsAvailable?.Invoke(this, new ResultsEventArgs(FornecerResultado()));
             }
             else
             {
                 throw new CommandNotValid(commandReceived);
             }*/

        }


      
        
     }

}