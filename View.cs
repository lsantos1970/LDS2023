using AnaliseImagens;

namespace AnaliseImagens
{
    class View
    {
        //Atributos
        private Controller controller;
        private Model model;

        public Model Model
        {
            get { return model; }
            set
            {
                model = value;
                model.OnResultsAvailable += ApresentarResultados;
            }
        }
        //Construtor
        public View(Controller _controller) 
        {
            controller = _controller;
        }

        public void ApresentarInstrucoes()
        {
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



        public void ApresentarResultados(object sender, ResultsEventArgs e)
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