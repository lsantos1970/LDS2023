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
            Console.WriteLine("Available commands:");
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

       

    
        public void ApresentarResultados(object sender, ResultsEventArgs e)
        {
             ColorPercentages results = e.Results;

            Console.WriteLine("Results:");
            Console.WriteLine($"Red: {results.RedPercentage}%");
            Console.WriteLine($"Green: {results.GreenPercentage}%");
            Console.WriteLine($"Blue: {results.BluePercentage}%");

            Environment.Exit(ExitCodes.SUCCESS);
        }

    }
}