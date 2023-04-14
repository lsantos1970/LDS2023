using System.IO;

namespace AnaliseImagens
{
    //Definição das diferentes excepções que esta classe pode lançar
    class NoCommandFound : Exception
    {
        public NoCommandFound() : base("Deve introduzir um comando."){}
    }


    class CommandNotValid : Exception
    {
        public CommandNotValid(string command) : base($"Comando {command} não é válido.") { }
    }

    class InvalidPath : Exception
    {
        public InvalidPath(string path) : base($"Não foi encontrada nenhuma imagem em {path}.") { }
    }

    class OperationError: Exception
    {
        public OperationError(string operation) : base($"Não foi posível executar a operação {operation} com sucesso.") { }
    }


    class Model
    {
        //Atributos
        private List<string> listCmds;
        private Controller controller;
        private View view;

        //Construtor
        public Model(Controller _controller, View _view)
        {
            controller = _controller;
            view = _view;
        }

        public List<string> ListarComandos() 
        {

            return listCmds;
        }

        public void ValidarComando(string commandReceived) {}


        public void ExecutarComando(string commandReceived) { }


        public void FornecerResultado() { }
        
     }

}