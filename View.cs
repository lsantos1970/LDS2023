using AnaliseImagens;

namespace AnaliseImagens
{
    class View
    {
        //Atributos
        private Controller controller;
        private Model model;

        /*
         * O evento PrecisoDasInstrucoes pode ser respondido por delegados do tipo SolicitacaoInstrucoes, ou seja, pode ser 
         * respondido por qualquer método que tenha a mesma assignatura que o delegado definido. 
         * Quando o evento PrecisoDasInstrucoes é lançado, delegados que tenham subscrito a esse evento vão receber uma lista de string
         * por referência que podem modificar
         */
        public delegate void SolicitacaoInstrucoes(ref List<string> commands);
        public event SolicitacaoInstrucoes PrecisoDasInstrucoes;




        //Construtor
        public View() {}

        /*
         *  Quando este método é chamado, lança um evento PrecisoDasInstrucoes
         */
        public void ApresentarInstrucoes()
        {

            List<string> availableCommands = new List<string>();
            PrecisoDasInstrucoes(ref availableCommands);

            Console.WriteLine("Comandos disponíveis:");
            foreach (string command in availableCommands)
            {
                Console.WriteLine($"- {command}");
            }
        }

        /*
         * Imprime um prompt que solicita ao utilizador para inserir o comando. Esse prompt pode ser precedido de uma mensagem
         * de erro.
        */
        public void ImprimirPromptInserirInput(string msg)
        {
            Console.WriteLine(msg + "Introduza um comando. Para sair, pressione 'E':");
        }

        /*
        * Mensagem de erro quando a operação não foi executada com sucesso e término do programa com código 
        * ERROR_OPERATION_NOT_SUCCESSFUL
        */
        public void ImprimirMensagemErro(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(ExitCodes.ERROR_OPERATION_NOT_SUCCESSFUL);
        }


        /*
         * Mensagem de despedida quando utilizador solicita término do programa e saída com código SUCCESS
         */ 
        public void ImprimirMensagemDespedida()
        {
            Console.WriteLine("A terminar sessão, até breve!");
            Environment.Exit(ExitCodes.SUCCESS);
        }

        /*
        * ############################## CÓDIGO BRUNO ##########################################3
        */

        public Model Model
        {
            get { return model; }
            set
            {
                model = value;
                model.OnResultsAvailable += ApresentarResultados;
            }


        }


        public void ApresentarResultados (object sender, ResultsEventArgs e)
        {
            ColorPercentages results = e.Results;
            Console.WriteLine("Resultados:");
            Console.WriteLine($"Red: {results.RedPercentage}%");
            Console.WriteLine($"Green: {results.GreenPercentage}%");
            Console.WriteLine($"Blue: {results.BluePercentage}%");

            Environment.Exit(ExitCodes.SUCCESS);
        }
    }
}