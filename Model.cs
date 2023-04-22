using System.IO;

namespace AnaliseImagens
{
    class Model
    {
        //Atributos
        private List<string> listCmds;
        private View view;

        //Construtor
        public Model(View _view)
        {
            view = _view;
        }

        public List<string> ListarComandos() 
        {

            return listCmds;
        }

        public void ExecutarComando(string commandReceived) {

            /*
             * Se comando inválido -> throw CommandNotValid
             * 
             * Se path inválido -> throw InvalidPath
             * 
             * Se operação não foi bem sucedida --> throw OperationError
             */

            //Se for bem sucedido
            view.ApresentarResultados();
        }


        
     }

}