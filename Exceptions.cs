using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseImagens
{
    //Definição das diferentes excepções que esta classe pode lançar
    class NoCommandFound : Exception
    {
        public NoCommandFound() : base("Deve introduzir um comando.") { }
    }


    class CommandNotValid : Exception
    {
        public CommandNotValid(string command) : base($"Comando {command} não é válido.") { }
    }

    class InvalidPath : Exception
    {
        public InvalidPath(string path) : base($"Não foi encontrada nenhuma imagem em {path}.") { }
    }

    class OperationError : Exception
    {
        public OperationError(string operation) : base($"Não foi posível executar a operação {operation} com sucesso.") { }
    }
}
