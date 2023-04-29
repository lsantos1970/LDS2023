using System;
using System.Collections.Generic;
using System.IO;
using static AnaliseImagens.Model;


namespace AnaliseImagens
{

    //Definição da classe ColorPercentages
    public class ColorPercentages
    {
        public double RedPercentage { get; set; }
        public double GreenPercentage { get; set; }
        public double BluePercentage { get; set; }
    }
   
    class Model
    {
        //Atributos da classe
        private List<string> listCmds;
        public delegate void CommandValidator(string path);
        public delegate ColorPercentages CommandExecutor(string path);
        private Dictionary<string, CommandValidator> commandValidators; 
        private Dictionary<string, CommandExecutor> commandExecutors;

        /*
         * O evento OnResultsAvailable pode ser respondido por delegados do tipo AnalysisResultsHandler, ou seja, pode ser 
         * respondido por qualquer método que tenha a mesma assignatura que o delegado definido. 
         * Quando o evento OnResultsAvailable é lançado, delegados que tenham subscrito a esse evento vão receber e terão acesso
         * aos resultados
         */
        public delegate void AnalysisResultsHandler(object sender, AnalysisResultsEventArgs e);
        public event AnalysisResultsHandler OnResultsAvailable;

       

        //Construtor
        public Model()
        {
          
            listCmds = new List<string> {"analisar..."};

            //Os dicionários são inicializados associando a cada comando uma função que irá validar ou executar o comando
             commandValidators = new Dictionary<string, CommandValidator>
            {
                { "analyze", ValidateAnalyzeCmd }
            };

            commandExecutors = new Dictionary<string, CommandExecutor>
            {
                { "analyze", ExecuteAnalyzeCmd }
            };
        }


        /*
         * Implementação do método que lança o evento 'OnResultsAvailable'
        */
        protected virtual void RaiseResultsAvailable(ColorPercentages results)
        {
            OnResultsAvailable?.Invoke(this, new AnalysisResultsEventArgs(results));
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

               
            if (commandValidators.TryGetValue(commandReceived, out CommandValidator validator))
            {
                validator(commandReceived);
            }
            else
            {
                throw new CommandNotValid(commandReceived);
            }
        }

        /*
         * Executa comando introduzido pelo utilizador. 
         * Se comando for executado com sucesso, o evento 'OnResultsAvailable' é lançado. Um método da View subscreve a este método
         * Se o comando não for executado com sucesso, é lançada uma excepção e o controlo retorna ao Controller que irá lidar com essa
         * excepção
         */
        public void ExecutarComando(string cmd, string path)
        {
       
             if (commandExecutors.TryGetValue(cmd, out CommandExecutor executor))
             {
                //Quando os resultados estão prontos, é lançado o evento
                ColorPercentages results = executor(path);
                RaiseResultsAvailable(results);
            }
             else
             {
                 throw new OperationError(cmd);
             }

        }

        private void ValidateAnalyzeCmd (string path)
        {

        }


        /* ---------------------------- TO DO -------------------------------------
        * Função que calcula as percentagens de cada cor e retornar resultado como objecto do tipo ColorPercentages
        */
        private ColorPercentages ExecuteAnalyzeCmd (string path)
        {
            ColorPercentages results = new ColorPercentages
            {
                RedPercentage = 0.30,
                GreenPercentage = 0.3,
                BluePercentage = 0.4,
            };

            return results;
        }



     }

}